using Quokka.RTL.Tools;
using Quokka.RTL.Verilog;
using Quokka.RTL.VHDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL
{
    public interface IRTLSignalInfoProvider
    {
        RTLSignalInfo Of(vhdIdentifier source);
        RTLSignalInfo Of(vlgIdentifier source);
    }

    public interface IRTLClonable
    {
        object Clone();
    }

    public interface IRTLComparable
    {
        bool IsEqual(object rhs);
    }
}
