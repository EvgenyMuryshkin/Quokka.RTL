using System;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL.Tools
{
    public class PredefinedTypes
    {
        public static Dictionary<string, Type> TypeAliases = new Dictionary<string, Type>()
        {
            { "bool", typeof(bool) },
            { "byte", typeof(byte) },
            { "sbyte", typeof(sbyte) },
            { "short", typeof(short) },
            { "ushort", typeof(ushort) },
            { "int", typeof(int) },
            { "uint", typeof(uint) },
            { "long", typeof(long) },
            { "ulong", typeof(ulong) },
            { "float", typeof(float) },
            { "single", typeof(float) },
        };

        public static Dictionary<Type, RTLSignalInfo> TypeInfos = new RTLSignalInfo[]
        {
            new RTLSignalInfo(typeof(bool), 1, RTLSignalType.Unsigned ),
            new RTLSignalInfo(typeof(byte), 8, RTLSignalType.Unsigned ),
            new RTLSignalInfo(typeof(sbyte), 8, RTLSignalType.Signed ),
            new RTLSignalInfo(typeof(short), 16, RTLSignalType.Signed ),
            new RTLSignalInfo(typeof(ushort), 16, RTLSignalType.Unsigned ),
            new RTLSignalInfo(typeof(int), 32, RTLSignalType.Signed ),
            new RTLSignalInfo(typeof(uint), 32, RTLSignalType.Unsigned ),
            new RTLSignalInfo(typeof(long), 64, RTLSignalType.Signed ),
            new RTLSignalInfo(typeof(ulong), 64, RTLSignalType.Unsigned ),
            new RTLSignalInfo(typeof(float), 32, RTLSignalType.Floating ),
        }.ToDictionary(p => p.Type);
    }
}
