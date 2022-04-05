using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
using Newtonsoft.Json;
public abstract partial class vlgAbstractCollection
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public abstract partial class vlgAbstractForLoop
{
	[JsonIgnore]
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	[JsonIgnore]
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractCollection> AsAbstractCollection => Children.OfType<vlgAbstractCollection>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public abstract partial class vlgAbstractObject
{
	public abstract IEnumerable<vlgAbstractObject> SelfWithChildren();
}
public partial class vlgAggregateExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Expressions != null) result.AddRange(Expressions.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgAssign
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Expression != null) result.AddRange(Expression.SelfWithChildren());
		return result;
	}
}
public partial class vlgAssignExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Target != null) result.AddRange(Target.SelfWithChildren());
		if (Expression != null) result.AddRange(Expression.SelfWithChildren());
		return result;
	}
}
public partial class vlgAttribute
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgBinaryValueExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vlgBlock
{
	[JsonIgnore]
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	[JsonIgnore]
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	[JsonIgnore]
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	[JsonIgnore]
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	[JsonIgnore]
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	[JsonIgnore]
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	[JsonIgnore]
	public IEnumerable<vlgProcedureCall> AsProcedureCall => Children.OfType<vlgProcedureCall>();
	[JsonIgnore]
	public IEnumerable<vlgGenvar> AsGenvar => Children.OfType<vlgGenvar>();
	[JsonIgnore]
	public IEnumerable<vlgGenerate> AsGenerate => Children.OfType<vlgGenerate>();
	[JsonIgnore]
	public IEnumerable<vlgModuleInstance> AsModuleInstance => Children.OfType<vlgModuleInstance>();
	[JsonIgnore]
	public IEnumerable<vlgCase> AsCase => Children.OfType<vlgCase>();
	[JsonIgnore]
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	[JsonIgnore]
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractCollection> AsAbstractCollection => Children.OfType<vlgAbstractCollection>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgCase
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Check != null) result.AddRange(Check.SelfWithChildren());
		if (Statements != null) result.AddRange(Statements.SelectMany(c => c.SelfWithChildren()));
		if (Default != null) result.AddRange(Default.SelfWithChildren());
		return result;
	}
}
public partial class vlgCaseDefault
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public abstract partial class vlgCaseItem
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vlgCaseStatement
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vlgCombBlock
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (SensitivityList != null) result.AddRange(SensitivityList.SelectMany(c => c.SelfWithChildren()));
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vlgComment
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgCompareExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vlgConditionalStatement
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Condition != null) result.AddRange(Condition.SelfWithChildren());
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vlgCustomDeclaration
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgCustomModulePortDeclaration
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vlgDeclarationModulePort
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vlgExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgFile
{
	[JsonIgnore]
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	[JsonIgnore]
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	[JsonIgnore]
	public IEnumerable<vlgModule> AsModule => Children.OfType<vlgModule>();
	[JsonIgnore]
	public IEnumerable<vlgAttribute> AsAttribute => Children.OfType<vlgAttribute>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgForLoop
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		if (Initializer != null) result.AddRange(Initializer.SelfWithChildren());
		if (Condition != null) result.AddRange(Condition.SelfWithChildren());
		if (Increment != null) result.AddRange(Increment.SelfWithChildren());
		return result;
	}
}
public partial class vlgGenerate
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vlgGenericBlock
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgGenvar
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgIdentifier
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Indexes != null) result.AddRange(Indexes.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgIdentifierExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Source != null) result.AddRange(Source.SelfWithChildren());
		return result;
	}
}
public partial class vlgIf
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Statements != null) result.AddRange(Statements.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgInitial
{
	[JsonIgnore]
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	[JsonIgnore]
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	[JsonIgnore]
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	[JsonIgnore]
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractCollection> AsAbstractCollection => Children.OfType<vlgAbstractCollection>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgIterator
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vlgLocalParam
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vlgLocalParamName
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgLocalParamNameBinaryValue
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgLocalParamNameExplicitValue
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgLogicExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vlgLogicSignal
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgMathExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vlgMemoryBlock
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgModule
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Parameters != null) result.AddRange(Parameters.SelfWithChildren());
		if (Interface != null) result.AddRange(Interface.SelfWithChildren());
		if (Implementation != null) result.AddRange(Implementation.SelfWithChildren());
		return result;
	}
}
public partial class vlgModuleImplementation
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vlgModuleImplementationBlock
{
	[JsonIgnore]
	public IEnumerable<vlgLocalParamNameBinaryValue> AsLocalParamNameBinaryValue => Children.OfType<vlgLocalParamNameBinaryValue>();
	[JsonIgnore]
	public IEnumerable<vlgLocalParamNameExplicitValue> AsLocalParamNameExplicitValue => Children.OfType<vlgLocalParamNameExplicitValue>();
	[JsonIgnore]
	public IEnumerable<vlgStandardModulePortImplementation> AsStandardModulePortImplementation => Children.OfType<vlgStandardModulePortImplementation>();
	[JsonIgnore]
	public IEnumerable<vlgCustomDeclaration> AsCustomDeclaration => Children.OfType<vlgCustomDeclaration>();
	[JsonIgnore]
	public IEnumerable<vlgLogicSignal> AsLogicSignal => Children.OfType<vlgLogicSignal>();
	[JsonIgnore]
	public IEnumerable<vlgMemoryBlock> AsMemoryBlock => Children.OfType<vlgMemoryBlock>();
	[JsonIgnore]
	public IEnumerable<vlgInitial> AsInitial => Children.OfType<vlgInitial>();
	[JsonIgnore]
	public IEnumerable<vlgIterator> AsIterator => Children.OfType<vlgIterator>();
	[JsonIgnore]
	public IEnumerable<vlgCombBlock> AsCombBlock => Children.OfType<vlgCombBlock>();
	[JsonIgnore]
	public IEnumerable<vlgSyncBlock> AsSyncBlock => Children.OfType<vlgSyncBlock>();
	[JsonIgnore]
	public IEnumerable<vlgModuleImplementationBlock> AsModuleImplementationBlock => Children.OfType<vlgModuleImplementationBlock>();
	[JsonIgnore]
	public IEnumerable<vlgLocalParamName> AsLocalParamName => Children.OfType<vlgLocalParamName>();
	[JsonIgnore]
	public IEnumerable<vlgStandardModulePort> AsStandardModulePort => Children.OfType<vlgStandardModulePort>();
	[JsonIgnore]
	public IEnumerable<vlgSignal> AsSignal => Children.OfType<vlgSignal>();
	[JsonIgnore]
	public IEnumerable<vlgLocalParam> AsLocalParam => Children.OfType<vlgLocalParam>();
	[JsonIgnore]
	public IEnumerable<vlgDeclarationModulePort> AsDeclarationModulePort => Children.OfType<vlgDeclarationModulePort>();
	[JsonIgnore]
	public IEnumerable<vlgModulePort> AsModulePort => Children.OfType<vlgModulePort>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgModuleInstance
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Parameters != null) result.AddRange(Parameters.SelfWithChildren());
		if (PortMappings != null) result.AddRange(PortMappings.SelfWithChildren());
		return result;
	}
}
public partial class vlgModuleInstanceNamedPortMapping
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (External != null) result.AddRange(External.SelfWithChildren());
		return result;
	}
}
public partial class vlgModuleInstanceParameter
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgModuleInstanceParameters
{
	[JsonIgnore]
	public IEnumerable<vlgModuleInstanceParameter> AsModuleInstanceParameter => Children.OfType<vlgModuleInstanceParameter>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public abstract partial class vlgModuleInstancePortMapping
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgModuleInstancePortMappings
{
	[JsonIgnore]
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	[JsonIgnore]
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	[JsonIgnore]
	public IEnumerable<vlgModuleInstanceNamedPortMapping> AsModuleInstanceNamedPortMapping => Children.OfType<vlgModuleInstanceNamedPortMapping>();
	[JsonIgnore]
	public IEnumerable<vlgModuleInstanceSimplePortMapping> AsModuleInstanceSimplePortMapping => Children.OfType<vlgModuleInstanceSimplePortMapping>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vlgModuleInstancePortMapping> AsModuleInstancePortMapping => Children.OfType<vlgModuleInstancePortMapping>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgModuleInstanceSimplePortMapping
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (External != null) result.AddRange(External.SelfWithChildren());
		return result;
	}
}
public partial class vlgModuleInterface
{
	[JsonIgnore]
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	[JsonIgnore]
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	[JsonIgnore]
	public IEnumerable<vlgPlaceholderModulePort> AsPlaceholderModulePort => Children.OfType<vlgPlaceholderModulePort>();
	[JsonIgnore]
	public IEnumerable<vlgCustomModulePortDeclaration> AsCustomModulePortDeclaration => Children.OfType<vlgCustomModulePortDeclaration>();
	[JsonIgnore]
	public IEnumerable<vlgStandardModulePortDeclaration> AsStandardModulePortDeclaration => Children.OfType<vlgStandardModulePortDeclaration>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vlgModulePort> AsModulePort => Children.OfType<vlgModulePort>();
	[JsonIgnore]
	public IEnumerable<vlgDeclarationModulePort> AsDeclarationModulePort => Children.OfType<vlgDeclarationModulePort>();
	[JsonIgnore]
	public IEnumerable<vlgStandardModulePort> AsStandardModulePort => Children.OfType<vlgStandardModulePort>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgModuleParameterDeclaration
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgModuleParameters
{
	[JsonIgnore]
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	[JsonIgnore]
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	[JsonIgnore]
	public IEnumerable<vlgModuleParameterDeclaration> AsModuleParameterDeclaration => Children.OfType<vlgModuleParameterDeclaration>();
	[JsonIgnore]
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public abstract partial class vlgModulePort
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgPlaceholderModulePort
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgProcedureCall
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Parameters != null) result.AddRange(Parameters.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgRange
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Indexes != null) result.AddRange(Indexes.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgShiftExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public abstract partial class vlgSignal
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgSimpleForLoop
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vlgSizedAggregateExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Expressions != null) result.AddRange(Expressions.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public abstract partial class vlgStandardModulePort
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgStandardModulePortDeclaration
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgStandardModulePortImplementation
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgSyncBlock
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (SensitivityList != null) result.AddRange(SensitivityList.SelectMany(c => c.SelfWithChildren()));
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vlgSyncBlockSensitivityItem
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Identifier != null) result.AddRange(Identifier.SelfWithChildren());
		return result;
	}
}
public partial class vlgTernaryExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Condition != null) result.AddRange(Condition.SelfWithChildren());
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vlgText
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		return result;
	}
}
public partial class vlgUnaryExpression
{
	public override IEnumerable<vlgAbstractObject> SelfWithChildren()
	{
		var result = new List<vlgAbstractObject>() { this };
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
} // Quokka.RTL.Verilog
