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
                RTLSignalType.Unsigned,
                Convert.ToString(value, 2),
                8);
        }

        public static implicit operator sbyte(RTLBitArray value)
        {
            return (sbyte)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(sbyte value)
        {
            return new RTLBitArray(
                RTLSignalType.Signed,
                Convert.ToString((byte)value, 2),
                8);
        }

        public static implicit operator ushort(RTLBitArray value)
        {
            return (ushort)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(ushort value)
        {
            return new RTLBitArray(
                RTLSignalType.Unsigned,
                Convert.ToString((short)value, 2),
                16);
        }


        public static implicit operator short(RTLBitArray value)
        {
            return (short)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(short value)
        {
            return new RTLBitArray(
                RTLSignalType.Signed,
                Convert.ToString(value, 2),
                16);
        }


        public static implicit operator uint(RTLBitArray value)
        {
            return (uint)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(uint value)
        {
            return new RTLBitArray(
                RTLSignalType.Unsigned,
                Convert.ToString((int)value, 2),
                32);
        }


        public static implicit operator int(RTLBitArray value)
        {
            return (int)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(int value)
        {
            return new RTLBitArray(
                RTLSignalType.Signed,
                Convert.ToString(value, 2),
                32);
        }


        public static implicit operator ulong(RTLBitArray value)
        {
            return value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(ulong value)
        {
            return new RTLBitArray(
                RTLSignalType.Unsigned,
                Convert.ToString((long)value, 2),
                64);
        }


        public static implicit operator long(RTLBitArray value)
        {
            return (long)value.As64BitsUnsigned();
        }
        public static implicit operator RTLBitArray(long value)
        {
            return new RTLBitArray(
                RTLSignalType.Signed,
                Convert.ToString(value, 2),
                64);
        }
    }
}
