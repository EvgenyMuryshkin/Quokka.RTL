using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
public enum vlgAssignType
{
	Auto = 0,
	Equal = 1,
	Assign = 2,
	Blocking = 3,
	NonBlocking = 4,
}
public enum vlgCompareType
{
	Equal = 0,
	NotEqual = 1,
	Greater = 2,
	GreaterOrEqual = 3,
	Less = 4,
	LessOrEqual = 5,
}
public enum vlgDataType
{
	Unsigned = 0,
	Signed = 1,
	StdLogic = 2,
	StdLogicVector = 3,
}
public enum vlgEdgeType
{
	Pos = 0,
	Neg = 1,
}
public enum vlgLogicType
{
	And = 0,
	Or = 1,
	Xor = 2,
}
public enum vlgMathType
{
	Add = 0,
	Subtract = 1,
	Multiply = 2,
	Divide = 3,
	Remainder = 4,
}
public enum vlgNetType
{
	Auto = 0,
	Wire = 1,
	Reg = 2,
}
public enum vlgPortDirection
{
	Input = 0,
	Output = 1,
	Bidir = 2,
}
public enum vlgShiftType
{
	RightLogic = 0,
	RightArith = 1,
	Left = 2,
}
public enum vlgUnaryType
{
	Not = 0,
}
} // Quokka.RTL.Verilog
