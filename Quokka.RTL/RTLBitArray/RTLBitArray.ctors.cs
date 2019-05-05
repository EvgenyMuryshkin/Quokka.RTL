using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        internal RTLBitArray(BitArray source)
        {
            _data = new BitArray(source.Count);
            for (var idx = 0; idx < source.Count; idx++)
                _data[idx] = source[idx];
        }

        internal void FromBinaryString(string value, int size, RTLBitArrayType dataType)
        {
            value = value.PadLeft(size, '0');

            _dataType = dataType;
            internalResize(value.Length);

            value = string.Join("", value.Reverse());

            for (var idx = 0; idx < value.Length; idx++)
            {
                _data[idx] = value[idx] == '0' ? false : true;
            }
        }

        /// <summary>
        /// Empty constructor, defaults to unsigned bit
        /// </summary>
        public RTLBitArray() : this(false)
        {
        }

        public RTLBitArray(string binaryString, int size, RTLBitArrayType type)
        {
            FromBinaryString(binaryString, size, type);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="source"></param>
        public RTLBitArray(RTLBitArray source) : this(source._data)
        {
            _dataType = source._dataType;
        }

        public RTLBitArray(bool value)
        {
            FromBinaryString(value ? "1" : "0", 1, RTLBitArrayType.Unsigned);
        }

        public RTLBitArray(byte value)
        {
            FromBinaryString(
                Convert.ToString(value, 2),
				8,
                RTLBitArrayType.Unsigned);
        }

        public RTLBitArray(sbyte value)
        {
            FromBinaryString(
                Convert.ToString((byte)value, 2),
				8,
                RTLBitArrayType.Signed);
        }

        public RTLBitArray(ushort value)
        {
            FromBinaryString(
                Convert.ToString((short)value, 2),
				16,
                RTLBitArrayType.Unsigned);
        }

        public RTLBitArray(short value)
        {
            FromBinaryString(
                Convert.ToString(value, 2),
				16,
                RTLBitArrayType.Signed);
        }

        public RTLBitArray(uint value)
        {
            FromBinaryString(
                Convert.ToString((int)value, 2),
				32,
                RTLBitArrayType.Unsigned);
        }

        public RTLBitArray(int value)
        {
            FromBinaryString(
                Convert.ToString(value, 2),
				32,
                RTLBitArrayType.Signed);
        }

        public RTLBitArray(ulong value)
        {
            FromBinaryString(
                Convert.ToString((long)value, 2),
				64,
                RTLBitArrayType.Unsigned);
        }

        public RTLBitArray(long value)
        {
            FromBinaryString(
                Convert.ToString(value, 2),
				64,
                RTLBitArrayType.Signed);
        }
    }
}
