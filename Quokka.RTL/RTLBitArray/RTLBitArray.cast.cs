using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public static implicit operator bool(RTLBitArray value)
        {
            return value[0];
        }

        public static implicit operator RTLBitArray(bool value)
        {
            return new RTLBitArray(value);
        }

        public static implicit operator byte(RTLBitArray value)
        {
            return (byte)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(byte value)
        {
            return new RTLBitArray(
                RTLDataType.Unsigned,
                RTLBitArrayInitType.MSB,
                Convert.ToString(value, 2),
                8,
                true);
        }

        public static implicit operator sbyte(RTLBitArray value)
        {
            return (sbyte)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(sbyte value)
        {
            return new RTLBitArray(
                RTLDataType.Signed,
                RTLBitArrayInitType.MSB,
                Convert.ToString((byte)value, 2),
                8,
                true);
        }

        public static implicit operator ushort(RTLBitArray value)
        {
            return (ushort)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(ushort value)
        {
            return new RTLBitArray(
                RTLDataType.Unsigned,
                RTLBitArrayInitType.MSB,
                Convert.ToString((short)value, 2),
                16,
                true);
        }


        public static implicit operator short(RTLBitArray value)
        {
            return (short)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(short value)
        {
            return new RTLBitArray(
                RTLDataType.Signed,
                RTLBitArrayInitType.MSB,
                Convert.ToString(value, 2),
                16,
                true);
        }


        public static implicit operator uint(RTLBitArray value)
        {
            return (uint)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(uint value)
        {
            return new RTLBitArray(
                RTLDataType.Unsigned,
                RTLBitArrayInitType.MSB,
                Convert.ToString((int)value, 2),
                32,
                true);
        }


        public static implicit operator int(RTLBitArray value)
        {
            return (int)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(int value)
        {
            return new RTLBitArray(
                RTLDataType.Signed,
                RTLBitArrayInitType.MSB,
                Convert.ToString(value, 2),
                32,
                true);
        }


        public static implicit operator ulong(RTLBitArray value)
        {
            return value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(ulong value)
        {
            return new RTLBitArray(
                RTLDataType.Unsigned,
                RTLBitArrayInitType.MSB,
                Convert.ToString((long)value, 2),
                64,
                true);
        }


        public static implicit operator long(RTLBitArray value)
        {
            return (long)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(long value)
        {
            return new RTLBitArray(
                RTLDataType.Signed,
                RTLBitArrayInitType.MSB,
                Convert.ToString(value, 2),
                64,
                true);
        }

        public static implicit operator byte[](RTLBitArray value)
        {
            var aligned = value.Size >> 3;
            if ((value.Size & 0x7) != 0)
                aligned++;

            IEnumerable<bool> bits = value.Resized(aligned << 3).LSB;

            var result = new byte[aligned];
            for (int i = 0; i < aligned; i++)
            {
                result[i] = new RTLBitArray(bits.Take(8));
                bits = bits.Skip(8);
            }

            return result;
        }

        public static RTLBitArray FromValue(object value)
        {
            var valueType = value.GetType();
            if (valueType.IsEnum)
            {
                var initializer = RTLSignalTools.RawMemoryElementInitializer(value);
                return new RTLBitArray(RTLBitArrayInitType.MSB, initializer);
            }

            switch (value)
            {
                case bool v: return new RTLBitArray(v);
                case sbyte v: return new RTLBitArray(v);
                case byte v: return new RTLBitArray(v);
                case short v: return new RTLBitArray(v);
                case ushort v: return new RTLBitArray(v);
                case int v: return new RTLBitArray(v);
                case uint v: return new RTLBitArray(v);
                case long v: return new RTLBitArray(v);
                case ulong v: return new RTLBitArray(v);
                case RTLBitArray v: return (RTLBitArray)v.Clone();
                default: throw new Exception($"Cannot convert object of type '{value?.GetType()?.Name}' to RTLBitArray");
            }
        }

        public object ToValue(Type type)
        {
            var value = this;
            var instance = Activator.CreateInstance(type);

            if (type.IsEnum)
            {
                var underlyingType = type.GetEnumUnderlyingType();
                var underlyingValue = ToValue(underlyingType);
                var values = Enum.GetValues(type).AsEnumerableOfObjects().ToList();
                var matchingValue = values.Where(v =>
                {
                    var unveryingTypeValue = (IComparable)Convert.ChangeType(v, underlyingType);
                    return unveryingTypeValue.Equals(underlyingValue);
                }).FirstOrDefault();

                if (matchingValue == null)
                    throw new Exception($"Cannot convert RTLBitArray to enum of type {type.Name}");

                return Convert.ChangeType(matchingValue, type);
            }

            switch (instance)
            {
                case bool v: return (bool)value;
                case sbyte v: return (sbyte)value;
                case byte v: return (byte)value;
                case short v: return (short)value;
                case ushort v: return (ushort)value;
                case int v: return (int)value;
                case uint v: return (uint)value;
                case long v: return (long)value;
                case ulong v: return (ulong)value;
                case RTLBitArray v: return this.Clone();
                default: throw new Exception($"Cannot convert RTLBitArray to object of type '{type.Name}'");
            }
        }
    }
}
