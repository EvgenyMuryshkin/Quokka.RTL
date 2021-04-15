using Newtonsoft.Json;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Rollout")]

namespace Quokka.RTL
{
    public class DeepCompareItem
    {
        public DeepCompareItem(IEnumerable<MemberInfo> path, object lhs, object rhs, params string[] messages)
        {
            Path = path ?? Enumerable.Empty<MemberInfo>();
            this.lhs = lhs;
            this.rhs = rhs;
            Messages = messages.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }

        public DeepCompareItem(IEnumerable<MemberInfo> path, object lhs, object rhs, IEnumerable<string> messages, params string[] extra)
        {
            Path = path ?? Enumerable.Empty<MemberInfo>();
            this.lhs = lhs;
            this.rhs = rhs;
            Messages = (messages ?? Enumerable.Empty<string>()).Concat(extra).Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        public IEnumerable<MemberInfo> Path { get; private set; }
        public object lhs { get; private set; }
        public object rhs { get; private set; }
        public IEnumerable<string> Messages { get; private set; }
    }

    public static class RTLModuleHelper
    {
        public static bool IsModuleTypeMember(Type member)
        {
            if (member == null)
                return false;

            if (member.IsArray)
                return IsModuleTypeMember(member.GetElementType());

            return typeof(IRTLCombinationalModule).IsAssignableFrom(member);
        }

        public static bool IsPipelineTypeMember(Type member)
        {
            if (member == null)
                return false;

            return typeof(IRTLPipeline).IsAssignableFrom(member);
        }

        public static List<MemberInfo> ModuleProperties(Type type)
        {
            return RTLReflectionTools.SynthesizableMembers(type)
                .Where(m => IsModuleTypeMember(m.GetMemberType()))
                .ToList();
        }

        public static bool IsField(MemberInfo memberInfo) => memberInfo is FieldInfo;
        public static bool IsGetProperty(MemberInfo memberInfo)
        {
            if (memberInfo is PropertyInfo pi)
            {
                return pi.GetSetMethod() == null;
            }

            return false;
        }

        public static bool IsInternalProperty(MemberInfo memberInfo)
        {
            var isPublic = memberInfo.IsPublic();
            var isPropertyOrField = memberInfo is FieldInfo || memberInfo is PropertyInfo;
            var isToolkitType = RTLTypeCheck.IsToolkitType(memberInfo.DeclaringType);
            var isArray = memberInfo.GetMemberType().IsArray;

            return isArray || !isPublic && isPropertyOrField && !isToolkitType;
        }

        internal static bool IsStruct(this Type type) => type.IsValueType && !type.IsEnum && !type.IsPrimitive;

        public static bool IsSynthesizableObject(Type type)
        {
            if (!type.IsClass && !type.IsStruct())
                return false;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return false;

            var getSetMembers = new HashSet<MethodInfo>(
                RTLReflectionTools.SynthesizableMembers(type)
                .OfType<PropertyInfo>()
                .SelectMany(p => new[] { p.GetGetMethod(), p.GetSetMethod() })
                .Where(m => m != null));

            foreach (var m in type.GetMembers())
            {
                switch(m)
                {
                    case FieldInfo fi:
                        if (!IsSynthesizableSignalType(fi.FieldType) && !IsSynthesizableArrayType(fi.FieldType))
                            return false;
                        break;
                    case PropertyInfo pi:
                        if (!IsSynthesizableSignalType(pi.PropertyType) && !IsSynthesizableArrayType(pi.PropertyType))
                            return false;
                        break;
                    case MethodInfo mi:
                        if (getSetMembers.Contains(mi))
                            continue;

                        // methods on data classes\structs are not synthesizable yet
                        var baseType = mi.DeclaringType.BaseType ?? mi.DeclaringType;
                        if (baseType == typeof(object) || baseType == typeof(ValueType))
                            continue;

                        return false;
                    case ConstructorInfo ci:
                        // constructors are allowed, but they are not translated into HDL
                        break;
                }
            }

            return true;
        }

        public static bool IsSynthesizableSignalType(Type type)
        {
            if (IsSynthesizableObject(type))
                return true;

            return type.IsValueType || type == typeof(RTLBitArray);
        }

        public static bool IsSynthesizableArrayType(Type type)
        {
            return type.IsArray && IsSynthesizableSignalType(type.GetElementType());
        }

        public static List<MemberInfo> SignalProperties(Type type)
        {
            return RTLReflectionTools
                .SynthesizableMembers(type)
                .Where(m => IsSynthesizableSignalType(m.GetMemberType()) || IsSynthesizableArrayType(m.GetMemberType()))
                .ToList();
        }

        public static List<MemberInfo> PipelineProperties(Type type)
        {
            return RTLReflectionTools
                .SynthesizableMembers(type)
                .Where(m => IsPipelineTypeMember(m.GetMemberType()) && IsField(m))
                .ToList();
        }

        public static List<MemberInfo> OutputProperties(Type type)
        {
            return SignalProperties(type)
                .Where(p => !IsInternalProperty(p))
                .GroupBy(p => p.Name)
                .Select(g =>
                {
                    if (g.Count() == 1)
                        return g.First();

                    return g.OrderByDescending(t => InheritanceLevel(t.DeclaringType)).First();
                })
                .ToList();
        }

