using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog
{
    public interface vlgVisitorInterface
    {
        void Visit(object obj, IndentedStringBuilder builder);
    }

    public interface vlgVisitorInterface<T> : vlgVisitorInterface
        where T : class
    {
        void OnVisit(T obj);
    }

    public interface vlgVisitorFactoryInterface
    {
        vlgVisitorInterface Resolve(object obj);
    }

    public interface vlgFormattersInterface
    {
        string RTLBitArray(RTLBitArray value);
        string EdgeType(string signalName, vlgEdgeType edgeType);
        string DirectionType(string signalName, vlgPortDirection type);
        string NetType(string signalName, vlgNetType type);
        string DataType(string signalName, vlgDataType dataType);
        bool IsBus(vlgDataType dataType);
    }
}
