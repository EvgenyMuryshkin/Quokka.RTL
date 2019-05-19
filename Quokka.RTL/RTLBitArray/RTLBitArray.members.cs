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

        public IEnumerable<bool> Bits => _data.OfType<bool>();

        public bool this[int idx]
        {
            get
            {
                return _data[idx];
            }
            set
            {
                _data[idx] = value;
            }
        }
    }
}
