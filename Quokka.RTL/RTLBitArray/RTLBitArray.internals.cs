using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        internal void internalInit(RTLBitArrayType dataType, params bool[] lsbSource)
        {
            _data = new BitArray(lsbSource);
            DataType = dataType;
        }

        internal void FromBinaryString(RTLBitArrayType dataType, string msbBitString, int size)
        {
            msbBitString = msbBitString.PadLeft(size, '0');

            internalInit(dataType, msbBitString.Reverse().Select(b => b == '0' ? false : true).ToArray());
        }

        internal void internalChangeType(RTLBitArrayType dataType)
        {
            DataType = dataType;
        }

        internal void internalResize(int newSize)
        {
            if (newSize < 0)
                throw new ArgumentOutOfRangeException(nameof(newSize), "Should be >= 0");

            if (newSize == 0)
                _data = new BitArray(0);

            if (newSize == Size)
            {
                return;
            }

            var newData = new List<bool>();

            var delta = newSize - Size;
            if (delta > 0)
            {
                // expand

                // keep value
                newData.AddRange(Enumerable.Range(0, Size).Select(idx => _data[idx]));

                switch (DataType)
                {
                    case RTLBitArrayType.Signed:
                        {
                            // expand with sign
                            newData.AddRange(Enumerable.Range(0, delta).Select(_ => Size > 0 ? _data[Size - 1] : false));
                        }
                        break;
                    case RTLBitArrayType.Unsigned:
                        {
                            // expand with zeros
                            newData.AddRange(Enumerable.Range(0, delta).Select(_ => false));
                        }
                        break;
                    default:
                        throw new Exception($"No rules to expand {DataType}");
                }
            }
            else
            {
                // truncate
                switch (DataType)
                {
                    case RTLBitArrayType.Signed:
                    case RTLBitArrayType.Unsigned:
                        newData.AddRange(Enumerable.Range(0, newSize).Select(idx => _data[idx]));
                        break;
                    default:
                        throw new Exception($"No rules to truncate {DataType}");
                }
            }

            _data = new BitArray(newData.ToArray());
        }

        internal void internalAdd(RTLBitArray value)
        {
            var resizedValue = new RTLBitArray(value);
            resizedValue.internalResize(Size);

            int carry = 0;

            for (var idx = 0; idx < Size; idx++)
            {
                var sum = (_data[idx] ? 1 : 0) + (resizedValue[idx] ? 1 : 0) + carry;
                _data[idx] = ((sum & 1) != 0) ? true : false;

                carry = sum > 1 ? 1 : 0;
            }
        }

        internal void internal2SComplement()
        {
            internalInvert();
            // add 1 bit value
            internalAdd(new RTLBitArray(true));
        }

        internal void internalInvert()
        {
            _data = _data.Not();
        }

        internal void internalLogic(RTLBitArray value, Func<bool, bool, bool> logic)
        {
            if (Size != value.Size)
                throw new Exception($"Sizes should be same");

            var newData = LSB.Zip(value.LSB, (l, r) => logic(l, r)).ToArray();
            _data = new BitArray(newData);
        }

        internal void internalToSigned()
        {
            internalResize(Size + 1);
            internalChangeType(RTLBitArrayType.Signed);
        }
    }
}
