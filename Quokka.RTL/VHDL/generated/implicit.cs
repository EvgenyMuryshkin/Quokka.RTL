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
	public static implicit operator vhdAbstractObject(Boolean Value)
	{
		return new vhdAggregateOthersConnection(Value);
	}
	public static implicit operator vhdAbstractObject(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
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
	public static implicit operator vhdAggregateExpression(vhdAggregate Aggregate)
	{
		return new vhdAggregateExpression(Aggregate);
	}
}
public partial class vhdAggregateOthersConnection : vhdAbstractObject
{
	public static implicit operator vhdAggregateOthersConnection(Boolean Value)
	{
		return new vhdAggregateOthersConnection(Value);
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
	public static implicit operator vhdCase(vhdAggregateExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdAggregate Aggregate)
	{
		return new vhdCase(new vhdAggregateExpression(Aggregate));
	}
	public static implicit operator vhdCase(vhdAssignExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdBinaryValueExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(RTLBitArray Value)
	{
		return new vhdCase(new vhdBinaryValueExpression(Value));
	}
	public static implicit operator vhdCase(vhdCastExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdCastResizeExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdCompareExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdIdentifierExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(String Name)
	{
		return new vhdCase(new vhdIdentifierExpression(new vhdIdentifier(Name)));
	}
	public static implicit operator vhdCase(vhdIdentifier Source)
	{
		return new vhdCase(new vhdIdentifierExpression(Source));
	}
	public static implicit operator vhdCase(vhdIndexedExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdLogicExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdMathExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdOthersExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdParenthesizedExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdPredefinedAttributeExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdResizeExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdShiftExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdTernaryExpression source)
	{
		return new vhdCase(source);
	}
	public static implicit operator vhdCase(vhdUnaryExpression source)
	{
		return new vhdCase(source);
	}
}
public partial class vhdCaseStatement : vhdAbstractObject
{
	public static implicit operator vhdCaseStatement(vhdAggregateExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdAggregate Aggregate)
	{
		return new vhdCaseStatement(new vhdAggregateExpression(Aggregate));
	}
	public static implicit operator vhdCaseStatement(vhdAssignExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdBinaryValueExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(RTLBitArray Value)
	{
		return new vhdCaseStatement(new vhdBinaryValueExpression(Value));
	}
	public static implicit operator vhdCaseStatement(vhdCastExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdCastResizeExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdCompareExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdIdentifierExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(String Name)
	{
		return new vhdCaseStatement(new vhdIdentifierExpression(new vhdIdentifier(Name)));
	}
	public static implicit operator vhdCaseStatement(vhdIdentifier Source)
	{
		return new vhdCaseStatement(new vhdIdentifierExpression(Source));
	}
	public static implicit operator vhdCaseStatement(vhdIndexedExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdLogicExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdMathExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdOthersExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdParenthesizedExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdPredefinedAttributeExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdResizeExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdShiftExpression source)
	{
		return new vhdCaseStatement(source);
	}
	public static implicit operator vhdCaseStatement(vhdTernaryExpression source)
	{
		return new vhdCaseStatement(source);
	}
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
	public static implicit operator vhdConditionalStatement(vhdAggregateExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdAggregate Aggregate)
	{
		return new vhdConditionalStatement(new vhdAggregateExpression(Aggregate));
	}
	public static implicit operator vhdConditionalStatement(vhdAssignExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdBinaryValueExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(RTLBitArray Value)
	{
		return new vhdConditionalStatement(new vhdBinaryValueExpression(Value));
	}
	public static implicit operator vhdConditionalStatement(vhdCastExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdCastResizeExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdCompareExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdIdentifierExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(String Name)
	{
		return new vhdConditionalStatement(new vhdIdentifierExpression(new vhdIdentifier(Name)));
	}
	public static implicit operator vhdConditionalStatement(vhdIdentifier Source)
	{
		return new vhdConditionalStatement(new vhdIdentifierExpression(Source));
	}
	public static implicit operator vhdConditionalStatement(vhdIndexedExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdLogicExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdMathExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdOthersExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdParenthesizedExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdPredefinedAttributeExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdResizeExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdShiftExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdTernaryExpression source)
	{
		return new vhdConditionalStatement(source);
	}
	public static implicit operator vhdConditionalStatement(vhdUnaryExpression source)
	{
		return new vhdConditionalStatement(source);
	}
}
public partial class vhdCustomDataType : vhdDataTypeSource
{
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
	public static implicit operator vhdCustomNetType(String NetType)
	{
		return new vhdCustomNetType(NetType);
	}
}
public abstract partial class vhdDataTypeSource : vhdAbstractObject
{
	public static implicit operator vhdDataTypeSource(String DataType)
	{
		return new vhdCustomDataType(DataType);
	}
	public static implicit operator vhdDataTypeSource(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
}
public partial class vhdDefaultDataType : vhdDataTypeSource
{
	public static implicit operator vhdDefaultDataType(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
}
public partial class vhdDefaultNetType : vhdNetTypeSource
{
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
	public static implicit operator vhdExpression(vhdAggregate Aggregate)
	{
		return new vhdAggregateExpression(Aggregate);
	}
	public static implicit operator vhdExpression(RTLBitArray Value)
	{
		return new vhdBinaryValueExpression(Value);
	}
	public static implicit operator vhdExpression(String Name)
	{
		return new vhdIdentifierExpression(new vhdIdentifier(Name));
	}
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
	public static implicit operator vhdIdentifier(String Name)
	{
		return new vhdIdentifier(Name);
	}
}
public partial class vhdIdentifierExpression : vhdExpression
{
	public static implicit operator vhdIdentifierExpression(String Name)
	{
		return new vhdIdentifierExpression(new vhdIdentifier(Name));
	}
	public static implicit operator vhdIdentifierExpression(vhdIdentifier Source)
	{
		return new vhdIdentifierExpression(Source);
	}
}
public partial class vhdIf : vhdAbstractObject
{
}
public partial class vhdIndexedExpression : vhdExpression
{
}
public partial class vhdLibraryReference : vhdAbstractObject
{
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
	public static implicit operator vhdNetTypeSource(String NetType)
	{
		return new vhdCustomNetType(NetType);
	}
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
	public static implicit operator vhdProcedureCall(String Proc)
	{
		return new vhdProcedureCall(Proc);
	}
}
public partial class vhdProcess : vhdAbstractObject
{
	public static implicit operator vhdProcess(vhdIdentifier source)
	{
		return new vhdProcess(source);
	}
	public static implicit operator vhdProcess(String Name)
	{
		return new vhdProcess(new vhdIdentifier(Name));
	}
}
public partial class vhdProcessDeclarations : vhdAbstractCollection
{
}
public partial class vhdRange : vhdAbstractObject
{
	public static implicit operator vhdRange(vhdExpression source)
	{
		return new vhdRange(source);
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
	public static implicit operator vhdUse(String Value)
	{
		return new vhdUse(Value);
	}
}
} // Quokka.RTL.VHDL
