using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public class RTLBitArrayInitType
    {
        internal enum InitType
        {
            LSB,
            MSB
        }
        InitType _initType;

        internal RTLBitArrayInitType(InitType initType)
        {
            _initType = initType;
        }

        public static RTLBitArrayInitType LSB = new RTLBitArrayInitType(InitType.LSB);
        public static RTLBitArrayInitType MSB = new RTLBitArrayInitType(InitType.MSB);
    }

    public partial class RTLBitArray
    {
        /// <summary>
        /// Empty constructor, defaults to unsigned bit
        /// </summary>
        public RTLBitArray()
        {
            internalInit(RTLDataType.Unsigned, false);
        }

        private RTLBitArray(params bool[] lsbBits)
        {
            internalInit(RTLDataType.Unsigned, lsbBits.ToArray());
        }

        public RTLBitArray(RTLBitArray source)
            : this(RTLBitArrayInitType.MSB, source)
        {

        }

        public RTLBitArray(RTLBitArrayInitType initType, params RTLBitArray[] sources)
        {
            if (sources.Length == 1)
            {
                var source = sources[0];
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
                var type = sources[0].DataType;

                var lsbSources = initType == RTLBitArrayInitType.LSB
                    ? sources
                    : sources.Reverse();

                var lsbBits = lsbSources
                    .SelectMany(source => source.LSB)
                    .ToArray();

                internalInit(type, lsbBits);
            }
        }

        public RTLBitArray(byte[] lsb) : this(RTLBitArrayInitType.LSB, lsb.Select(b => new RTLBitArray(b)).ToArray())
        {

        }

        public RTLBitArray(IEnumerable<bool> lsbBits)
        {
            internalInit(RTLDataType.Unsigned, lsbBits.ToArray());
        }

        public RTLBitArray(RTLBitArrayInitType initType, IEnumerable<bool> source)
        {
            var lsbBits = initType == RTLBitArrayInitType.LSB
                ? source
                : source.Reverse();

            internalInit(RTLDataType.Unsigned, lsbBits.ToArray());
        }

        public RTLBitArray(RTLDataType type, RTLBitArrayInitType initType, string bitString, int size)
        {
            FromBinaryString(
                type,
                initType == RTLBitArrayInitType.MSB
                    ? bitString
                    : string.Join("", bitString.Reverse()),
                size
            );
        }

        internal RTLBitArray(RTLDataType type, bool[] lsb, bool fromCast)
        {
            internalInitWithBuffer(type, lsb);
            _fromCast = fromCast;
        }

        internal RTLBitArray(RTLDataType type, RTLBitArrayInitType initType, string bitString, int size, bool fromCast)
        {
            FromBinaryString(
                type,
                initType == RTLBitArrayInitType.MSB
                    ? bitString
                    : string.Join("", bitString.Reverse()),
                size
            );

            _fromCast = fromCast;
        }

        public RTLBitArray(RTLDataType dataType, RTLBitArrayInitType initType, string bitString)
            : this(dataType, initType, bitString, bitString.Length)
        {
        }

        public RTLBitArray(RTLBitArrayInitType initType, string bitString) 
            : this(RTLDataType.Unsigned, initType, bitString, bitString.Length)
        {
        }
    }
}
