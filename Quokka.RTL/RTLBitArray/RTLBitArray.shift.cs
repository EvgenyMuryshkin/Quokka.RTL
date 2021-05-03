using Quokka.RTL.Tools;
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

            var list = LSB.ToList();

            while (value-- != 0)
            {
                list.Insert(0, false);
            }

            //_data = new BitArray(list.ToArray());
            _data = list.ToArray();
        }

        internal void internalShiftRight(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Should not be negative");

            var list = LSB.ToList();
            var remaining = list.Skip(value).ToArray();

            // keep original size of bit array
            var padding = Enumerable
                .Range(0, Size - remaining.Length)
                .Select(idx => DataType == RTLSignalType.Signed ? list[Size - 1] : false);

            //_data = new BitArray(remaining.Concat(padding).ToArray());
            _data = remaining.Concat(padding).ToArray();
        }

        public RTLBitArray ShiftLeft(RTLBitArray by)
        {
            var shifted = this << by;
            var totalLength = Size + (1 << by.Size) - 1;

            return shifted.Resized(totalLength);
        }

        public RTLBitArray ShiftRight(RTLBitArray by)
        {
            return this >> by;
        }
    }
}
