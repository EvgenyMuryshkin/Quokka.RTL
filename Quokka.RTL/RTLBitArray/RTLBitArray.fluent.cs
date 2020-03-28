using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public RTLBitArray Resized(int newSize)
        {
            var result = new RTLBitArray(this);
            result.internalResize(newSize);
            return result;
        }

        public RTLBitArray TypeChanged(RTLBitArrayType dataType)
        {
            var result = new RTLBitArray(this);
            result.internalChangeType(dataType);
            return result;
        }

        public RTLBitArray Reversed()
        {
            return new RTLBitArray(LSB.ToArray()).TypeChanged(DataType);
        }
    }
}
