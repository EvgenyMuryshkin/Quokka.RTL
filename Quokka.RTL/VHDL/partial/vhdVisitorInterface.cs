﻿using Quokka.RTL.Tools;

namespace Quokka.RTL.VHDL
{
    public interface vhdVisitorInterface
    {
        void Visit(object obj, IndentedStringBuilder builder);
    }

    public interface vhdVisitorInterface<T> : vhdVisitorInterface
        where T : class
    {
        void OnVisit(T obj);
    }

    public interface vhdVisitorFactoryInterface
    {
        vhdVisitorInterface Resolve(object obj);
    }

    public interface vhdFormattersInterface
    {
        string RTLBitArray(RTLBitArray value);
        string DirectionType(string signalName, vhdPortDirection type);
        string DataType(string signalName, int width, vhdDataTypeSource type);
        string CastType(vhdCastType type);
        string DataType(string signalName, RTLBitArray value);
        string DataType(vhdDataType dataType);
        string NetType(string signalName, vhdNetTypeSource type);
        string EdgeType(string signalName, vhdEdgeType type);
        /*
        string DirectionType(string signalName, vlgPortDirection type);
        */
        string Range(int l, int r, bool explicitRange = false);
        string Range(int size, bool explicitRange = false);
        bool IsBus(vhdDataTypeSource type);
        bool IsMemory(vhdNetTypeSource type);
    }
}
