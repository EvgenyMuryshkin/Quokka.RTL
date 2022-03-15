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
	/// vlgAggregateExpression
	///
	/// vlgAssign
	///
	/// vlgAssignExpression
	///
	/// vlgAttribute
	///
	/// vlgBinaryValueExpression
	///
	/// vlgCase
	///
	/// vlgCaseDefault
	///
	/// vlgCaseStatement
	///
	/// vlgCombBlock
	///
	/// vlgComment
	///
	/// vlgCompareExpression
	///
	/// vlgConditionalStatement
	///
	/// vlgCustomDeclaration
	///
	/// vlgCustomModulePortDeclaration
	///
	/// vlgFile
	///
	/// vlgForLoop
	///
	/// vlgGenerate
	///
	/// vlgGenericBlock
	///
	/// vlgGenvar
	///
	/// vlgIdentifier
	///
	/// vlgIdentifierExpression
	///
	/// vlgIf
	///
	/// vlgInitial
	///
	/// vlgIterator
	///
	/// vlgLocalParamNameBinaryValue
	///
	/// vlgLocalParamNameExplicitValue
	///
	/// vlgLogicExpression
	///
	/// vlgLogicSignal
	///
	/// vlgMathExpression
	///
	/// vlgMemoryBlock
	///
	/// vlgModule
	///
	/// vlgModuleImplementation
	///
	/// vlgModuleImplementationBlock
	///
	/// vlgModuleInstance
	///
	/// vlgModuleInstanceNamedPortMapping
	///
	/// vlgModuleInstanceParameter
	///
	/// vlgModuleInstanceParameters
	///
	/// vlgModuleInstancePortMappings
	///
	/// vlgModuleInstanceSimplePortMapping
	///
	/// vlgModuleInterface
	///
	/// vlgModuleParameterDeclaration
	///
	/// vlgModuleParameters
	///
	/// vlgPlaceholderModulePort
	///
	/// vlgProcedureCall
	///
	/// vlgRange
	///
	/// vlgShiftExpression
	///
	/// vlgSimpleForLoop
	///
	/// vlgSizedAggregateExpression
	///
	/// vlgStandardModulePortDeclaration
	///
	/// vlgStandardModulePortImplementation
	///
	/// vlgSyncBlock
	///
	/// vlgSyncBlockSensitivityItem
	///
	/// vlgTernaryExpression
	///
	/// vlgText
	///
	/// vlgUnaryExpression
	///
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
public partial class vlgAggregateExpression : vlgExpression
{
	public vlgAggregateExpression() { }
	public vlgAggregateExpression(IEnumerable<vlgExpression> Expressions)
	{
		this.Expressions = (Expressions ?? Enumerable.Empty<vlgExpression>()).Where(s => s != null).ToList();
	}
	// from vlgAggregateExpression
	// ignored vlgAggregateExpression(IEnumerable<vlgExpression> Expressions)
	/// <summary>
	/// from vlgAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Expression"></param>
	public vlgAggregateExpression(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Expressions.Add(new vlgAssignExpression(Target, Type, Expression));
	}
	/// <summary>
	/// from vlgBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vlgAggregateExpression(RTLBitArray Value)
	{
		this.Expressions.Add(new vlgBinaryValueExpression(Value));
	}
	/// <summary>
	/// from vlgCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgAggregateExpression(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.Expressions.Add(new vlgCompareExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vlgIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vlgAggregateExpression(vlgIdentifier Source)
	{
		this.Expressions.Add(new vlgIdentifierExpression(Source));
	}
	/// <summary>
	/// from vlgLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgAggregateExpression(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.Expressions.Add(new vlgLogicExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vlgMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgAggregateExpression(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.Expressions.Add(new vlgMathExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vlgShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgAggregateExpression(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.Expressions.Add(new vlgShiftExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	/// <param name="Expressions"></param>
	public vlgAggregateExpression(Int32 Size, IEnumerable<vlgExpression> Expressions)
	{
		this.Expressions.Add(new vlgSizedAggregateExpression(Size, Expressions));
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	public vlgAggregateExpression(Int32 Size)
	{
		this.Expressions.Add(new vlgSizedAggregateExpression(Size));
	}
	// from vlgTernaryExpression
	// ignored vlgAggregateExpression(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	/// <summary>
	/// from vlgUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgAggregateExpression(vlgUnaryType Type, vlgExpression Rhs)
	{
		this.Expressions.Add(new vlgUnaryExpression(Type, Rhs));
	}
	/// <summary>
	/// vlgAggregateExpression
	///
	/// vlgAssignExpression
	///
	/// vlgBinaryValueExpression
	///
	/// vlgCompareExpression
	///
	/// vlgIdentifierExpression
	///
	/// vlgLogicExpression
	///
	/// vlgMathExpression
	///
	/// vlgShiftExpression
	///
	/// vlgSizedAggregateExpression
	///
	/// vlgTernaryExpression
	///
	/// vlgUnaryExpression
	///
	/// </summary>
	public List<vlgExpression> Expressions { get; set; } = new List<vlgExpression>();
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
	public vlgCase(vlgExpression Check, IEnumerable<vlgCaseStatement> Statements)
	{
		this.Check = Check;
		this.Statements = (Statements ?? Enumerable.Empty<vlgCaseStatement>()).Where(s => s != null).ToList();
	}
	public vlgCase(vlgExpression Check)
	{
		this.Check = Check;
	}
	/// <summary>
	/// from vlgAggregateExpression
	/// </summary>
	/// <param name="Expressions"></param>
	public vlgCase(IEnumerable<vlgExpression> Expressions)
	{
		this.Check = new vlgAggregateExpression(Expressions);
	}
	/// <summary>
	/// from vlgAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Expression"></param>
	public vlgCase(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Check = new vlgAssignExpression(Target, Type, Expression);
	}
	/// <summary>
	/// from vlgBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vlgCase(RTLBitArray Value)
	{
		this.Check = new vlgBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vlgCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgCase(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.Check = new vlgCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vlgCase(vlgIdentifier Source)
	{
		this.Check = new vlgIdentifierExpression(Source);
	}
	/// <summary>
	/// from vlgLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgCase(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.Check = new vlgLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgCase(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.Check = new vlgMathExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgCase(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.Check = new vlgShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	/// <param name="Expressions"></param>
	public vlgCase(Int32 Size, IEnumerable<vlgExpression> Expressions)
	{
		this.Check = new vlgSizedAggregateExpression(Size, Expressions);
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	public vlgCase(Int32 Size)
	{
		this.Check = new vlgSizedAggregateExpression(Size);
	}
	/// <summary>
	/// from vlgTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vlgCase(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	{
		this.Check = new vlgTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vlgUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
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
public abstract partial class vlgCaseItem : vlgAbstractObject
{
	public vlgCaseItem() { }
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
public partial class vlgCaseStatement : vlgCaseItem
{
	public vlgCaseStatement() { }
	public vlgCaseStatement(IEnumerable<vlgICaseStatement> Conditions)
	{
		this.Conditions = (Conditions ?? Enumerable.Empty<vlgICaseStatement>()).Where(s => s != null).ToList();
	}
	/// <summary>
	/// from vlgBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vlgCaseStatement(RTLBitArray Value)
	{
		this.Conditions.Add(new vlgBinaryValueExpression(Value));
	}
	/// <summary>
	/// from vlgIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vlgCaseStatement(vlgIdentifier Source)
	{
		this.Conditions.Add(new vlgIdentifierExpression(Source));
	}
	/// <summary>
	/// vlgBinaryValueExpression
	///
	/// vlgIdentifierExpression
	///
	/// </summary>
	public List<vlgICaseStatement> Conditions { get; set; } = new List<vlgICaseStatement>();
}
public partial class vlgCombBlock : vlgAbstractObject
{
	public vlgCombBlock() { }
	public vlgCombBlock(IEnumerable<vlgIdentifier> SensitivityList)
	{
		this.SensitivityList = (SensitivityList ?? Enumerable.Empty<vlgIdentifier>()).Where(s => s != null).ToList();
	}
	/// <summary>
	/// from vlgIdentifier
	/// </summary>
	/// <param name="Name"></param>
	/// <param name="Indexes"></param>
	public vlgCombBlock(String Name, IEnumerable<vlgRange> Indexes)
	{
		this.SensitivityList.Add(new vlgIdentifier(Name, Indexes));
	}
	/// <summary>
	/// from vlgIdentifier
	/// </summary>
	/// <param name="Name"></param>
	public vlgCombBlock(String Name)
	{
		this.SensitivityList.Add(new vlgIdentifier(Name));
	}
	public List<vlgIdentifier> SensitivityList { get; set; } = new List<vlgIdentifier>();
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
public partial class vlgComment : vlgAbstractObject
{
	public vlgComment() { }
	public vlgComment(IEnumerable<String> Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
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
	/// <summary>
	/// from vlgAggregateExpression
	/// </summary>
	/// <param name="Expressions"></param>
	public vlgConditionalStatement(IEnumerable<vlgExpression> Expressions)
	{
		this.Condition = new vlgAggregateExpression(Expressions);
	}
	/// <summary>
	/// from vlgAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Expression"></param>
	public vlgConditionalStatement(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Condition = new vlgAssignExpression(Target, Type, Expression);
	}
	/// <summary>
	/// from vlgBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vlgConditionalStatement(RTLBitArray Value)
	{
		this.Condition = new vlgBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vlgCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgConditionalStatement(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vlgConditionalStatement(vlgIdentifier Source)
	{
		this.Condition = new vlgIdentifierExpression(Source);
	}
	/// <summary>
	/// from vlgLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgConditionalStatement(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgConditionalStatement(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgMathExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgConditionalStatement(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.Condition = new vlgShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	/// <param name="Expressions"></param>
	public vlgConditionalStatement(Int32 Size, IEnumerable<vlgExpression> Expressions)
	{
		this.Condition = new vlgSizedAggregateExpression(Size, Expressions);
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	public vlgConditionalStatement(Int32 Size)
	{
		this.Condition = new vlgSizedAggregateExpression(Size);
	}
	/// <summary>
	/// from vlgTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vlgConditionalStatement(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	{
		this.Condition = new vlgTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vlgUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
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
	public vlgIdentifier(String Name, IEnumerable<vlgRange> Indexes)
	{
		this.Name = Name;
		this.Indexes = (Indexes ?? Enumerable.Empty<vlgRange>()).Where(s => s != null).ToList();
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
	public vlgIdentifierExpression(String Name, IEnumerable<vlgRange> Indexes)
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
	public vlgMemoryBlock(vlgNetType NetType, String Name, vlgSignType Sign, Int32 Width, Int32 Depth)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.Sign = Sign;
		this.Width = Width;
		this.Depth = Depth;
	}
	public vlgNetType NetType { get; set; }
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
	/// <summary>
	/// from vlgAggregateExpression
	/// </summary>
	/// <param name="Expressions"></param>
	public vlgModuleInstanceSimplePortMapping(IEnumerable<vlgExpression> Expressions)
	{
		this.External = new vlgAggregateExpression(Expressions);
	}
	/// <summary>
	/// from vlgAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Expression"></param>
	public vlgModuleInstanceSimplePortMapping(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.External = new vlgAssignExpression(Target, Type, Expression);
	}
	/// <summary>
	/// from vlgBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vlgModuleInstanceSimplePortMapping(RTLBitArray Value)
	{
		this.External = new vlgBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vlgCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgModuleInstanceSimplePortMapping(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.External = new vlgCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vlgModuleInstanceSimplePortMapping(vlgIdentifier Source)
	{
		this.External = new vlgIdentifierExpression(Source);
	}
	/// <summary>
	/// from vlgLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgModuleInstanceSimplePortMapping(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.External = new vlgLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgModuleInstanceSimplePortMapping(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.External = new vlgMathExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgModuleInstanceSimplePortMapping(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.External = new vlgShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	/// <param name="Expressions"></param>
	public vlgModuleInstanceSimplePortMapping(Int32 Size, IEnumerable<vlgExpression> Expressions)
	{
		this.External = new vlgSizedAggregateExpression(Size, Expressions);
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	public vlgModuleInstanceSimplePortMapping(Int32 Size)
	{
		this.External = new vlgSizedAggregateExpression(Size);
	}
	/// <summary>
	/// from vlgTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vlgModuleInstanceSimplePortMapping(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	{
		this.External = new vlgTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vlgUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
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
	public vlgProcedureCall(String Proc, String Name, IEnumerable<vlgExpression> Parameters)
	{
		this.Proc = Proc;
		this.Name = Name;
		this.Parameters = (Parameters ?? Enumerable.Empty<vlgExpression>()).Where(s => s != null).ToList();
	}
	public vlgProcedureCall(String Proc, String Name)
	{
		this.Proc = Proc;
		this.Name = Name;
	}
	public String Proc { get; set; }
	public String Name { get; set; }
	/// <summary>
	/// vlgAggregateExpression
	///
	/// vlgAssignExpression
	///
	/// vlgBinaryValueExpression
	///
	/// vlgCompareExpression
	///
	/// vlgIdentifierExpression
	///
	/// vlgLogicExpression
	///
	/// vlgMathExpression
	///
	/// vlgShiftExpression
	///
	/// vlgSizedAggregateExpression
	///
	/// vlgTernaryExpression
	///
	/// vlgUnaryExpression
	///
	/// </summary>
	public List<vlgExpression> Parameters { get; set; } = new List<vlgExpression>();
}
public partial class vlgRange : vlgAbstractObject
{
	public vlgRange() { }
	public vlgRange(IEnumerable<vlgExpression> Indexes)
	{
		this.Indexes = (Indexes ?? Enumerable.Empty<vlgExpression>()).Where(s => s != null).ToList();
	}
	// from vlgAggregateExpression
	// ignored vlgRange(IEnumerable<vlgExpression> Expressions)
	/// <summary>
	/// from vlgAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Expression"></param>
	public vlgRange(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Indexes.Add(new vlgAssignExpression(Target, Type, Expression));
	}
	/// <summary>
	/// from vlgBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vlgRange(RTLBitArray Value)
	{
		this.Indexes.Add(new vlgBinaryValueExpression(Value));
	}
	/// <summary>
	/// from vlgCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgRange(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
	{
		this.Indexes.Add(new vlgCompareExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vlgIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vlgRange(vlgIdentifier Source)
	{
		this.Indexes.Add(new vlgIdentifierExpression(Source));
	}
	/// <summary>
	/// from vlgLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgRange(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
	{
		this.Indexes.Add(new vlgLogicExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vlgMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgRange(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
	{
		this.Indexes.Add(new vlgMathExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vlgShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgRange(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
	{
		this.Indexes.Add(new vlgShiftExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	/// <param name="Expressions"></param>
	public vlgRange(Int32 Size, IEnumerable<vlgExpression> Expressions)
	{
		this.Indexes.Add(new vlgSizedAggregateExpression(Size, Expressions));
	}
	/// <summary>
	/// from vlgSizedAggregateExpression
	/// </summary>
	/// <param name="Size"></param>
	public vlgRange(Int32 Size)
	{
		this.Indexes.Add(new vlgSizedAggregateExpression(Size));
	}
	// from vlgTernaryExpression
	// ignored vlgRange(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
	/// <summary>
	/// from vlgUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vlgRange(vlgUnaryType Type, vlgExpression Rhs)
	{
		this.Indexes.Add(new vlgUnaryExpression(Type, Rhs));
	}
	/// <summary>
	/// vlgAggregateExpression
	///
	/// vlgAssignExpression
	///
	/// vlgBinaryValueExpression
	///
	/// vlgCompareExpression
	///
	/// vlgIdentifierExpression
	///
	/// vlgLogicExpression
	///
	/// vlgMathExpression
	///
	/// vlgShiftExpression
	///
	/// vlgSizedAggregateExpression
	///
	/// vlgTernaryExpression
	///
	/// vlgUnaryExpression
	///
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
public partial class vlgSizedAggregateExpression : vlgExpression
{
	public vlgSizedAggregateExpression() { }
	public vlgSizedAggregateExpression(Int32 Size, IEnumerable<vlgExpression> Expressions)
	{
		this.Size = Size;
		this.Expressions = (Expressions ?? Enumerable.Empty<vlgExpression>()).Where(s => s != null).ToList();
	}
	public vlgSizedAggregateExpression(Int32 Size)
	{
		this.Size = Size;
	}
	public Int32 Size { get; set; }
	/// <summary>
	/// vlgAggregateExpression
	///
	/// vlgAssignExpression
	///
	/// vlgBinaryValueExpression
	///
	/// vlgCompareExpression
	///
	/// vlgIdentifierExpression
	///
	/// vlgLogicExpression
	///
	/// vlgMathExpression
	///
	/// vlgShiftExpression
	///
	/// vlgSizedAggregateExpression
	///
	/// vlgTernaryExpression
	///
	/// vlgUnaryExpression
	///
	/// </summary>
	public List<vlgExpression> Expressions { get; set; } = new List<vlgExpression>();
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
	public vlgSyncBlock(IEnumerable<vlgSyncBlockSensitivityItem> SensitivityList)
	{
		this.SensitivityList = (SensitivityList ?? Enumerable.Empty<vlgSyncBlockSensitivityItem>()).Where(s => s != null).ToList();
	}
	/// <summary>
	/// from vlgSyncBlockSensitivityItem
	/// </summary>
	/// <param name="Edge"></param>
	/// <param name="Identifier"></param>
	public vlgSyncBlock(vlgEdgeType Edge, vlgIdentifier Identifier)
	{
		this.SensitivityList.Add(new vlgSyncBlockSensitivityItem(Edge, Identifier));
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
	public vlgText(IEnumerable<String> Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
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
