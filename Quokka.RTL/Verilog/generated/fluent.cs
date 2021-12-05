using System;
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
	public vlgAbstractForLoop WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgAbstractForLoop WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgAbstractForLoop WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public abstract partial class vlgAbstractObject
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
	public vlgBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgBlock WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgBlock WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgForLoop
	public vlgBlock WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	public vlgBlock WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgBlock WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgBlock WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgAssign
	public vlgBlock WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgBlock WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgBlock WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgProcedureCall
	public vlgBlock WithProcedureCall(String Proc, String Name, params vlgExpression[] Parameters)
	{
		this.Children.Add(new vlgProcedureCall(Proc, Name, Parameters));
		return this;
	}
	public vlgBlock WithProcedureCall(vlgProcedureCall obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgGenvar
	public vlgBlock WithGenvar(String Name)
	{
		this.Children.Add(new vlgGenvar(Name));
		return this;
	}
	public vlgBlock WithGenvar(vlgGenvar obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgGenerate
	public vlgBlock WithGenerate(vlgGenericBlock Block)
	{
		this.Children.Add(new vlgGenerate(Block));
		return this;
	}
	public vlgBlock WithGenerate(vlgGenerate obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgModuleInstance
	public vlgBlock WithModuleInstance(String Type, String Name)
	{
		this.Children.Add(new vlgModuleInstance(Type, Name));
		return this;
	}
	public vlgBlock WithModuleInstance(vlgModuleInstance obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCase
	public vlgBlock WithCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Children.Add(new vlgCase(Check, Statements));
		return this;
	}
	public vlgBlock WithCase(vlgCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
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
	public vlgFile WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgFile WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgFile WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgFile WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgModule
	public vlgFile WithModule(String Name)
	{
		this.Children.Add(new vlgModule(Name));
		return this;
	}
	public vlgFile WithModule(vlgModule obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgAttribute
	public vlgFile WithAttribute(String Name, String Value)
	{
		this.Children.Add(new vlgAttribute(Name, Value));
		return this;
	}
	public vlgFile WithAttribute(vlgAttribute obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public partial class vlgForLoop
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
	public vlgInitial WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgInitial WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgInitial WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgInitial WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgInitial WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgInitial WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgAssign
	public vlgInitial WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgInitial WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
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
	public vlgModuleImplementationBlock WithLocalParamNameBinaryValue(String Name, RTLBitArray Value)
	{
		this.Children.Add(new vlgLocalParamNameBinaryValue(Name, Value));
		return this;
	}
	public vlgModuleImplementationBlock WithLocalParamNameBinaryValue(vlgLocalParamNameBinaryValue obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgLocalParamNameExplicitValue
	public vlgModuleImplementationBlock WithLocalParamNameExplicitValue(String Name, String Value)
	{
		this.Children.Add(new vlgLocalParamNameExplicitValue(Name, Value));
		return this;
	}
	public vlgModuleImplementationBlock WithLocalParamNameExplicitValue(vlgLocalParamNameExplicitValue obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgStandardModulePortImplementation
	public vlgModuleImplementationBlock WithStandardModulePortImplementation(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Children.Add(new vlgStandardModulePortImplementation(Direction, NetType, Sign, Width, Name));
		return this;
	}
	public vlgModuleImplementationBlock WithStandardModulePortImplementation(vlgStandardModulePortImplementation obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCustomDeclaration
	public vlgModuleImplementationBlock WithCustomDeclaration(String Type, String Name, String Initializer)
	{
		this.Children.Add(new vlgCustomDeclaration(Type, Name, Initializer));
		return this;
	}
	public vlgModuleImplementationBlock WithCustomDeclaration(vlgCustomDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgLogicSignal
	public vlgModuleImplementationBlock WithLogicSignal(vlgNetType NetType, vlgSignType Sign, String Name, Int32 Width, String Initializer)
	{
		this.Children.Add(new vlgLogicSignal(NetType, Sign, Name, Width, Initializer));
		return this;
	}
	public vlgModuleImplementationBlock WithLogicSignal(vlgLogicSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgMemoryBlock
	public vlgModuleImplementationBlock WithMemoryBlock(String Name, vlgSignType Sign, Int32 Width, Int32 Depth)
	{
		this.Children.Add(new vlgMemoryBlock(Name, Sign, Width, Depth));
		return this;
	}
	public vlgModuleImplementationBlock WithMemoryBlock(vlgMemoryBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgInitial
	public vlgModuleImplementationBlock WithInitial(String Name)
	{
		this.Children.Add(new vlgInitial(Name));
		return this;
	}
	public vlgModuleImplementationBlock WithInitial(vlgInitial obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgIterator
	public vlgModuleImplementationBlock WithIterator(String Name)
	{
		this.Children.Add(new vlgIterator(Name));
		return this;
	}
	public vlgModuleImplementationBlock WithIterator(vlgIterator obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCombBlock
	public vlgModuleImplementationBlock WithCombBlock(params vlgIdentifier[] SensitivityList)
	{
		this.Children.Add(new vlgCombBlock(SensitivityList));
		return this;
	}
	public vlgModuleImplementationBlock WithCombBlock(vlgCombBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSyncBlock
	public vlgModuleImplementationBlock WithSyncBlock(params vlgSyncBlockSensitivityItem[] SensitivityList)
	{
		this.Children.Add(new vlgSyncBlock(SensitivityList));
		return this;
	}
	public vlgModuleImplementationBlock WithSyncBlock(vlgSyncBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementationBlock WithModuleImplementationBlock(vlgModuleImplementationBlock obj)
	{
		if (obj != null) Children.Add(obj);
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
	public vlgModuleInstanceParameters WithModuleInstanceParameter(String Name, String Value)
	{
		this.Children.Add(new vlgModuleInstanceParameter(Name, Value));
		return this;
	}
	public vlgModuleInstanceParameters WithModuleInstanceParameter(vlgModuleInstanceParameter obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public abstract partial class vlgModuleInstancePortMapping
{
}
public partial class vlgModuleInstancePortMappings
{
	//vlgComment
	public vlgModuleInstancePortMappings WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgModuleInstancePortMappings WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgModuleInstancePortMappings WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgModuleInstancePortMappings WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgModuleInstanceNamedPortMapping
	public vlgModuleInstancePortMappings WithModuleInstanceNamedPortMapping(String Internal, vlgExpression External)
	{
		this.Children.Add(new vlgModuleInstanceNamedPortMapping(Internal, External));
		return this;
	}
	public vlgModuleInstancePortMappings WithModuleInstanceNamedPortMapping(vlgModuleInstanceNamedPortMapping obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgModuleInstanceSimplePortMapping
	public vlgModuleInstancePortMappings WithModuleInstanceSimplePortMapping(vlgExpression External)
	{
		this.Children.Add(new vlgModuleInstanceSimplePortMapping(External));
		return this;
	}
	public vlgModuleInstancePortMappings WithModuleInstanceSimplePortMapping(vlgModuleInstanceSimplePortMapping obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public partial class vlgModuleInstanceSimplePortMapping
{
}
public partial class vlgModuleInterface
{
	//vlgComment
	public vlgModuleInterface WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgModuleInterface WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgModuleInterface WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgModuleInterface WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgPlaceholderModulePort
	public vlgModuleInterface WithPlaceholderModulePort(String Name)
	{
		this.Children.Add(new vlgPlaceholderModulePort(Name));
		return this;
	}
	public vlgModuleInterface WithPlaceholderModulePort(vlgPlaceholderModulePort obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCustomModulePortDeclaration
	public vlgModuleInterface WithCustomModulePortDeclaration(vlgPortDirection Direction, vlgNetType NetType, String DataType, String Name)
	{
		this.Children.Add(new vlgCustomModulePortDeclaration(Direction, NetType, DataType, Name));
		return this;
	}
	public vlgModuleInterface WithCustomModulePortDeclaration(vlgCustomModulePortDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgStandardModulePortDeclaration
	public vlgModuleInterface WithStandardModulePortDeclaration(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Children.Add(new vlgStandardModulePortDeclaration(Direction, NetType, Sign, Width, Name));
		return this;
	}
	public vlgModuleInterface WithStandardModulePortDeclaration(vlgStandardModulePortDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
}
public partial class vlgModuleParameterDeclaration
{
}
public partial class vlgModuleParameters
{
	//vlgComment
	public vlgModuleParameters WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgModuleParameters WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgModuleParameters WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgModuleParameters WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgModuleParameterDeclaration
	public vlgModuleParameters WithModuleParameterDeclaration(String Name, Int32 Width, RTLBitArray DefaultValue)
	{
		this.Children.Add(new vlgModuleParameterDeclaration(Name, Width, DefaultValue));
		return this;
	}
	public vlgModuleParameters WithModuleParameterDeclaration(vlgModuleParameterDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
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
