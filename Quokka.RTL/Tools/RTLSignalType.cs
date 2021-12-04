using System.Text;

namespace Quokka.RTL.Tools
{
    public enum RTLSignalType : byte
    {
        Unsigned,
        Signed,
        Floating,
        Iterator
    }

    public enum RTLOrderType : byte
    {
        LBS,
        MSB
    }
}
