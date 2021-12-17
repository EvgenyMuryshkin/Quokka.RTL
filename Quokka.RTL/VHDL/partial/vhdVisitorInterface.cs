using Quokka.RTL.Tools;

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
        string DataType(string signalName, RTLBitArray value);
        string NetType(string signalName, vhdNetTypeSource type);
        /*
        string EdgeType(string signalName, vlgEdgeType edgeType);
        string DirectionType(string signalName, vlgPortDirection type);
        */
        string Range(int l, int r);
        string Range(int size);

    }
}
