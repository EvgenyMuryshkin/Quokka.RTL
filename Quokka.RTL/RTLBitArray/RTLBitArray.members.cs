using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        //private BitArray _data = new BitArray(1);
        internal bool[] _data = new bool[1];
        internal bool _fromCast;

        public RTLSignalType DataType { get; private set; } = RTLSignalType.Unsigned;

        public int Size => _data.Length;
        public IEnumerable<bool> MSB => LSB.Reverse();
        public bool[] LSB
        {
            get
            {
                var size = _data.Length;
                var result = new bool[size];

                for (var i = 0; i < size; i++)
                    result[i] = _data[i];

                return result;
            }
        }

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
