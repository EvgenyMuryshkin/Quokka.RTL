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
            internalInit(RTLSignalType.Unsigned, false);
        }
        private RTLBitArray(params bool[] msbBits)
        {
            internalInit(RTLSignalType.Unsigned, msbBits.Reverse().ToArray());
        }

        public RTLBitArray(params RTLBitArray[] msbSources)
        {
            var type = msbSources[0].DataType;
            var msbBits = msbSources.SelectMany(source => source.MSB).ToArray();

            internalInit(type, msbBits.Reverse().ToArray());
        }

        public RTLBitArray(IEnumerable<bool> msbBits)
        {
            internalInit(RTLSignalType.Unsigned, msbBits.Reverse().ToArray());
        }

        public RTLBitArray(RTLSignalType type, string msbBitString, int size)
        {
            FromBinaryString(type, msbBitString, size);
        }

        public RTLBitArray(RTLSignalType type, string msbBitString)
            : this(type, msbBitString, msbBitString.Length)
        {
        }

        public RTLBitArray(string msbBitString) 
            : this(RTLSignalType.Unsigned, msbBitString, msbBitString.Length)
        {
        }
    }
}
