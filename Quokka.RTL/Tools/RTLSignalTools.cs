using FPGA;
using Quokka.RTL.Tools;
using System;
using System.Collections;
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

            return new RTLSignalInfo() { Type = type, Size = ti.Size, DataType = ti.DataType };
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
                        DataType = a.DataType,
                        SignalType = RTLSignalType.Bus,
                        Size = a.Size
                    };
                default:
                {
                    var valueType = value.GetType();
                    if (value is IEnumerable valueList)
                    {
                        return new RTLSignalInfo()
                        {
                            Type = valueType,
                            Size = valueList.OfType<object>().Select(o => SizeOfValue(o).Size).Sum(),
                            DataType = RTLDataType.Unsigned,
                            SignalType = RTLSignalType.Bus
                        };
                    }
                    else if (RTLTypeCheck.IsSynthesizableObject(value.GetType()))
                    {
                        return new RTLSignalInfo()
                        {
                            Type = valueType,
                            Size = RTLReflectionTools.SerializableMembers(valueType).Sum(m => SizeOfValue(m.GetValue(value)).Size),
                            DataType = RTLDataType.Unsigned,
                            SignalType = RTLSignalType.Bus
                        };
                    }
                    else if (RTLTypeCheck.IsTuple(valueType))
                    {
                        return new RTLSignalInfo()
                        {
                            Type = valueType,
                            Size = RTLReflectionTools.SerializableMembers(valueType).Sum(m => SizeOfValue(m.GetValue(value)).Size),
                            DataType = RTLDataType.Unsigned,
                            SignalType = RTLSignalType.Bus
                        };
                    }
                    else
                    {
                        return SizeOf(valueType);
                    }
                }
            }
        }

        public static RTLSignalInfo SizeOf(MemberInfo member)
        {
            var type = member.GetMemberType();
            return SizeOf(type, () => new Exception($"Cannot calculate sizeof {type.Name}: {member.Name}"));
        }

        public static RTLSignalInfo SizeOf(Type sourceType, Func<Exception> exceptionFormatter = null)
        {
            var type = sourceType.IsByRef ? sourceType.GetElementType() : sourceType;

            if (exceptionFormatter == null)
                exceptionFormatter = () => new Exception($"Cannot calculate sizeof {type.Name}");

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

                if (underlyingSize.DataType != RTLDataType.Unsigned)
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
                    DataType = RTLDataType.Unsigned
                };
            }

            if (PredefinedTypes.TypeInfos.ContainsKey(type))
                return SizeOfPredefinedType(type);

            if (RTLTypeCheck.IsSynthesizableObject(type))
            {
                return new RTLSignalInfo()
                {
                    Type = type,
                    Size = RTLReflectionTools.SerializableMembers(type).Sum(m => SizeOf(m).Size),
                    DataType = RTLDataType.Unsigned
                };
            }

            // TODO: should not really be there
            if (type.IsArray)
                return SizeOf(type.GetElementType());

            if (RTLReflectionTools.TryGetNullableType(type, out var actualType))
                return SizeOf(actualType);

            throw exceptionFormatter();
        }

        static string RawMemoryElementInitializer(object value)
        {
            if (value == null) throw new NullReferenceException(nameof(value));

            switch (value)
            {
                case bool b: return new RTLBitArray(b).AsBinaryString();
                case byte b: return new RTLBitArray(b).AsBinaryString();
                case sbyte b: return new RTLBitArray(b).AsBinaryString();
                case short b: return new RTLBitArray(b).AsBinaryString();
                case ushort b: return new RTLBitArray(b).AsBinaryString();
                case int b: return new RTLBitArray(b).AsBinaryString();
                case uint b: return new RTLBitArray(b).AsBinaryString();
                case long b: return new RTLBitArray(b).AsBinaryString();
                case ulong b: return new RTLBitArray(b).AsBinaryString();
                case RTLBitArray b: return b.AsBinaryString();
                default:
                    var valueType = value.GetType();
                    if (RTLTypeCheck.IsSynthesizableObject(valueType))
                    {
                        var orderedMembers = RTLReflectionTools.SerializableMembers(valueType);
                        var combinedInitialier = string.Join(
                            "", 
                            orderedMembers
                                .Select(m => RawMemoryElementInitializer(m.GetValue(value)))
                                .Reverse()
                        );
                        return combinedInitialier;
                    }
                    else if (valueType.IsCollection())
                    {
                        var combinedInitialier = string.Join(
                            "",
                            (value as IEnumerable)
                                .OfType<object>()
                                .Select(m => RawMemoryElementInitializer(m))
                                .Reverse()
                        );
                        return combinedInitialier;

                    }
                    else if (valueType.IsTuple())
                    {
                        var orderedMembers = RTLReflectionTools.SerializableMembers(valueType);
                        var combinedInitialier = string.Join(
                            "",
                            orderedMembers
                                .Select(m => RawMemoryElementInitializer(m.GetValue(value)))
                        );
                        return combinedInitialier;
                    }

                    throw new Exception($"MemoryElementInitializer: unsupported value: value - {value}");
            }
        }

        public static string MemoryElementInitializer(object value)
        {
            return $"bin:{RawMemoryElementInitializer(value)}";
        }
    }
}
