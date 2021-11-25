using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL.Verilog
{
    public class vlgFormattersImplementation : vlgFormattersInterface
    {
        public string RTLBitArray(RTLBitArray value)
        {
            if (value == null)
                return null;

            return $"{value.Size}'b{value.AsBinaryString()}";
        }

        public string EdgeType(string signalName, vlgEdgeType edgeType)
        {
            switch (edgeType)
            {
                case vlgEdgeType.Pos: return "posedge";
                case vlgEdgeType.Neg: return "negedge";
                default: throw new Exception($"Unsupported edge type (${signalName}): {edgeType}");
            }
        }

        public string DirectionType(string signalName, vlgPortDirection type)
        {
            switch (type)
            {
                case vlgPortDirection.Input: return "input";
                case vlgPortDirection.Output: return "output";
                case vlgPortDirection.Bidir: return "inout";
                default: throw new Exception($"Unsupported direction type (${signalName}): {type}");
            }
        }
        public string NetType(string signalName, vlgNetType type)
        {
            switch (type)
            {
                case vlgNetType.Reg: return "reg";
                case vlgNetType.Wire: return "wire";
                default: throw new Exception($"Unsupported signal type (${signalName}): {type}");
            }
        }

        public string SignType(string signalName, vlgSignType sign)
        {
            switch (sign)
            {
                case vlgSignType.Signed: return "signed";
                case vlgSignType.Unsigned: return "";
                default: throw new Exception($"unsupported sign type ({signalName}): {sign}");
            }
        }
    }
}
