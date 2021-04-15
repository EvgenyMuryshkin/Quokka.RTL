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
            var ret = new RTLBitArray(source);
            ret.internalInvert();
            return ret;
        }

        public static RTLBitArray operator &(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size);
            var type = op1.DataType == op2.DataType ? op1.DataType : RTLSignalType.Signed;

            var lhs = new RTLBitArray(op1).Resized(size).TypeChanged(type);
            var rhs = new RTLBitArray(op2).Resized(size).TypeChanged(type);

            lhs.internalAnd(rhs);
            return lhs;
        }

        public static RTLBitArray operator |(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size);
            var type = op1.DataType == op2.DataType ? op1.DataType : RTLSignalType.Signed;

            var lhs = new RTLBitArray(op1).Resized(size).TypeChanged(type);
            var rhs = new RTLBitArray(op2).Resized(size).TypeChanged(type);

            lhs.internalOr(rhs);
            return lhs;
        }

        public static RTLBitArray operator ^(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size);
            var type = op1.DataType == op2.DataType ? op1.DataType : RTLSignalType.Signed;

            var lhs = new RTLBitArray(op1).Resized(size).TypeChanged(type);
            var rhs = new RTLBitArray(op2).Resized(size).TypeChanged(type);

            lhs.internalXor(rhs);
            return lhs;
        }
    }
}
