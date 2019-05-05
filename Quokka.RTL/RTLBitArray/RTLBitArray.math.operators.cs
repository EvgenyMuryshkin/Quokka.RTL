using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public static RTLBitArray operator +(RTLBitArray op1, RTLBitArray op2)
        {
            var ret = new RTLBitArray(op1);
            ret.Add(op2);
            return ret;
        }

        public static RTLBitArray operator -(RTLBitArray op1, RTLBitArray op2)
        {
            var ret = new RTLBitArray(op1);
            ret.Subtract(op2);
            return ret;
        }

        public static RTLBitArray operator *(RTLBitArray op1, RTLBitArray op2)
        {
            var ret = new RTLBitArray(op1);
            ret.Multiply(op2);
            return ret;
        }
    }
}
