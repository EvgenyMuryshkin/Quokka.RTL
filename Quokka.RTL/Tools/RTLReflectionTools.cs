using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Quokka.RTL.Tools
{
    public static class RTLReflectionTools
    {
        public static bool IsToolkitType(Type type)
        {
            if (type == null)
                return false;

            if (type.IsConstructedGenericType)
                return IsToolkitType(type.GetGenericTypeDefinition());

            return type.GetCustomAttribute<RTLToolkitTypeAttribute>(false) != null;
        }

        public static IEnumerable<MemberInfo> RecursiveMembers(Type type)
        {
            if (type == null || type == typeof(object))
                return Enumerable.Empty<MemberInfo>();

            var baseMembers = SynthesizableMembers(type.BaseType);

            var props = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            var fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();

            return baseMembers
                .Concat(props)
                .Concat(fields)
                // exclude backing fields
                .Where(p => p.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static IEnumerable<MemberInfo> SynthesizableMembers(Type type, bool includeToolkitTypes = false)
        {
            if (!includeToolkitTypes && IsToolkitType(type))
                return Enumerable.Empty<MemberInfo>();

            return RecursiveMembers(type)
                .Where(p => !p.IsAbstract());
        }
    }
}
