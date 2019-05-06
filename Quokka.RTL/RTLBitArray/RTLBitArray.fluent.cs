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

        public RTLBitArray this[int high, int low]
        {
            get
            {
                if (high <= low)
                    throw new Exception($"violation high({high}) > low({low})");

                // take inclusive range
                var bits = Bits.Skip(low).Take(high - low + 1);

                return new RTLBitArray(bits, _dataType);
            }
        }

        public RTLBitArray Reversed()
        {
            return new RTLBitArray(Bits.Reverse(), _dataType);
        }
    }
}
