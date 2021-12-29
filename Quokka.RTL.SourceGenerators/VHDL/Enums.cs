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

    public enum vhdCastType
    {
        Unsigned,
        Signed,
        Integer
    }

    public enum vhdNetType
    {
        Constant,
        Signal,
        Variable,
        SharedVariable
    }

    public enum vhdEdgeType
    {
        Rising,
        Falling
    }

    public enum vhdUnaryType
    {
        Not
    }

    public enum vhdCompareType
    {
        Equal,
        NotEqual,
        Greater,
        GreaterOrEqual,
        Less,
        LessOrEqual
    }

    public enum vhdMathType
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Remainder
    }

    public enum vhdLogicType
    {
        And,
        Or,
        Xor
    }

    public enum vhdShiftType
    {
        Right,
        Left
    }

    public enum vhdPredefinedAttribute
    {
        BASE,
        LEFT,
        RIGHT,
        HIGH,
        LOW,
        ASCENDING,
        IMAGE,
        VALUE,
        POS,
        VAL,
        SUCC,
        PRED,
        LEFTOF,
        RIGHTOF,
        RANGE,
        REVERSE_RANGE,
        LENGTH,
        DELAYED,
        STABLE,
        QUIET,
        TRANSACTION,
        EVENT,
        ACTIVE,
        LAST_EVENT,
        LAST_ACTIVE,
        LAST_VALUE,
        DRIVING,
        DRIVING_VALUE,
        SIMPLE_NAME,
        INSTANCE_NAME,
    }

    public enum vhdAssignType
    {
        Signal,
        Variable
    }
}
