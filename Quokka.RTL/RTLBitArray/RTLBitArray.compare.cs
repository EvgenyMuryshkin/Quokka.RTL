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
            var size = Math.Max(op1.Size, op2.Size) + 1;

            var lhs = new RTLBitArray(op1).Resize(size).ChangeType(RTLBitArrayType.Signed);
            var rhs = new RTLBitArray(op2).Resize(size).ChangeType(RTLBitArrayType.Signed);

            return lhs.ToString() == rhs.ToString();
        }

        public static bool operator >(RTLBitArray op1, RTLBitArray op2)
        {
            var size = Math.Max(op1.Size, op2.Size) + 1;

            var lhs = new RTLBitArray(op1).Resize(size).ChangeType(RTLBitArrayType.Signed);
            var rhs = new RTLBitArray(op2).Resize(size).ChangeType(RTLBitArrayType.Signed);

            var lhsSig = lhs[size - 1];
            var rhsSig = rhs[size - 1];

            if (lhsSig != rhsSig)
            {
                return (lhsSig ? 0 : 1) > (rhsSig ? 0 : 1);
            }

            if (!lhsSig)
            {
                // both positive, compare string represenation
                var lhsString = lhs.ToString();
                var rhsString = rhs.ToString();
                var stringLength = Math.Max(lhsString.Length, rhsString.Length);
                lhsString = lhsString.PadLeft(stringLength, '0');
                rhsString = rhsString.PadLeft(stringLength, '0');

                return lhsString.CompareTo(rhsString) > 0;
            }
            else
            {
                // both negative
                lhs.internal2SComplement();
                rhs.internal2SComplement();
                return rhs > lhs;
            }
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
