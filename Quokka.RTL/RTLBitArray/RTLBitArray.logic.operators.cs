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
            var size = Math.Max(op1.Size, op2.Size) + 1;
            var type = op1._dataType == op2._dataType ? op1._dataType : RTLBitArrayType.Signed;

            var lhs = new RTLBitArray(op1).Resize(size).ChangeType(type);
            var rhs = new RTLBitArray(op2).Resize(size).ChangeType(type);

            lhs.internalAnd(rhs);
            return lhs;
        }

        public static RTLBitArray operator |(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size) + 1;
            var type = op1._dataType == op2._dataType ? op1._dataType : RTLBitArrayType.Signed;

            var lhs = new RTLBitArray(op1).Resize(size).ChangeType(type);
            var rhs = new RTLBitArray(op2).Resize(size).ChangeType(type);

            lhs.internalOr(rhs);
            return lhs;
        }

        public static RTLBitArray operator ^(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size) + 1;
            var type = op1._dataType == op2._dataType ? op1._dataType : RTLBitArrayType.Signed;

            var lhs = new RTLBitArray(op1).Resize(size).ChangeType(type);
            var rhs = new RTLBitArray(op2).Resize(size).ChangeType(type);

            lhs.internalXor(rhs);
            return lhs;
        }
    }
}
