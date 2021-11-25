using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public enum vlgSignType
    {
        Unsigned,
        Signed
    }

    public enum vlgAssignType
    {
        Auto,
        Equal,
        Assign,
        Blocking,
        NonBlocking
    }

    public enum vlgNetType
    {
        Auto,
        Wire,
        Reg
    }

    public enum vlgPortDirection
    {
        Input,
        Output,
        Bidir
    }

    public enum vlgUnaryType
    {
        Not
    }

    public enum vlgCompareType
    {
        Equal,
        NotEqual,
        Greater,
        GreaterOrEqual,
        Less,
        LessOrEqual
    }

    public enum vlgMathType
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Remainder
    }

    public enum vlgLogicType
    {
        And,
        Or,
        Xor
    }

    public enum vlgEdgeType
    {
        Pos,
        Neg
    }
}
