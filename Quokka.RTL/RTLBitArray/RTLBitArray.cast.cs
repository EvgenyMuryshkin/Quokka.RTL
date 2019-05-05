using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public static explicit operator bool(RTLBitArray value)
        {
            return value[0];
        }

        public static explicit operator byte(RTLBitArray value)
        {
            return (byte)value.As64BitsUnsigned();
        }

        public static explicit operator sbyte(RTLBitArray value)
        {
            return (sbyte)value.As64BitsUnsigned();
        }

        public static explicit operator ushort(RTLBitArray value)
        {
            return (ushort)value.As64BitsUnsigned();
        }

        public static explicit operator short(RTLBitArray value)
        {
            return (short)value.As64BitsUnsigned();
        }

        public static explicit operator uint(RTLBitArray value)
        {
            return (uint)value.As64BitsUnsigned();
        }

        public static explicit operator int(RTLBitArray value)
        {
            return (int)value.As64BitsUnsigned();
        }

        public static explicit operator ulong(RTLBitArray value)
        {
            return value.As64BitsUnsigned();
        }

        public static explicit operator long(RTLBitArray value)
        {
            return (long)value.As64BitsUnsigned();
        }
    }
}
