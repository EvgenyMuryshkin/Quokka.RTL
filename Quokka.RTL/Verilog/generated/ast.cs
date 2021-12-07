using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
public abstract partial class vlgAbstractCollection : vlgAbstractObject
{
	public vlgAbstractCollection() { }
	/// <summary>
	/// vlgAssign
	/// vlgAssignExpression
	/// vlgAttribute
	/// vlgBinaryValueExpression
	/// vlgCase
	/// vlgCombBlock
	/// vlgComment
	/// vlgCompareExpression
	/// vlgConditionalStatement
	/// vlgCustomDeclaration
	/// vlgCustomModulePortDeclaration
	/// vlgFile
	/// vlgForLoop
	/// vlgGenerate
	/// vlgGenericBlock
	/// vlgGenvar
	/// vlgIdentifier
	/// vlgIdentifierExpression
	/// vlgIf
	/// vlgInitial
	/// vlgIterator
	/// vlgLocalParamNameBinaryValue
	/// vlgLocalParamNameExplicitValue
	/// vlgLogicExpression
	/// vlgLogicSignal
	/// vlgMathExpression
	/// vlgMemoryBlock
	/// vlgModule
	/// vlgModuleImplementation
	/// vlgModuleImplementationBlock
	/// vlgModuleInstance
	/// vlgModuleInstanceNamedPortMapping
	/// vlgModuleInstanceParameter
	/// vlgModuleInstanceParameters
	/// vlgModuleInstancePortMappings
	/// vlgModuleInstanceSimplePortMapping
	/// vlgModuleInterface
	/// vlgModuleParameterDeclaration
	/// vlgModuleParameters
	/// vlgPlaceholderModulePort
	/// vlgProcedureCall
	/// vlgRange
	/// vlgShiftExpression
	/// vlgSimpleForLoop
	/// vlgStandardModulePortDeclaration
	/// vlgStandardModulePortImplementation
	/// vlgSyncBlock
	/// vlgSyncBlockSensitivityItem
	/// vlgTernaryExpression
	/// vlgText
	/// vlgUnaryExpression
	/// </summary>
	public List<vlgAbstractObject> Children { get; set; } = new List<vlgAbstractObject>();
}
public abstract partial class vlgAbstractForLoop : vlgAbstractCollection
{
	public vlgAbstractForLoop() { }
	public String Name { get; set; }
}
public abstract partial class vlgAbstractObject
{
	public vlgAbstractObject() { }
}
public partial class vlgAssign : vlgAbstractObject
{
	public vlgAssign() { }
	public vlgAssign(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Expression = new vlgAssignExpression(Target, Type, Expression);
	}
	public vlgAssign(vlgAssignExpression Expression)
	{
		this.Expression = Expression;
	}
	public vlgAssignExpression Expression { get; set; } = new vlgAssignExpression();
}
public partial class vlgAssignExpression : vlgExpression
{
	public vlgAssignExpression() { }
	public vlgAssignExpression(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Target = Target;
		this.Type = Type;
		this.Expression = Expression;
	}
	public vlgIdentifier Target { get; set; } = new vlgIdentifier();
	public vlgAssignType Type { get; set; }
	public vlgExpression Expression { get; set; }
}
public partial class vlgAttribute : vlgAbstractObject
{
	public vlgAttribute() { }
	public vlgAttribute(String Name, String Value)
	{
		this.Name = Name;
		this.Value = Value;
	}
	public String Name { get; set; }
	public String Value { get; set; }
}
public partial class vlgBinaryValueExpression : vlgExpression, vlgICaseStatement
{
	public vlgBinaryValueExpression() { }
	public vlgBinaryValueExpression(RTLBitArray Value)
	{
		this.Value = Value;
	}
	public RTLBitArray Value { get; set; } = new RTLBitArray();
}
public abstract partial class vlgBlock : vlgAbstractCollection
{
	public vlgBlock() { }
}
public partial class vlgCase : vlgAbstractObject
{
	public vlgCase() { }
	public vlgCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Check = Check;
		this.Statements = Statements?.ToList() ?? new List<vlgCaseStatement>();
	}
	public vlgCase(vlgExpression Check)
	{
		this.Check = Check;
	}
	// from vlgAssignExpression
	public vlgCase(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Check = new vlgAssignExpression(Target, Type, Expression);
	}
	// from vlgBinaryValueExpression
	public vlgCase(RTLBitArray Value)
	{
		this.Check = new vlgBinaryValueExpression(Value);
	}
	// from vlgCompareExpression
	public vlgCase(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.Check = new vlgCompareExpression(Lhs, Type, Rhs);
	}
	// from vlgIdentifierExpression
	public vlgCase(vlgIdentifier Source)
	{
		this.Check = new vlgIdentifierExpression(Source);
	}
	// from vlgLogicExpression
	public vlgCase(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.Check = new vlgLogicExpression(Lhs, Type, Rhs);
	}
	// from vlgMathExpression
	public vlgCase(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.Check = new vlgMathExpression(Lhs, Type, Rhs);
	}
	// from vlgShiftExpression
	public vlgCase(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.Check = new vlgShiftExpression(Lhs, Type, Rhs);
	}
	// from vlgTernaryExpression
	public vlgCase(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	{
		this.Check = new vlgTernaryExpression(Condition, Lhs, Rhs);
	}
	// from vlgUnaryExpression
	public vlgCase(vlgUnaryType Type, vlgExpression Rhs)
	{
		this.Check = new vlgUnaryExpression(Type, Rhs);
	}
	public vlgExpression Check { get; set; }
	public List<vlgCaseStatement> Statements { get; set; } = new List<vlgCaseStatement>();
	public vlgCaseDefault Default { get; set; } = new vlgCaseDefault();
}
public partial class vlgCaseDefault : vlgCaseItem
{
	public vlgCaseDefault() { }
}
public abstract partial class vlgCaseItem
{
	public vlgCaseItem() { }
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
public partial class vlgCaseStatement : vlgCaseItem
{
	public vlgCaseStatement() { }
	public vlgCaseStatement(params vlgICaseStatement[] Conditions)
	{
		this.Conditions = Conditions?.ToList() ?? new List<vlgICaseStatement>();
	}
	/// <summary>
	/// vlgBinaryValueExpression
	/// vlgIdentifierExpression
	/// </summary>
	public List<vlgICaseStatement> Conditions { get; set; } = new List<vlgICaseStatement>();
}
public partial class vlgCombBlock : vlgAbstractObject
{
	public vlgCombBlock() { }
	public vlgCombBlock(params vlgIdentifier[] SensitivityList)
	{
		this.SensitivityList = SensitivityList?.ToList() ?? new List<vlgIdentifier>();
	}
	public List<vlgIdentifier> SensitivityList { get; set; } = new List<vlgIdentifier>();
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
public partial class vlgComment : vlgAbstractObject
{
	public vlgComment() { }
	public vlgComment(params String[] Lines)
	{
		this.Lines = Lines?.ToList() ?? new List<String>();
	}
	public List<String> Lines { get; set; } = new List<String>();
}
public partial class vlgCompareExpression : vlgExpression
{
	public vlgCompareExpression() { }
	public vlgCompareExpression(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.Lhs = Lhs;
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vlgExpression Lhs { get; set; }
	public vlgCompareType Type { get; set; }
	public vlgExpression Rhs { get; set; }
}
public partial class vlgConditionalStatement : vlgAbstractObject
{
	public vlgConditionalStatement() { }
	public vlgConditionalStatement(vlgExpression Condition)
	{
		this.Condition = Condition;
	}
	// from vlgAssignExpression
	public vlgConditionalStatement(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Condition = new vlgAssignExpression(Target, Type, Expression);
	}
	// from vlgBinaryValueExpression
	public vlgConditionalStatement(RTLBitArray Value)
	{
		this.Condition = new vlgBinaryValueExpression(Value);
	}
	// from vlgCompareExpression
	public vlgConditionalStatement(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgCompareExpression(Lhs, Type, Rhs);
	}
	// from vlgIdentifierExpression
	public vlgConditionalStatement(vlgIdentifier Source)
	{
		this.Condition = new vlgIdentifierExpression(Source);
	}
	// from vlgLogicExpression
	public vlgConditionalStatement(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgLogicExpression(Lhs, Type, Rhs);
	}
	// from vlgMathExpression
	public vlgConditionalStatement(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgMathExpression(Lhs, Type, Rhs);
	}
	// from vlgShiftExpression
	public vlgConditionalStatement(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgShiftExpression(Lhs, Type, Rhs);
	}
	// from vlgTernaryExpression
	public vlgConditionalStatement(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	{
		this.Condition = new vlgTernaryExpression(Condition, Lhs, Rhs);
	}
	// from vlgUnaryExpression
	public vlgConditionalStatement(vlgUnaryType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgUnaryExpression(Type, Rhs);
	}
	public vlgExpression Condition { get; set; }
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
public partial class vlgCustomDeclaration : vlgAbstractObject
{
	public vlgCustomDeclaration() { }
	public vlgCustomDeclaration(String Type, String Name, String Initializer)
	{
		this.Type = Type;
		this.Name = Name;
		this.Initializer = Initializer;
	}
	public String Type { get; set; }
	public String Name { get; set; }
	public String Initializer { get; set; }
}
public partial class vlgCustomModulePortDeclaration : vlgDeclarationModulePort
{
	public vlgCustomModulePortDeclaration() { }
	public vlgCustomModulePortDeclaration(vlgPortDirection Direction, vlgNetType NetType, String DataType, String Name)
	{
		this.Direction = Direction;
		this.NetType = NetType;
		this.DataType = DataType;
		this.Name = Name;
	}
	public String DataType { get; set; }
	public String Name { get; set; }
}
public abstract partial class vlgDeclarationModulePort : vlgModulePort
{
	public vlgDeclarationModulePort() { }
	public vlgDeclarationModulePort(vlgPortDirection Direction, vlgNetType NetType)
	{
		this.Direction = Direction;
		this.NetType = NetType;
	}
	public vlgPortDirection Direction { get; set; }
	public vlgNetType NetType { get; set; }
}
public abstract partial class vlgExpression : vlgAbstractObject
{
	public vlgExpression() { }
}
public partial class vlgFile : vlgAbstractCollection
{
	public vlgFile() { }
}
public partial class vlgForLoop : vlgAbstractForLoop
{
	public vlgForLoop() { }
	public vlgForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Initializer = Initializer;
		this.Condition = Condition;
		this.Increment = Increment;
	}
	public vlgExpression Initializer { get; set; }
	public vlgExpression Condition { get; set; }
	public vlgExpression Increment { get; set; }
}
public partial class vlgGenerate : vlgAbstractObject
{
	public vlgGenerate() { }
	public vlgGenerate(vlgGenericBlock Block)
	{
		this.Block = Block;
	}
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
public partial class vlgGenericBlock : vlgBlock
{
	public vlgGenericBlock() { }
}
public partial class vlgGenvar : vlgAbstractObject
{
	public vlgGenvar() { }
	public vlgGenvar(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vlgIdentifier : vlgAbstractObject
{
	public vlgIdentifier() { }
	public vlgIdentifier(String Name, params vlgRange[] Indexes)
	{
		this.Name = Name;
		this.Indexes = Indexes?.ToList() ?? new List<vlgRange>();
	}
	public vlgIdentifier(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
	public List<vlgRange> Indexes { get; set; } = new List<vlgRange>();
}
public partial class vlgIdentifierExpression : vlgExpression, vlgICaseStatement
{
	public vlgIdentifierExpression() { }
	public vlgIdentifierExpression(String Name, params vlgRange[] Indexes)
	{
		this.Source = new vlgIdentifier(Name, Indexes);
	}
	public vlgIdentifierExpression(String Name)
	{
		this.Source = new vlgIdentifier(Name);
	}
	public vlgIdentifierExpression(vlgIdentifier Source)
	{
		this.Source = Source;
	}
	public vlgIdentifier Source { get; set; } = new vlgIdentifier();
}
public partial class vlgIf : vlgAbstractObject
{
	public vlgIf() { }
	public List<vlgConditionalStatement> Statements { get; set; } = new List<vlgConditionalStatement>();
}
public partial class vlgInitial : vlgAbstractCollection
{
	public vlgInitial() { }
	public vlgInitial(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vlgIterator : vlgAbstractObject
{
	public vlgIterator() { }
	public vlgIterator(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public abstract partial class vlgLocalParam : vlgAbstractObject
{
	public vlgLocalParam() { }
}
public abstract partial class vlgLocalParamName : vlgLocalParam
{
	public vlgLocalParamName() { }
	public vlgLocalParamName(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vlgLocalParamNameBinaryValue : vlgLocalParamName
{
	public vlgLocalParamNameBinaryValue() { }
	public vlgLocalParamNameBinaryValue(String Name, RTLBitArray Value)
	{
		this.Name = Name;
		this.Value = Value;
	}
	public RTLBitArray Value { get; set; } = new RTLBitArray();
}
public partial class vlgLocalParamNameExplicitValue : vlgLocalParamName
{
	public vlgLocalParamNameExplicitValue() { }
	public vlgLocalParamNameExplicitValue(String Name, String Value)
	{
		this.Name = Name;
		this.Value = Value;
	}
	public String Value { get; set; }
}
public partial class vlgLogicExpression : vlgExpression
{
	public vlgLogicExpression() { }
	public vlgLogicExpression(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.Lhs = Lhs;
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vlgExpression Lhs { get; set; }
	public vlgLogicType Type { get; set; }
	public vlgExpression Rhs { get; set; }
}
public partial class vlgLogicSignal : vlgSignal
{
	public vlgLogicSignal() { }
	public vlgLogicSignal(vlgNetType NetType, vlgSignType Sign, String Name, Int32 Width, String Initializer)
	{
		this.NetType = NetType;
		this.Sign = Sign;
		this.Name = Name;
		this.Width = Width;
		this.Initializer = Initializer;
	}
	public vlgNetType NetType { get; set; }
	public vlgSignType Sign { get; set; }
	public String Name { get; set; }
	public Int32 Width { get; set; }
	public String Initializer { get; set; }
}
public partial class vlgMathExpression : vlgExpression
{
	public vlgMathExpression() { }
	public vlgMathExpression(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.Lhs = Lhs;
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vlgExpression Lhs { get; set; }
	public vlgMathType Type { get; set; }
	public vlgExpression Rhs { get; set; }
}
public partial class vlgMemoryBlock : vlgSignal
{
	public vlgMemoryBlock() { }
	public vlgMemoryBlock(String Name, vlgSignType Sign, Int32 Width, Int32 Depth)
	{
		this.Name = Name;
		this.Sign = Sign;
		this.Width = Width;
		this.Depth = Depth;
	}
	public String Name { get; set; }
	public vlgSignType Sign { get; set; }
	public Int32 Width { get; set; }
	public Int32 Depth { get; set; }
}
public partial class vlgModule : vlgAbstractObject
{
	public vlgModule() { }
	public vlgModule(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
	public vlgModuleParameters Parameters { get; set; } = new vlgModuleParameters();
	public vlgModuleInterface Interface { get; set; } = new vlgModuleInterface();
	public vlgModuleImplementation Implementation { get; set; } = new vlgModuleImplementation();
}
public partial class vlgModuleImplementation : vlgAbstractObject
{
	public vlgModuleImplementation() { }
	public vlgModuleImplementation(vlgModuleImplementationBlock Block)
	{
		this.Block = Block;
	}
	public vlgModuleImplementationBlock Block { get; set; } = new vlgModuleImplementationBlock();
}
public partial class vlgModuleImplementationBlock : vlgBlock
{
	public vlgModuleImplementationBlock() { }
}
public partial class vlgModuleInstance : vlgAbstractObject
{
	public vlgModuleInstance() { }
	public vlgModuleInstance(String Type, String Name)
	{
		this.Type = Type;
		this.Name = Name;
	}
	public String Type { get; set; }
	public String Name { get; set; }
	public vlgModuleInstanceParameters Parameters { get; set; } = new vlgModuleInstanceParameters();
	public vlgModuleInstancePortMappings PortMappings { get; set; } = new vlgModuleInstancePortMappings();
}
public partial class vlgModuleInstanceNamedPortMapping : vlgModuleInstancePortMapping
{
	public vlgModuleInstanceNamedPortMapping() { }
	public vlgModuleInstanceNamedPortMapping(String Internal, vlgExpression External)
	{
		this.Internal = Internal;
		this.External = External;
	}
	public String Internal { get; set; }
	public vlgExpression External { get; set; }
}
public partial class vlgModuleInstanceParameter : vlgAbstractObject
{
	public vlgModuleInstanceParameter() { }
	public vlgModuleInstanceParameter(String Name, String Value)
	{
		this.Name = Name;
		this.Value = Value;
	}
	public String Name { get; set; }
	public String Value { get; set; }
}
public partial class vlgModuleInstanceParameters : vlgAbstractCollection
{
	public vlgModuleInstanceParameters() { }
}
public abstract partial class vlgModuleInstancePortMapping : vlgAbstractObject
{
	public vlgModuleInstancePortMapping() { }
}
public partial class vlgModuleInstancePortMappings : vlgAbstractCollection
{
	public vlgModuleInstancePortMappings() { }
}
public partial class vlgModuleInstanceSimplePortMapping : vlgModuleInstancePortMapping
{
	public vlgModuleInstanceSimplePortMapping() { }
	public vlgModuleInstanceSimplePortMapping(vlgExpression External)
	{
		this.External = External;
	}
	// from vlgAssignExpression
	public vlgModuleInstanceSimplePortMapping(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.External = new vlgAssignExpression(Target, Type, Expression);
	}
	// from vlgBinaryValueExpression
	public vlgModuleInstanceSimplePortMapping(RTLBitArray Value)
	{
		this.External = new vlgBinaryValueExpression(Value);
	}
	// from vlgCompareExpression
	public vlgModuleInstanceSimplePortMapping(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.External = new vlgCompareExpression(Lhs, Type, Rhs);
	}
	// from vlgIdentifierExpression
	public vlgModuleInstanceSimplePortMapping(vlgIdentifier Source)
	{
		this.External = new vlgIdentifierExpression(Source);
	}
	// from vlgLogicExpression
	public vlgModuleInstanceSimplePortMapping(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.External = new vlgLogicExpression(Lhs, Type, Rhs);
	}
	// from vlgMathExpression
	public vlgModuleInstanceSimplePortMapping(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.External = new vlgMathExpression(Lhs, Type, Rhs);
	}
	// from vlgShiftExpression
	public vlgModuleInstanceSimplePortMapping(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.External = new vlgShiftExpression(Lhs, Type, Rhs);
	}
	// from vlgTernaryExpression
	public vlgModuleInstanceSimplePortMapping(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	{
		this.External = new vlgTernaryExpression(Condition, Lhs, Rhs);
	}
	// from vlgUnaryExpression
	public vlgModuleInstanceSimplePortMapping(vlgUnaryType Type, vlgExpression Rhs)
	{
		this.External = new vlgUnaryExpression(Type, Rhs);
	}
	public vlgExpression External { get; set; }
}
public partial class vlgModuleInterface : vlgAbstractCollection
{
	public vlgModuleInterface() { }
}
public partial class vlgModuleParameterDeclaration : vlgAbstractObject
{
	public vlgModuleParameterDeclaration() { }
	public vlgModuleParameterDeclaration(String Name, Int32 Width, RTLBitArray DefaultValue)
	{
		this.Name = Name;
		this.Width = Width;
		this.DefaultValue = DefaultValue;
	}
	public String Name { get; set; }
	public Int32 Width { get; set; }
	public RTLBitArray DefaultValue { get; set; } = new RTLBitArray();
}
public partial class vlgModuleParameters : vlgAbstractCollection
{
	public vlgModuleParameters() { }
}
public abstract partial class vlgModulePort : vlgAbstractObject
{
	public vlgModulePort() { }
}
public partial class vlgPlaceholderModulePort : vlgModulePort
{
	public vlgPlaceholderModulePort() { }
	public vlgPlaceholderModulePort(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vlgProcedureCall : vlgAbstractObject
{
	public vlgProcedureCall() { }
	public vlgProcedureCall(String Proc, String Name, params vlgExpression[] Parameters)
	{
		this.Proc = Proc;
		this.Name = Name;
		this.Parameters = Parameters?.ToList() ?? new List<vlgExpression>();
	}
	public vlgProcedureCall(String Proc, String Name)
	{
		this.Proc = Proc;
		this.Name = Name;
	}
	public String Proc { get; set; }
	public String Name { get; set; }
	/// <summary>
	/// vlgAssignExpression
	/// vlgBinaryValueExpression
	/// vlgCompareExpression
	/// vlgIdentifierExpression
	/// vlgLogicExpression
	/// vlgMathExpression
	/// vlgShiftExpression
	/// vlgTernaryExpression
	/// vlgUnaryExpression
	/// </summary>
	public List<vlgExpression> Parameters { get; set; } = new List<vlgExpression>();
}
public partial class vlgRange : vlgAbstractObject
{
	public vlgRange() { }
	public vlgRange(params vlgExpression[] Indexes)
	{
		this.Indexes = Indexes?.ToList() ?? new List<vlgExpression>();
	}
	/// <summary>
	/// vlgAssignExpression
	/// vlgBinaryValueExpression
	/// vlgCompareExpression
	/// vlgIdentifierExpression
	/// vlgLogicExpression
	/// vlgMathExpression
	/// vlgShiftExpression
	/// vlgTernaryExpression
	/// vlgUnaryExpression
	/// </summary>
	public List<vlgExpression> Indexes { get; set; } = new List<vlgExpression>();
}
public partial class vlgShiftExpression : vlgExpression
{
	public vlgShiftExpression() { }
	public vlgShiftExpression(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.Lhs = Lhs;
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vlgExpression Lhs { get; set; }
	public vlgShiftType Type { get; set; }
	public vlgExpression Rhs { get; set; }
}
public abstract partial class vlgSignal : vlgAbstractObject
{
	public vlgSignal() { }
}
public partial class vlgSimpleForLoop : vlgAbstractForLoop
{
	public vlgSimpleForLoop() { }
	public vlgSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Iterator = Iterator;
		this.From = From;
		this.To = To;
	}
	public String Iterator { get; set; }
	public Int32 From { get; set; }
	public Int32 To { get; set; }
}
public abstract partial class vlgStandardModulePort : vlgDeclarationModulePort
{
	public vlgStandardModulePort() { }
	public vlgStandardModulePort(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Direction = Direction;
		this.NetType = NetType;
		this.Sign = Sign;
		this.Width = Width;
		this.Name = Name;
	}
	public vlgSignType Sign { get; set; }
	public Int32 Width { get; set; }
	public String Name { get; set; }
}
public partial class vlgStandardModulePortDeclaration : vlgStandardModulePort
{
	public vlgStandardModulePortDeclaration() { }
	public vlgStandardModulePortDeclaration(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Direction = Direction;
		this.NetType = NetType;
		this.Sign = Sign;
		this.Width = Width;
		this.Name = Name;
	}
}
public partial class vlgStandardModulePortImplementation : vlgStandardModulePort
{
	public vlgStandardModulePortImplementation() { }
	public vlgStandardModulePortImplementation(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Direction = Direction;
		this.NetType = NetType;
		this.Sign = Sign;
		this.Width = Width;
		this.Name = Name;
	}
}
public partial class vlgSyncBlock : vlgAbstractObject
{
	public vlgSyncBlock() { }
	public vlgSyncBlock(params vlgSyncBlockSensitivityItem[] SensitivityList)
	{
		this.SensitivityList = SensitivityList?.ToList() ?? new List<vlgSyncBlockSensitivityItem>();
	}
	public List<vlgSyncBlockSensitivityItem> SensitivityList { get; set; } = new List<vlgSyncBlockSensitivityItem>();
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
public partial class vlgSyncBlockSensitivityItem : vlgAbstractObject
{
	public vlgSyncBlockSensitivityItem() { }
	public vlgSyncBlockSensitivityItem(vlgEdgeType Edge, vlgIdentifier Identifier)
	{
		this.Edge = Edge;
		this.Identifier = Identifier;
	}
	public vlgEdgeType Edge { get; set; }
	public vlgIdentifier Identifier { get; set; } = new vlgIdentifier();
}
public partial class vlgTernaryExpression : vlgExpression
{
	public vlgTernaryExpression() { }
	public vlgTernaryExpression(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	{
		this.Condition = Condition;
		this.Lhs = Lhs;
		this.Rhs = Rhs;
	}
	public vlgExpression Condition { get; set; }
	public vlgExpression Lhs { get; set; }
	public vlgExpression Rhs { get; set; }
}
public partial class vlgText : vlgAbstractObject
{
	public vlgText() { }
	public vlgText(params String[] Lines)
	{
		this.Lines = Lines?.ToList() ?? new List<String>();
	}
	public List<String> Lines { get; set; } = new List<String>();
}
public partial class vlgUnaryExpression : vlgExpression
{
	public vlgUnaryExpression() { }
	public vlgUnaryExpression(vlgUnaryType Type, vlgExpression Rhs)
	{
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vlgUnaryType Type { get; set; }
	public vlgExpression Rhs { get; set; }
}
} // Quokka.RTL.Verilog
