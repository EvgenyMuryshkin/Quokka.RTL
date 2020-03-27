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

        internal void FromBinaryString(string msbBitString, int size, RTLBitArrayType dataType)
        {
            msbBitString = msbBitString.PadLeft(size, '0');

            _dataType = dataType;
            internalResize(msbBitString.Length);

            msbBitString = string.Join("", msbBitString.Reverse());

            for (var idx = 0; idx < msbBitString.Length; idx++)
            {
                _data[idx] = msbBitString[idx] == '0' ? false : true;
            }
        }

        /// <summary>
        /// Empty constructor, defaults to unsigned bit
        /// </summary>
        public RTLBitArray() : this(false)
        {
        }

        public RTLBitArray(RTLBitArrayType type, params bool[] msbBits)
        {
            var msbString = string.Join("", msbBits.Select(b => b ? "1" : "0"));
            FromBinaryString(msbString, msbString.Length, type);
        }

        public RTLBitArray(params bool[] msbBits)
            : this(RTLBitArrayType.Unsigned, msbBits)
        {
        }

        public RTLBitArray(params RTLBitArray[] msbSources)
            : this(msbSources.SelectMany(source => source.MSB).ToArray())
        {
        }

        public RTLBitArray(string msbBitString, int size, RTLBitArrayType type)
        {
            FromBinaryString(msbBitString, size, type);
        }

        public RTLBitArray(string msbBitString, RTLBitArrayType type)
        {
            FromBinaryString(msbBitString, msbBitString.Length, type);
        }

        public RTLBitArray(string msbBitString)
        {
            FromBinaryString(msbBitString, msbBitString.Length, RTLBitArrayType.Unsigned);
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
