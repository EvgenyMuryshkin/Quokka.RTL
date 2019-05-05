using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public RTLBitArray Resize(int newSize)
        {
            var result = new RTLBitArray(this);
            result.internalResize(newSize);
            return result;
        }

        public RTLBitArray ChangeType(RTLBitArrayType dataType)
        {
            var result = new RTLBitArray(this);
            result.internalChangeType(dataType);
            return result;
        }
    }
}
