﻿using Quokka.RTL.Tools;
using System;

namespace Quokka.RTL.VHDL
{
    public class vhdFormattersImplementation : vhdFormattersInterface
    {
        public string EdgeType(string signalName, vhdEdgeType type)
        {
            switch(type)
            {
                case vhdEdgeType.Rising: return "rising_edge";
                case vhdEdgeType.Falling: return "falling_edge";
                default: throw new Exception($"Edge type is not supported for '{signalName}': {type}");
            }
        }

        public string Range(int size)
        {
            if (size == 0)
                return null;

            return Range(size - 1, 0);
        }

        public string Range(int l, int r)
        {
            if (l == r)
                return null;

            if (l > r)
                return $"({l} downto {r})";
            else
                return $"({l} to {r})";
        }

        public string RTLBitArray(RTLBitArray value)
        {
            if (value == null || value.Size == 0)
                return null;

            if (value.Size == 1)
                return $"'{value.AsBinaryString()}'";
            else
                return $"\"{value.AsBinaryString()}\"";
        }

        public string DirectionType(string signalName, vhdPortDirection type)
        {
            switch (type)
            {
                case vhdPortDirection.Input: return "in";
                case vhdPortDirection.Output: return "out";
                case vhdPortDirection.Bidir: return "inout";
                default: throw new Exception($"Unsupported direction type (${signalName}): {type}");
            }
        }

        public string DataType(string signalName, RTLBitArray value)
        {
            if (value == null)
                return null;

            if (value.Size <= 1)
                return "std_logic";

            switch (value.DataType)
            {
                case RTLDataType.Signed: return "signed";
                case RTLDataType.Unsigned: return "unsigned";
                default: throw new Exception($"unsupported sign type ({signalName}): {value.DataType}");
            }
        }

        public string CastType(vhdCastType type)
        {
            switch (type)
            {
                case vhdCastType.Signed: return "signed";
                case vhdCastType.Unsigned: return "unsigned";
                case vhdCastType.Integer: return "to_integer";
                case vhdCastType.BitToInteger: return "bit_to_integer";
                default: throw new Exception($"unsupported sign type {type}");
            }

        }


        public string DataType(vhdDataType dataType)
        {
            switch (dataType)
            {
                case vhdDataType.Signed: return "signed";
                case vhdDataType.Unsigned: return "unsigned";
                case vhdDataType.StdLogic: return "std_logic";
                default: throw new Exception($"unsupported sign type {dataType}");
            }
        }

        public vhdSignalType SignalType(string signalName, int width, vhdDataTypeSource type)
        {
            switch (type)
            {
                case vhdDefaultDataType d:
                    if (d.DataType == vhdDataType.Boolean)
                        return vhdSignalType.Auto;

                    switch (d.DataType)
                    {
                        case vhdDataType.Signed:
                            {
                                if (width == 1)
                                    return vhdSignalType.Signal;

                                return vhdSignalType.Auto;
                            }
                        case vhdDataType.Unsigned:
                            {
                                if (width == 1)
                                    return vhdSignalType.Signal;

                                return vhdSignalType.Auto;
                            }
                        case vhdDataType.StdLogic:
                            {
                                switch (d.SignalType)
                                {
                                    case vhdSignalType.Auto:
                                        {
                                            if (width == 1)
                                                return vhdSignalType.Signal;

                                            return vhdSignalType.Bus;
                                        }
                                    default:
                                        return d.SignalType;
                                }
                            }
                        default: throw new Exception($"unsupported sign type ({signalName}): {d.DataType}");
                    }
                case vhdCustomDataType d:
                    return vhdSignalType.Auto;
                default:
                    throw new Exception($"unsupported data type ({signalName}): {type}");
            }
        }

        public string DataType(string signalName, int width, vhdDataTypeSource type)
        {
            switch (type)
            {
                case vhdDefaultDataType d:
                    if (d.DataType == vhdDataType.Boolean)
                        return "boolean";

                    var signalType = SignalType(signalName, width, type);
                    switch (signalType)
                    {
                        case vhdSignalType.Signal: return "std_logic";
                        case vhdSignalType.Bus: return "std_logic_vector";
                    }

                    switch (d.DataType)
                    {
                        case vhdDataType.Signed: return "signed";
                        case vhdDataType.Unsigned: return "unsigned";
                        case vhdDataType.StdLogic:
                            {
                                throw new Exception($"Signal type was not resolved for '{signalName}'");
                            }
                        default: throw new Exception($"unsupported sign type ({signalName}): {d.DataType}");
                    }
                case vhdCustomDataType d:
                    return d.DataType;
                default:
                    throw new Exception($"unsupported data type ({signalName}): {type}");
            }

        }

        public string NetType(string signalName, vhdNetTypeSource type)
        {
            switch (type)
            {
                case vhdDefaultNetType d:
                {
                    switch (d.NetType)
                    {
                        case vhdNetType.Constant: return "constant";
                        case vhdNetType.Signal: return "signal";
                        case vhdNetType.Variable: return "variable";
                        case vhdNetType.SharedVariable: return "shared variable";
                        default: throw new Exception($"unsupported net type for signal {signalName}: {d.NetType}");
                    }
                }
                case vhdCustomNetType c:
                    return c.NetType;
                default:
                    throw new Exception($"unsupported net type source for signal {signalName}: {type}");
            }
        }

    }
}
