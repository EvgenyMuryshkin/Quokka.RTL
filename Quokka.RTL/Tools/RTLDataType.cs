using System.Text;

namespace Quokka.RTL.Tools
{
    public enum RTLDataType : byte
    {
        Unsigned,
        Signed,
        Floating,
        SignedIterator,
        UnsignedIterator,
        StdLogic
    }

    public enum RTLOrderType : byte
    {
        LBS,
        MSB
    }
}
