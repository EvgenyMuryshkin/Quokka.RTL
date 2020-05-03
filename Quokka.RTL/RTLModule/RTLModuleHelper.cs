using Quokka.RTL;
using Quokka.VCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Reflection
{
    public static class MemberExtensions
    {
        public static object GetValue(this MemberInfo member, object target)
        {
            switch (member)
            {
                case PropertyInfo p: return p.GetValue(target);
                case FieldInfo f: return f.GetValue(target);
                default: throw new InvalidOperationException();
            }
        }

        public static void SetValue(this MemberInfo member, object target, object value)
        {
            switch (member)
            {
                case PropertyInfo p: 
                    p.SetValue(target, value); 
                    break;
                case FieldInfo f: 
                    f.SetValue(target, value); 
                    break;
                default: 
                    throw new InvalidOperationException();
            }
        }

        public static Type GetMemberType(this MemberInfo member)
        {
            switch (member)
            {
                case PropertyInfo p: return p.PropertyType;
                case FieldInfo f: return f.FieldType;
                default: throw new InvalidOperationException();
            }
        }

        public static bool IsPublic(this MemberInfo member)
        {
            switch (member)
            {
                case PropertyInfo p: return p.GetGetMethod()?.IsPublic ?? false;
                case FieldInfo f: return f.IsPublic;
                default: throw new InvalidOperationException();
            }
        }
    }
}

namespace Quokka.RTL
{
    public static class RTLModuleHelper
    {
        public static IEnumerable<MemberInfo> SynthesizableMembers(Type type)
        {
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();

            return props.Concat(fields).Where(p => p.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static List<MemberInfo> ModuleProperties(Type type)
        {
            return SynthesizableMembers(type)
                .Where(m => typeof(IRTLCombinationalModule).IsAssignableFrom(m.GetMemberType()))
                .ToList();
        }
        public static bool IsInternalProperty(MemberInfo memberInfo)
        {
            var isPublic = memberInfo.IsPublic();
            var isPropertyOrField = memberInfo is FieldInfo || memberInfo is PropertyInfo;
            var isDecaledOnBaseModue = memberInfo.DeclaringType.IsConstructedGenericType && (memberInfo.DeclaringType.GetGenericTypeDefinition() == typeof(RTLCombinationalModule<>) || memberInfo.DeclaringType.GetGenericTypeDefinition() == typeof(RTLSynchronousModule<,>));
            var isArray = memberInfo.GetMemberType().IsArray;

            return isArray || !isPublic && isPropertyOrField && !isDecaledOnBaseModue;
        }

        public static bool IsSynthesizableSignalType(Type type)
        {
            return type.IsValueType || type == typeof(RTLBitArray);
        }

        public static List<MemberInfo> SignalProperties(Type type)
        {
            return SynthesizableMembers(type)
                .Where(m => IsSynthesizableSignalType(m.GetMemberType()) || (m.GetMemberType().IsArray && IsSynthesizableSignalType(m.GetMemberType().GetElementType())) )
                .ToList();
        }

        public static List<MemberInfo> OutputProperties(Type type)
        {
            return SignalProperties(type).Where(p => !IsInternalProperty(p)).ToList();
        }

        public static List<MemberInfo> InternalProperties(Type type)
        {
            return SignalProperties(type).Where(p => IsInternalProperty(p)).ToList();
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
    }
}
