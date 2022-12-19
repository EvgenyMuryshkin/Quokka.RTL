using Quokka.RTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL.Tools
{
    internal static class Extensions
    {
        public static bool IsList(this Type t)
        {
            return t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(List<>);
        }

        public static bool HasValue(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static string ToCSV(this IEnumerable<string> source)
        {
            if (source == null) return "";

            return string.Join(", ", source.Where(s => s.HasValue()));
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }

        public static string StringJoin(this IEnumerable<string> source, string separator)
        {
            return string.Join(separator, source.Where(s => s.HasValue()));
        }
    }
}

namespace System
{
    public static class SystemExtensions
    {
        public static bool IsConstant(this MemberInfo memberInfo) => memberInfo is FieldInfo f && f.IsInitOnly;
        public static bool IsStruct(this Type type) => type != null && type.IsValueType && !type.IsEnum && !type.IsPrimitive;
        public static bool IsRTLBitArray(this Type type) => type != null && typeof(RTLBitArray).IsAssignableFrom(type);
        public static bool IsList(this Type type) => type != null && type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(List<>);

        public static Type GetCollectionItem(this Type type)
        {
            if (type == null)
                return null;

            if (type.IsArray)
                return type.GetElementType();

            if (type.IsList())
                return type.GetGenericArguments()[0];

            return null;
        }

        public static bool IsTuple(this Type type)
        {
            if (type.IsConstructedGenericType)
            {
                var generic = type.GetGenericTypeDefinition();
                if (generic.Name.StartsWith(nameof(ValueTuple)) || generic.Name.StartsWith(nameof(Tuple)))
                {
                    return true;
                }
            }

            return false;
        }

        public static MemberInfo SingleMember(this Type source, string name)
        {
            return source.GetMember(name).Single();
        }

        public static MemberInfo SingleOrDefaultMember(this Type source, string name)
        {
            return source.GetMember(name).SingleOrDefault();
        }

        public static MemberInfo SingleMember(this object source, string name)
        {
            return source.GetType().GetMember(name).Single();
        }
    }
}