using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public sealed partial class RTLBitArray
    {
        BitArray _data = new BitArray(1);

        RTLBitArrayType _dataType { get; set; } = RTLBitArrayType.Unsigned;

        public int Size => _data.Count;
        public RTLBitArrayType DataType => _dataType;

        public IEnumerable<bool> MSB => LSB.Reverse();
        public IEnumerable<bool> LSB => _data.OfType<bool>();

        void AssertIndex(int idx)
        {
            if (idx < 0 || idx >= Size)
                throw new IndexOutOfRangeException($"BitArray index '{idx}' is out of range '{Size}'");
        }

        public bool this[int idx]
        {
            get
            {
                AssertIndex(idx);
                return _data[idx];
            }
            set
            {
                _data[idx] = value;
            }
        }

        public RTLBitArray this[int msbFrom, int msbTo]
        {
            get
            {
                AssertIndex(msbFrom);
                AssertIndex(msbTo);

                var skip = Math.Min(msbFrom, msbTo);
                var take = Math.Abs(msbTo - msbFrom) + 1;

                var range = LSB.Skip(skip).Take(take);

                return msbFrom < msbTo ? new RTLBitArray(range.ToArray()) : new RTLBitArray(range.Reverse().ToArray());
            }
        }

    }
}
