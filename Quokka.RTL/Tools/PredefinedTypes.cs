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
            new RTLSignalInfo(typeof(bool), 1, RTLDataType.Unsigned, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(byte), 8, RTLDataType.Unsigned, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(sbyte), 8, RTLDataType.Signed, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(short), 16, RTLDataType.Signed, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(ushort), 16, RTLDataType.Unsigned, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(int), 32, RTLDataType.Signed, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(uint), 32, RTLDataType.Unsigned, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(long), 64, RTLDataType.Signed, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(ulong), 64, RTLDataType.Unsigned, RTLSignalType.Auto ),
            new RTLSignalInfo(typeof(float), 32, RTLDataType.Floating, RTLSignalType.Auto ),
        }.ToDictionary(p => p.Type);
    }
}