        public static int InheritanceLevel(Type t)
        {
            if (t.IsInterface)
            {
                return 1 + (t.GetInterfaces().Any() ? t.GetInterfaces().Max(i => InheritanceLevel(i)) : 0);
            }

            if (t.IsClass)
            {
                if (t.BaseType == typeof(object))
                    return 0;

                return 1 + InheritanceLevel(t.BaseType);
            }

            return 0;
        }

        public static List<MemberInfo> InternalProperties(Type type)
        {
            return SignalProperties(type)
                .Where(p => IsInternalProperty(p))
                .GroupBy(p => p.Name)
                .Select(g =>
                {
                    if (g.Count() == 1)
                        return g.First();

                    return g.OrderByDescending(t => InheritanceLevel(t.DeclaringType)).First();
                })
                .ToList();
        }

        static JsonSerializerSettings typeSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };
        public static T JSONCopy<T>(T source)
        {
            var str = JsonConvert.SerializeObject(source, typeSettings);
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static T DeepCopy<T>(T source)
        {
            return JSONCopy(source);
        }

        public static DeepCompareItem DeepCompare(object lhs, object rhs, List<MemberInfo> path = null)
        {
            path = path ?? new List<MemberInfo>();

            if (lhs == null && rhs == null) return null;
            if (lhs == null || rhs == null) return new DeepCompareItem(path, lhs, rhs);

            var lhsType = lhs.GetType();
            var rhsType = rhs.GetType();

            if (lhsType != rhsType) 
                return new DeepCompareItem(path, lhs, rhs, $"lhs type {lhsType} is not equal to rhs type {rhsType}");

            foreach (var prop in SignalProperties(lhs.GetType()))
            {
                var propPath = path.ToList();
                propPath.Add(prop);

                var lhsValue = prop.GetValue(lhs);
                var rhsValue = prop.GetValue(rhs);

                if (lhsValue == null && rhsValue == null)
                    continue;

                if (IsSynthesizableArrayType(prop.GetMemberType()))
                {
                    if (lhsType.GetElementType() != rhsType.GetElementType())
                        return new DeepCompareItem(propPath, lhsValue, rhsValue, $"lhs array type {lhsType} is not equal to rhs array type {rhsType}");

                    var lhsArray = lhsValue as Array;
                    var rhsArray = rhsValue as Array;

                    if (lhsArray == null && rhsArray == null)
                        continue;

                    if (lhsArray == null || rhsArray == null)
                        return new DeepCompareItem(propPath, lhsValue, rhsValue);

                    if (lhsArray.Length != rhsArray.Length)
                        return new DeepCompareItem(propPath, lhsValue, rhsValue, $"Array length does not match");

                    for (var idx = 0; idx < lhsArray.Length; idx++)
                    {
                        var lhsArrayItem = lhsArray.GetValue(idx);
                        var rhsArrayItem = rhsArray.GetValue(idx);

                        var arrayItemCompare = DeepCompare(lhsArrayItem, rhsArrayItem, propPath);
                        if (arrayItemCompare != null)
                            return new DeepCompareItem(propPath, lhsArrayItem, rhsArrayItem, arrayItemCompare.Messages, $"Element at index {idx} does not match");
                    }
                }
                else if (lhsValue is RTLBitArray)
                {
                    if (!lhsValue.Equals(rhsValue))
                        return new DeepCompareItem(propPath, lhsValue, rhsValue);
                }
                else if (prop.GetMemberType().IsClass)
                {
                    var classCompare = DeepCompare(lhsValue, rhsValue, propPath);
                    if (classCompare != null)
                        return new DeepCompareItem(propPath, lhsValue, rhsValue, classCompare.Messages);
                }
                else
                {
                    if (!lhsValue.Equals(rhsValue))
                        return new DeepCompareItem(propPath, lhsValue, rhsValue);
                }
            }

            return null;
        }

        public static bool DeepEquals(object lhs, object rhs)
        {
            return DeepCompare(lhs, rhs) == null;
        }

        public static object Activate(Type type)
        {
            if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return Activate(type.GetGenericArguments()[0]);

            if (type.IsValueType)
                return Activator.CreateInstance(type);

            if (type.IsClass)
            {
                var defaultCtor = type.GetConstructors().Where(c => c.GetParameters().Length == 0 && c.IsPublic).FirstOrDefault();
                if (defaultCtor != null)
                    return Activator.CreateInstance(type);

                // looks like anonymous type
                if (type.GetConstructors().Length != 1)
                    throw new Exception($"Cannot create instance of type '{type}', found multiple constructors");

                var typeCtor = type.GetConstructors()[0];
                var defaultValues = typeCtor.GetParameters().Select(p => Activate(p.ParameterType));

                return Activator.CreateInstance(type, defaultValues.ToArray());
            }

            throw new Exception($"Type '{type}' should have public parameterless constructor to be activated");
        }

        public static T Activate<T>()
        {
            var type = typeof(T);
            return (T)Activate(type);
        }

        internal static string SolutionLocation(string current = null)
        {
            if (current == "")
                return "";

            current = current ?? Directory.GetCurrentDirectory();
            if (Directory.EnumerateFiles(current, "*.sln").Any())
                return current;

            return SolutionLocation(Path.GetDirectoryName(current));
        }
    }
}
