using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public abstract partial class vhdAbstractCollection : vhdAbstractObject
{
	public vhdAbstractCollection() { }
	/// <summary>
	/// vhdAggregate
	///
	/// vhdAggregateBitConnection
	///
	/// vhdAggregateExpression
	///
	/// vhdAggregateOthersConnection
	///
	/// vhdAlias
	///
	/// vhdArchitecture
	///
	/// vhdArchitectureDeclarations
	///
	/// vhdArchitectureImplementation
	///
	/// vhdArchitectureImplementationBlock
	///
	/// vhdArrayTypeDeclaration
	///
	/// vhdAssignExpression
	///
	/// vhdAttribute
	///
	/// vhdBinaryValueExpression
	///
	/// vhdCase
	///
	/// vhdCaseStatement
	///
	/// vhdCastExpression
	///
	/// vhdCastResizeExpression
	///
	/// vhdComment
	///
	/// vhdCompareExpression
	///
	/// vhdConditionalStatement
	///
	/// vhdCustomDataType
	///
	/// vhdCustomEntityPort
	///
	/// vhdCustomNetType
	///
	/// vhdDefaultDataType
	///
	/// vhdDefaultNetType
	///
	/// vhdDefaultSignal
	///
	/// vhdEntity
	///
	/// vhdEntityInstance
	///
	/// vhdEntityInstanceNamedPortMapping
	///
	/// vhdEntityInstancePortMappings
	///
	/// vhdEntityInterface
	///
	/// vhdFile
	///
	/// vhdGenericBlock
	///
	/// vhdIdentifier
	///
	/// vhdIdentifierExpression
	///
	/// vhdIf
	///
	/// vhdLibraryReference
	///
	/// vhdLogicExpression
	///
	/// vhdLogicSignal
	///
	/// vhdMathExpression
	///
	/// vhdNull
	///
	/// vhdOthersExpression
	///
	/// vhdParenthesizedExpression
	///
	/// vhdPredefinedAttributeExpression
	///
	/// vhdProcedureCall
	///
	/// vhdProcedureCallExpression
	///
	/// vhdProcess
	///
	/// vhdProcessDeclarations
	///
	/// vhdRange
	///
	/// vhdResizeExpression
	///
	/// vhdShiftExpression
	///
	/// vhdSimpleForLoop
	///
	/// vhdStandardEntityPort
	///
	/// vhdSyncBlock
	///
	/// vhdTernaryExpression
	///
	/// vhdText
	///
	/// vhdUnaryExpression
	///
	/// vhdUse
	///
	/// </summary>
	public List<vhdAbstractObject> Children { get; set; } = new List<vhdAbstractObject>();
}
public abstract partial class vhdAbstractObject
{
	public vhdAbstractObject() { }
}
/// <summary>
/// </summary>
public interface vhdAggregateChild
{
}
public partial class vhdAggregate : vhdAbstractCollection, IEnumerable//<vhdAggregateChild>
{
	public vhdAggregate() { }
	// vhdAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	public void Add(vhdAggregateChild child)
	{
		var typed = child as vhdAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
public partial class vhdAggregateBitConnection : vhdAbstractObject
{
	public vhdAggregateBitConnection() { }
	public vhdAggregateBitConnection(Int32 Bit, vhdExpression Value)
	{
		this.Bit = Bit;
		this.Value = Value;
	}
	public Int32 Bit { get; set; }
	public vhdExpression Value { get; set; }
}
public abstract partial class vhdAggregateConnection : vhdAbstractObject
{
	public vhdAggregateConnection() { }
}
public partial class vhdAggregateExpression : vhdExpression, IEnumerable//<vhdAggregateChild>
{
	public vhdAggregateExpression() { }
	// Aggregate single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Aggregate as IEnumerable).GetEnumerator();
	public void Add(vhdAggregateChild child)
	{
		Aggregate.Add(child);
	}
	public vhdAggregateExpression(vhdAggregate Aggregate)
	{
		this.Aggregate = Aggregate;
	}
	public vhdAggregate Aggregate { get; set; } = new vhdAggregate();
}
public partial class vhdAggregateOthersConnection : vhdAbstractObject
{
	public vhdAggregateOthersConnection() { }
	public vhdAggregateOthersConnection(vhdExpression Expression)
	{
		this.Expression = Expression;
	}
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	/// <param name="Aggregate"></param>
	public vhdAggregateOthersConnection(vhdAggregate Aggregate)
	{
		this.Expression = new vhdAggregateExpression(Aggregate);
	}
	/// <summary>
	/// from vhdAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdAggregateOthersConnection(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Expression = new vhdAssignExpression(Target, Type, Source);
	}
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vhdAggregateOthersConnection(RTLBitArray Value)
	{
		this.Expression = new vhdBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vhdCastExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdAggregateOthersConnection(vhdCastType Type, vhdExpression Source)
	{
		this.Expression = new vhdCastExpression(Type, Source);
	}
	/// <summary>
	/// from vhdCastResizeExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdAggregateOthersConnection(vhdCastType Type, vhdExpression Source, vhdExpression Length)
	{
		this.Expression = new vhdCastResizeExpression(Type, Source, Length);
	}
	/// <summary>
	/// from vhdCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdAggregateOthersConnection(vhdExpression Lhs, vhdCompareType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vhdAggregateOthersConnection(vhdIdentifier Source)
	{
		this.Expression = new vhdIdentifierExpression(Source);
	}
	/// <summary>
	/// from vhdLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdAggregateOthersConnection(vhdExpression Lhs, vhdLogicType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdAggregateOthersConnection(vhdExpression Lhs, vhdMathType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdMathExpression(Lhs, Type, Rhs);
	}
	// from vhdParenthesizedExpression
	// ignored vhdAggregateOthersConnection(vhdExpression Expression)
	/// <summary>
	/// from vhdPredefinedAttributeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Attribute"></param>
	public vhdAggregateOthersConnection(vhdExpression Source, vhdPredefinedAttribute Attribute)
	{
		this.Expression = new vhdPredefinedAttributeExpression(Source, Attribute);
	}
	/// <summary>
	/// from vhdProcedureCallExpression
	/// </summary>
	/// <param name="Proc"></param>
	/// <param name="Parameters"></param>
	public vhdAggregateOthersConnection(String Proc, IEnumerable<vhdExpression> Parameters)
	{
		this.Expression = new vhdProcedureCallExpression(Proc, Parameters);
	}
	/// <summary>
	/// from vhdResizeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdAggregateOthersConnection(vhdExpression Source, vhdExpression Length)
	{
		this.Expression = new vhdResizeExpression(Source, Length);
	}
	/// <summary>
	/// from vhdShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdAggregateOthersConnection(vhdExpression Lhs, vhdShiftType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vhdAggregateOthersConnection(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	{
		this.Expression = new vhdTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vhdUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdAggregateOthersConnection(vhdUnaryType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdUnaryExpression(Type, Rhs);
	}
	public vhdExpression Expression { get; set; }
}
public partial class vhdAlias : vhdAbstractObject, vhdProcessDeclarationsChild
{
	public vhdAlias() { }
	public vhdAlias(String Alias, vhdExpression Expression)
	{
		this.Alias = Alias;
		this.Expression = Expression;
	}
	public String Alias { get; set; }
	public vhdExpression Expression { get; set; }
}
public partial class vhdArchitecture : vhdAbstractObject, vhdFileChild, IEnumerable//<vhdArchitectureDeclarationsChild>
{
	public vhdArchitecture() { }
	// Declarations single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Declarations as IEnumerable).GetEnumerator();
	public void Add(vhdArchitectureDeclarationsChild child)
	{
		Declarations.Add(child);
	}
	public vhdArchitecture(String Type, String Entity)
	{
		this.Type = Type;
		this.Entity = Entity;
	}
	public String Type { get; set; }
	public String Entity { get; set; }
	public vhdArchitectureDeclarations Declarations { get; set; } = new vhdArchitectureDeclarations();
	public vhdArchitectureImplementation Implementation { get; set; } = new vhdArchitectureImplementation();
}
/// <summary>
/// vhdComment
/// vhdText
/// vhdDefaultSignal
/// vhdLogicSignal
/// vhdArrayTypeDeclaration
/// </summary>
public interface vhdArchitectureDeclarationsChild
{
}
public partial class vhdArchitectureDeclarations : vhdAbstractCollection, IEnumerable//<vhdArchitectureDeclarationsChild>
{
	public vhdArchitectureDeclarations() { }
	// vhdAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	public void Add(vhdArchitectureDeclarationsChild child)
	{
		var typed = child as vhdAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
public partial class vhdArchitectureImplementation : vhdAbstractObject, IEnumerable//<vhdArchitectureImplementationBlockChild>
{
	public vhdArchitectureImplementation() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	public void Add(vhdArchitectureImplementationBlockChild child)
	{
		Block.Add(child);
	}
	public vhdArchitectureImplementation(vhdArchitectureImplementationBlock Block)
	{
		this.Block = Block;
	}
	public vhdArchitectureImplementationBlock Block { get; set; } = new vhdArchitectureImplementationBlock();
}
/// <summary>
/// vhdEntityInstance
/// </summary>
public interface vhdArchitectureImplementationBlockChild
{
}
public partial class vhdArchitectureImplementationBlock : vhdBlock, IEnumerable//<vhdArchitectureImplementationBlockChild>
{
	public vhdArchitectureImplementationBlock() { }
	// vhdAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	public void Add(vhdArchitectureImplementationBlockChild child)
	{
		var typed = child as vhdAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
public partial class vhdArrayTypeDeclaration : vhdTypeDeclaration, vhdArchitectureDeclarationsChild, vhdProcessDeclarationsChild
{
	public vhdArrayTypeDeclaration() { }
	public vhdArrayTypeDeclaration(String Name, Int32 Depth, vhdDataType Type, Int32 Width)
	{
		this.Name = Name;
		this.Depth = Depth;
		this.Type = Type;
		this.Width = Width;
	}
	public Int32 Depth { get; set; }
	public vhdDataType Type { get; set; }
	public Int32 Width { get; set; }
}
public partial class vhdAssignExpression : vhdExpression, vhdArchitectureImplementationBlockChild, vhdGenericBlockChild
{
	public vhdAssignExpression() { }
	public vhdAssignExpression(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Target = Target;
		this.Type = Type;
		this.Source = Source;
	}
	public vhdExpression Target { get; set; }
	public vhdAssignType Type { get; set; }
	public vhdExpression Source { get; set; }
}
public partial class vhdAttribute : vhdAbstractObject, vhdFileChild
{
	public vhdAttribute() { }
	public vhdAttribute(String Name, String Target, String Value)
	{
		this.Name = Name;
		this.Target = Target;
		this.Value = Value;
	}
	public String Name { get; set; }
	public String Target { get; set; }
	public String Value { get; set; }
}
public partial class vhdBinaryValueExpression : vhdExpression
{
	public vhdBinaryValueExpression() { }
	public vhdBinaryValueExpression(RTLBitArray Value)
	{
		this.Value = Value;
	}
	public RTLBitArray Value { get; set; } = new RTLBitArray();
}
public abstract partial class vhdBlock : vhdAbstractCollection
{
	public vhdBlock() { }
}
public partial class vhdCase : vhdAbstractObject, vhdArchitectureImplementationBlockChild, vhdGenericBlockChild, IEnumerable//<vhdCaseStatement>
{
	public vhdCase() { }
	// vhdCaseStatement single list member
	IEnumerator IEnumerable.GetEnumerator() => (Statements as IEnumerable).GetEnumerator();
	public void Add(vhdCaseStatement child)
	{
		Statements.Add(child);
	}
	public vhdCase(vhdExpression Expression)
	{
		this.Expression = Expression;
	}
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	/// <param name="Aggregate"></param>
	public vhdCase(vhdAggregate Aggregate)
	{
		this.Expression = new vhdAggregateExpression(Aggregate);
	}
	/// <summary>
	/// from vhdAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdCase(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Expression = new vhdAssignExpression(Target, Type, Source);
	}
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vhdCase(RTLBitArray Value)
	{
		this.Expression = new vhdBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vhdCastExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdCase(vhdCastType Type, vhdExpression Source)
	{
		this.Expression = new vhdCastExpression(Type, Source);
	}
	/// <summary>
	/// from vhdCastResizeExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdCase(vhdCastType Type, vhdExpression Source, vhdExpression Length)
	{
		this.Expression = new vhdCastResizeExpression(Type, Source, Length);
	}
	/// <summary>
	/// from vhdCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCase(vhdExpression Lhs, vhdCompareType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vhdCase(vhdIdentifier Source)
	{
		this.Expression = new vhdIdentifierExpression(Source);
	}
	/// <summary>
	/// from vhdLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCase(vhdExpression Lhs, vhdLogicType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCase(vhdExpression Lhs, vhdMathType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdMathExpression(Lhs, Type, Rhs);
	}
	// from vhdParenthesizedExpression
	// ignored vhdCase(vhdExpression Expression)
	/// <summary>
	/// from vhdPredefinedAttributeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Attribute"></param>
	public vhdCase(vhdExpression Source, vhdPredefinedAttribute Attribute)
	{
		this.Expression = new vhdPredefinedAttributeExpression(Source, Attribute);
	}
	/// <summary>
	/// from vhdProcedureCallExpression
	/// </summary>
	/// <param name="Proc"></param>
	/// <param name="Parameters"></param>
	public vhdCase(String Proc, IEnumerable<vhdExpression> Parameters)
	{
		this.Expression = new vhdProcedureCallExpression(Proc, Parameters);
	}
	/// <summary>
	/// from vhdResizeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdCase(vhdExpression Source, vhdExpression Length)
	{
		this.Expression = new vhdResizeExpression(Source, Length);
	}
	/// <summary>
	/// from vhdShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCase(vhdExpression Lhs, vhdShiftType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vhdCase(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	{
		this.Expression = new vhdTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vhdUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCase(vhdUnaryType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdUnaryExpression(Type, Rhs);
	}
	public vhdExpression Expression { get; set; }
	public List<vhdCaseStatement> Statements { get; set; } = new List<vhdCaseStatement>();
}
public partial class vhdCaseStatement : vhdAbstractObject, IEnumerable//<vhdGenericBlockChild>
{
	public vhdCaseStatement() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	public void Add(vhdGenericBlockChild child)
	{
		Block.Add(child);
	}
	public vhdCaseStatement(vhdExpression When)
	{
		this.When = When;
	}
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	/// <param name="Aggregate"></param>
	public vhdCaseStatement(vhdAggregate Aggregate)
	{
		this.When = new vhdAggregateExpression(Aggregate);
	}
	/// <summary>
	/// from vhdAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdCaseStatement(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.When = new vhdAssignExpression(Target, Type, Source);
	}
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vhdCaseStatement(RTLBitArray Value)
	{
		this.When = new vhdBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vhdCastExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdCaseStatement(vhdCastType Type, vhdExpression Source)
	{
		this.When = new vhdCastExpression(Type, Source);
	}
	/// <summary>
	/// from vhdCastResizeExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdCaseStatement(vhdCastType Type, vhdExpression Source, vhdExpression Length)
	{
		this.When = new vhdCastResizeExpression(Type, Source, Length);
	}
	/// <summary>
	/// from vhdCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCaseStatement(vhdExpression Lhs, vhdCompareType Type, vhdExpression Rhs)
	{
		this.When = new vhdCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vhdCaseStatement(vhdIdentifier Source)
	{
		this.When = new vhdIdentifierExpression(Source);
	}
	/// <summary>
	/// from vhdLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCaseStatement(vhdExpression Lhs, vhdLogicType Type, vhdExpression Rhs)
	{
		this.When = new vhdLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCaseStatement(vhdExpression Lhs, vhdMathType Type, vhdExpression Rhs)
	{
		this.When = new vhdMathExpression(Lhs, Type, Rhs);
	}
	// from vhdParenthesizedExpression
	// ignored vhdCaseStatement(vhdExpression Expression)
	/// <summary>
	/// from vhdPredefinedAttributeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Attribute"></param>
	public vhdCaseStatement(vhdExpression Source, vhdPredefinedAttribute Attribute)
	{
		this.When = new vhdPredefinedAttributeExpression(Source, Attribute);
	}
	/// <summary>
	/// from vhdProcedureCallExpression
	/// </summary>
	/// <param name="Proc"></param>
	/// <param name="Parameters"></param>
	public vhdCaseStatement(String Proc, IEnumerable<vhdExpression> Parameters)
	{
		this.When = new vhdProcedureCallExpression(Proc, Parameters);
	}
	/// <summary>
	/// from vhdResizeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdCaseStatement(vhdExpression Source, vhdExpression Length)
	{
		this.When = new vhdResizeExpression(Source, Length);
	}
	/// <summary>
	/// from vhdShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCaseStatement(vhdExpression Lhs, vhdShiftType Type, vhdExpression Rhs)
	{
		this.When = new vhdShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vhdCaseStatement(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	{
		this.When = new vhdTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vhdUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdCaseStatement(vhdUnaryType Type, vhdExpression Rhs)
	{
		this.When = new vhdUnaryExpression(Type, Rhs);
	}
	public vhdExpression When { get; set; }
	public vhdGenericBlock Block { get; set; } = new vhdGenericBlock();
}
public partial class vhdCastExpression : vhdExpression
{
	public vhdCastExpression() { }
	public vhdCastExpression(vhdCastType Type, vhdExpression Source)
	{
		this.Type = Type;
		this.Source = Source;
	}
	public vhdCastType Type { get; set; }
	public vhdExpression Source { get; set; }
}
public partial class vhdCastResizeExpression : vhdExpression
{
	public vhdCastResizeExpression() { }
	public vhdCastResizeExpression(vhdCastType Type, vhdExpression Source, vhdExpression Length)
	{
		this.Type = Type;
		this.Source = Source;
		this.Length = Length;
	}
	public vhdCastType Type { get; set; }
	public vhdExpression Source { get; set; }
	public vhdExpression Length { get; set; }
}
public partial class vhdComment : vhdAbstractObject, vhdArchitectureDeclarationsChild, vhdArchitectureImplementationBlockChild, vhdEntityInstancePortMappingsChild, vhdEntityInterfaceChild, vhdFileChild, vhdGenericBlockChild, vhdProcessDeclarationsChild
{
	public vhdComment() { }
	public vhdComment(IEnumerable<String> Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public vhdComment(params String[] Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public List<String> Lines { get; set; } = new List<String>();
}
public partial class vhdCompareExpression : vhdExpression
{
	public vhdCompareExpression() { }
	public vhdCompareExpression(vhdExpression Lhs, vhdCompareType Type, vhdExpression Rhs)
	{
		this.Lhs = Lhs;
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vhdExpression Lhs { get; set; }
	public vhdCompareType Type { get; set; }
	public vhdExpression Rhs { get; set; }
}
public partial class vhdConditionalStatement : vhdAbstractObject, IEnumerable//<vhdGenericBlockChild>
{
	public vhdConditionalStatement() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	public void Add(vhdGenericBlockChild child)
	{
		Block.Add(child);
	}
	public vhdConditionalStatement(vhdExpression Condition)
	{
		this.Condition = Condition;
	}
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	/// <param name="Aggregate"></param>
	public vhdConditionalStatement(vhdAggregate Aggregate)
	{
		this.Condition = new vhdAggregateExpression(Aggregate);
	}
	/// <summary>
	/// from vhdAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdConditionalStatement(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Condition = new vhdAssignExpression(Target, Type, Source);
	}
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vhdConditionalStatement(RTLBitArray Value)
	{
		this.Condition = new vhdBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vhdCastExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdConditionalStatement(vhdCastType Type, vhdExpression Source)
	{
		this.Condition = new vhdCastExpression(Type, Source);
	}
	/// <summary>
	/// from vhdCastResizeExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdConditionalStatement(vhdCastType Type, vhdExpression Source, vhdExpression Length)
	{
		this.Condition = new vhdCastResizeExpression(Type, Source, Length);
	}
	/// <summary>
	/// from vhdCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdConditionalStatement(vhdExpression Lhs, vhdCompareType Type, vhdExpression Rhs)
	{
		this.Condition = new vhdCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vhdConditionalStatement(vhdIdentifier Source)
	{
		this.Condition = new vhdIdentifierExpression(Source);
	}
	/// <summary>
	/// from vhdLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdConditionalStatement(vhdExpression Lhs, vhdLogicType Type, vhdExpression Rhs)
	{
		this.Condition = new vhdLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdConditionalStatement(vhdExpression Lhs, vhdMathType Type, vhdExpression Rhs)
	{
		this.Condition = new vhdMathExpression(Lhs, Type, Rhs);
	}
	// from vhdParenthesizedExpression
	// ignored vhdConditionalStatement(vhdExpression Expression)
	/// <summary>
	/// from vhdPredefinedAttributeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Attribute"></param>
	public vhdConditionalStatement(vhdExpression Source, vhdPredefinedAttribute Attribute)
	{
		this.Condition = new vhdPredefinedAttributeExpression(Source, Attribute);
	}
	/// <summary>
	/// from vhdProcedureCallExpression
	/// </summary>
	/// <param name="Proc"></param>
	/// <param name="Parameters"></param>
	public vhdConditionalStatement(String Proc, IEnumerable<vhdExpression> Parameters)
	{
		this.Condition = new vhdProcedureCallExpression(Proc, Parameters);
	}
	/// <summary>
	/// from vhdResizeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdConditionalStatement(vhdExpression Source, vhdExpression Length)
	{
		this.Condition = new vhdResizeExpression(Source, Length);
	}
	/// <summary>
	/// from vhdShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdConditionalStatement(vhdExpression Lhs, vhdShiftType Type, vhdExpression Rhs)
	{
		this.Condition = new vhdShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vhdConditionalStatement(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	{
		this.Condition = new vhdTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vhdUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdConditionalStatement(vhdUnaryType Type, vhdExpression Rhs)
	{
		this.Condition = new vhdUnaryExpression(Type, Rhs);
	}
	public vhdExpression Condition { get; set; }
	public vhdGenericBlock Block { get; set; } = new vhdGenericBlock();
}
public partial class vhdCustomDataType : vhdDataTypeSource
{
	public vhdCustomDataType() { }
	public vhdCustomDataType(String DataType)
	{
		this.DataType = DataType;
	}
	public String DataType { get; set; }
}
public partial class vhdCustomEntityPort : vhdEntityPort, vhdEntityInterfaceChild
{
	public vhdCustomEntityPort() { }
	public vhdCustomEntityPort(String Name, vhdPortDirection Direction, String Declaration, String Initializer)
	{
		this.Name = Name;
		this.Direction = Direction;
		this.Declaration = Declaration;
		this.Initializer = Initializer;
	}
	public String Declaration { get; set; }
	public String Initializer { get; set; }
}
public partial class vhdCustomNetType : vhdNetTypeSource
{
	public vhdCustomNetType() { }
	public vhdCustomNetType(String NetType)
	{
		this.NetType = NetType;
	}
	public String NetType { get; set; }
}
public abstract partial class vhdDataTypeSource : vhdAbstractObject
{
	public vhdDataTypeSource() { }
}
public partial class vhdDefaultDataType : vhdDataTypeSource
{
	public vhdDefaultDataType() { }
	public vhdDefaultDataType(vhdDataType DataType)
	{
		this.DataType = DataType;
	}
	public vhdDataType DataType { get; set; }
}
public partial class vhdDefaultNetType : vhdNetTypeSource
{
	public vhdDefaultNetType() { }
	public vhdDefaultNetType(vhdNetType NetType)
	{
		this.NetType = NetType;
	}
	public vhdNetType NetType { get; set; }
}
public partial class vhdDefaultSignal : vhdNet, vhdArchitectureDeclarationsChild, vhdProcessDeclarationsChild
{
	public vhdDefaultSignal() { }
	public vhdDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width, IEnumerable<String> Initializer)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.DataType = DataType;
		this.Width = Width;
		this.Initializer = (Initializer ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public vhdDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width, params String[] Initializer)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.DataType = DataType;
		this.Width = Width;
		this.Initializer = (Initializer ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public vhdDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.DataType = DataType;
		this.Width = Width;
	}
	public vhdDataTypeSource DataType { get; set; }
	public Int32 Width { get; set; }
	public List<String> Initializer { get; set; } = new List<String>();
}
public partial class vhdEntity : vhdAbstractObject, vhdFileChild, IEnumerable//<vhdEntityInterfaceChild>
{
	public vhdEntity() { }
	// Interface single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Interface as IEnumerable).GetEnumerator();
	public void Add(vhdEntityInterfaceChild child)
	{
		Interface.Add(child);
	}
	public vhdEntity(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
	public vhdEntityInterface Interface { get; set; } = new vhdEntityInterface();
}
public partial class vhdEntityInstance : vhdAbstractObject, vhdArchitectureImplementationBlockChild, IEnumerable//<vhdEntityInstancePortMappingsChild>
{
	public vhdEntityInstance() { }
	// PortMappings single object collection
	IEnumerator IEnumerable.GetEnumerator() => (PortMappings as IEnumerable).GetEnumerator();
	public void Add(vhdEntityInstancePortMappingsChild child)
	{
		PortMappings.Add(child);
	}
	public vhdEntityInstance(String Name, String Type)
	{
		this.Name = Name;
		this.Type = Type;
	}
	public String Name { get; set; }
	public String Type { get; set; }
	public vhdEntityInstancePortMappings PortMappings { get; set; } = new vhdEntityInstancePortMappings();
}
public partial class vhdEntityInstanceNamedPortMapping : vhdEntityInstancePortMapping, vhdEntityInstancePortMappingsChild
{
	public vhdEntityInstanceNamedPortMapping() { }
	public vhdEntityInstanceNamedPortMapping(String Internal, vhdExpression External)
	{
		this.Internal = Internal;
		this.External = External;
	}
	public String Internal { get; set; }
	public vhdExpression External { get; set; }
}
public abstract partial class vhdEntityInstancePortMapping : vhdAbstractObject
{
	public vhdEntityInstancePortMapping() { }
}
/// <summary>
/// vhdComment
/// vhdText
/// vhdEntityInstanceNamedPortMapping
/// </summary>
public interface vhdEntityInstancePortMappingsChild
{
}
public partial class vhdEntityInstancePortMappings : vhdAbstractCollection, IEnumerable//<vhdEntityInstancePortMappingsChild>
{
	public vhdEntityInstancePortMappings() { }
	// vhdAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	public void Add(vhdEntityInstancePortMappingsChild child)
	{
		var typed = child as vhdAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
/// <summary>
/// vhdComment
/// vhdText
/// vhdCustomEntityPort
/// vhdStandardEntityPort
/// </summary>
public interface vhdEntityInterfaceChild
{
}
public partial class vhdEntityInterface : vhdAbstractCollection, IEnumerable//<vhdEntityInterfaceChild>
{
	public vhdEntityInterface() { }
	// vhdAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	public void Add(vhdEntityInterfaceChild child)
	{
		var typed = child as vhdAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
public abstract partial class vhdEntityPort : vhdAbstractObject
{
	public vhdEntityPort() { }
	public vhdEntityPort(String Name, vhdPortDirection Direction)
	{
		this.Name = Name;
		this.Direction = Direction;
	}
	public String Name { get; set; }
	public vhdPortDirection Direction { get; set; }
}
public abstract partial class vhdExpression : vhdAbstractObject
{
	public vhdExpression() { }
}
/// <summary>
/// vhdComment
/// vhdText
/// vhdLibraryReference
/// vhdUse
/// vhdEntity
/// vhdArchitecture
/// vhdAttribute
/// </summary>
public interface vhdFileChild
{
}
public partial class vhdFile : vhdAbstractCollection, IEnumerable//<vhdFileChild>
{
	public vhdFile() { }
	// vhdAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	public void Add(vhdFileChild child)
	{
		var typed = child as vhdAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
/// <summary>
/// vhdGenericBlock
/// </summary>
public interface vhdGenericBlockChild
{
}
public partial class vhdGenericBlock : vhdBlock, vhdGenericBlockChild, IEnumerable//<vhdGenericBlockChild>
{
	public vhdGenericBlock() { }
	// vhdAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	public void Add(vhdGenericBlockChild child)
	{
		var typed = child as vhdAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
public partial class vhdIdentifier : vhdAbstractObject, IEnumerable//<vhdRange>
{
	public vhdIdentifier() { }
	// vhdRange single list member
	IEnumerator IEnumerable.GetEnumerator() => (Indexes as IEnumerable).GetEnumerator();
	public void Add(vhdRange child)
	{
		Indexes.Add(child);
	}
	public vhdIdentifier(String Name, IEnumerable<vhdRange> Indexes)
	{
		this.Name = Name;
		this.Indexes = (Indexes ?? Enumerable.Empty<vhdRange>()).Where(s => s != null).ToList();
	}
	public vhdIdentifier(String Name, params vhdRange[] Indexes)
	{
		this.Name = Name;
		this.Indexes = (Indexes ?? Enumerable.Empty<vhdRange>()).Where(s => s != null).ToList();
	}
	public vhdIdentifier(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
	public List<vhdRange> Indexes { get; set; } = new List<vhdRange>();
}
public partial class vhdIdentifierExpression : vhdExpression
{
	public vhdIdentifierExpression() { }
	public vhdIdentifierExpression(String Name, IEnumerable<vhdRange> Indexes)
	{
		this.Source = new vhdIdentifier(Name, Indexes);
	}
	public vhdIdentifierExpression(String Name, params vhdRange[] Indexes)
	{
		this.Source = new vhdIdentifier(Name, Indexes);
	}
	public vhdIdentifierExpression(vhdIdentifier Source)
	{
		this.Source = Source;
	}
	public vhdIdentifier Source { get; set; } = new vhdIdentifier();
}
public partial class vhdIf : vhdAbstractObject, vhdArchitectureImplementationBlockChild, vhdGenericBlockChild, IEnumerable//<vhdConditionalStatement>
{
	public vhdIf() { }
	// vhdConditionalStatement single list member
	IEnumerator IEnumerable.GetEnumerator() => (Statements as IEnumerable).GetEnumerator();
	public void Add(vhdConditionalStatement child)
	{
		Statements.Add(child);
	}
	public List<vhdConditionalStatement> Statements { get; set; } = new List<vhdConditionalStatement>();
}
public partial class vhdLibraryReference : vhdAbstractObject, vhdFileChild
{
	public vhdLibraryReference() { }
	public vhdLibraryReference(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vhdLogicExpression : vhdExpression
{
	public vhdLogicExpression() { }
	public vhdLogicExpression(vhdExpression Lhs, vhdLogicType Type, vhdExpression Rhs)
	{
		this.Lhs = Lhs;
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vhdExpression Lhs { get; set; }
	public vhdLogicType Type { get; set; }
	public vhdExpression Rhs { get; set; }
}
public partial class vhdLogicSignal : vhdNet, vhdArchitectureDeclarationsChild, vhdProcessDeclarationsChild
{
	public vhdLogicSignal() { }
	public vhdLogicSignal(vhdNetTypeSource NetType, String Name, IEnumerable<RTLBitArray> Initializer)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.Initializer = (Initializer ?? Enumerable.Empty<RTLBitArray>()).Where(s => s != null).ToList();
	}
	public vhdLogicSignal(vhdNetTypeSource NetType, String Name, params RTLBitArray[] Initializer)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.Initializer = (Initializer ?? Enumerable.Empty<RTLBitArray>()).Where(s => s != null).ToList();
	}
	public vhdLogicSignal(vhdNetTypeSource NetType, String Name)
	{
		this.NetType = NetType;
		this.Name = Name;
	}
	public List<RTLBitArray> Initializer { get; set; } = new List<RTLBitArray>();
}
public partial class vhdMathExpression : vhdExpression
{
	public vhdMathExpression() { }
	public vhdMathExpression(vhdExpression Lhs, vhdMathType Type, vhdExpression Rhs)
	{
		this.Lhs = Lhs;
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vhdExpression Lhs { get; set; }
	public vhdMathType Type { get; set; }
	public vhdExpression Rhs { get; set; }
}
public abstract partial class vhdNet : vhdAbstractObject
{
	public vhdNet() { }
	public vhdNet(vhdNetTypeSource NetType, String Name)
	{
		this.NetType = NetType;
		this.Name = Name;
	}
	public vhdNetTypeSource NetType { get; set; }
	public String Name { get; set; }
}
public abstract partial class vhdNetTypeSource : vhdAbstractObject
{
	public vhdNetTypeSource() { }
}
public partial class vhdNull : vhdAbstractObject, vhdArchitectureImplementationBlockChild, vhdGenericBlockChild
{
	public vhdNull() { }
}
public partial class vhdOthersExpression : vhdExpression
{
	public vhdOthersExpression() { }
}
public partial class vhdParenthesizedExpression : vhdExpression
{
	public vhdParenthesizedExpression() { }
	public vhdParenthesizedExpression(vhdExpression Expression)
	{
		this.Expression = Expression;
	}
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	/// <param name="Aggregate"></param>
	public vhdParenthesizedExpression(vhdAggregate Aggregate)
	{
		this.Expression = new vhdAggregateExpression(Aggregate);
	}
	/// <summary>
	/// from vhdAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdParenthesizedExpression(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Expression = new vhdAssignExpression(Target, Type, Source);
	}
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vhdParenthesizedExpression(RTLBitArray Value)
	{
		this.Expression = new vhdBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vhdCastExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdParenthesizedExpression(vhdCastType Type, vhdExpression Source)
	{
		this.Expression = new vhdCastExpression(Type, Source);
	}
	/// <summary>
	/// from vhdCastResizeExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdParenthesizedExpression(vhdCastType Type, vhdExpression Source, vhdExpression Length)
	{
		this.Expression = new vhdCastResizeExpression(Type, Source, Length);
	}
	/// <summary>
	/// from vhdCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdParenthesizedExpression(vhdExpression Lhs, vhdCompareType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vhdParenthesizedExpression(vhdIdentifier Source)
	{
		this.Expression = new vhdIdentifierExpression(Source);
	}
	/// <summary>
	/// from vhdLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdParenthesizedExpression(vhdExpression Lhs, vhdLogicType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdParenthesizedExpression(vhdExpression Lhs, vhdMathType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdMathExpression(Lhs, Type, Rhs);
	}
	// from vhdParenthesizedExpression
	// ignored vhdParenthesizedExpression(vhdExpression Expression)
	/// <summary>
	/// from vhdPredefinedAttributeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Attribute"></param>
	public vhdParenthesizedExpression(vhdExpression Source, vhdPredefinedAttribute Attribute)
	{
		this.Expression = new vhdPredefinedAttributeExpression(Source, Attribute);
	}
	/// <summary>
	/// from vhdProcedureCallExpression
	/// </summary>
	/// <param name="Proc"></param>
	/// <param name="Parameters"></param>
	public vhdParenthesizedExpression(String Proc, IEnumerable<vhdExpression> Parameters)
	{
		this.Expression = new vhdProcedureCallExpression(Proc, Parameters);
	}
	/// <summary>
	/// from vhdResizeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdParenthesizedExpression(vhdExpression Source, vhdExpression Length)
	{
		this.Expression = new vhdResizeExpression(Source, Length);
	}
	/// <summary>
	/// from vhdShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdParenthesizedExpression(vhdExpression Lhs, vhdShiftType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vhdParenthesizedExpression(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	{
		this.Expression = new vhdTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vhdUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdParenthesizedExpression(vhdUnaryType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdUnaryExpression(Type, Rhs);
	}
	public vhdExpression Expression { get; set; }
}
public partial class vhdPredefinedAttributeExpression : vhdExpression
{
	public vhdPredefinedAttributeExpression() { }
	public vhdPredefinedAttributeExpression(vhdExpression Source, vhdPredefinedAttribute Attribute)
	{
		this.Source = Source;
		this.Attribute = Attribute;
	}
	public vhdExpression Source { get; set; }
	public vhdPredefinedAttribute Attribute { get; set; }
}
public partial class vhdProcedureCall : vhdAbstractObject, vhdArchitectureImplementationBlockChild, vhdGenericBlockChild, IEnumerable//<vhdExpression>
{
	public vhdProcedureCall() { }
	// vhdExpression single list member
	IEnumerator IEnumerable.GetEnumerator() => (Parameters as IEnumerable).GetEnumerator();
	public void Add(vhdExpression child)
	{
		Parameters.Add(child);
	}
	public vhdProcedureCall(String Proc, IEnumerable<vhdExpression> Parameters)
	{
		this.Proc = Proc;
		this.Parameters = (Parameters ?? Enumerable.Empty<vhdExpression>()).Where(s => s != null).ToList();
	}
	public vhdProcedureCall(String Proc, params vhdExpression[] Parameters)
	{
		this.Proc = Proc;
		this.Parameters = (Parameters ?? Enumerable.Empty<vhdExpression>()).Where(s => s != null).ToList();
	}
	public vhdProcedureCall(String Proc)
	{
		this.Proc = Proc;
	}
	public String Proc { get; set; }
	/// <summary>
	/// vhdAggregateExpression
	///
	/// vhdAssignExpression
	///
	/// vhdBinaryValueExpression
	///
	/// vhdCastExpression
	///
	/// vhdCastResizeExpression
	///
	/// vhdCompareExpression
	///
	/// vhdIdentifierExpression
	///
	/// vhdLogicExpression
	///
	/// vhdMathExpression
	///
	/// vhdOthersExpression
	///
	/// vhdParenthesizedExpression
	///
	/// vhdPredefinedAttributeExpression
	///
	/// vhdProcedureCallExpression
	///
	/// vhdResizeExpression
	///
	/// vhdShiftExpression
	///
	/// vhdTernaryExpression
	///
	/// vhdUnaryExpression
	///
	/// </summary>
	public List<vhdExpression> Parameters { get; set; } = new List<vhdExpression>();
}
public partial class vhdProcedureCallExpression : vhdExpression, IEnumerable//<vhdExpression>
{
	public vhdProcedureCallExpression() { }
	// vhdExpression single list member
	IEnumerator IEnumerable.GetEnumerator() => (Parameters as IEnumerable).GetEnumerator();
	public void Add(vhdExpression child)
	{
		Parameters.Add(child);
	}
	public vhdProcedureCallExpression(String Proc, IEnumerable<vhdExpression> Parameters)
	{
		this.Proc = Proc;
		this.Parameters = (Parameters ?? Enumerable.Empty<vhdExpression>()).Where(s => s != null).ToList();
	}
	public vhdProcedureCallExpression(String Proc, params vhdExpression[] Parameters)
	{
		this.Proc = Proc;
		this.Parameters = (Parameters ?? Enumerable.Empty<vhdExpression>()).Where(s => s != null).ToList();
	}
	public String Proc { get; set; }
	/// <summary>
	/// vhdAggregateExpression
	///
	/// vhdAssignExpression
	///
	/// vhdBinaryValueExpression
	///
	/// vhdCastExpression
	///
	/// vhdCastResizeExpression
	///
	/// vhdCompareExpression
	///
	/// vhdIdentifierExpression
	///
	/// vhdLogicExpression
	///
	/// vhdMathExpression
	///
	/// vhdOthersExpression
	///
	/// vhdParenthesizedExpression
	///
	/// vhdPredefinedAttributeExpression
	///
	/// vhdProcedureCallExpression
	///
	/// vhdResizeExpression
	///
	/// vhdShiftExpression
	///
	/// vhdTernaryExpression
	///
	/// vhdUnaryExpression
	///
	/// </summary>
	public List<vhdExpression> Parameters { get; set; } = new List<vhdExpression>();
}
public partial class vhdProcess : vhdAbstractObject, vhdArchitectureImplementationBlockChild, vhdGenericBlockChild, IEnumerable//<vhdIdentifier>
{
	public vhdProcess() { }
	// vhdIdentifier single list member
	IEnumerator IEnumerable.GetEnumerator() => (SensitivityList as IEnumerable).GetEnumerator();
	public void Add(vhdIdentifier child)
	{
		SensitivityList.Add(child);
	}
	public vhdProcess(IEnumerable<vhdIdentifier> SensitivityList)
	{
		this.SensitivityList = (SensitivityList ?? Enumerable.Empty<vhdIdentifier>()).Where(s => s != null).ToList();
	}
	public vhdProcess(params vhdIdentifier[] SensitivityList)
	{
		this.SensitivityList = (SensitivityList ?? Enumerable.Empty<vhdIdentifier>()).Where(s => s != null).ToList();
	}
	/// <summary>
	/// from vhdIdentifier
	/// </summary>
	/// <param name="Name"></param>
	/// <param name="Indexes"></param>
	public vhdProcess(String Name, IEnumerable<vhdRange> Indexes)
	{
		this.SensitivityList.Add(new vhdIdentifier(Name, Indexes));
	}
	/// <summary>
	/// from vhdIdentifier
	/// </summary>
	/// <param name="Name"></param>
	public vhdProcess(String Name)
	{
		this.SensitivityList.Add(new vhdIdentifier(Name));
	}
	public List<vhdIdentifier> SensitivityList { get; set; } = new List<vhdIdentifier>();
	public vhdProcessDeclarations Declarations { get; set; } = new vhdProcessDeclarations();
	public vhdGenericBlock Block { get; set; } = new vhdGenericBlock();
}
/// <summary>
/// vhdComment
/// vhdText
/// vhdDefaultSignal
/// vhdLogicSignal
/// vhdArrayTypeDeclaration
/// vhdAlias
/// </summary>
public interface vhdProcessDeclarationsChild
{
}
public partial class vhdProcessDeclarations : vhdAbstractCollection, IEnumerable//<vhdProcessDeclarationsChild>
{
	public vhdProcessDeclarations() { }
	// vhdAbstractObject collection
	IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
	public void Add(vhdProcessDeclarationsChild child)
	{
		var typed = child as vhdAbstractObject;
		if (typed == null) throw new Exception($"Type of child object is not expected: {child?.GetType()}");
		Children.Add(typed);
	}
}
public partial class vhdRange : vhdAbstractObject, IEnumerable//<vhdExpression>
{
	public vhdRange() { }
	// vhdExpression single list member
	IEnumerator IEnumerable.GetEnumerator() => (Indexes as IEnumerable).GetEnumerator();
	public void Add(vhdExpression child)
	{
		Indexes.Add(child);
	}
	public vhdRange(IEnumerable<vhdExpression> Indexes)
	{
		this.Indexes = (Indexes ?? Enumerable.Empty<vhdExpression>()).Where(s => s != null).ToList();
	}
	public vhdRange(params vhdExpression[] Indexes)
	{
		this.Indexes = (Indexes ?? Enumerable.Empty<vhdExpression>()).Where(s => s != null).ToList();
	}
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	/// <param name="Aggregate"></param>
	public vhdRange(vhdAggregate Aggregate)
	{
		this.Indexes.Add(new vhdAggregateExpression(Aggregate));
	}
	/// <summary>
	/// from vhdAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdRange(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Indexes.Add(new vhdAssignExpression(Target, Type, Source));
	}
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vhdRange(RTLBitArray Value)
	{
		this.Indexes.Add(new vhdBinaryValueExpression(Value));
	}
	/// <summary>
	/// from vhdCastExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdRange(vhdCastType Type, vhdExpression Source)
	{
		this.Indexes.Add(new vhdCastExpression(Type, Source));
	}
	/// <summary>
	/// from vhdCastResizeExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdRange(vhdCastType Type, vhdExpression Source, vhdExpression Length)
	{
		this.Indexes.Add(new vhdCastResizeExpression(Type, Source, Length));
	}
	/// <summary>
	/// from vhdCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdRange(vhdExpression Lhs, vhdCompareType Type, vhdExpression Rhs)
	{
		this.Indexes.Add(new vhdCompareExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vhdRange(vhdIdentifier Source)
	{
		this.Indexes.Add(new vhdIdentifierExpression(Source));
	}
	/// <summary>
	/// from vhdLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdRange(vhdExpression Lhs, vhdLogicType Type, vhdExpression Rhs)
	{
		this.Indexes.Add(new vhdLogicExpression(Lhs, Type, Rhs));
	}
	/// <summary>
	/// from vhdMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdRange(vhdExpression Lhs, vhdMathType Type, vhdExpression Rhs)
	{
		this.Indexes.Add(new vhdMathExpression(Lhs, Type, Rhs));
	}
	// from vhdParenthesizedExpression
	// ignored vhdRange(vhdExpression Expression)
	/// <summary>
	/// from vhdPredefinedAttributeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Attribute"></param>
	public vhdRange(vhdExpression Source, vhdPredefinedAttribute Attribute)
	{
		this.Indexes.Add(new vhdPredefinedAttributeExpression(Source, Attribute));
	}
	/// <summary>
	/// from vhdProcedureCallExpression
	/// </summary>
	/// <param name="Proc"></param>
	/// <param name="Parameters"></param>
	public vhdRange(String Proc, IEnumerable<vhdExpression> Parameters)
	{
		this.Indexes.Add(new vhdProcedureCallExpression(Proc, Parameters));
	}
	// from vhdResizeExpression
	// ignored vhdRange(vhdExpression Source, vhdExpression Length)
	/// <summary>
	/// from vhdShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdRange(vhdExpression Lhs, vhdShiftType Type, vhdExpression Rhs)
	{
		this.Indexes.Add(new vhdShiftExpression(Lhs, Type, Rhs));
	}
	// from vhdTernaryExpression
	// ignored vhdRange(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	/// <summary>
	/// from vhdUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdRange(vhdUnaryType Type, vhdExpression Rhs)
	{
		this.Indexes.Add(new vhdUnaryExpression(Type, Rhs));
	}
	/// <summary>
	/// vhdAggregateExpression
	///
	/// vhdAssignExpression
	///
	/// vhdBinaryValueExpression
	///
	/// vhdCastExpression
	///
	/// vhdCastResizeExpression
	///
	/// vhdCompareExpression
	///
	/// vhdIdentifierExpression
	///
	/// vhdLogicExpression
	///
	/// vhdMathExpression
	///
	/// vhdOthersExpression
	///
	/// vhdParenthesizedExpression
	///
	/// vhdPredefinedAttributeExpression
	///
	/// vhdProcedureCallExpression
	///
	/// vhdResizeExpression
	///
	/// vhdShiftExpression
	///
	/// vhdTernaryExpression
	///
	/// vhdUnaryExpression
	///
	/// </summary>
	public List<vhdExpression> Indexes { get; set; } = new List<vhdExpression>();
}
public partial class vhdResizeExpression : vhdExpression
{
	public vhdResizeExpression() { }
	public vhdResizeExpression(vhdExpression Source, vhdExpression Length)
	{
		this.Source = Source;
		this.Length = Length;
	}
	public vhdExpression Source { get; set; }
	public vhdExpression Length { get; set; }
}
public partial class vhdShiftExpression : vhdExpression
{
	public vhdShiftExpression() { }
	public vhdShiftExpression(vhdExpression Lhs, vhdShiftType Type, vhdExpression Rhs)
	{
		this.Lhs = Lhs;
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vhdExpression Lhs { get; set; }
	public vhdShiftType Type { get; set; }
	public vhdExpression Rhs { get; set; }
}
public partial class vhdSimpleForLoop : vhdAbstractObject, vhdArchitectureImplementationBlockChild, vhdGenericBlockChild, IEnumerable//<vhdGenericBlockChild>
{
	public vhdSimpleForLoop() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	public void Add(vhdGenericBlockChild child)
	{
		Block.Add(child);
	}
	public vhdSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Iterator = Iterator;
		this.From = From;
		this.To = To;
	}
	public String Iterator { get; set; }
	public Int32 From { get; set; }
	public Int32 To { get; set; }
	public vhdGenericBlock Block { get; set; } = new vhdGenericBlock();
}
public partial class vhdStandardEntityPort : vhdEntityPort, vhdEntityInterfaceChild
{
	public vhdStandardEntityPort() { }
	public vhdStandardEntityPort(String Name, vhdPortDirection Direction, vhdDataType Sign, Int32 Width, String Initializer)
	{
		this.Name = Name;
		this.Direction = Direction;
		this.Sign = Sign;
		this.Width = Width;
		this.Initializer = Initializer;
	}
	public vhdDataType Sign { get; set; }
	public Int32 Width { get; set; }
	public String Initializer { get; set; }
}
public partial class vhdSyncBlock : vhdAbstractObject, vhdArchitectureImplementationBlockChild, vhdGenericBlockChild, IEnumerable//<vhdGenericBlockChild>
{
	public vhdSyncBlock() { }
	// Block single object collection
	IEnumerator IEnumerable.GetEnumerator() => (Block as IEnumerable).GetEnumerator();
	public void Add(vhdGenericBlockChild child)
	{
		Block.Add(child);
	}
	public vhdSyncBlock(vhdEdgeType Type, vhdExpression Source)
	{
		this.Type = Type;
		this.Source = Source;
	}
	public vhdEdgeType Type { get; set; }
	public vhdExpression Source { get; set; }
	public vhdGenericBlock Block { get; set; } = new vhdGenericBlock();
}
public partial class vhdTernaryExpression : vhdExpression
{
	public vhdTernaryExpression() { }
	public vhdTernaryExpression(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	{
		this.Condition = Condition;
		this.Lhs = Lhs;
		this.Rhs = Rhs;
	}
	public vhdExpression Condition { get; set; }
	public vhdExpression Lhs { get; set; }
	public vhdExpression Rhs { get; set; }
}
public partial class vhdText : vhdAbstractObject, vhdArchitectureDeclarationsChild, vhdArchitectureImplementationBlockChild, vhdEntityInstancePortMappingsChild, vhdEntityInterfaceChild, vhdFileChild, vhdGenericBlockChild, vhdProcessDeclarationsChild
{
	public vhdText() { }
	public vhdText(IEnumerable<String> Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public vhdText(params String[] Lines)
	{
		this.Lines = (Lines ?? Enumerable.Empty<String>()).Where(s => s != null).ToList();
	}
	public List<String> Lines { get; set; } = new List<String>();
}
public abstract partial class vhdTypeDeclaration : vhdAbstractObject
{
	public vhdTypeDeclaration() { }
	public vhdTypeDeclaration(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vhdUnaryExpression : vhdExpression
{
	public vhdUnaryExpression() { }
	public vhdUnaryExpression(vhdUnaryType Type, vhdExpression Rhs)
	{
		this.Type = Type;
		this.Rhs = Rhs;
	}
	public vhdUnaryType Type { get; set; }
	public vhdExpression Rhs { get; set; }
}
public partial class vhdUse : vhdAbstractObject, vhdFileChild
{
	public vhdUse() { }
	public vhdUse(String Value)
	{
		this.Value = Value;
	}
	public String Value { get; set; }
}
} // Quokka.RTL.VHDL
