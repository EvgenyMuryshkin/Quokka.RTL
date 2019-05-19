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
            var remaining = list.Skip(value).ToArray();

            // keep original size of bit array
            var padding = Enumerable
                .Range(0, Size - remaining.Length)
                .Select(idx => DataType == RTLBitArrayType.Signed ? list[Size - 1] : false);
            _data = new BitArray(remaining.Concat(padding).ToArray());
        }
    }
}
