using System.Text;

namespace Quokka.RTL.Tools
{
    public enum RTLSignalType : byte
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
}
