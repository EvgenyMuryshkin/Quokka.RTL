using Quokka.RTL;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL.Tools
{
    internal static class Extensions
    {
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
        public static bool IsConstant(this MemberInfo memberInfo) => RTLTypeCheck.IsConstant(memberInfo);
        public static bool IsStruct(this Type type) => type != null && type.IsValueType && !type.IsEnum && !type.IsPrimitive;
        public static bool IsRTLBitArray(this Type type) => RTLTypeCheck.IsRTLBitArray(type);
        public static bool IsList(this Type type) => RTLTypeCheck.IsList(type);
        public static bool IsCollection(this Type type) => RTLTypeCheck.IsCollection(type);
        public static Type GetCollectionItemType(this Type type) => RTLReflectionTools.GetCollectionItemType(type);
        public static bool IsTuple(this Type type) => RTLTypeCheck.IsTuple(type);
        public static bool IsGenericTuple(this Type type) => RTLTypeCheck.IsGenericTuple(type);


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