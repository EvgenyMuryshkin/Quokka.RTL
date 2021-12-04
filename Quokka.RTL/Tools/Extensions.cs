using System;
using System.Collections.Generic;
using System.Linq;

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

        public static string StringJoin(this IEnumerable<string> source, string separator)
        {
            return string.Join(separator, source.Where(s => s.HasValue()));
        }
    }
}
