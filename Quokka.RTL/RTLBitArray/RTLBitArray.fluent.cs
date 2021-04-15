using Quokka.RTL.Tools;
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

        public RTLBitArray Resized(uint newSize)
        {
            return Resized((int)newSize);
        }

        public RTLBitArray TypeChanged(RTLSignalType dataType)
        {
            var result = new RTLBitArray(this);
            result.internalChangeType(dataType);
            return result;
        }

        public RTLBitArray Signed()
        {
            var result = new RTLBitArray(this);
            result.internalChangeType(RTLSignalType.Signed);
            return result;
        }
        public RTLBitArray Unsigned()
        {
            var result = new RTLBitArray(this);
            result.internalChangeType(RTLSignalType.Unsigned);
            return result;
        }

        public RTLBitArray Reversed()
        {
            return new RTLBitArray(LSB.ToArray()).TypeChanged(DataType);
        }

        public bool And()
        {
            return LSB.All(b => b);
        }
        public bool Or()
        {
            return LSB.Any(b => b);
        }
        public bool Xor()
        {
            return LSB.Where(b => b).Count() % 2 != 0;
        }
    }
}
