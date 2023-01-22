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

            return !isPublic && isPropertyOrField && !isToolkitType;
        }

        static TypeCache<bool> IsSynthesizableArrayTypeCache = new TypeCache<bool>(
            (type) =>
            {
                return RTLTypeCheck.IsSynthesizableArrayType(type);
            });

        public static bool IsSynthesizableArrayType(Type type) => IsSynthesizableArrayTypeCache[type];

        static TypeCache<List<MemberInfo>> signalPropertiesCache = new TypeCache<List<MemberInfo>>(
            (type) =>
            {
                return RTLReflectionTools
                    .SynthesizableMembers(type)
                    .Where(m => RTLTypeCheck.IsTypeSerializable(m.GetMemberType()))
                    .ToList();
            });

        public static List<MemberInfo> SignalProperties(Type type) => signalPropertiesCache[type];

        static TypeCache<List<MemberInfo>> pipelinePropertiesCache = new TypeCache<List<MemberInfo>>(
            (type) =>
            {
                return RTLReflectionTools
                    .SynthesizableMembers(type)
                    .Where(m => IsPipelineTypeMember(m.GetMemberType()) && IsField(m))
                    .ToList();
            });

        public static List<MemberInfo> RecursiveMembers(Type type) => RecursiveMembersCache[type];

        static TypeCache<List<MemberInfo>> RecursiveMembersCache = new TypeCache<List<MemberInfo>>(
            (type) =>
            {
                return RTLReflectionTools.RecursiveMembers(type).ToList();
            });

        public static List<MemberInfo> RecursiveWritableMembers(Type type) => RecursiveWritableMembersCache[type];

        static TypeCache<List<MemberInfo>> RecursiveWritableMembersCache = new TypeCache<List<MemberInfo>>(
            (type) =>
            {
                var member = RecursiveMembers(type);

                return member.Where(m => m.HasSetter()).ToList();
            });
        

        public static List<MemberInfo> PipelineProperties(Type type) => pipelinePropertiesCache[type];

        public static List<MemberInfo> OutputProperties(Type type)
        {
            return SignalProperties(type)
                .Where(p => p.IsPublic())
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

        public static T Activate<T>(Type type)
        {
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
