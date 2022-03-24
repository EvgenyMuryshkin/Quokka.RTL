using System;
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
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdDefaultSignal> AsDefaultSignal => Children.OfType<vhdDefaultSignal>();
	public IEnumerable<vhdLogicSignal> AsLogicSignal => Children.OfType<vhdLogicSignal>();
	public IEnumerable<vhdArrayTypeDeclaration> AsArrayTypeDeclaration => Children.OfType<vhdArrayTypeDeclaration>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public IEnumerable<vhdNet> AsNet => Children.OfType<vhdNet>();
	public IEnumerable<vhdTypeDeclaration> AsTypeDeclaration => Children.OfType<vhdTypeDeclaration>();
}
public partial class vhdArchitectureImplementation
{
}
public partial class vhdArchitectureImplementationBlock
{
	public IEnumerable<vhdEntityInstance> AsEntityInstance => Children.OfType<vhdEntityInstance>();
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
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdIf> AsIf => Children.OfType<vhdIf>();
	public IEnumerable<vhdCase> AsCase => Children.OfType<vhdCase>();
	public IEnumerable<vhdProcess> AsProcess => Children.OfType<vhdProcess>();
	public IEnumerable<vhdSyncBlock> AsSyncBlock => Children.OfType<vhdSyncBlock>();
	public IEnumerable<vhdAssignExpression> AsAssignExpression => Children.OfType<vhdAssignExpression>();
	public IEnumerable<vhdProcedureCall> AsProcedureCall => Children.OfType<vhdProcedureCall>();
	public IEnumerable<vhdSimpleForLoop> AsSimpleForLoop => Children.OfType<vhdSimpleForLoop>();
	public IEnumerable<vhdNull> AsNull => Children.OfType<vhdNull>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public IEnumerable<vhdExpression> AsExpression => Children.OfType<vhdExpression>();
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
public partial class vhdEntityInstanceNamedPortMapping
{
}
public abstract partial class vhdEntityInstancePortMapping
{
}
public partial class vhdEntityInstancePortMappings
{
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdEntityInstanceNamedPortMapping> AsEntityInstanceNamedPortMapping => Children.OfType<vhdEntityInstanceNamedPortMapping>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public IEnumerable<vhdEntityInstancePortMapping> AsEntityInstancePortMapping => Children.OfType<vhdEntityInstancePortMapping>();
}
public partial class vhdEntityInterface
{
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdCustomEntityPort> AsCustomEntityPort => Children.OfType<vhdCustomEntityPort>();
	public IEnumerable<vhdStandardEntityPort> AsStandardEntityPort => Children.OfType<vhdStandardEntityPort>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public IEnumerable<vhdEntityPort> AsEntityPort => Children.OfType<vhdEntityPort>();
}
public abstract partial class vhdEntityPort
{
}
public abstract partial class vhdExpression
{
}
public partial class vhdFile
{
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdLibraryReference> AsLibraryReference => Children.OfType<vhdLibraryReference>();
	public IEnumerable<vhdUse> AsUse => Children.OfType<vhdUse>();
	public IEnumerable<vhdEntity> AsEntity => Children.OfType<vhdEntity>();
	public IEnumerable<vhdArchitecture> AsArchitecture => Children.OfType<vhdArchitecture>();
	public IEnumerable<vhdAttribute> AsAttribute => Children.OfType<vhdAttribute>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
}
public partial class vhdGenericBlock
{
	public IEnumerable<vhdGenericBlock> AsGenericBlock => Children.OfType<vhdGenericBlock>();
	public IEnumerable<vhdBlock> AsBlock => Children.OfType<vhdBlock>();
	public IEnumerable<vhdAbstractCollection> AsAbstractCollection => Children.OfType<vhdAbstractCollection>();
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
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdDefaultSignal> AsDefaultSignal => Children.OfType<vhdDefaultSignal>();
	public IEnumerable<vhdLogicSignal> AsLogicSignal => Children.OfType<vhdLogicSignal>();
	public IEnumerable<vhdArrayTypeDeclaration> AsArrayTypeDeclaration => Children.OfType<vhdArrayTypeDeclaration>();
	public IEnumerable<vhdAlias> AsAlias => Children.OfType<vhdAlias>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public IEnumerable<vhdNet> AsNet => Children.OfType<vhdNet>();
	public IEnumerable<vhdTypeDeclaration> AsTypeDeclaration => Children.OfType<vhdTypeDeclaration>();
}
public partial class vhdRange
{
}
public partial class vhdResizeExpression
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
