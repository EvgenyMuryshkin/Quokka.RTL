using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public enum vhdPortDirection
    {
        Input,
        Output,
        Bidir
    }

    public enum vhdDataType
    {
        Unsigned,
        Signed,
        StdLogic
    }

    public enum vhdNetType
    {
        Constant,
        Signal,
        Variable,
        SharedVariable
    }
}
