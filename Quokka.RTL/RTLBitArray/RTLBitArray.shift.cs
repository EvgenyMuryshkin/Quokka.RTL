using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        internal void internalShiftLeft(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Should not be negative");

            var list = Bits.ToList();

            while (value-- != 0)
            {
                list.Insert(0, false);
            }

            _data = new BitArray(list.ToArray());
        }

        internal void internalShiftRight(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Should not be negative");

            var list = Bits.ToList();

            _data = new BitArray(list.Skip(value).ToArray());
        }
    }
}
