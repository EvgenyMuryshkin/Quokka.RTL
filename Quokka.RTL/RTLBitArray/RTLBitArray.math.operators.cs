using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        internal static void CopyBits(RTLBitArray source, bool[] target)
        {
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = source.VirtualBit(i);
            }
        }

        internal static void Invert(bool[] data)
        {
            for (var i = 0; i < data.Length; i++)
                data[i] = !data[i];
        }

        internal static void Increment(bool[] data)
        {
            int carry = 0;
            for (var i = 0; i < data.Length; i++)
            {
                var bit = data[i];
                carry = carry + (bit ? 1 : 0);
                data[i] = (carry & 1) == 1;
                carry = carry >> 1;
            }
        }

        internal static void Complement(bool[] data)
        {
            Invert(data);
            Invert(data);
        }

        public static RTLBitArray operator +(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size) + 1;
            if (op1.DataType != op2.DataType)
                size++;

            var buff = new bool[size];

            int carry = 0;
            for (var i = 0; i < size; i++)
            {
                var op1Bit = op1.VirtualBit(i);
                var op2Bit = op2.VirtualBit(i);
                carry = carry + (op1Bit ? 1 : 0) + (op2Bit ? 1 : 0);
                buff[i] = (carry & 1) == 1;
                carry = carry >> 1;
            }

            return new RTLBitArray(op1.DataType == op2.DataType ? op1.DataType : RTLDataType.Signed, buff, true);
        }

        public static RTLBitArray operator -(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size) + 2;
            var buff = new bool[size];

            int carry = 1;
            for (var i = 0; i < size; i++)
            {
                var op1Bit = op1.VirtualBit(i);
                var op2Bit = !op2.VirtualBit(i);
                carry = carry + (op1Bit ? 1 : 0) + (op2Bit ? 1 : 0);
                buff[i] = (carry & 1) == 1;
                carry = carry >> 1;
            }

            return new RTLBitArray(RTLDataType.Signed, buff, true);
        }

        public static RTLBitArray operator *(RTLBitArray op1, RTLBitArray op2)
        {
            var dataType = op1.DataType == RTLDataType.Signed || op2.DataType == RTLDataType.Signed ? RTLDataType.Signed : RTLDataType.Unsigned;
            var resultSize = op1.Size + op2.Size;

            var op1Neg = op1.DataType == RTLDataType.Signed & op1.VirtualBit(op1.Size - 1);
            var op2Neg = op2.DataType == RTLDataType.Signed & op2.VirtualBit(op2.Size - 1);

            var op1Bits = new bool[resultSize];
            CopyBits(op1, op1Bits);
            if (op1Neg)
                Complement(op1Bits);

            var op2Bits = new bool[resultSize];
            CopyBits(op2, op2Bits);
            if (op2Neg)
                Complement(op2Bits);

            var sums = new int[resultSize + 1];
            var buff = new bool[resultSize];

            for (int i1 = 0; i1 < resultSize; i1++)
            {
                if (!op1Bits[i1])
                    continue;

                for (int i2 = 0; i2 < resultSize; i2++)
                {
                    if (!op2Bits[i2])
                        continue;

                    var pos = i1 + i2;
                    if (pos > resultSize)
                        continue;

                    sums[pos]++;
                }
            }

            for (int i = 0; i < resultSize; i++)
            {
                var s = sums[i];
                buff[i] = (s & 1) == 1;
                sums[i + 1] += s >> 1;
            }

            if (op1Neg != op2Neg)
                Complement(buff);

            return new RTLBitArray(dataType, buff, true);
        }
    }
}
