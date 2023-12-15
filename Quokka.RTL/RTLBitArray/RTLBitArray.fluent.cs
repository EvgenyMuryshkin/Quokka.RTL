using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        internal RTLBitArray Resized(int newSize, RTLDataType dataType)
        {
            var result = this.Resized(newSize);
            result.internalChangeType(dataType);
            return result;
        }

        public RTLBitArray Resized(int newSize)
        {
            var buff = new bool[newSize];
            for (int i = 0; i < newSize; i++)
            {
                buff[i] = VirtualBit(i);
            }

            return new RTLBitArray(DataType, buff, true);
        }

        public RTLBitArray Resized(uint newSize)
        {
            return Resized((int)newSize);
        }

        public RTLBitArray TypeChanged(RTLDataType dataType)
        {
            var result = new RTLBitArray(this);
            result.internalChangeType(dataType);
            return result;
        }

        public RTLBitArray Signed()
        {
            var result = new RTLBitArray(this);
            result.internalChangeType(RTLDataType.Signed);
            return result;
        }
        public RTLBitArray Unsigned()
        {
            var result = new RTLBitArray(this);
            result.internalChangeType(RTLDataType.Unsigned);
            return result;
        }

        public RTLBitArray Reversed()
        {
            return new RTLBitArray(LSB).TypeChanged(DataType);
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
