using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Quokka.RTL
{
    public static class RTLModuleHelper
    {
        public static bool IsToolkitType(Type type)
        {
            if (type.IsConstructedGenericType)
                return IsToolkitType(type.GetGenericTypeDefinition());

            return type.GetCustomAttribute<RTLToolkitTypeAttribute>(false) != null;
        }

        public static IEnumerable<MemberInfo> SynthesizableMembers(Type type)
        {
            if (type == null || type == typeof(object) || IsToolkitType(type)) 
                return Enumerable.Empty<MemberInfo>();

            var baseMembers = SynthesizableMembers(type.BaseType);

            var props = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            var fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();

            return baseMembers
                .Concat(props)
                .Concat(fields)
                .Where(p => !p.IsAbstract())
                .Where(p => p.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static bool IsModuleTypeMember(Type member)
        {
            if (member == null)
                return false;

            if (member.IsArray)
                return IsModuleTypeMember(member.GetElementType());

            return typeof(IRTLCombinationalModule).IsAssignableFrom(member);
        }

        public static List<MemberInfo> ModuleProperties(Type type)
        {
            return SynthesizableMembers(type)
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
            var isToolkitType = IsToolkitType(memberInfo.DeclaringType);
            var isArray = memberInfo.GetMemberType().IsArray;

            return isArray || !isPublic && isPropertyOrField && !isToolkitType;
        }

        internal static bool IsStruct(this Type type) => type.IsValueType && !type.IsEnum && !type.IsPrimitive;

        public static bool IsSynthesizableObject(Type type)
        {
            if (!type.IsClass && !type.IsStruct())
                return false;

            foreach (var m in type.GetMembers())
            {
                switch(m)
                {
                    case FieldInfo fi:
                        if (!IsSynthesizableSignalType(fi.FieldType))
                            return false;
                        break;
                    case PropertyInfo pi:
                        if (!IsSynthesizableSignalType(pi.PropertyType))
                            return false;
                        break;
                    case MethodInfo mi:
                        // methods on data classes\structs are not synthesizable yet
                        var baseType = mi.DeclaringType.BaseType ?? mi.DeclaringType;
                        if (baseType == typeof(object) || baseType == typeof(ValueType))
                            continue;

                        return false;
                    case ConstructorInfo ci:
                        // constructors are allwowed, but they are not translated into HDL
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
            return SynthesizableMembers(type)
                .Where(m => IsSynthesizableSignalType(m.GetMemberType()) || IsSynthesizableArrayType(m.GetMemberType()))
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

        public static int SizeOfEnum(Type enumType)
        {
            var values = Enum.GetValues(enumType);

            // defaults to single bit variable
            if (values.Length == 0)
                return 1;

            var maxValue = Enumerable
                .Range(0, values.Length)
                .Select(idx => (uint)Convert.ChangeType(values.GetValue(idx), typeof(uint)))
                .Max();

            return (int)Math.Max(1, Math.Ceiling(Math.Log(maxValue + 1, 2)));
        }

        public static T BSONCopy<T>(T source)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    using (var writer = new BsonWriter(ms))
                    {
                        var serializer = new JsonSerializer();
                        serializer.Serialize(writer, source);

                        ms.Seek(0, SeekOrigin.Begin);

                        using (var reader = new BsonReader(ms))
                        {
                            return serializer.Deserialize<T>(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var json = JsonConvert.SerializeObject(source, Formatting.Indented);
                throw new Exception($"Failed to make a copy of {source.GetType().Name}: {json}", ex);
            }
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
    }
}
