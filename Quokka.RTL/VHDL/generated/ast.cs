using System;
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

	/// vhdAggregateBitConnection

	/// vhdAggregateExpression

	/// vhdAggregateOthersConnection

	/// vhdAlias

	/// vhdArchitecture

	/// vhdArchitectureDeclarations

	/// vhdArchitectureImplementation

	/// vhdArchitectureImplementationBlock

	/// vhdArrayTypeDeclaration

	/// vhdAssignExpression

	/// vhdAttribute

	/// vhdBinaryValueExpression

	/// vhdCase

	/// vhdCaseStatement

	/// vhdCastExpression

	/// vhdCastResizeExpression

	/// vhdComment

	/// vhdCompareExpression

	/// vhdConditionalStatement

	/// vhdCustomDataType

	/// vhdCustomEntityPort

	/// vhdCustomNetType

	/// vhdDefaultDataType

	/// vhdDefaultNetType

	/// vhdDefaultSignal

	/// vhdEntity

	/// vhdEntityInstance

	/// vhdEntityInstanceNamedPortMapping

	/// vhdEntityInstancePortMappings

	/// vhdEntityInterface

	/// vhdFile

	/// vhdGenericBlock

	/// vhdIdentifier

	/// vhdIdentifierExpression

	/// vhdIf

	/// vhdIndexedExpression

	/// vhdLibraryReference

	/// vhdLogicExpression

	/// vhdLogicSignal

	/// vhdMathExpression

	/// vhdNull

	/// vhdOthersExpression

	/// vhdParenthesizedExpression

	/// vhdPredefinedAttributeExpression

	/// vhdProcedureCall

	/// vhdProcess

	/// vhdProcessDeclarations

	/// vhdRange

	/// vhdResizeExpression

	/// vhdShiftExpression

	/// vhdSimpleForLoop

	/// vhdStandardEntityPort

	/// vhdSyncBlock

	/// vhdTernaryExpression

	/// vhdText

	/// vhdUnaryExpression

	/// vhdUse

	/// </summary>
	public List<vhdAbstractObject> Children { get; set; } = new List<vhdAbstractObject>();
}
public abstract partial class vhdAbstractObject
{
	public vhdAbstractObject() { }
}
public partial class vhdAggregate : vhdAbstractCollection
{
	public vhdAggregate() { }
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
public partial class vhdAggregateExpression : vhdExpression
{
	public vhdAggregateExpression() { }
	public vhdAggregateExpression(vhdAggregate Aggregate)
	{
		this.Aggregate = Aggregate;
	}
	public vhdAggregate Aggregate { get; set; } = new vhdAggregate();
}
public partial class vhdAggregateOthersConnection : vhdAbstractObject
{
	public vhdAggregateOthersConnection() { }
	public vhdAggregateOthersConnection(Boolean Value)
	{
		this.Value = Value;
	}
	public Boolean Value { get; set; }
}
public partial class vhdAlias : vhdAbstractObject
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
public partial class vhdArchitecture : vhdAbstractObject
{
	public vhdArchitecture() { }
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
public partial class vhdArchitectureDeclarations : vhdAbstractCollection
{
	public vhdArchitectureDeclarations() { }
}
public partial class vhdArchitectureImplementation : vhdAbstractObject
{
	public vhdArchitectureImplementation() { }
	public vhdArchitectureImplementation(vhdArchitectureImplementationBlock Block)
	{
		this.Block = Block;
	}
	public vhdArchitectureImplementationBlock Block { get; set; } = new vhdArchitectureImplementationBlock();
}
public partial class vhdArchitectureImplementationBlock : vhdBlock
{
	public vhdArchitectureImplementationBlock() { }
}
public partial class vhdArrayTypeDeclaration : vhdTypeDeclaration
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
public partial class vhdAssignExpression : vhdExpression
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
public partial class vhdAttribute : vhdAbstractObject
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
public partial class vhdCase : vhdAbstractObject
{
	public vhdCase() { }
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
	/// from vhdIndexedExpression
	/// </summary>
	/// <param name="Expression"></param>
	/// <param name="Indexes"></param>
	public vhdCase(vhdExpression Expression, params vhdRange[] Indexes)
	{
		this.Expression = new vhdIndexedExpression(Expression, Indexes);
	}
	// from vhdIndexedExpression
	// ignored vhdCase(vhdExpression Expression)
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
public partial class vhdCaseStatement : vhdAbstractObject
{
	public vhdCaseStatement() { }
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
	/// from vhdIndexedExpression
	/// </summary>
	/// <param name="Expression"></param>
	/// <param name="Indexes"></param>
	public vhdCaseStatement(vhdExpression Expression, params vhdRange[] Indexes)
	{
		this.When = new vhdIndexedExpression(Expression, Indexes);
	}
	// from vhdIndexedExpression
	// ignored vhdCaseStatement(vhdExpression Expression)
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
public partial class vhdComment : vhdAbstractObject
{
	public vhdComment() { }
	public vhdComment(params String[] Lines)
	{
		this.Lines = (Lines ?? Array.Empty<String>()).Where(s => s != null).ToList();
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
public partial class vhdConditionalStatement : vhdAbstractObject
{
	public vhdConditionalStatement() { }
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
	/// from vhdIndexedExpression
	/// </summary>
	/// <param name="Expression"></param>
	/// <param name="Indexes"></param>
	public vhdConditionalStatement(vhdExpression Expression, params vhdRange[] Indexes)
	{
		this.Condition = new vhdIndexedExpression(Expression, Indexes);
	}
	// from vhdIndexedExpression
	// ignored vhdConditionalStatement(vhdExpression Expression)
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
public partial class vhdCustomEntityPort : vhdEntityPort
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
public partial class vhdDefaultSignal : vhdNet
{
	public vhdDefaultSignal() { }
	public vhdDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width, params String[] Initializer)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.DataType = DataType;
		this.Width = Width;
		this.Initializer = (Initializer ?? Array.Empty<String>()).Where(s => s != null).ToList();
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
public partial class vhdEntity : vhdAbstractObject
{
	public vhdEntity() { }
	public vhdEntity(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
	public vhdEntityInterface Interface { get; set; } = new vhdEntityInterface();
}
public partial class vhdEntityInstance : vhdAbstractObject
{
	public vhdEntityInstance() { }
	public vhdEntityInstance(String Name, String Type)
	{
		this.Name = Name;
		this.Type = Type;
	}
	public String Name { get; set; }
	public String Type { get; set; }
	public vhdEntityInstancePortMappings PortMappings { get; set; } = new vhdEntityInstancePortMappings();
}
public partial class vhdEntityInstanceNamedPortMapping : vhdEntityInstancePortMapping
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
public partial class vhdEntityInstancePortMappings : vhdAbstractCollection
{
	public vhdEntityInstancePortMappings() { }
}
public partial class vhdEntityInterface : vhdAbstractCollection
{
	public vhdEntityInterface() { }
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
public partial class vhdFile : vhdAbstractCollection
{
	public vhdFile() { }
}
public partial class vhdGenericBlock : vhdBlock
{
	public vhdGenericBlock() { }
}
public partial class vhdIdentifier : vhdAbstractObject
{
	public vhdIdentifier() { }
	public vhdIdentifier(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vhdIdentifierExpression : vhdExpression
{
	public vhdIdentifierExpression() { }
	public vhdIdentifierExpression(String Name)
	{
		this.Source = new vhdIdentifier(Name);
	}
	public vhdIdentifierExpression(vhdIdentifier Source)
	{
		this.Source = Source;
	}
	public vhdIdentifier Source { get; set; } = new vhdIdentifier();
}
public partial class vhdIf : vhdAbstractObject
{
	public vhdIf() { }
	public List<vhdConditionalStatement> Statements { get; set; } = new List<vhdConditionalStatement>();
}
public partial class vhdIndexedExpression : vhdExpression
{
	public vhdIndexedExpression() { }
	public vhdIndexedExpression(vhdExpression Expression, params vhdRange[] Indexes)
	{
		this.Expression = Expression;
		this.Indexes = (Indexes ?? Array.Empty<vhdRange>()).Where(s => s != null).ToList();
	}
	public vhdIndexedExpression(vhdExpression Expression)
	{
		this.Expression = Expression;
	}
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	/// <param name="Aggregate"></param>
	public vhdIndexedExpression(vhdAggregate Aggregate)
	{
		this.Expression = new vhdAggregateExpression(Aggregate);
	}
	/// <summary>
	/// from vhdAssignExpression
	/// </summary>
	/// <param name="Target"></param>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdIndexedExpression(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Expression = new vhdAssignExpression(Target, Type, Source);
	}
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	/// <param name="Value"></param>
	public vhdIndexedExpression(RTLBitArray Value)
	{
		this.Expression = new vhdBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vhdCastExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	public vhdIndexedExpression(vhdCastType Type, vhdExpression Source)
	{
		this.Expression = new vhdCastExpression(Type, Source);
	}
	/// <summary>
	/// from vhdCastResizeExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdIndexedExpression(vhdCastType Type, vhdExpression Source, vhdExpression Length)
	{
		this.Expression = new vhdCastResizeExpression(Type, Source, Length);
	}
	/// <summary>
	/// from vhdCompareExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdIndexedExpression(vhdExpression Lhs, vhdCompareType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdCompareExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	/// <param name="Source"></param>
	public vhdIndexedExpression(vhdIdentifier Source)
	{
		this.Expression = new vhdIdentifierExpression(Source);
	}
	// from vhdIndexedExpression
	// ignored vhdIndexedExpression(vhdExpression Expression, params vhdRange[] Indexes)
	// from vhdIndexedExpression
	// ignored vhdIndexedExpression(vhdExpression Expression)
	/// <summary>
	/// from vhdLogicExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdIndexedExpression(vhdExpression Lhs, vhdLogicType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdLogicExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdMathExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdIndexedExpression(vhdExpression Lhs, vhdMathType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdMathExpression(Lhs, Type, Rhs);
	}
	// from vhdParenthesizedExpression
	// ignored vhdIndexedExpression(vhdExpression Expression)
	/// <summary>
	/// from vhdPredefinedAttributeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Attribute"></param>
	public vhdIndexedExpression(vhdExpression Source, vhdPredefinedAttribute Attribute)
	{
		this.Expression = new vhdPredefinedAttributeExpression(Source, Attribute);
	}
	/// <summary>
	/// from vhdResizeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdIndexedExpression(vhdExpression Source, vhdExpression Length)
	{
		this.Expression = new vhdResizeExpression(Source, Length);
	}
	/// <summary>
	/// from vhdShiftExpression
	/// </summary>
	/// <param name="Lhs"></param>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdIndexedExpression(vhdExpression Lhs, vhdShiftType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdShiftExpression(Lhs, Type, Rhs);
	}
	/// <summary>
	/// from vhdTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vhdIndexedExpression(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	{
		this.Expression = new vhdTernaryExpression(Condition, Lhs, Rhs);
	}
	/// <summary>
	/// from vhdUnaryExpression
	/// </summary>
	/// <param name="Type"></param>
	/// <param name="Rhs"></param>
	public vhdIndexedExpression(vhdUnaryType Type, vhdExpression Rhs)
	{
		this.Expression = new vhdUnaryExpression(Type, Rhs);
	}
	public vhdExpression Expression { get; set; }
	public List<vhdRange> Indexes { get; set; } = new List<vhdRange>();
}
public partial class vhdLibraryReference : vhdAbstractObject
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
public partial class vhdLogicSignal : vhdNet
{
	public vhdLogicSignal() { }
	public vhdLogicSignal(vhdNetTypeSource NetType, String Name, params RTLBitArray[] Initializer)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.Initializer = (Initializer ?? Array.Empty<RTLBitArray>()).Where(s => s != null).ToList();
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
public partial class vhdNull : vhdAbstractObject
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
	/// from vhdIndexedExpression
	/// </summary>
	/// <param name="Expression"></param>
	/// <param name="Indexes"></param>
	public vhdParenthesizedExpression(vhdExpression Expression, params vhdRange[] Indexes)
	{
		this.Expression = new vhdIndexedExpression(Expression, Indexes);
	}
	// from vhdIndexedExpression
	// ignored vhdParenthesizedExpression(vhdExpression Expression)
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
public partial class vhdProcedureCall : vhdAbstractObject
{
	public vhdProcedureCall() { }
	public vhdProcedureCall(String Proc, params vhdExpression[] Parameters)
	{
		this.Proc = Proc;
		this.Parameters = (Parameters ?? Array.Empty<vhdExpression>()).Where(s => s != null).ToList();
	}
	public vhdProcedureCall(String Proc)
	{
		this.Proc = Proc;
	}
	public String Proc { get; set; }
	/// <summary>
	/// vhdAggregateExpression

	/// vhdAssignExpression

	/// vhdBinaryValueExpression

	/// vhdCastExpression

	/// vhdCastResizeExpression

	/// vhdCompareExpression

	/// vhdIdentifierExpression

	/// vhdIndexedExpression

	/// vhdLogicExpression

	/// vhdMathExpression

	/// vhdOthersExpression

	/// vhdParenthesizedExpression

	/// vhdPredefinedAttributeExpression

	/// vhdResizeExpression

	/// vhdShiftExpression

	/// vhdTernaryExpression

	/// vhdUnaryExpression

	/// </summary>
	public List<vhdExpression> Parameters { get; set; } = new List<vhdExpression>();
}
public partial class vhdProcess : vhdAbstractObject
{
	public vhdProcess() { }
	public vhdProcess(params vhdIdentifier[] SensitivityList)
	{
		this.SensitivityList = (SensitivityList ?? Array.Empty<vhdIdentifier>()).Where(s => s != null).ToList();
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
public partial class vhdProcessDeclarations : vhdAbstractCollection
{
	public vhdProcessDeclarations() { }
}
public partial class vhdRange : vhdAbstractObject
{
	public vhdRange() { }
	public vhdRange(params vhdExpression[] Indexes)
	{
		this.Indexes = (Indexes ?? Array.Empty<vhdExpression>()).Where(s => s != null).ToList();
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
	/// from vhdIndexedExpression
	/// </summary>
	/// <param name="Expression"></param>
	/// <param name="Indexes"></param>
	public vhdRange(vhdExpression Expression, params vhdRange[] Indexes)
	{
		this.Indexes.Add(new vhdIndexedExpression(Expression, Indexes));
	}
	// from vhdIndexedExpression
	// ignored vhdRange(vhdExpression Expression)
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
	/// from vhdResizeExpression
	/// </summary>
	/// <param name="Source"></param>
	/// <param name="Length"></param>
	public vhdRange(vhdExpression Source, vhdExpression Length)
	{
		this.Indexes.Add(new vhdResizeExpression(Source, Length));
	}
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
	/// <summary>
	/// from vhdTernaryExpression
	/// </summary>
	/// <param name="Condition"></param>
	/// <param name="Lhs"></param>
	/// <param name="Rhs"></param>
	public vhdRange(vhdExpression Condition, vhdExpression Lhs, vhdExpression Rhs)
	{
		this.Indexes.Add(new vhdTernaryExpression(Condition, Lhs, Rhs));
	}
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

	/// vhdAssignExpression

	/// vhdBinaryValueExpression

	/// vhdCastExpression

	/// vhdCastResizeExpression

	/// vhdCompareExpression

	/// vhdIdentifierExpression

	/// vhdIndexedExpression

	/// vhdLogicExpression

	/// vhdMathExpression

	/// vhdOthersExpression

	/// vhdParenthesizedExpression

	/// vhdPredefinedAttributeExpression

	/// vhdResizeExpression

	/// vhdShiftExpression

	/// vhdTernaryExpression

	/// vhdUnaryExpression

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
public partial class vhdSimpleForLoop : vhdAbstractObject
{
	public vhdSimpleForLoop() { }
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
public partial class vhdStandardEntityPort : vhdEntityPort
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
public partial class vhdSyncBlock : vhdAbstractObject
{
	public vhdSyncBlock() { }
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
public partial class vhdText : vhdAbstractObject
{
	public vhdText() { }
	public vhdText(params String[] Lines)
	{
		this.Lines = (Lines ?? Array.Empty<String>()).Where(s => s != null).ToList();
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
public partial class vhdUse : vhdAbstractObject
{
	public vhdUse() { }
	public vhdUse(String Value)
	{
		this.Value = Value;
	}
	public String Value { get; set; }
}
} // Quokka.RTL.VHDL
