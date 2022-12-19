using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public abstract partial class vhdAbstractCollection
{
}
public abstract partial class vhdAbstractObject
{
}
public partial class vhdAggregate
{
	//vhdAggregateBitConnection
	public vhdAggregate WithAggregateBitConnection(vhdAggregateBitConnection obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdAggregate WithAggregateBitConnection(Int32 Bit, vhdExpression Value)
	{
		this.Children.Add(new vhdAggregateBitConnection(Bit, Value));
		return this;
	}
	//vhdAggregateOthersConnection
	public vhdAggregate WithAggregateOthersConnection(vhdAggregateOthersConnection obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdAggregate WithAggregateOthersConnection(vhdExpression Expression)
	{
		this.Children.Add(new vhdAggregateOthersConnection(Expression));
		return this;
	}
	public vhdAggregate WithAggregateOthersConnection()
	{
		this.Children.Add(new vhdAggregateOthersConnection());
		return this;
	}
}
public partial class vhdAggregateBitConnection
{
}
public abstract partial class vhdAggregateConnection
{
}
public partial class vhdAggregateExpression
{
}
public partial class vhdAggregateOthersConnection
{
}
public partial class vhdAlias
{
}
public partial class vhdArchitecture
{
}
public partial class vhdArchitectureDeclarations
{
	//vhdComment
	public vhdArchitectureDeclarations WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdArchitectureDeclarations WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdDefaultSignal
	public vhdArchitectureDeclarations WithDefaultSignal(vhdDefaultSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width, params String[] Initializer)
	{
		this.Children.Add(new vhdDefaultSignal(NetType, Name, DataType, Width, Initializer));
		return this;
	}
	//vhdLogicSignal
	public vhdArchitectureDeclarations WithLogicSignal(vhdLogicSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithLogicSignal(vhdNetTypeSource NetType, String Name, params RTLBitArray[] Initializer)
	{
		this.Children.Add(new vhdLogicSignal(NetType, Name, Initializer));
		return this;
	}
	//vhdArrayTypeDeclaration
	public vhdArchitectureDeclarations WithArrayTypeDeclaration(vhdArrayTypeDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithArrayTypeDeclaration(String Name, Int32 Depth, vhdDataType Type, Int32 Width)
	{
		this.Children.Add(new vhdArrayTypeDeclaration(Name, Depth, Type, Width));
		return this;
	}
	//vhdSubTypeDeclaration
	public vhdArchitectureDeclarations WithSubTypeDeclaration(vhdSubTypeDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithSubTypeDeclaration(String Name, vhdDataType Type, Int32 Width)
	{
		this.Children.Add(new vhdSubTypeDeclaration(Name, Type, Width));
		return this;
	}
	//vhdFunction
	public vhdArchitectureDeclarations WithFunction(vhdFunction obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithFunction(vhdFunctionDeclaration Declaration)
	{
		this.Children.Add(new vhdFunction(Declaration));
		return this;
	}
	public vhdArchitectureDeclarations WithFunction(String Name, vhdDataType Type, Int32 Width)
	{
		this.Children.Add(new vhdFunction(Name, Type, Width));
		return this;
	}
}
public partial class vhdArchitectureImplementation
{
}
public partial class vhdArchitectureImplementationBlock
{
	//vhdEntityInstance
	public vhdArchitectureImplementationBlock WithEntityInstance(vhdEntityInstance obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureImplementationBlock WithEntityInstance(String Name, String Type)
	{
		this.Children.Add(new vhdEntityInstance(Name, Type));
		return this;
	}
	//vhdComponentInstance
	public vhdArchitectureImplementationBlock WithComponentInstance(vhdComponentInstance obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureImplementationBlock WithComponentInstance(String Name, String Type)
	{
		this.Children.Add(new vhdComponentInstance(Name, Type));
		return this;
	}
	//vhdGenericBlock
	public vhdArchitectureImplementationBlock WithGenericBlock(vhdGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public partial class vhdArrayTypeDeclaration
{
}
public partial class vhdAssignExpression
{
}
public partial class vhdAttribute
{
}
public partial class vhdBinaryValueExpression
{
}
public abstract partial class vhdBlock
{
	//vhdComment
	public vhdBlock WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdBlock WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdIf
	public vhdBlock WithIf(vhdIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vhdCase
	public vhdBlock WithCase(vhdCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithCase(vhdExpression Expression)
	{
		this.Children.Add(new vhdCase(Expression));
		return this;
	}
	public vhdBlock WithCase()
	{
		this.Children.Add(new vhdCase());
		return this;
	}
	//vhdProcess
	public vhdBlock WithProcess(vhdProcess obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithProcess(params vhdIdentifier[] SensitivityList)
	{
		this.Children.Add(new vhdProcess(SensitivityList));
		return this;
	}
	//vhdSyncBlock
	public vhdBlock WithSyncBlock(vhdSyncBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithSyncBlock(vhdEdgeType Type, vhdExpression Source)
	{
		this.Children.Add(new vhdSyncBlock(Type, Source));
		return this;
	}
	//vhdAssignExpression
	public vhdBlock WithAssignExpression(vhdAssignExpression obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithAssignExpression(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Children.Add(new vhdAssignExpression(Target, Type, Source));
		return this;
	}
	//vhdProcedureCall
	public vhdBlock WithProcedureCall(vhdProcedureCall obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithProcedureCall(String Proc, params vhdExpression[] Parameters)
	{
		this.Children.Add(new vhdProcedureCall(Proc, Parameters));
		return this;
	}
	//vhdSimpleForLoop
	public vhdBlock WithSimpleForLoop(vhdSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vhdSimpleForLoop(Iterator, From, To));
		return this;
	}
	//vhdNull
	public vhdBlock WithNull(vhdNull obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vhdReturnExpression
	public vhdBlock WithReturnExpression(vhdReturnExpression obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithReturnExpression(vhdExpression Result)
	{
		this.Children.Add(new vhdReturnExpression(Result));
		return this;
	}
	public vhdBlock WithReturnExpression()
	{
		this.Children.Add(new vhdReturnExpression());
		return this;
	}
}
public partial class vhdCase
{
}
public partial class vhdCaseStatement
{
}
public partial class vhdCastExpression
{
}
public partial class vhdCastResizeExpression
{
}
public partial class vhdComment
{
}
public partial class vhdCompareExpression
{
}
public partial class vhdComponentInstance
{
}
public partial class vhdConditionalStatement
{
}
public partial class vhdCustomDataType
{
}
public partial class vhdCustomEntityPort
{
}
public partial class vhdCustomNetType
{
}
public abstract partial class vhdDataTypeSource
{
}
public partial class vhdDefaultDataType
{
}
public partial class vhdDefaultNetType
{
}
public partial class vhdDefaultSignal
{
}
public partial class vhdEntity
{
}
public partial class vhdEntityInstance
{
}
public abstract partial class vhdEntityInstanceGenericMapping
{
}
public partial class vhdEntityInstanceGenericMappings
{
	//vhdComment
	public vhdEntityInstanceGenericMappings WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInstanceGenericMappings WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdEntityInstanceGenericMappings WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInstanceGenericMappings WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdEntityInstanceNamedGenericMapping
	public vhdEntityInstanceGenericMappings WithEntityInstanceNamedGenericMapping(vhdEntityInstanceNamedGenericMapping obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInstanceGenericMappings WithEntityInstanceNamedGenericMapping(String Internal, vhdExpression External)
	{
		this.Children.Add(new vhdEntityInstanceNamedGenericMapping(Internal, External));
		return this;
	}
}
public partial class vhdEntityInstanceNamedGenericMapping
{
}
public partial class vhdEntityInstanceNamedPortMapping
{
}
public abstract partial class vhdEntityInstancePortMapping
{
}
public partial class vhdEntityInstancePortMappings
{
	//vhdComment
	public vhdEntityInstancePortMappings WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInstancePortMappings WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdEntityInstancePortMappings WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInstancePortMappings WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdEntityInstanceNamedPortMapping
	public vhdEntityInstancePortMappings WithEntityInstanceNamedPortMapping(vhdEntityInstanceNamedPortMapping obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInstancePortMappings WithEntityInstanceNamedPortMapping(vhdIdentifier Internal, vhdExpression External, vhdPortDirection Direction)
	{
		this.Children.Add(new vhdEntityInstanceNamedPortMapping(Internal, External, Direction));
		return this;
	}
}
public partial class vhdEntityInterface
{
	//vhdComment
	public vhdEntityInterface WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInterface WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdEntityInterface WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInterface WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdCustomEntityPort
	public vhdEntityInterface WithCustomEntityPort(vhdCustomEntityPort obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInterface WithCustomEntityPort(String Name, vhdPortDirection Direction, String Declaration, String Initializer)
	{
		this.Children.Add(new vhdCustomEntityPort(Name, Direction, Declaration, Initializer));
		return this;
	}
	//vhdStandardEntityPort
	public vhdEntityInterface WithStandardEntityPort(vhdStandardEntityPort obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInterface WithStandardEntityPort(String Name, vhdPortDirection Direction, vhdDataType Sign, Int32 Width, String Initializer)
	{
		this.Children.Add(new vhdStandardEntityPort(Name, Direction, Sign, Width, Initializer));
		return this;
	}
}
public abstract partial class vhdEntityPort
{
}
public abstract partial class vhdExpression
{
}
public partial class vhdFile
{
	//vhdComment
	public vhdFile WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdFile WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdLibraryReference
	public vhdFile WithLibraryReference(vhdLibraryReference obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithLibraryReference(String Name)
	{
		this.Children.Add(new vhdLibraryReference(Name));
		return this;
	}
	//vhdUse
	public vhdFile WithUse(vhdUse obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithUse(String Value)
	{
		this.Children.Add(new vhdUse(Value));
		return this;
	}
	//vhdEntity
	public vhdFile WithEntity(vhdEntity obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithEntity(String Name)
	{
		this.Children.Add(new vhdEntity(Name));
		return this;
	}
	//vhdArchitecture
	public vhdFile WithArchitecture(vhdArchitecture obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithArchitecture(String Type, String Entity)
	{
		this.Children.Add(new vhdArchitecture(Type, Entity));
		return this;
	}
	//vhdAttribute
	public vhdFile WithAttribute(vhdAttribute obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithAttribute(String Name, String Target, String Value)
	{
		this.Children.Add(new vhdAttribute(Name, Target, Value));
		return this;
	}
}
public partial class vhdFunction
{
}
public partial class vhdFunctionCustomPortDeclaration
{
}
public partial class vhdFunctionDeclaration
{
}
public partial class vhdFunctionImplementation
{
}
public partial class vhdFunctionImplementationBlock
{
	//vhdComment
	public vhdFunctionImplementationBlock WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionImplementationBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdFunctionImplementationBlock WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionImplementationBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdAssignExpression
	public vhdFunctionImplementationBlock WithAssignExpression(vhdAssignExpression obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionImplementationBlock WithAssignExpression(vhdExpression Target, vhdAssignType Type, vhdExpression Source)
	{
		this.Children.Add(new vhdAssignExpression(Target, Type, Source));
		return this;
	}
	//vhdIf
	public vhdFunctionImplementationBlock WithIf(vhdIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vhdReturnExpression
	public vhdFunctionImplementationBlock WithReturnExpression(vhdReturnExpression obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionImplementationBlock WithReturnExpression(vhdExpression Result)
	{
		this.Children.Add(new vhdReturnExpression(Result));
		return this;
	}
	public vhdFunctionImplementationBlock WithReturnExpression()
	{
		this.Children.Add(new vhdReturnExpression());
		return this;
	}
}
public partial class vhdFunctionInterface
{
	//vhdComment
	public vhdFunctionInterface WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionInterface WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdFunctionInterface WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionInterface WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdFunctionPortDeclaration
	public vhdFunctionInterface WithFunctionPortDeclaration(vhdFunctionPortDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionInterface WithFunctionPortDeclaration(String Name, vhdDataType Type, Int32 Width)
	{
		this.Children.Add(new vhdFunctionPortDeclaration(Name, Type, Width));
		return this;
	}
	//vhdFunctionCustomPortDeclaration
	public vhdFunctionInterface WithFunctionCustomPortDeclaration(vhdFunctionCustomPortDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionInterface WithFunctionCustomPortDeclaration(String Name, String Type)
	{
		this.Children.Add(new vhdFunctionCustomPortDeclaration(Name, Type));
		return this;
	}
}
public partial class vhdFunctionPortDeclaration
{
}
public partial class vhdFunctionTypeDeclarations
{
	//vhdArrayTypeDeclaration
	public vhdFunctionTypeDeclarations WithArrayTypeDeclaration(vhdArrayTypeDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionTypeDeclarations WithArrayTypeDeclaration(String Name, Int32 Depth, vhdDataType Type, Int32 Width)
	{
		this.Children.Add(new vhdArrayTypeDeclaration(Name, Depth, Type, Width));
		return this;
	}
	//vhdSubTypeDeclaration
	public vhdFunctionTypeDeclarations WithSubTypeDeclaration(vhdSubTypeDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFunctionTypeDeclarations WithSubTypeDeclaration(String Name, vhdDataType Type, Int32 Width)
	{
		this.Children.Add(new vhdSubTypeDeclaration(Name, Type, Width));
		return this;
	}
}
public partial class vhdGenericBlock
{
	//vhdGenericBlock
	public vhdGenericBlock WithGenericBlock(vhdGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public partial class vhdIdentifier
{
}
public partial class vhdIdentifierExpression
{
}
public partial class vhdIf
{
}
public partial class vhdLibraryReference
{
}
public partial class vhdLogicExpression
{
}
public partial class vhdLogicSignal
{
}
public partial class vhdMathExpression
{
}
public abstract partial class vhdNet
{
}
public abstract partial class vhdNetTypeSource
{
}
public partial class vhdNull
{
}
public partial class vhdOthersExpression
{
}
public partial class vhdParenthesizedExpression
{
}
public partial class vhdPredefinedAttributeExpression
{
}
public partial class vhdProcedureCall
{
}
public partial class vhdProcedureCallExpression
{
}
public partial class vhdProcess
{
}
public partial class vhdProcessDeclarations
{
	//vhdComment
	public vhdProcessDeclarations WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdProcessDeclarations WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdProcessDeclarations WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdProcessDeclarations WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdDefaultSignal
	public vhdProcessDeclarations WithDefaultSignal(vhdDefaultSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdProcessDeclarations WithDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width, params String[] Initializer)
	{
		this.Children.Add(new vhdDefaultSignal(NetType, Name, DataType, Width, Initializer));
		return this;
	}
	//vhdLogicSignal
	public vhdProcessDeclarations WithLogicSignal(vhdLogicSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdProcessDeclarations WithLogicSignal(vhdNetTypeSource NetType, String Name, params RTLBitArray[] Initializer)
	{
		this.Children.Add(new vhdLogicSignal(NetType, Name, Initializer));
		return this;
	}
	//vhdArrayTypeDeclaration
	public vhdProcessDeclarations WithArrayTypeDeclaration(vhdArrayTypeDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdProcessDeclarations WithArrayTypeDeclaration(String Name, Int32 Depth, vhdDataType Type, Int32 Width)
	{
		this.Children.Add(new vhdArrayTypeDeclaration(Name, Depth, Type, Width));
		return this;
	}
	//vhdAlias
	public vhdProcessDeclarations WithAlias(vhdAlias obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdProcessDeclarations WithAlias(String Alias, vhdExpression Expression)
	{
		this.Children.Add(new vhdAlias(Alias, Expression));
		return this;
	}
}
public partial class vhdRange
{
}
public partial class vhdResizeExpression
{
}
public partial class vhdReturnExpression
{
}
public partial class vhdShiftExpression
{
}
public partial class vhdSimpleForLoop
{
}
public partial class vhdStandardEntityPort
{
}
public partial class vhdSubTypeDeclaration
{
}
public partial class vhdSyncBlock
{
}
public partial class vhdTernaryExpression
{
}
public partial class vhdText
{
}
public abstract partial class vhdTypeDeclaration
{
}
public partial class vhdUnaryExpression
{
}
public partial class vhdUse
{
}
} // Quokka.RTL.VHDL
