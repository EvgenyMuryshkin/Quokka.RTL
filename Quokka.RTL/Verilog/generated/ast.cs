using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
using Newtonsoft.Json;
[JsonObjectAttribute]
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
	/// vlgFunction
	///
	/// vlgFunctionDeclaration
	///
	/// vlgFunctionImplementation
	///
	/// vlgFunctionImplementationBlock
	///
	/// vlgFunctionInterface
	///
	/// vlgFunctionPortDeclaration
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
	/// vlgIntegerExpression
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
	/// vlgProcedureCallExpression
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
[JsonObjectAttribute]
public abstract partial class vlgAbstractForLoop : vlgAbstractCollection
{
	public vlgAbstractForLoop() { }
	public String Name { get; set; }
}
[JsonObjectAttribute]
public abstract partial class vlgAbstractObject
{
	public vlgAbstractObject() { }
}
[JsonObjectAttribute]
public partial class vlgAggregateExpression : vlgExpression, IEnumerable//<vlgExpression>
{
	public vlgAggregateExpression() { }
	// vlgExpression single list member
	IEnumerator IEnumerable.GetEnumerator() => (Expressions as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgExpression);
	public void Add(vlgExpression child)
	{
		Expressions.Add(child);
	}
	public vlgAggregateExpression(IEnumerable<vlgExpression> Expressions)
	{
		this.Expressions = (Expressions ?? Enumerable.Empty<vlgExpression>()).Where(s => s != null).ToList();
	}
	public vlgAggregateExpression(params vlgExpression[] Expressions)
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
	// from vlgIntegerExpression
	// ignored vlgAggregateExpression(Int32 Value)
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
	/// from vlgProcedureCallExpression
	/// </summary>
	/// <param name="Call"></param>
	public vlgAggregateExpression(vlgProcedureCall Call)
	{
		this.Expressions.Add(new vlgProcedureCallExpression(Call));
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
	// from vlgSizedAggregateExpression
	// ignored vlgAggregateExpression(Int32 Size)
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
	/// vlgIntegerExpression
	///
	/// vlgLogicExpression
	///
	/// vlgMathExpression
	///
	/// vlgProcedureCallExpression
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
[JsonObjectAttribute]
public partial class vlgAssign : vlgAbstractObject, vlgForLoopChild, vlgFunctionImplementationBlockChild, vlgGenericBlockChild, vlgInitialChild, vlgModuleImplementationBlockChild, vlgSimpleForLoopChild
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
[JsonObjectAttribute]
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
	public Boolean Debugger { get; set; }
}
[JsonObjectAttribute]
public partial class vlgAttribute : vlgAbstractObject, vlgFileChild
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
[JsonObjectAttribute]
public partial class vlgBinaryValueExpression : vlgExpression, vlgICaseStatement
{
	public vlgBinaryValueExpression() { }
	public vlgBinaryValueExpression(RTLBitArray Value)
	{
		this.Value = Value;
	}
	public RTLBitArray Value { get; set; } = new RTLBitArray();
}
[JsonObjectAttribute]
public abstract partial class vlgBlock : vlgAbstractCollection
{
	public vlgBlock() { }
}
[JsonObjectAttribute]
public partial class vlgCase : vlgAbstractObject, vlgGenericBlockChild, vlgModuleImplementationBlockChild, IEnumerable//<vlgCaseStatement>
{
	public vlgCase() { }
	// vlgCaseStatement single list member
	IEnumerator IEnumerable.GetEnumerator() => (Statements as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgCaseStatement);
	public void Add(vlgCaseStatement child)
	{
		Statements.Add(child);
	}
	public vlgCase(vlgExpression Check, IEnumerable<vlgCaseStatement> Statements)
	{
		this.Check = Check;
		this.Statements = (Statements ?? Enumerable.Empty<vlgCaseStatement>()).Where(s => s != null).ToList();
	}
	public vlgCase(vlgExpression Check, params vlgCaseStatement[] Statements)
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
	// from vlgIntegerExpression
	// ignored vlgCase(Int32 Value)
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
	/// from vlgProcedureCallExpression
	/// </summary>
	/// <param name="Call"></param>
	public vlgCase(vlgProcedureCall Call)
	{
		this.Check = new vlgProcedureCallExpression(Call);
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
	// from vlgSizedAggregateExpression
	// ignored vlgCase(Int32 Size)
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
[JsonObjectAttribute]
public partial class vlgCaseDefault : vlgCaseItem, IEnumerable//<vlgGenericBlockChild>
{
	public vlgCaseDefault() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgGenericBlockChild child)
	{
		Block.Add(child);
	}
}
[JsonObjectAttribute]
public abstract partial class vlgCaseItem : vlgAbstractObject
{
	public vlgCaseItem() { }
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
[JsonObjectAttribute]
public partial class vlgCaseStatement : vlgCaseItem, IEnumerable//<vlgGenericBlockChild>
{
	public vlgCaseStatement() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgGenericBlockChild child)
	{
		Block.Add(child);
	}
	public vlgCaseStatement(IEnumerable<vlgICaseStatement> Conditions)
	{
		this.Conditions = (Conditions ?? Enumerable.Empty<vlgICaseStatement>()).Where(s => s != null).ToList();
	}
	public vlgCaseStatement(params vlgICaseStatement[] Conditions)
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
[JsonObjectAttribute]
public partial class vlgCombBlock : vlgAbstractObject, vlgModuleImplementationBlockChild, IEnumerable//<vlgGenericBlockChild>
{
	public vlgCombBlock() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgGenericBlockChild child)
	{
		Block.Add(child);
	}
	public vlgCombBlock(IEnumerable<vlgIdentifier> SensitivityList)
	{
		this.SensitivityList = (SensitivityList ?? Enumerable.Empty<vlgIdentifier>()).Where(s => s != null).ToList();
	}
	public vlgCombBlock(params vlgIdentifier[] SensitivityList)
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
[JsonObjectAttribute]
public partial class vlgComment : vlgAbstractObject, vlgFileChild, vlgFunctionImplementationBlockChild, vlgFunctionInterfaceChild, vlgGenericBlockChild, vlgInitialChild, vlgModuleImplementationBlockChild, vlgModuleInstancePortMappingsChild, vlgModuleInterfaceChild, vlgModuleParametersChild
{
	public vlgComment() { }
	public vlgComment(IEnumerable<String> Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public vlgComment(params String[] Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public List<String> Lines { get; set; } = new List<String>();
}
[JsonObjectAttribute]
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
[JsonObjectAttribute]
public partial class vlgConditionalStatement : vlgAbstractObject, IEnumerable//<vlgGenericBlockChild>
{
	public vlgConditionalStatement() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgGenericBlockChild child)
	{
		Block.Add(child);
	}
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
	// from vlgIntegerExpression
	// ignored vlgConditionalStatement(Int32 Value)
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
	/// from vlgProcedureCallExpression
	/// </summary>
	/// <param name="Call"></param>
	public vlgConditionalStatement(vlgProcedureCall Call)
	{
		this.Condition = new vlgProcedureCallExpression(Call);
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
	// from vlgSizedAggregateExpression
	// ignored vlgConditionalStatement(Int32 Size)
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
[JsonObjectAttribute]
public partial class vlgCustomDeclaration : vlgAbstractObject, vlgModuleImplementationBlockChild
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
[JsonObjectAttribute]
public partial class vlgCustomModulePortDeclaration : vlgDeclarationModulePort, vlgModuleInterfaceChild
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
[JsonObjectAttribute]
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
[JsonObjectAttribute]
public abstract partial class vlgExpression : vlgAbstractObject
{
	public vlgExpression() { }
	public Nullable<vlgSignType> ExpressionSignType { get; set; }
	public Nullable<Int32> ExpressionSize { get; set; }
}
/// <summary>
/// vlgComment
/// vlgText
/// vlgModule
/// vlgAttribute
/// </summary>
public interface vlgFileChild
{
}
[JsonObjectAttribute]
public partial class vlgFile : vlgAbstractCollection, IEnumerable//<vlgFileChild>
{
	public vlgFile() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgFileChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
/// <summary>
/// </summary>
public interface vlgForLoopChild
{
}
[JsonObjectAttribute]
public partial class vlgForLoop : vlgAbstractForLoop, vlgGenericBlockChild, vlgModuleImplementationBlockChild, IEnumerable//<vlgForLoopChild>
{
	public vlgForLoop() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgForLoopChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
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
/// <summary>
/// </summary>
public interface vlgFunctionChild
{
}
[JsonObjectAttribute]
public partial class vlgFunction : vlgAbstractCollection, vlgModuleImplementationBlockChild, IEnumerable//<vlgFunctionChild>
{
	public vlgFunction() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgFunctionChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
	public vlgFunction(String Name, Int32 Width)
	{
		this.Declaration = new vlgFunctionDeclaration(Name, Width);
	}
	public vlgFunction(vlgFunctionDeclaration Declaration)
	{
		this.Declaration = Declaration;
	}
	public vlgFunctionDeclaration Declaration { get; set; } = new vlgFunctionDeclaration();
	public vlgFunctionInterface Interface { get; set; } = new vlgFunctionInterface();
	public vlgFunctionImplementation Implementation { get; set; } = new vlgFunctionImplementation();
}
[JsonObjectAttribute]
public partial class vlgFunctionDeclaration : vlgAbstractObject
{
	public vlgFunctionDeclaration() { }
	public vlgFunctionDeclaration(String Name, Int32 Width)
	{
		this.Name = Name;
		this.Width = Width;
	}
	public String Name { get; set; }
	public Int32 Width { get; set; }
}
[JsonObjectAttribute]
public partial class vlgFunctionImplementation : vlgAbstractObject, IEnumerable//<vlgFunctionImplementationBlockChild>
{
	public vlgFunctionImplementation() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgFunctionImplementationBlockChild child)
	{
		Block.Add(child);
	}
	public vlgFunctionImplementation(vlgFunctionImplementationBlock Block)
	{
		this.Block = Block;
	}
	public vlgFunctionImplementationBlock Block { get; set; } = new vlgFunctionImplementationBlock();
}
/// <summary>
/// vlgComment
/// vlgText
/// vlgAssign
/// </summary>
public interface vlgFunctionImplementationBlockChild
{
}
[JsonObjectAttribute]
public partial class vlgFunctionImplementationBlock : vlgAbstractCollection, IEnumerable//<vlgFunctionImplementationBlockChild>
{
	public vlgFunctionImplementationBlock() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgFunctionImplementationBlockChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
/// <summary>
/// vlgComment
/// vlgText
/// vlgFunctionPortDeclaration
/// </summary>
public interface vlgFunctionInterfaceChild
{
}
[JsonObjectAttribute]
public partial class vlgFunctionInterface : vlgAbstractCollection, IEnumerable//<vlgFunctionInterfaceChild>
{
	public vlgFunctionInterface() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgFunctionInterfaceChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
[JsonObjectAttribute]
public partial class vlgFunctionPortDeclaration : vlgStandardModulePort, vlgFunctionInterfaceChild
{
	public vlgFunctionPortDeclaration() { }
	public vlgFunctionPortDeclaration(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Direction = Direction;
		this.NetType = NetType;
		this.Sign = Sign;
		this.Width = Width;
		this.Name = Name;
	}
}
[JsonObjectAttribute]
public partial class vlgGenerate : vlgAbstractObject, vlgGenericBlockChild, vlgModuleImplementationBlockChild, IEnumerable//<vlgGenericBlockChild>
{
	public vlgGenerate() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgGenericBlockChild child)
	{
		Block.Add(child);
	}
	public vlgGenerate(vlgGenericBlock Block)
	{
		this.Block = Block;
	}
	public vlgGenericBlock Block { get; set; } = new vlgGenericBlock();
}
/// <summary>
/// </summary>
public interface vlgGenericBlockChild
{
}
[JsonObjectAttribute]
public partial class vlgGenericBlock : vlgBlock, vlgForLoopChild, vlgGenericBlockChild, vlgModuleImplementationBlockChild, vlgSimpleForLoopChild, IEnumerable//<vlgGenericBlockChild>
{
	public vlgGenericBlock() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgGenericBlockChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
[JsonObjectAttribute]
public partial class vlgGenvar : vlgAbstractObject, vlgGenericBlockChild, vlgModuleImplementationBlockChild
{
	public vlgGenvar() { }
	public vlgGenvar(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
[JsonObjectAttribute]
public partial class vlgIdentifier : vlgAbstractObject, IEnumerable//<vlgRange>
{
	public vlgIdentifier() { }
	// vlgRange single list member
	IEnumerator IEnumerable.GetEnumerator() => (Indexes as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgRange);
	public void Add(vlgRange child)
	{
		Indexes.Add(child);
	}
	public vlgIdentifier(String Name, IEnumerable<vlgRange> Indexes)
	{
		this.Name = Name;
		this.Indexes = (Indexes ?? Enumerable.Empty<vlgRange>()).Where(s => s != null).ToList();
	}
	public vlgIdentifier(String Name, params vlgRange[] Indexes)
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
[JsonObjectAttribute]
public partial class vlgIdentifierExpression : vlgExpression, vlgICaseStatement
{
	public vlgIdentifierExpression() { }
	public vlgIdentifierExpression(String Name, IEnumerable<vlgRange> Indexes)
	{
		this.Source = new vlgIdentifier(Name, Indexes);
	}
	public vlgIdentifierExpression(String Name, params vlgRange[] Indexes)
	{
		this.Source = new vlgIdentifier(Name, Indexes);
	}
	public vlgIdentifierExpression(vlgIdentifier Source)
	{
		this.Source = Source;
	}
	public vlgIdentifier Source { get; set; } = new vlgIdentifier();
}
[JsonObjectAttribute]
public partial class vlgIf : vlgAbstractObject, vlgGenericBlockChild, vlgModuleImplementationBlockChild, IEnumerable//<vlgConditionalStatement>
{
	public vlgIf() { }
	// vlgConditionalStatement single list member
	IEnumerator IEnumerable.GetEnumerator() => (Statements as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgConditionalStatement);
	public void Add(vlgConditionalStatement child)
	{
		Statements.Add(child);
	}
	public List<vlgConditionalStatement> Statements { get; set; } = new List<vlgConditionalStatement>();
}
/// <summary>
/// vlgComment
/// vlgText
/// vlgSimpleForLoop
/// vlgAssign
/// </summary>
public interface vlgInitialChild
{
}
[JsonObjectAttribute]
public partial class vlgInitial : vlgAbstractCollection, vlgModuleImplementationBlockChild, IEnumerable//<vlgInitialChild>
{
	public vlgInitial() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgInitialChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
	public vlgInitial(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
[JsonObjectAttribute]
public partial class vlgIntegerExpression : vlgExpression
{
	public vlgIntegerExpression() { }
	public vlgIntegerExpression(Int32 Value)
	{
		this.Value = Value;
	}
	public Int32 Value { get; set; }
}
[JsonObjectAttribute]
public partial class vlgIterator : vlgAbstractObject, vlgModuleImplementationBlockChild
{
	public vlgIterator() { }
	public vlgIterator(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
[JsonObjectAttribute]
public abstract partial class vlgLocalParam : vlgAbstractObject
{
	public vlgLocalParam() { }
}
[JsonObjectAttribute]
public abstract partial class vlgLocalParamName : vlgLocalParam
{
	public vlgLocalParamName() { }
	public vlgLocalParamName(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
[JsonObjectAttribute]
public partial class vlgLocalParamNameBinaryValue : vlgLocalParamName, vlgModuleImplementationBlockChild
{
	public vlgLocalParamNameBinaryValue() { }
	public vlgLocalParamNameBinaryValue(String Name, RTLBitArray Value)
	{
		this.Name = Name;
		this.Value = Value;
	}
	public RTLBitArray Value { get; set; } = new RTLBitArray();
}
[JsonObjectAttribute]
public partial class vlgLocalParamNameExplicitValue : vlgLocalParamName, vlgModuleImplementationBlockChild
{
	public vlgLocalParamNameExplicitValue() { }
	public vlgLocalParamNameExplicitValue(String Name, String Value)
	{
		this.Name = Name;
		this.Value = Value;
	}
	public String Value { get; set; }
}
[JsonObjectAttribute]
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
[JsonObjectAttribute]
public partial class vlgLogicSignal : vlgSignal, vlgModuleImplementationBlockChild
{
	public vlgLogicSignal() { }
	public vlgLogicSignal(vlgNetType NetType, vlgSignType Sign, vlgSignalType SignalType, String Name, Int32 Width, String Initializer)
	{
		this.NetType = NetType;
		this.Sign = Sign;
		this.SignalType = SignalType;
		this.Name = Name;
		this.Width = Width;
		this.Initializer = Initializer;
	}
	public vlgNetType NetType { get; set; }
	public vlgSignType Sign { get; set; }
	public vlgSignalType SignalType { get; set; }
	public String Name { get; set; }
	public Int32 Width { get; set; }
	public String Initializer { get; set; }
}
[JsonObjectAttribute]
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
[JsonObjectAttribute]
public partial class vlgMemoryBlock : vlgSignal, vlgModuleImplementationBlockChild
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
[JsonObjectAttribute]
public partial class vlgModule : vlgAbstractObject, vlgFileChild
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
[JsonObjectAttribute]
public partial class vlgModuleImplementation : vlgAbstractObject, IEnumerable//<vlgModuleImplementationBlockChild>
{
	public vlgModuleImplementation() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgModuleImplementationBlockChild child)
	{
		Block.Add(child);
	}
	public vlgModuleImplementation(vlgModuleImplementationBlock Block)
	{
		this.Block = Block;
	}
	public vlgModuleImplementationBlock Block { get; set; } = new vlgModuleImplementationBlock();
}
/// <summary>
/// vlgLocalParamNameBinaryValue
/// vlgLocalParamNameExplicitValue
/// vlgStandardModulePortImplementation
/// vlgCustomDeclaration
/// vlgLogicSignal
/// vlgMemoryBlock
/// vlgInitial
/// vlgIterator
/// vlgCombBlock
/// vlgSyncBlock
/// vlgModuleImplementationBlock
/// vlgFunction
/// </summary>
public interface vlgModuleImplementationBlockChild
{
}
[JsonObjectAttribute]
public partial class vlgModuleImplementationBlock : vlgBlock, vlgModuleImplementationBlockChild, IEnumerable//<vlgModuleImplementationBlockChild>
{
	public vlgModuleImplementationBlock() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgModuleImplementationBlockChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
[JsonObjectAttribute]
public partial class vlgModuleInstance : vlgAbstractObject, vlgGenericBlockChild, vlgModuleImplementationBlockChild
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
[JsonObjectAttribute]
public partial class vlgModuleInstanceNamedPortMapping : vlgModuleInstancePortMapping, vlgModuleInstancePortMappingsChild
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
[JsonObjectAttribute]
public partial class vlgModuleInstanceParameter : vlgAbstractObject, vlgModuleInstanceParametersChild
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
/// <summary>
/// vlgModuleInstanceParameter
/// </summary>
public interface vlgModuleInstanceParametersChild
{
}
[JsonObjectAttribute]
public partial class vlgModuleInstanceParameters : vlgAbstractCollection, IEnumerable//<vlgModuleInstanceParametersChild>
{
	public vlgModuleInstanceParameters() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgModuleInstanceParametersChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
[JsonObjectAttribute]
public abstract partial class vlgModuleInstancePortMapping : vlgAbstractObject
{
	public vlgModuleInstancePortMapping() { }
}
/// <summary>
/// vlgComment
/// vlgText
/// vlgModuleInstanceNamedPortMapping
/// vlgModuleInstanceSimplePortMapping
/// </summary>
public interface vlgModuleInstancePortMappingsChild
{
}
[JsonObjectAttribute]
public partial class vlgModuleInstancePortMappings : vlgAbstractCollection, IEnumerable//<vlgModuleInstancePortMappingsChild>
{
	public vlgModuleInstancePortMappings() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgModuleInstancePortMappingsChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
[JsonObjectAttribute]
public partial class vlgModuleInstanceSimplePortMapping : vlgModuleInstancePortMapping, vlgModuleInstancePortMappingsChild
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
	// from vlgIntegerExpression
	// ignored vlgModuleInstanceSimplePortMapping(Int32 Value)
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
	/// from vlgProcedureCallExpression
	/// </summary>
	/// <param name="Call"></param>
	public vlgModuleInstanceSimplePortMapping(vlgProcedureCall Call)
	{
		this.External = new vlgProcedureCallExpression(Call);
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
	// from vlgSizedAggregateExpression
	// ignored vlgModuleInstanceSimplePortMapping(Int32 Size)
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
/// <summary>
/// vlgComment
/// vlgText
/// vlgPlaceholderModulePort
/// vlgCustomModulePortDeclaration
/// vlgStandardModulePortDeclaration
/// </summary>
public interface vlgModuleInterfaceChild
{
}
[JsonObjectAttribute]
public partial class vlgModuleInterface : vlgAbstractCollection, IEnumerable//<vlgModuleInterfaceChild>
{
	public vlgModuleInterface() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgModuleInterfaceChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
[JsonObjectAttribute]
public partial class vlgModuleParameterDeclaration : vlgAbstractObject, vlgModuleParametersChild
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
/// <summary>
/// vlgComment
/// vlgText
/// vlgModuleParameterDeclaration
/// </summary>
public interface vlgModuleParametersChild
{
}
[JsonObjectAttribute]
public partial class vlgModuleParameters : vlgAbstractCollection, IEnumerable//<vlgModuleParametersChild>
{
	public vlgModuleParameters() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgModuleParametersChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
[JsonObjectAttribute]
public abstract partial class vlgModulePort : vlgAbstractObject
{
	public vlgModulePort() { }
}
[JsonObjectAttribute]
public partial class vlgPlaceholderModulePort : vlgModulePort, vlgModuleInterfaceChild
{
	public vlgPlaceholderModulePort() { }
	public vlgPlaceholderModulePort(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
[JsonObjectAttribute]
public partial class vlgProcedureCall : vlgAbstractObject, vlgGenericBlockChild, vlgModuleImplementationBlockChild, IEnumerable//<vlgExpression>
{
	public vlgProcedureCall() { }
	// vlgExpression single list member
	IEnumerator IEnumerable.GetEnumerator() => (Parameters as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgExpression);
	public void Add(vlgExpression child)
	{
		Parameters.Add(child);
	}
	public vlgProcedureCall(String Proc, String Name, IEnumerable<vlgExpression> Parameters)
	{
		this.Proc = Proc;
		this.Name = Name;
		this.Parameters = (Parameters ?? Enumerable.Empty<vlgExpression>()).Where(s => s != null).ToList();
	}
	public vlgProcedureCall(String Proc, String Name, params vlgExpression[] Parameters)
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
	/// vlgIntegerExpression
	///
	/// vlgLogicExpression
	///
	/// vlgMathExpression
	///
	/// vlgProcedureCallExpression
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
[JsonObjectAttribute]
public partial class vlgProcedureCallExpression : vlgExpression
{
	public vlgProcedureCallExpression() { }
	public vlgProcedureCallExpression(String Proc, String Name, IEnumerable<vlgExpression> Parameters)
	{
		this.Call = new vlgProcedureCall(Proc, Name, Parameters);
	}
	public vlgProcedureCallExpression(String Proc, String Name, params vlgExpression[] Parameters)
	{
		this.Call = new vlgProcedureCall(Proc, Name, Parameters);
	}
	public vlgProcedureCallExpression(vlgProcedureCall Call)
	{
		this.Call = Call;
	}
	public vlgProcedureCall Call { get; set; } = new vlgProcedureCall();
}
[JsonObjectAttribute]
public partial class vlgRange : vlgAbstractObject, IEnumerable//<vlgExpression>
{
	public vlgRange() { }
	// vlgExpression single list member
	IEnumerator IEnumerable.GetEnumerator() => (Indexes as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgExpression);
	public void Add(vlgExpression child)
	{
		Indexes.Add(child);
	}
	public vlgRange(IEnumerable<vlgExpression> Indexes)
	{
		this.Indexes = (Indexes ?? Enumerable.Empty<vlgExpression>()).Where(s => s != null).ToList();
	}
	public vlgRange(params vlgExpression[] Indexes)
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
	// from vlgIntegerExpression
	// ignored vlgRange(Int32 Value)
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
	/// from vlgProcedureCallExpression
	/// </summary>
	/// <param name="Call"></param>
	public vlgRange(vlgProcedureCall Call)
	{
		this.Indexes.Add(new vlgProcedureCallExpression(Call));
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
	// from vlgSizedAggregateExpression
	// ignored vlgRange(Int32 Size)
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
	/// vlgIntegerExpression
	///
	/// vlgLogicExpression
	///
	/// vlgMathExpression
	///
	/// vlgProcedureCallExpression
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
[JsonObjectAttribute]
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
[JsonObjectAttribute]
public abstract partial class vlgSignal : vlgAbstractObject
{
	public vlgSignal() { }
}
/// <summary>
/// </summary>
public interface vlgSimpleForLoopChild
{
}
[JsonObjectAttribute]
public partial class vlgSimpleForLoop : vlgAbstractForLoop, vlgGenericBlockChild, vlgInitialChild, vlgModuleImplementationBlockChild, IEnumerable//<vlgSimpleForLoopChild>
{
	public vlgSimpleForLoop() { }
	// vlgAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgSimpleForLoopChild child)
	{
		var typed = child as vlgAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
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
[JsonObjectAttribute]
public partial class vlgSizedAggregateExpression : vlgExpression, IEnumerable//<vlgExpression>
{
	public vlgSizedAggregateExpression() { }
	// vlgExpression single list member
	IEnumerator IEnumerable.GetEnumerator() => (Expressions as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgExpression);
	public void Add(vlgExpression child)
	{
		Expressions.Add(child);
	}
	public vlgSizedAggregateExpression(Int32 Size, IEnumerable<vlgExpression> Expressions)
	{
		this.Size = Size;
		this.Expressions = (Expressions ?? Enumerable.Empty<vlgExpression>()).Where(s => s != null).ToList();
	}
	public vlgSizedAggregateExpression(Int32 Size, params vlgExpression[] Expressions)
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
	/// vlgIntegerExpression
	///
	/// vlgLogicExpression
	///
	/// vlgMathExpression
	///
	/// vlgProcedureCallExpression
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
[JsonObjectAttribute]
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
[JsonObjectAttribute]
public partial class vlgStandardModulePortDeclaration : vlgStandardModulePort, vlgModuleInterfaceChild
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
[JsonObjectAttribute]
public partial class vlgStandardModulePortImplementation : vlgStandardModulePort, vlgModuleImplementationBlockChild
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
[JsonObjectAttribute]
public partial class vlgSyncBlock : vlgAbstractObject, vlgModuleImplementationBlockChild, IEnumerable//<vlgGenericBlockChild>
{
	public vlgSyncBlock() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	[Obsolete]public void Add(object obj) => Add(obj as vlgAbstractObject);
	public void Add(vlgGenericBlockChild child)
	{
		Block.Add(child);
	}
	public vlgSyncBlock(IEnumerable<vlgSyncBlockSensitivityItem> SensitivityList)
	{
		this.SensitivityList = (SensitivityList ?? Enumerable.Empty<vlgSyncBlockSensitivityItem>()).Where(s => s != null).ToList();
	}
	public vlgSyncBlock(params vlgSyncBlockSensitivityItem[] SensitivityList)
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
[JsonObjectAttribute]
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
[JsonObjectAttribute]
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
[JsonObjectAttribute]
public partial class vlgText : vlgAbstractObject, vlgFileChild, vlgFunctionImplementationBlockChild, vlgFunctionInterfaceChild, vlgGenericBlockChild, vlgInitialChild, vlgModuleImplementationBlockChild, vlgModuleInstancePortMappingsChild, vlgModuleInterfaceChild, vlgModuleParametersChild
{
	public vlgText() { }
	public vlgText(IEnumerable<String> Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public vlgText(params String[] Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public List<String> Lines { get; set; } = new List<String>();
}
[JsonObjectAttribute]
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
