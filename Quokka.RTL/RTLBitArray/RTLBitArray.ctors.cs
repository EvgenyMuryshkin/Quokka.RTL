using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        /// <summary>
        /// Empty constructor, defaults to unsigned bit
        /// </summary>
        public RTLBitArray()
        {
            internalInit(RTLDataType.Unsigned, false);
        }

        private RTLBitArray(params bool[] msbBits)
        {
            internalInit(RTLDataType.Unsigned, msbBits.Reverse().ToArray());
        }

        public RTLBitArray(params RTLBitArray[] msbSources)
        {
            if (msbSources.Length == 1)
            {
                var source = msbSources[0];
                if (source._fromCast)
                {
                    internalInitFromArray(source.DataType, source._data);
                }
                else
                {
                    internalInit(source.DataType, source.LSB);
                }
            }
            else
            {
                var type = msbSources[0].DataType;
                var lsbBits = msbSources
                    .SelectMany(source => source.MSB)
                    .Reverse()
                    .ToArray();

                internalInit(type, lsbBits);
            }
        }

        public RTLBitArray(byte[] lsb) : this(lsb.Reverse().Select(b => new RTLBitArray(b)).ToArray())
        {

        }

        public RTLBitArray(IEnumerable<bool> msbBits)
        {
            internalInit(RTLDataType.Unsigned, msbBits.Reverse().ToArray());
        }

        public RTLBitArray(RTLDataType type, string msbBitString, int size)
        {
            FromBinaryString(type, msbBitString, size);
        }

        internal RTLBitArray(RTLDataType type, bool[] lsb, bool fromCast)
        {
            internalInitWithBuffer(type, lsb);
            _fromCast = fromCast;
        }

        internal RTLBitArray(RTLDataType type, string msbBitString, int size, bool fromCast)
        {
            FromBinaryString(type, msbBitString, size);
            _fromCast = fromCast;
        }

        public RTLBitArray(RTLDataType type, string msbBitString)
            : this(type, msbBitString, msbBitString.Length)
        {
        }

        public RTLBitArray(string msbBitString) 
            : this(RTLDataType.Unsigned, msbBitString, msbBitString.Length)
        {
        }
    }
}
