using System.Text;

namespace Quokka.RTL.Tools
{
    public enum RTLDataType : byte
    {
        Unsigned,
        Signed,
        Floating,
        SignedIterator,
        UnsignedIterator
    }

    public enum RTLOrderType : byte
    {
        LBS,
        MSB
    }

    public enum RTLSignalType
    {
        Auto,
        Signal,
        Bus
    }
}
