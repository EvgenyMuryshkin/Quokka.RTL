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
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
	public IEnumerable<vlgAbstractCollection> AsAbstractCollection => Children.OfType<vlgAbstractCollection>();
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
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgForLoop> AsForLoop => Children.OfType<vlgForLoop>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgGenericBlock> AsGenericBlock => Children.OfType<vlgGenericBlock>();
	public IEnumerable<vlgProcedureCall> AsProcedureCall => Children.OfType<vlgProcedureCall>();
	public IEnumerable<vlgGenvar> AsGenvar => Children.OfType<vlgGenvar>();
	public IEnumerable<vlgGenerate> AsGenerate => Children.OfType<vlgGenerate>();
	public IEnumerable<vlgModuleInstance> AsModuleInstance => Children.OfType<vlgModuleInstance>();
	public IEnumerable<vlgCase> AsCase => Children.OfType<vlgCase>();
	public IEnumerable<vlgIf> AsIf => Children.OfType<vlgIf>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgBlock> AsBlock => Children.OfType<vlgBlock>();
	public IEnumerable<vlgAbstractCollection> AsAbstractCollection => Children.OfType<vlgAbstractCollection>();
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
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgModule> AsModule => Children.OfType<vlgModule>();
	public IEnumerable<vlgAttribute> AsAttribute => Children.OfType<vlgAttribute>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
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
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgSimpleForLoop> AsSimpleForLoop => Children.OfType<vlgSimpleForLoop>();
	public IEnumerable<vlgAssign> AsAssign => Children.OfType<vlgAssign>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgAbstractForLoop> AsAbstractForLoop => Children.OfType<vlgAbstractForLoop>();
	public IEnumerable<vlgAbstractCollection> AsAbstractCollection => Children.OfType<vlgAbstractCollection>();
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
	public IEnumerable<vlgLocalParamNameBinaryValue> AsLocalParamNameBinaryValue => Children.OfType<vlgLocalParamNameBinaryValue>();
	public IEnumerable<vlgLocalParamNameExplicitValue> AsLocalParamNameExplicitValue => Children.OfType<vlgLocalParamNameExplicitValue>();
	public IEnumerable<vlgStandardModulePortImplementation> AsStandardModulePortImplementation => Children.OfType<vlgStandardModulePortImplementation>();
	public IEnumerable<vlgCustomDeclaration> AsCustomDeclaration => Children.OfType<vlgCustomDeclaration>();
	public IEnumerable<vlgLogicSignal> AsLogicSignal => Children.OfType<vlgLogicSignal>();
	public IEnumerable<vlgMemoryBlock> AsMemoryBlock => Children.OfType<vlgMemoryBlock>();
	public IEnumerable<vlgInitial> AsInitial => Children.OfType<vlgInitial>();
	public IEnumerable<vlgIterator> AsIterator => Children.OfType<vlgIterator>();
	public IEnumerable<vlgCombBlock> AsCombBlock => Children.OfType<vlgCombBlock>();
	public IEnumerable<vlgSyncBlock> AsSyncBlock => Children.OfType<vlgSyncBlock>();
	public IEnumerable<vlgModuleImplementationBlock> AsModuleImplementationBlock => Children.OfType<vlgModuleImplementationBlock>();
	public IEnumerable<vlgLocalParamName> AsLocalParamName => Children.OfType<vlgLocalParamName>();
	public IEnumerable<vlgStandardModulePort> AsStandardModulePort => Children.OfType<vlgStandardModulePort>();
	public IEnumerable<vlgSignal> AsSignal => Children.OfType<vlgSignal>();
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
	public IEnumerable<vlgModuleInstanceParameter> AsModuleInstanceParameter => Children.OfType<vlgModuleInstanceParameter>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
}
public abstract partial class vlgModuleInstancePortMapping
{
}
public partial class vlgModuleInstancePortMappings
{
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgModuleInstanceNamedPortMapping> AsModuleInstanceNamedPortMapping => Children.OfType<vlgModuleInstanceNamedPortMapping>();
	public IEnumerable<vlgModuleInstanceSimplePortMapping> AsModuleInstanceSimplePortMapping => Children.OfType<vlgModuleInstanceSimplePortMapping>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgModuleInstancePortMapping> AsModuleInstancePortMapping => Children.OfType<vlgModuleInstancePortMapping>();
}
public partial class vlgModuleInstanceSimplePortMapping
{
}
public partial class vlgModuleInterface
{
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgPlaceholderModulePort> AsPlaceholderModulePort => Children.OfType<vlgPlaceholderModulePort>();
	public IEnumerable<vlgCustomModulePortDeclaration> AsCustomModulePortDeclaration => Children.OfType<vlgCustomModulePortDeclaration>();
	public IEnumerable<vlgStandardModulePortDeclaration> AsStandardModulePortDeclaration => Children.OfType<vlgStandardModulePortDeclaration>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
	public IEnumerable<vlgModulePort> AsModulePort => Children.OfType<vlgModulePort>();
	public IEnumerable<vlgDeclarationModulePort> AsDeclarationModulePort => Children.OfType<vlgDeclarationModulePort>();
	public IEnumerable<vlgStandardModulePort> AsStandardModulePort => Children.OfType<vlgStandardModulePort>();
}
public partial class vlgModuleParameterDeclaration
{
}
public partial class vlgModuleParameters
{
	public IEnumerable<vlgComment> AsComment => Children.OfType<vlgComment>();
	public IEnumerable<vlgText> AsText => Children.OfType<vlgText>();
	public IEnumerable<vlgModuleParameterDeclaration> AsModuleParameterDeclaration => Children.OfType<vlgModuleParameterDeclaration>();
	public IEnumerable<vlgAbstractObject> AsAbstractObject => Children.OfType<vlgAbstractObject>();
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
