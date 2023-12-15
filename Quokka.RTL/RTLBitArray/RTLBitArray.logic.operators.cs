using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public static RTLBitArray operator !(RTLBitArray source)
        {
            var size = source.Size;
            var buff = new bool[source.Size];

            for (var i = 0; i < size; i++)
            {
                buff[i] = !source.VirtualBit(i);
            }

            return new RTLBitArray(source.DataType, buff, true);
        }

        public static RTLBitArray operator &(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size);
            var type = op1.DataType == op2.DataType ? op1.DataType : RTLDataType.Signed;

            var buff = new bool[size];

            for (var i = 0; i < size; i++)
            {
                var op1Bit = op1.VirtualBit(i);
                var op2Bit = op2.VirtualBit(i);
                buff[i] = op1Bit & op2Bit;
            }

            return new RTLBitArray(type, buff, true);
        }

        public static RTLBitArray operator |(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size);
            var type = op1.DataType == op2.DataType ? op1.DataType : RTLDataType.Signed;

            var buff = new bool[size];

            for (var i = 0; i < size; i++)
            {
                var op1Bit = op1.VirtualBit(i);
                var op2Bit = op2.VirtualBit(i);
                buff[i] = op1Bit | op2Bit;
            }

            return new RTLBitArray(type, buff, true);
        }

        public static RTLBitArray operator ^(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size);
            var type = op1.DataType == op2.DataType ? op1.DataType : RTLDataType.Signed;

            var buff = new bool[size];

            for (var i = 0; i < size; i++)
            {
                var op1Bit = op1.VirtualBit(i);
                var op2Bit = op2.VirtualBit(i);
                buff[i] = op1Bit ^ op2Bit;
            }

            return new RTLBitArray(type, buff, true);
        }
    }
}
