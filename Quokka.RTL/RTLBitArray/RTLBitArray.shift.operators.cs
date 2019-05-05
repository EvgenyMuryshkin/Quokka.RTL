using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public static RTLBitArray operator <<(RTLBitArray value, int shiftBy)
        {
            var ret = new RTLBitArray(value);
            ret.internalShiftLeft(shiftBy);
            return ret;
        }

        public static RTLBitArray operator >>(RTLBitArray value, int shiftBy)
        {
            var ret = new RTLBitArray(value);
            ret.internalShiftRight(shiftBy);
            return ret;
        }
    }
}
