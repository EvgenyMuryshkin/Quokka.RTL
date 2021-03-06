﻿using Quokka.RTL.Tools;
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

        public RTLBitArray(IEnumerable<bool> msbBits)
        {
            internalInit(RTLSignalType.Unsigned, msbBits.Reverse().ToArray());
        }

        public RTLBitArray(RTLSignalType type, string msbBitString, int size)
        {
            FromBinaryString(type, msbBitString, size);
        }

        internal RTLBitArray(RTLSignalType type, bool[] lsb, bool fromCast)
        {
            internalInitWithBuffer(type, lsb);
            _fromCast = fromCast;
        }

        internal RTLBitArray(RTLSignalType type, string msbBitString, int size, bool fromCast)
        {
            FromBinaryString(type, msbBitString, size);
            _fromCast = fromCast;
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
