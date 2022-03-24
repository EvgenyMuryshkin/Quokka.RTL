using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public abstract partial class vhdAbstractCollection : vhdAbstractObject
{
}
public abstract partial class vhdAbstractObject
{
	/// <summary>
	/// from vhdDefaultDataType
	/// </summary>
	public static implicit operator vhdAbstractObject(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
	/// <summary>
	/// from vhdDefaultNetType
	/// </summary>
	public static implicit operator vhdAbstractObject(vhdNetType NetType)
	{
		return new vhdDefaultNetType(NetType);
	}
}
public partial class vhdAggregate : vhdAbstractCollection
{
}
public partial class vhdAggregateBitConnection : vhdAbstractObject
{
}
public abstract partial class vhdAggregateConnection : vhdAbstractObject
{
}
public partial class vhdAggregateExpression : vhdExpression
{
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	public static implicit operator vhdAggregateExpression(vhdAggregate Aggregate)
	{
		return new vhdAggregateExpression(Aggregate);
	}
}
public partial class vhdAggregateOthersConnection : vhdAbstractObject
{
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdAggregateExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdAggregate Aggregate)
	{
		return new vhdAggregateOthersConnection(new vhdAggregateExpression(Aggregate));
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdAssignExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdBinaryValueExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(RTLBitArray Value)
	{
		return new vhdAggregateOthersConnection(new vhdBinaryValueExpression(Value));
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdCastExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdCastResizeExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdCompareExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdIdentifierExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(String Name)
	{
		return new vhdAggregateOthersConnection(new vhdIdentifierExpression(new vhdIdentifier(Name)));
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdIdentifier Source)
	{
		return new vhdAggregateOthersConnection(new vhdIdentifierExpression(Source));
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdLogicExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdMathExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdOthersExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdParenthesizedExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdPredefinedAttributeExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdProcedureCallExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdResizeExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdShiftExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdTernaryExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
	/// <summary>
	/// from vhdAggregateOthersConnection
	/// </summary>
	public static implicit operator vhdAggregateOthersConnection(vhdUnaryExpression source)
	{
		return new vhdAggregateOthersConnection(source);
	}
}
public partial class vhdAlias : vhdAbstractObject
{
}
public partial class vhdArchitecture : vhdAbstractObject
{
}
public partial class vhdArchitectureDeclarations : vhdAbstractCollection
{
}
public partial class vhdArchitectureImplementation : vhdAbstractObject
{
	/// <summary>
	/// from vhdArchitectureImplementation
	/// </summary>
	public static implicit operator vhdArchitectureImplementation(vhdArchitectureImplementationBlock Block)
	{
		return new vhdArchitectureImplementation(Block);
	}
}
public partial class vhdArchitectureImplementationBlock : vhdBlock
{
}
public partial class vhdArrayTypeDeclaration : vhdTypeDeclaration
{
}
public partial class vhdAssignExpression : vhdExpression
{
}
public partial class vhdAttribute : vhdAbstractObject
{
}
public partial class vhdBinaryValueExpression : vhdExpression
{
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	public static implicit operator vhdBinaryValueExpression(RTLBitArray Value)
	{
		return new vhdBinaryValueExpression(Value);
	}
}
public abstract partial class vhdBlock : vhdAbstractCollection
{
}
public partial class vhdCase : vhdAbstractObject
{
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdAggregateExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdAggregate Aggregate)
	{
		return new vhdCase(new vhdAggregateExpression(Aggregate));
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdAssignExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdBinaryValueExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(RTLBitArray Value)
	{
		return new vhdCase(new vhdBinaryValueExpression(Value));
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdCastExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdCastResizeExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdCompareExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdIdentifierExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(String Name)
	{
		return new vhdCase(new vhdIdentifierExpression(new vhdIdentifier(Name)));
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdIdentifier Source)
	{
		return new vhdCase(new vhdIdentifierExpression(Source));
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdLogicExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdMathExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdOthersExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdParenthesizedExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdPredefinedAttributeExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdProcedureCallExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdResizeExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdShiftExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdTernaryExpression source)
	{
		return new vhdCase(source);
	}
	/// <summary>
	/// from vhdCase
	/// </summary>
	public static implicit operator vhdCase(vhdUnaryExpression source)
	{
		return new vhdCase(source);
	}
}
public partial class vhdCaseStatement : vhdAbstractObject
{
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdAggregateExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdAggregate Aggregate)
	{
		return new vhdCaseStatement(new vhdAggregateExpression(Aggregate));
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdAssignExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdBinaryValueExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(RTLBitArray Value)
	{
		return new vhdCaseStatement(new vhdBinaryValueExpression(Value));
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdCastExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdCastResizeExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdCompareExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdIdentifierExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(String Name)
	{
		return new vhdCaseStatement(new vhdIdentifierExpression(new vhdIdentifier(Name)));
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdIdentifier Source)
	{
		return new vhdCaseStatement(new vhdIdentifierExpression(Source));
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdLogicExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdMathExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdOthersExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdParenthesizedExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdPredefinedAttributeExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdProcedureCallExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdResizeExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdShiftExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdTernaryExpression source)
	{
		return new vhdCaseStatement(source);
	}
	/// <summary>
	/// from vhdCaseStatement
	/// </summary>
	public static implicit operator vhdCaseStatement(vhdUnaryExpression source)
	{
		return new vhdCaseStatement(source);
	}
}
public partial class vhdCastExpression : vhdExpression
{
}
public partial class vhdCastResizeExpression : vhdExpression
{
}
public partial class vhdComment : vhdAbstractObject
{
}
public partial class vhdCompareExpression : vhdExpression
{
}
public partial class vhdConditionalStatement : vhdAbstractObject
{
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdAggregateExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdAggregate Aggregate)
	{
		return new vhdConditionalStatement(new vhdAggregateExpression(Aggregate));
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdAssignExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdBinaryValueExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(RTLBitArray Value)
	{
		return new vhdConditionalStatement(new vhdBinaryValueExpression(Value));
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdCastExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdCastResizeExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdCompareExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdIdentifierExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(String Name)
	{
		return new vhdConditionalStatement(new vhdIdentifierExpression(new vhdIdentifier(Name)));
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdIdentifier Source)
	{
		return new vhdConditionalStatement(new vhdIdentifierExpression(Source));
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdLogicExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdMathExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdOthersExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdParenthesizedExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdPredefinedAttributeExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdProcedureCallExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdResizeExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdShiftExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdTernaryExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	/// <summary>
	/// from vhdConditionalStatement
	/// </summary>
	public static implicit operator vhdConditionalStatement(vhdUnaryExpression source)
	{
		return new vhdConditionalStatement(source);
	}
}
public partial class vhdCustomDataType : vhdDataTypeSource
{
	/// <summary>
	/// from vhdCustomDataType
	/// </summary>
	public static implicit operator vhdCustomDataType(String DataType)
	{
		return new vhdCustomDataType(DataType);
	}
}
public partial class vhdCustomEntityPort : vhdEntityPort
{
}
public partial class vhdCustomNetType : vhdNetTypeSource
{
	/// <summary>
	/// from vhdCustomNetType
	/// </summary>
	public static implicit operator vhdCustomNetType(String NetType)
	{
		return new vhdCustomNetType(NetType);
	}
}
public abstract partial class vhdDataTypeSource : vhdAbstractObject
{
	/// <summary>
	/// from vhdCustomDataType
	/// </summary>
	public static implicit operator vhdDataTypeSource(String DataType)
	{
		return new vhdCustomDataType(DataType);
	}
	/// <summary>
	/// from vhdDefaultDataType
	/// </summary>
	public static implicit operator vhdDataTypeSource(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
}
public partial class vhdDefaultDataType : vhdDataTypeSource
{
	/// <summary>
	/// from vhdDefaultDataType
	/// </summary>
	public static implicit operator vhdDefaultDataType(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
}
public partial class vhdDefaultNetType : vhdNetTypeSource
{
	/// <summary>
	/// from vhdDefaultNetType
	/// </summary>
	public static implicit operator vhdDefaultNetType(vhdNetType NetType)
	{
		return new vhdDefaultNetType(NetType);
	}
}
public partial class vhdDefaultSignal : vhdNet
{
}
public partial class vhdEntity : vhdAbstractObject
{
	/// <summary>
	/// from vhdEntity
	/// </summary>
	public static implicit operator vhdEntity(String Name)
	{
		return new vhdEntity(Name);
	}
}
public partial class vhdEntityInstance : vhdAbstractObject
{
}
public partial class vhdEntityInstanceNamedPortMapping : vhdEntityInstancePortMapping
{
}
public abstract partial class vhdEntityInstancePortMapping : vhdAbstractObject
{
}
public partial class vhdEntityInstancePortMappings : vhdAbstractCollection
{
}
public partial class vhdEntityInterface : vhdAbstractCollection
{
}
public abstract partial class vhdEntityPort : vhdAbstractObject
{
}
public abstract partial class vhdExpression : vhdAbstractObject
{
	/// <summary>
	/// from vhdAggregateExpression
	/// </summary>
	public static implicit operator vhdExpression(vhdAggregate Aggregate)
	{
		return new vhdAggregateExpression(Aggregate);
	}
	/// <summary>
	/// from vhdBinaryValueExpression
	/// </summary>
	public static implicit operator vhdExpression(RTLBitArray Value)
	{
		return new vhdBinaryValueExpression(Value);
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	public static implicit operator vhdExpression(String Name)
	{
		return new vhdIdentifierExpression(new vhdIdentifier(Name));
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	public static implicit operator vhdExpression(vhdIdentifier Source)
	{
		return new vhdIdentifierExpression(Source);
	}
}
public partial class vhdFile : vhdAbstractCollection
{
}
public partial class vhdGenericBlock : vhdBlock
{
}
public partial class vhdIdentifier : vhdAbstractObject
{
	/// <summary>
	/// from vhdIdentifier
	/// </summary>
	public static implicit operator vhdIdentifier(String Name)
	{
		return new vhdIdentifier(Name);
	}
}
public partial class vhdIdentifierExpression : vhdExpression
{
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	public static implicit operator vhdIdentifierExpression(String Name)
	{
		return new vhdIdentifierExpression(new vhdIdentifier(Name));
	}
	/// <summary>
	/// from vhdIdentifierExpression
	/// </summary>
	public static implicit operator vhdIdentifierExpression(vhdIdentifier Source)
	{
		return new vhdIdentifierExpression(Source);
	}
}
public partial class vhdIf : vhdAbstractObject
{
}
public partial class vhdLibraryReference : vhdAbstractObject
{
	/// <summary>
	/// from vhdLibraryReference
	/// </summary>
	public static implicit operator vhdLibraryReference(String Name)
	{
		return new vhdLibraryReference(Name);
	}
}
public partial class vhdLogicExpression : vhdExpression
{
}
public partial class vhdLogicSignal : vhdNet
{
}
public partial class vhdMathExpression : vhdExpression
{
}
public abstract partial class vhdNet : vhdAbstractObject
{
}
public abstract partial class vhdNetTypeSource : vhdAbstractObject
{
	/// <summary>
	/// from vhdCustomNetType
	/// </summary>
	public static implicit operator vhdNetTypeSource(String NetType)
	{
		return new vhdCustomNetType(NetType);
	}
	/// <summary>
	/// from vhdDefaultNetType
	/// </summary>
	public static implicit operator vhdNetTypeSource(vhdNetType NetType)
	{
		return new vhdDefaultNetType(NetType);
	}
}
public partial class vhdNull : vhdAbstractObject
{
}
public partial class vhdOthersExpression : vhdExpression
{
}
public partial class vhdParenthesizedExpression : vhdExpression
{
}
public partial class vhdPredefinedAttributeExpression : vhdExpression
{
}
public partial class vhdProcedureCall : vhdAbstractObject
{
	/// <summary>
	/// from vhdProcedureCall
	/// </summary>
	public static implicit operator vhdProcedureCall(String Proc)
	{
		return new vhdProcedureCall(Proc);
	}
}
public partial class vhdProcedureCallExpression : vhdExpression
{
}
public partial class vhdProcess : vhdAbstractObject
{
	/// <summary>
	/// from vhdProcess
	/// </summary>
	public static implicit operator vhdProcess(vhdIdentifier source)
	{
		return new vhdProcess(new [] { source });
	}
	/// <summary>
	/// from vhdProcess
	/// </summary>
	public static implicit operator vhdProcess(String Name)
	{
		return new vhdProcess(new [] { new vhdIdentifier(Name) });
	}
}
public partial class vhdProcessDeclarations : vhdAbstractCollection
{
}
public partial class vhdRange : vhdAbstractObject
{
	/// <summary>
	/// from vhdRange
	/// </summary>
	public static implicit operator vhdRange(vhdExpression source)
	{
		return new vhdRange(new [] { source });
	}
}
public partial class vhdResizeExpression : vhdExpression
{
}
public partial class vhdShiftExpression : vhdExpression
{
}
public partial class vhdSimpleForLoop : vhdAbstractObject
{
}
public partial class vhdStandardEntityPort : vhdEntityPort
{
}
public partial class vhdSyncBlock : vhdAbstractObject
{
}
public partial class vhdTernaryExpression : vhdExpression
{
}
public partial class vhdText : vhdAbstractObject
{
}
public abstract partial class vhdTypeDeclaration : vhdAbstractObject
{
}
public partial class vhdUnaryExpression : vhdExpression
{
}
public partial class vhdUse : vhdAbstractObject
{
	/// <summary>
	/// from vhdUse
	/// </summary>
	public static implicit operator vhdUse(String Value)
	{
		return new vhdUse(Value);
	}
}
} // Quokka.RTL.VHDL
