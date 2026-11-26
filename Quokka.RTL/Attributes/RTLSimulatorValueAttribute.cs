using Quokka.RTL.Tools;
using System;

namespace Quokka.RTL
{
    public class RTLSimulatorValueAttribute : Attribute
    {
        public RTLSimulatorValueAttribute(string msbBits)
        {
            Value = new RTLBitArray(RTLBitArrayInitType.MSB, msbBits);
        }

        public RTLSimulatorValueAttribute(ulong value, int bits, RTLDataType dataType)
        {
            Value = new RTLBitArray(value).Resized(bits, dataType);
        }

        public RTLBitArray Value { get; set; }
    }
}
