using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
public abstract partial class vlgAbstractCollection
{
}
public abstract partial class vlgAbstractForLoop
{
	//vlgAssign
	public vlgAbstractForLoop WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgAbstractForLoop WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgAbstractForLoop WithAssign(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Children.Add(new vlgAssign(Target, Type, Expression));
		return this;
	}
	//vlgGenericBlock
	public vlgAbstractForLoop WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public abstract partial class vlgAbstractObject
{
}
public partial class vlgAggregateExpression
{
}
public partial class vlgAssign
{
}
public partial class vlgAssignExpression
{
}
public partial class vlgAttribute
{
}
public partial class vlgBinaryValueExpression
{
}
public abstract partial class vlgBlock
{
	//vlgComment
	public vlgBlock WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	//vlgText
	public vlgBlock WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	//vlgForLoop
	public vlgBlock WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	//vlgSimpleForLoop
	public vlgBlock WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	//vlgAssign
	public vlgBlock WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgBlock WithAssign(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Children.Add(new vlgAssign(Target, Type, Expression));
		return this;
	}
	//vlgGenericBlock
	public vlgBlock WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgProcedureCall
	public vlgBlock WithProcedureCall(vlgProcedureCall obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithProcedureCall(String Proc, String Name, params vlgExpression[] Parameters)
	{
		this.Children.Add(new vlgProcedureCall(Proc, Name, Parameters));
		return this;
	}
	//vlgGenvar
	public vlgBlock WithGenvar(vlgGenvar obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithGenvar(String Name)
	{
		this.Children.Add(new vlgGenvar(Name));
		return this;
	}
	//vlgGenerate
	public vlgBlock WithGenerate(vlgGenerate obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithGenerate(vlgGenericBlock Block)
	{
		this.Children.Add(new vlgGenerate(Block));
		return this;
	}
	public vlgBlock WithGenerate()
	{
		this.Children.Add(new vlgGenerate());
		return this;
	}
	//vlgModuleInstance
	public vlgBlock WithModuleInstance(vlgModuleInstance obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithModuleInstance(String Type, String Name)
	{
		this.Children.Add(new vlgModuleInstance(Type, Name));
		return this;
	}
	//vlgCase
	public vlgBlock WithCase(vlgCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Children.Add(new vlgCase(Check, Statements));
		return this;
	}
	//vlgIf
	public vlgBlock WithIf(vlgIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public partial class vlgCase
{
}
public partial class vlgCaseDefault
{
}
public abstract partial class vlgCaseItem
{
}
public partial class vlgCaseStatement
{
}
public partial class vlgCombBlock
{
}
public partial class vlgComment
{
}
public partial class vlgCompareExpression
{
}
public partial class vlgConditionalStatement
{
}
public partial class vlgCustomDeclaration
{
}
public partial class vlgCustomModulePortDeclaration
{
}
public abstract partial class vlgDeclarationModulePort
{
}
public abstract partial class vlgExpression
{
}
public partial class vlgFile
{
	//vlgComment
	public vlgFile WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFile WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	//vlgText
	public vlgFile WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFile WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	//vlgModule
	public vlgFile WithModule(vlgModule obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFile WithModule(String Name)
	{
		this.Children.Add(new vlgModule(Name));
		return this;
	}
	//vlgAttribute
	public vlgFile WithAttribute(vlgAttribute obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFile WithAttribute(String Name, String Value)
	{
		this.Children.Add(new vlgAttribute(Name, Value));
		return this;
	}
}
public partial class vlgForLoop
{
}
public partial class vlgFunction
{
}
public partial class vlgFunctionDeclaration
{
}
public partial class vlgFunctionImplementation
{
}
public partial class vlgFunctionImplementationBlock
{
	//vlgComment
	public vlgFunctionImplementationBlock WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFunctionImplementationBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	//vlgText
	public vlgFunctionImplementationBlock WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFunctionImplementationBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	//vlgAssign
	public vlgFunctionImplementationBlock WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFunctionImplementationBlock WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgFunctionImplementationBlock WithAssign(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Children.Add(new vlgAssign(Target, Type, Expression));
		return this;
	}
}
public partial class vlgFunctionInterface
{
	//vlgComment
	public vlgFunctionInterface WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFunctionInterface WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	//vlgText
	public vlgFunctionInterface WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFunctionInterface WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	//vlgFunctionPortDeclaration
	public vlgFunctionInterface WithFunctionPortDeclaration(vlgFunctionPortDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgFunctionInterface WithFunctionPortDeclaration(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Children.Add(new vlgFunctionPortDeclaration(Direction, NetType, Sign, Width, Name));
		return this;
	}
}
public partial class vlgFunctionPortDeclaration
{
}
public partial class vlgGenerate
{
}
public partial class vlgGenericBlock
{
}
public partial class vlgGenvar
{
}
public partial class vlgIdentifier
{
}
public partial class vlgIdentifierExpression
{
}
public partial class vlgIf
{
}
public partial class vlgInitial
{
	//vlgComment
	public vlgInitial WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgInitial WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	//vlgText
	public vlgInitial WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgInitial WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	//vlgSimpleForLoop
	public vlgInitial WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgInitial WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	//vlgAssign
	public vlgInitial WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgInitial WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgInitial WithAssign(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
	{
		this.Children.Add(new vlgAssign(Target, Type, Expression));
		return this;
	}
}
public partial class vlgIntegerExpression
{
}
public partial class vlgIterator
{
}
public abstract partial class vlgLocalParam
{
}
public abstract partial class vlgLocalParamName
{
}
public partial class vlgLocalParamNameBinaryValue
{
}
public partial class vlgLocalParamNameExplicitValue
{
}
public partial class vlgLogicExpression
{
}
public partial class vlgLogicSignal
{
}
public partial class vlgMathExpression
{
}
public partial class vlgMemoryBlock
{
}
public partial class vlgModule
{
}
public partial class vlgModuleImplementation
{
}
public partial class vlgModuleImplementationBlock
{
	//vlgLocalParamNameBinaryValue
	public vlgModuleImplementationBlock WithLocalParamNameBinaryValue(vlgLocalParamNameBinaryValue obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithLocalParamNameBinaryValue(String Name, RTLBitArray Value)
	{
		this.Children.Add(new vlgLocalParamNameBinaryValue(Name, Value));
		return this;
	}
	//vlgLocalParamNameExplicitValue
	public vlgModuleImplementationBlock WithLocalParamNameExplicitValue(vlgLocalParamNameExplicitValue obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithLocalParamNameExplicitValue(String Name, String Value)
	{
		this.Children.Add(new vlgLocalParamNameExplicitValue(Name, Value));
		return this;
	}
	//vlgStandardModulePortImplementation
	public vlgModuleImplementationBlock WithStandardModulePortImplementation(vlgStandardModulePortImplementation obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithStandardModulePortImplementation(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Children.Add(new vlgStandardModulePortImplementation(Direction, NetType, Sign, Width, Name));
		return this;
	}
	//vlgCustomDeclaration
	public vlgModuleImplementationBlock WithCustomDeclaration(vlgCustomDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithCustomDeclaration(String Type, String Name, String Initializer)
	{
		this.Children.Add(new vlgCustomDeclaration(Type, Name, Initializer));
		return this;
	}
	//vlgLogicSignal
	public vlgModuleImplementationBlock WithLogicSignal(vlgLogicSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithLogicSignal(vlgNetType NetType, vlgSignType Sign, String Name, Int32 Width, String Initializer)
	{
		this.Children.Add(new vlgLogicSignal(NetType, Sign, Name, Width, Initializer));
		return this;
	}
	//vlgMemoryBlock
	public vlgModuleImplementationBlock WithMemoryBlock(vlgMemoryBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithMemoryBlock(vlgNetType NetType, String Name, vlgSignType Sign, Int32 Width, Int32 Depth)
	{
		this.Children.Add(new vlgMemoryBlock(NetType, Name, Sign, Width, Depth));
		return this;
	}
	//vlgInitial
	public vlgModuleImplementationBlock WithInitial(vlgInitial obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithInitial(String Name)
	{
		this.Children.Add(new vlgInitial(Name));
		return this;
	}
	//vlgIterator
	public vlgModuleImplementationBlock WithIterator(vlgIterator obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithIterator(String Name)
	{
		this.Children.Add(new vlgIterator(Name));
		return this;
	}
	//vlgCombBlock
	public vlgModuleImplementationBlock WithCombBlock(vlgCombBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithCombBlock(params vlgIdentifier[] SensitivityList)
	{
		this.Children.Add(new vlgCombBlock(SensitivityList));
		return this;
	}
	//vlgSyncBlock
	public vlgModuleImplementationBlock WithSyncBlock(vlgSyncBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithSyncBlock(params vlgSyncBlockSensitivityItem[] SensitivityList)
	{
		this.Children.Add(new vlgSyncBlock(SensitivityList));
		return this;
	}
	//vlgModuleImplementationBlock
	public vlgModuleImplementationBlock WithModuleImplementationBlock(vlgModuleImplementationBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgFunction
	public vlgModuleImplementationBlock WithFunction(vlgFunction obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithFunction(vlgFunctionDeclaration Declaration)
	{
		this.Children.Add(new vlgFunction(Declaration));
		return this;
	}
	public vlgModuleImplementationBlock WithFunction(String Name, Int32 Width)
	{
		this.Children.Add(new vlgFunction(Name, Width));
		return this;
	}
}
public partial class vlgModuleInstance
{
}
public partial class vlgModuleInstanceNamedPortMapping
{
}
public partial class vlgModuleInstanceParameter
{
}
public partial class vlgModuleInstanceParameters
{
	//vlgModuleInstanceParameter
	public vlgModuleInstanceParameters WithModuleInstanceParameter(vlgModuleInstanceParameter obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInstanceParameters WithModuleInstanceParameter(String Name, String Value)
	{
		this.Children.Add(new vlgModuleInstanceParameter(Name, Value));
		return this;
	}
}
public abstract partial class vlgModuleInstancePortMapping
{
}
public partial class vlgModuleInstancePortMappings
{
	//vlgComment
	public vlgModuleInstancePortMappings WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInstancePortMappings WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	//vlgText
	public vlgModuleInstancePortMappings WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInstancePortMappings WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	//vlgModuleInstanceNamedPortMapping
	public vlgModuleInstancePortMappings WithModuleInstanceNamedPortMapping(vlgModuleInstanceNamedPortMapping obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInstancePortMappings WithModuleInstanceNamedPortMapping(String Internal, vlgExpression External)
	{
		this.Children.Add(new vlgModuleInstanceNamedPortMapping(Internal, External));
		return this;
	}
	//vlgModuleInstanceSimplePortMapping
	public vlgModuleInstancePortMappings WithModuleInstanceSimplePortMapping(vlgModuleInstanceSimplePortMapping obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInstancePortMappings WithModuleInstanceSimplePortMapping(vlgExpression External)
	{
		this.Children.Add(new vlgModuleInstanceSimplePortMapping(External));
		return this;
	}
	public vlgModuleInstancePortMappings WithModuleInstanceSimplePortMapping()
	{
		this.Children.Add(new vlgModuleInstanceSimplePortMapping());
		return this;
	}
}
public partial class vlgModuleInstanceSimplePortMapping
{
}
public partial class vlgModuleInterface
{
	//vlgComment
	public vlgModuleInterface WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInterface WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	//vlgText
	public vlgModuleInterface WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInterface WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	//vlgPlaceholderModulePort
	public vlgModuleInterface WithPlaceholderModulePort(vlgPlaceholderModulePort obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInterface WithPlaceholderModulePort(String Name)
	{
		this.Children.Add(new vlgPlaceholderModulePort(Name));
		return this;
	}
	//vlgCustomModulePortDeclaration
	public vlgModuleInterface WithCustomModulePortDeclaration(vlgCustomModulePortDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInterface WithCustomModulePortDeclaration(vlgPortDirection Direction, vlgNetType NetType, String DataType, String Name)
	{
		this.Children.Add(new vlgCustomModulePortDeclaration(Direction, NetType, DataType, Name));
		return this;
	}
	//vlgStandardModulePortDeclaration
	public vlgModuleInterface WithStandardModulePortDeclaration(vlgStandardModulePortDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleInterface WithStandardModulePortDeclaration(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Children.Add(new vlgStandardModulePortDeclaration(Direction, NetType, Sign, Width, Name));
		return this;
	}
}
public partial class vlgModuleParameterDeclaration
{
}
public partial class vlgModuleParameters
{
	//vlgComment
	public vlgModuleParameters WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleParameters WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	//vlgText
	public vlgModuleParameters WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleParameters WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	//vlgModuleParameterDeclaration
	public vlgModuleParameters WithModuleParameterDeclaration(vlgModuleParameterDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleParameters WithModuleParameterDeclaration(String Name, Int32 Width, RTLBitArray DefaultValue)
	{
		this.Children.Add(new vlgModuleParameterDeclaration(Name, Width, DefaultValue));
		return this;
	}
}
public abstract partial class vlgModulePort
{
}
public partial class vlgPlaceholderModulePort
{
}
public partial class vlgProcedureCall
{
}
public partial class vlgProcedureCallExpression
{
}
public partial class vlgRange
{
}
public partial class vlgShiftExpression
{
}
public abstract partial class vlgSignal
{
}
public partial class vlgSimpleForLoop
{
}
public partial class vlgSizedAggregateExpression
{
}
public abstract partial class vlgStandardModulePort
{
}
public partial class vlgStandardModulePortDeclaration
{
}
public partial class vlgStandardModulePortImplementation
{
}
public partial class vlgSyncBlock
{
}
public partial class vlgSyncBlockSensitivityItem
{
}
public partial class vlgTernaryExpression
{
}
public partial class vlgText
{
}
public partial class vlgUnaryExpression
{
}
} // Quokka.RTL.Verilog
