using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public enum vhdDataType
{
	Unsigned = 0,
	Signed = 1,
	StdLogic = 2,
}
public enum vhdNetType
{
	Constant = 0,
	Signal = 1,
	Variable = 2,
	SharedVariable = 3,
}
public enum vhdPortDirection
{
	Input = 0,
	Output = 1,
	Bidir = 2,
}
} // Quokka.RTL.VHDL
