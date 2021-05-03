using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public static bool operator ==(RTLBitArray op1, RTLBitArray op2)
        {
            if (object.Equals(op1, null) || object.Equals(op2, null))
                return false;

            var maxSize = Math.Max(op1.Size, op2.Size);
            for (int i = 0; i < maxSize; i++)
            {
                if (op1.VirtualBit(i) != op2.VirtualBit(i))
                    return false;
            }

            if (op1.DataType == op2.DataType)
                return true;

            return op1.VirtualBit(maxSize) == op2.VirtualBit(maxSize);
        }

        static bool BitCompare_Op1_GT_Op2(RTLBitArray op1, RTLBitArray op2, int maxSize)
        {
            for (int i = maxSize - 1; i >= 0; i--)
            {
                var op1Bit = op1.VirtualBit(i);
                var op2Bit = op2.VirtualBit(i);
                if (op1Bit != op2Bit)
                    return op1Bit;
            }

            return false;
        }

        public static bool operator >(RTLBitArray op1, RTLBitArray op2)
        {
            if (object.Equals(op1, null) || object.Equals(op2, null))
                return false;

            var maxSize = Math.Max(op1.Size, op2.Size);
            var op1Sig = op1.VirtualBit(maxSize);
            var op2Sig = op2.VirtualBit(maxSize);

            if (op1Sig == op2Sig)
            {
                return BitCompare_Op1_GT_Op2(op1, op2, maxSize);
            }

            return op2Sig;
        }

        public static bool operator !=(RTLBitArray op1, RTLBitArray op2)
        {
            return !(op1 == op2);
        }

        public static bool operator <(RTLBitArray op1, RTLBitArray op2)
        {
            return op2 > op1;
        }

        public static bool operator <=(RTLBitArray op1, RTLBitArray op2)
        {
            return (op1 < op2) || (op1 == op2);
        }

        public static bool operator >=(RTLBitArray op1, RTLBitArray op2)
        {
            return (op1 > op2) || (op1 == op2);
        }
    }
}
