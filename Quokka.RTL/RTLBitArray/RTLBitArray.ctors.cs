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
            internalInit(RTLBitArrayType.Unsigned, false);
        }

        public RTLBitArray(RTLBitArrayType type, params bool[] msbBits)
        {
            internalInit(type, msbBits.Reverse().ToArray());
        }
        public RTLBitArray(RTLBitArrayType type, string msbBitString, int size)
        {
            FromBinaryString(type, msbBitString, size);
        }

        public RTLBitArray(params bool[] msbBits)
            : this(RTLBitArrayType.Unsigned, msbBits)
        {
        }

        public RTLBitArray(params RTLBitArray[] msbSources)
            : this(msbSources.SelectMany(source => source.MSB).ToArray())
        {
            if (msbSources.Length == 1)
            {
                DataType = msbSources[0].DataType;
            }
        }

        public RTLBitArray(RTLBitArrayType type, string msbBitString)
            : this(type, msbBitString, msbBitString.Length)
        {
        }

        public RTLBitArray(string msbBitString) 
            : this(RTLBitArrayType.Unsigned, msbBitString, msbBitString.Length)
        {
        }
    }
}
