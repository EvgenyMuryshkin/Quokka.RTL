using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public enum vhdAssignType
{
	Signal = 0,
	Variable = 1,
}
public enum vhdCastType
{
	Unsigned = 0,
	Signed = 1,
	Integer = 2,
	BitToInteger = 3,
}
public enum vhdCompareType
{
	Equal = 0,
	NotEqual = 1,
	Greater = 2,
	GreaterOrEqual = 3,
	Less = 4,
	LessOrEqual = 5,
}
public enum vhdDataType
{
	Unsigned = 0,
	Signed = 1,
	Boolean = 2,
	StdLogic = 3,
	StdLogicVector = 4,
}
public enum vhdEdgeType
{
	Rising = 0,
	Falling = 1,
}
public enum vhdLogicType
{
	And = 0,
	Or = 1,
	Xor = 2,
}
public enum vhdMathType
{
	Add = 0,
	Subtract = 1,
	Multiply = 2,
	Divide = 3,
	Remainder = 4,
}
public enum vhdNetType
{
	Constant = 0,
	ConstantMemory = 1,
	Signal = 2,
	Variable = 3,
	SharedVariable = 4,
}
public enum vhdPortDirection
{
	Input = 0,
	Output = 1,
	Bidir = 2,
}
public enum vhdPredefinedAttribute
{
	BASE = 0,
	LEFT = 1,
	RIGHT = 2,
	HIGH = 3,
	LOW = 4,
	ASCENDING = 5,
	IMAGE = 6,
	VALUE = 7,
	POS = 8,
	VAL = 9,
	SUCC = 10,
	PRED = 11,
	LEFTOF = 12,
	RIGHTOF = 13,
	RANGE = 14,
	REVERSE_RANGE = 15,
	LENGTH = 16,
	DELAYED = 17,
	STABLE = 18,
	QUIET = 19,
	TRANSACTION = 20,
	EVENT = 21,
	ACTIVE = 22,
	LAST_EVENT = 23,
	LAST_ACTIVE = 24,
	LAST_VALUE = 25,
	DRIVING = 26,
	DRIVING_VALUE = 27,
	SIMPLE_NAME = 28,
	INSTANCE_NAME = 29,
}
public enum vhdShiftType
{
	Right = 0,
	Left = 1,
}
public enum vhdUnaryType
{
	Not = 0,
}
} // Quokka.RTL.VHDL
