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

        public RTLBitArray(params bool[] msbBits)
        {
            internalInit(RTLBitArrayType.Unsigned, msbBits.Reverse().ToArray());
        }

        public RTLBitArray(params RTLBitArray[] msbSources)
        {
            var type = msbSources.Length == 1 ? msbSources[0].DataType : RTLBitArrayType.Unsigned;
            var msbBits = msbSources.SelectMany(source => source.MSB).ToArray();

            internalInit(type, msbBits.Reverse().ToArray());
        }

        public RTLBitArray(RTLBitArrayType type, string msbBitString, int size)
        {
            FromBinaryString(type, msbBitString, size);
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
