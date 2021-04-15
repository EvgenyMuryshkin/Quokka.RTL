using FPGA;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL.Tools
{
    public static class RTLSignalTools
    {
        public static RTLSignalInfo SizeOfPredefinedType(Type type)
        {
            var ti = PredefinedTypes.TypeInfos[type];

            return new RTLSignalInfo() { Type = type, Size = ti.Size, SignalType = ti.SignalType };
        }

        public static RTLSignalInfo SizeOfPredefinedType(string typeName)
        {
            if (!PredefinedTypes.TypeAliases.ContainsKey(typeName))
                throw new Exception($"unsupported type: '{typeName}'");

            var type = PredefinedTypes.TypeAliases[typeName];

            return SizeOfPredefinedType(type);
        }

        public static RTLSignalInfo SizeOfValue(object value)
        {
            switch (value)
            {
                case string s:
                    throw new ArgumentOutOfRangeException($"String value does not have RTL size: {value}");
                case RTLBitArray a:
                    return new RTLSignalInfo()
                    {
                        Type = a.GetType(),
                        SignalType = a.DataType,
                        Size = a.Size
                    };
                default:
                    return SizeOf(value.GetType());
            }
        }

        public static RTLSignalInfo SizeOf(Type sourceType)
        {
            var type = sourceType.IsByRef ? sourceType.GetElementType() : sourceType;

            if (type.IsConstructedGenericType)
            {
                var signalTypes = new HashSet<Type>() { typeof(Signal<>), typeof(InputSignal<>), typeof(OutputSignal<>), typeof(BidirSignal<>) };
                if (signalTypes.Contains(type.GetGenericTypeDefinition()))
                {
                    return SizeOf(type.GetGenericArguments()[0]);
                }
            }

            if (type.IsEnum)
            {
                var underlyingSize = SizeOf(type.GetEnumUnderlyingType());

                if (underlyingSize.SignalType != RTLSignalType.Unsigned)
                {
                    // check if any value is negative and use underlying type
                    var signedValues = Enum.GetValues(type).OfType<object>().Select(v => Convert.ToInt64(v));
                    if (signedValues.Any(v => v < 0))
                        return underlyingSize;
                }

                int bits = 1;

                var enumValues = Enum.GetValues(type).OfType<object>().Select(v => Convert.ToUInt64(v));
                if (enumValues.Any())
                {
                    var maxValue = enumValues.Max();
                    bits = (int)RTLCalculators.CalcBitsForValue(maxValue);
                }

                return new RTLSignalInfo()
                {
                    Type = type,
                    Size = bits,
                    SignalType = RTLSignalType.Unsigned
                };
            }

            if (PredefinedTypes.TypeInfos.ContainsKey(type))
                return SizeOfPredefinedType(type);

            if (RTLTypeCheck.IsSynthesizableObject(type))
            {
                return new RTLSignalInfo()
                {
                    Type = type,
                    Size = RTLReflectionTools.SerializableMembers(type).Sum(m => SizeOf(m.GetMemberType()).Size),
                    SignalType = RTLSignalType.Unsigned
                };
            }

            // TODO: should not really be there
            if (type.IsArray)
                return SizeOf(type.GetElementType());

            if (RTLReflectionTools.TryGetNullableType(type, out var actualType))
                return SizeOf(actualType);

            throw new Exception($"Cannot calculate sizeof {type.Name}");
        }
    }
}
