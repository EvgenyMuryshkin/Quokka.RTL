using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        internal void internalInitFromArray(RTLSignalType dataType, bool[] lsbSource)
        {
            _data = lsbSource;
            //_data = new BitArray(lsbSource);
            DataType = dataType;
        }

        internal void internalInitWithBuffer(RTLSignalType dataType, bool[] lsbSource)
        {
            _data = lsbSource;
            //_data = new BitArray(lsbSource);
            DataType = dataType;
        }

        internal void internalInit(RTLSignalType dataType, params bool[] lsbSource)
        {
            _data = lsbSource.ToArray();
            //_data = new BitArray(lsbSource);
            DataType = dataType;
        }

        internal void FromBinaryString(RTLSignalType dataType, string msbBitString, int size)
        {
            var bits = new bool[size];
            var chars = msbBitString.ToCharArray();
            var sourceLength = chars.Length;
            var offset = sourceLength - 1;
            for (int i = 0; i < sourceLength; i++, offset--)
            {
                bits[offset] = chars[i] != '0';
            }
            internalInit(dataType, bits);

            //msbBitString = msbBitString.PadLeft(size, '0');
            //internalInit(dataType, msbBitString.Reverse().Select(b => b == '0' ? false : true).ToArray());
        }

        internal void internalChangeType(RTLSignalType dataType)
        {
            DataType = dataType;
        }

        public bool VirtualBit(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Should be >= 0");

            if (index < Size)
                return _data[index];

            if (DataType == RTLSignalType.Unsigned)
                return false;

            return _data[Size - 1];
        }

        internal void internalResize(int newSize)
        {
            if (newSize < 0)
                throw new ArgumentOutOfRangeException(nameof(newSize), "Should be >= 0");

            if (newSize == 0)
            {
                //_data = new BitArray(0);
                _data = new bool[0];
            }

            if (newSize == Size)
            {
                return;
            }

            var newData = new bool[newSize];

            var delta = newSize - Size;
            if (delta > 0)
            {
                // expand

                // keep value
                for (var i = 0; i < Size; i++)
                    newData[i] = _data[i];

                switch (DataType)
                {
                    case RTLSignalType.Signed:
                        {
                            // expand with sign
                            if (_data[Size - 1])
                            {
                                for (var i = 0; i < delta; i++)
                                    newData[Size + i] = true;
                            }
                        }
                        break;
                    case RTLSignalType.Unsigned:
                        // expand with zeros, already filled with zeros
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
                    case RTLSignalType.Signed:
                    case RTLSignalType.Unsigned:
                        for (var i = 0; i < newSize; i++)
                            newData[i] = _data[i];
                        break;
                    default:
                        throw new Exception($"No rules to truncate {DataType}");
                }
            }

            //_data = new BitArray(newData.ToArray());
            _data = newData;
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
            //_data = _data.Not();
            _data = _data.Select(b => !b).ToArray();
        }

        internal void internalLogic(RTLBitArray value, Func<bool, bool, bool> logic)
        {
            if (Size != value.Size)
                throw new Exception($"Sizes should be same");

            var newData = LSB.Zip(value.LSB, (l, r) => logic(l, r)).ToArray();
            //_data = new BitArray(newData);
            _data = newData;
        }

        internal void internalToSigned()
        {
            internalResize(Size + 1);
            internalChangeType(RTLSignalType.Signed);
        }
    }
}
