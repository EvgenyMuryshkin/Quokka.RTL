using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        internal void internalAnd(RTLBitArray value)
        {
            internalLogic(value, (l, r) => l & r);
        }

        internal void internalOr(RTLBitArray value)
        {
            internalLogic(value, (l, r) => l | r);
        }

        internal void internalXor(RTLBitArray value)
        {
            internalLogic(value, (l, r) => l ^ r);
        }
    }
}
