using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
public abstract partial class vlgAbstractForLoop
{
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
}
public partial class vlgCase
{
}
public partial class vlgCaseDefault
{
	//vlgAssign
	public vlgCaseDefault WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgCaseDefault WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCase
	public vlgCaseDefault WithCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Children.Add(new vlgCase(Check, Statements));
		return this;
	}
	public vlgCaseDefault WithCase(vlgCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgComment
	public vlgCaseDefault WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgCaseDefault WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgForLoop
	public vlgCaseDefault WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	public vlgCaseDefault WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgCaseDefault WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgCaseDefault WithIf(vlgIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgCaseDefault WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgCaseDefault WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgCaseDefault WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgCaseDefault WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgCase> AsCase => Children.OfType<vlgCase>();
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
}
public abstract partial class vlgCaseItem
{
}
public partial class vlgCaseStatement
{
	//vlgAssign
	public vlgCaseStatement WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgCaseStatement WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCase
	public vlgCaseStatement WithCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Children.Add(new vlgCase(Check, Statements));
		return this;
	}
	public vlgCaseStatement WithCase(vlgCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgComment
	public vlgCaseStatement WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgCaseStatement WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgForLoop
	public vlgCaseStatement WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	public vlgCaseStatement WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgCaseStatement WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgCaseStatement WithIf(vlgIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgCaseStatement WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgCaseStatement WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgCaseStatement WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgCaseStatement WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgCase> AsCase => Children.OfType<vlgCase>();
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
}
public partial class vlgCombBlock
{
	//vlgAssign
	public vlgCombBlock WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgCombBlock WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCase
	public vlgCombBlock WithCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Children.Add(new vlgCase(Check, Statements));
		return this;
	}
	public vlgCombBlock WithCase(vlgCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgComment
	public vlgCombBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgCombBlock WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgForLoop
	public vlgCombBlock WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	public vlgCombBlock WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgCombBlock WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgCombBlock WithIf(vlgIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgCombBlock WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgCombBlock WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgCombBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgCombBlock WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgCase> AsCase => Children.OfType<vlgCase>();
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
}
public partial class vlgComment
{
}
public partial class vlgCompareExpression
{
}
public partial class vlgConditionalStatement
{
	//vlgAssign
	public vlgConditionalStatement WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgConditionalStatement WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCase
	public vlgConditionalStatement WithCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Children.Add(new vlgCase(Check, Statements));
		return this;
	}
	public vlgConditionalStatement WithCase(vlgCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgComment
	public vlgConditionalStatement WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgConditionalStatement WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgForLoop
	public vlgConditionalStatement WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	public vlgConditionalStatement WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgConditionalStatement WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgConditionalStatement WithIf(vlgIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgConditionalStatement WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgConditionalStatement WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgConditionalStatement WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgConditionalStatement WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgCase> AsCase => Children.OfType<vlgCase>();
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
}
public partial class vlgCustomDeclaration
{
}
public partial class vlgCustomModulePort
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
	public IEnumerable<vlgAttribute> AsAttribute => Children.OfType<vlgAttribute>();
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgModule> AsModule => Children.OfType<vlgModule>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
}
public partial class vlgForLoop
{
	//vlgAssign
	public vlgForLoop WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgForLoop WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgForLoop WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
}
public partial class vlgGenericBlock
{
	//vlgAssign
	public vlgGenericBlock WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgGenericBlock WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCase
	public vlgGenericBlock WithCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Children.Add(new vlgCase(Check, Statements));
		return this;
	}
	public vlgGenericBlock WithCase(vlgCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgComment
	public vlgGenericBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgGenericBlock WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgForLoop
	public vlgGenericBlock WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	public vlgGenericBlock WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgGenericBlock WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgGenericBlock WithIf(vlgIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgGenericBlock WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgGenericBlock WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgGenericBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgGenericBlock WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgCase> AsCase => Children.OfType<vlgCase>();
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
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
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
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
	//vlgAssign
	public vlgModuleImplementation WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgModuleImplementation WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementation WithCaseDefault(vlgCaseDefault obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCaseStatement
	public vlgModuleImplementation WithCaseStatement(params vlgICaseStatement[] Conditions)
	{
		this.Children.Add(new vlgCaseStatement(Conditions));
		return this;
	}
	public vlgModuleImplementation WithCaseStatement(vlgCaseStatement obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCombBlock
	public vlgModuleImplementation WithCombBlock(params vlgIdentifier[] SensitivityList)
	{
		this.Children.Add(new vlgCombBlock(SensitivityList));
		return this;
	}
	public vlgModuleImplementation WithCombBlock(vlgCombBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgComment
	public vlgModuleImplementation WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgModuleImplementation WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgConditionalStatement
	public vlgModuleImplementation WithConditionalStatement(vlgExpression Condition)
	{
		this.Children.Add(new vlgConditionalStatement(Condition));
		return this;
	}
	public vlgModuleImplementation WithConditionalStatement(vlgConditionalStatement obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCustomDeclaration
	public vlgModuleImplementation WithCustomDeclaration(String Type, String Name, String Initializer)
	{
		this.Children.Add(new vlgCustomDeclaration(Type, Name, Initializer));
		return this;
	}
	public vlgModuleImplementation WithCustomDeclaration(vlgCustomDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgForLoop
	public vlgModuleImplementation WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	public vlgModuleImplementation WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementation WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgModuleImplementation WithIf(vlgIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgInitial
	public vlgModuleImplementation WithInitial(String Name)
	{
		this.Children.Add(new vlgInitial(Name));
		return this;
	}
	public vlgModuleImplementation WithInitial(vlgInitial obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgIterator
	public vlgModuleImplementation WithIterator(String Name)
	{
		this.Children.Add(new vlgIterator(Name));
		return this;
	}
	public vlgModuleImplementation WithIterator(vlgIterator obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgLocalParamNameBinaryValue
	public vlgModuleImplementation WithLocalParamNameBinaryValue(String Name, RTLBitArray Value)
	{
		this.Children.Add(new vlgLocalParamNameBinaryValue(Name, Value));
		return this;
	}
	public vlgModuleImplementation WithLocalParamNameBinaryValue(vlgLocalParamNameBinaryValue obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgLocalParamNameExplicitValue
	public vlgModuleImplementation WithLocalParamNameExplicitValue(String Name, String Value)
	{
		this.Children.Add(new vlgLocalParamNameExplicitValue(Name, Value));
		return this;
	}
	public vlgModuleImplementation WithLocalParamNameExplicitValue(vlgLocalParamNameExplicitValue obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgLogicSignal
	public vlgModuleImplementation WithLogicSignal(vlgNetType NetType, vlgSignType Sign, String Name, Int32 Width, String Initializer)
	{
		this.Children.Add(new vlgLogicSignal(NetType, Sign, Name, Width, Initializer));
		return this;
	}
	public vlgModuleImplementation WithLogicSignal(vlgLogicSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgMemoryBlock
	public vlgModuleImplementation WithMemoryBlock(String Name, vlgSignType Sign, Int32 Width, Int32 Depth)
	{
		this.Children.Add(new vlgMemoryBlock(Name, Sign, Width, Depth));
		return this;
	}
	public vlgModuleImplementation WithMemoryBlock(vlgMemoryBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgModuleInstance
	public vlgModuleImplementation WithModuleInstance(String Type, String Name)
	{
		this.Children.Add(new vlgModuleInstance(Type, Name));
		return this;
	}
	public vlgModuleImplementation WithModuleInstance(vlgModuleInstance obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgModuleImplementation WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgModuleImplementation WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgStandardModulePortImplementation
	public vlgModuleImplementation WithStandardModulePortImplementation(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Children.Add(new vlgStandardModulePortImplementation(Direction, NetType, Sign, Width, Name));
		return this;
	}
	public vlgModuleImplementation WithStandardModulePortImplementation(vlgStandardModulePortImplementation obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSyncBlock
	public vlgModuleImplementation WithSyncBlock(params vlgSyncBlockSensitivityItem[] SensitivityList)
	{
		this.Children.Add(new vlgSyncBlock(SensitivityList));
		return this;
	}
	public vlgModuleImplementation WithSyncBlock(vlgSyncBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgModuleImplementation WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgModuleImplementation WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgCaseDefault> AsCaseDefault => Children.OfType<vlgCaseDefault>();
	public IEnumerable<vlgCaseStatement> AsCaseStatement => Children.OfType<vlgCaseStatement>();
	public IEnumerable<vlgCombBlock> AsCombBlock => Children.OfType<vlgCombBlock>();
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgConditionalStatement> AsConditionalStatement => Children.OfType<vlgConditionalStatement>();
	public IEnumerable<vlgCustomDeclaration> AsCustomDeclaration => Children.OfType<vlgCustomDeclaration>();
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	public IEnumerable<vlgInitial> AsInitial => Children.OfType<vlgInitial>();
	public IEnumerable<vlgIterator> AsIterator => Children.OfType<vlgIterator>();
	public IEnumerable<vlgLocalParamNameBinaryValue> AsLocalParamNameBinaryValue => Children.OfType<vlgLocalParamNameBinaryValue>();
	public IEnumerable<vlgLocalParamNameExplicitValue> AsLocalParamNameExplicitValue => Children.OfType<vlgLocalParamNameExplicitValue>();
	public IEnumerable<vlgLogicSignal> AsLogicSignal => Children.OfType<vlgLogicSignal>();
	public IEnumerable<vlgMemoryBlock> AsMemoryBlock => Children.OfType<vlgMemoryBlock>();
	public IEnumerable<vlgModuleInstance> AsModuleInstance => Children.OfType<vlgModuleInstance>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgStandardModulePortImplementation> AsStandardModulePortImplementation => Children.OfType<vlgStandardModulePortImplementation>();
	public IEnumerable<vlgSyncBlock> AsSyncBlock => Children.OfType<vlgSyncBlock>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgCaseItem> AsCaseItem => Children.OfType<vlgCaseItem>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgLocalParamName> AsLocalParamName => Children.OfType<vlgLocalParamName>();
	public IEnumerable<vlgSignal> AsSignal => Children.OfType<vlgSignal>();
	public IEnumerable<vlgStandardModulePort> AsStandardModulePort => Children.OfType<vlgStandardModulePort>();
	public IEnumerable<vlgLocalParam> AsLocalParam => Children.OfType<vlgLocalParam>();
	public IEnumerable<vlgDeclarationModulePort> AsDeclarationModulePort => Children.OfType<vlgDeclarationModulePort>();
	public IEnumerable<vlgModulePort> AsModulePort => Children.OfType<vlgModulePort>();
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
	public IEnumerable<vlgModuleInstanceParameter> AsModuleInstanceParameter => Children.OfType<vlgModuleInstanceParameter>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
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
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgModuleInstanceNamedPortMapping> AsModuleInstanceNamedPortMapping => Children.OfType<vlgModuleInstanceNamedPortMapping>();
	public IEnumerable<vlgModuleInstanceSimplePortMapping> AsModuleInstanceSimplePortMapping => Children.OfType<vlgModuleInstanceSimplePortMapping>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgModuleInstancePortMapping> AsModuleInstancePortMapping => Children.OfType<vlgModuleInstancePortMapping>();
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
	//vlgCustomModulePort
	public vlgModuleInterface WithCustomModulePort(vlgPortDirection Direction, vlgNetType NetType, String DataType, String Name)
	{
		this.Children.Add(new vlgCustomModulePort(Direction, NetType, DataType, Name));
		return this;
	}
	public vlgModuleInterface WithCustomModulePort(vlgCustomModulePort obj)
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
	//vlgStandardModulePortImplementation
	public vlgModuleInterface WithStandardModulePortImplementation(vlgPortDirection Direction, vlgNetType NetType, vlgSignType Sign, Int32 Width, String Name)
	{
		this.Children.Add(new vlgStandardModulePortImplementation(Direction, NetType, Sign, Width, Name));
		return this;
	}
	public vlgModuleInterface WithStandardModulePortImplementation(vlgStandardModulePortImplementation obj)
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
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgCustomModulePort> AsCustomModulePort => Children.OfType<vlgCustomModulePort>();
	public IEnumerable<vlgPlaceholderModulePort> AsPlaceholderModulePort => Children.OfType<vlgPlaceholderModulePort>();
	public IEnumerable<vlgStandardModulePortDeclaration> AsStandardModulePortDeclaration => Children.OfType<vlgStandardModulePortDeclaration>();
	public IEnumerable<vlgStandardModulePortImplementation> AsStandardModulePortImplementation => Children.OfType<vlgStandardModulePortImplementation>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgDeclarationModulePort> AsDeclarationModulePort => Children.OfType<vlgDeclarationModulePort>();
	public IEnumerable<vlgModulePort> AsModulePort => Children.OfType<vlgModulePort>();
	public IEnumerable<vlgStandardModulePort> AsStandardModulePort => Children.OfType<vlgStandardModulePort>();
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
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgModuleParameterDeclaration> AsModuleParameterDeclaration => Children.OfType<vlgModuleParameterDeclaration>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
}
public abstract partial class vlgModulePort
{
}
public partial class vlgPlaceholderModulePort
{
}
public partial class vlgRange
{
}
public abstract partial class vlgSignal
{
}
public partial class vlgSimpleForLoop
{
	//vlgAssign
	public vlgSimpleForLoop WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgSimpleForLoop WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgSimpleForLoop WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
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
	//vlgAssign
	public vlgSyncBlock WithAssign(vlgAssignExpression Expression)
	{
		this.Children.Add(new vlgAssign(Expression));
		return this;
	}
	public vlgSyncBlock WithAssign(vlgAssign obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgCase
	public vlgSyncBlock WithCase(vlgExpression Check, params vlgCaseStatement[] Statements)
	{
		this.Children.Add(new vlgCase(Check, Statements));
		return this;
	}
	public vlgSyncBlock WithCase(vlgCase obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgComment
	public vlgSyncBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vlgComment(Lines));
		return this;
	}
	public vlgSyncBlock WithComment(vlgComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgForLoop
	public vlgSyncBlock WithForLoop(vlgExpression Initializer, vlgExpression Condition, vlgExpression Increment)
	{
		this.Children.Add(new vlgForLoop(Initializer, Condition, Increment));
		return this;
	}
	public vlgSyncBlock WithForLoop(vlgForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgSyncBlock WithGenericBlock(vlgGenericBlock obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vlgSyncBlock WithIf(vlgIf obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgSimpleForLoop
	public vlgSyncBlock WithSimpleForLoop(String Iterator, Int32 From, Int32 To)
	{
		this.Children.Add(new vlgSimpleForLoop(Iterator, From, To));
		return this;
	}
	public vlgSyncBlock WithSimpleForLoop(vlgSimpleForLoop obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	//vlgText
	public vlgSyncBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vlgText(Lines));
		return this;
	}
	public vlgSyncBlock WithText(vlgText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgCase> AsCase => Children.OfType<vlgCase>();
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
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
