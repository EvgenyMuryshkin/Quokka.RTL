using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
using Newtonsoft.Json;
public abstract partial class vhdAbstractCollection
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public abstract partial class vhdAbstractObject
{
	public abstract IEnumerable<vhdAbstractObject> SelfWithChildren();
}
public partial class vhdAggregate
{
	[JsonIgnore]
	public IEnumerable<vhdAggregateBitConnection> AsAggregateBitConnection => Children.OfType<vhdAggregateBitConnection>();
	[JsonIgnore]
	public IEnumerable<vhdAggregateOthersConnection> AsAggregateOthersConnection => Children.OfType<vhdAggregateOthersConnection>();
	[JsonIgnore]
	public IEnumerable<vhdAggregateConnection> AsAggregateConnection => Children.OfType<vhdAggregateConnection>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdAggregateBitConnection
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Value != null) result.AddRange(Value.SelfWithChildren());
		return result;
	}
}
public abstract partial class vhdAggregateConnection
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdAggregateExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Aggregate != null) result.AddRange(Aggregate.SelfWithChildren());
		return result;
	}
}
public partial class vhdAggregateOthersConnection
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Expression != null) result.AddRange(Expression.SelfWithChildren());
		return result;
	}
}
public partial class vhdAlias
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Expression != null) result.AddRange(Expression.SelfWithChildren());
		return result;
	}
}
public partial class vhdArchitecture
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Declarations != null) result.AddRange(Declarations.SelfWithChildren());
		if (Implementation != null) result.AddRange(Implementation.SelfWithChildren());
		return result;
	}
}
public partial class vhdArchitectureDeclarations
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdDefaultSignal> AsDefaultSignal => Children.OfType<vhdDefaultSignal>();
	[JsonIgnore]
	public IEnumerable<vhdLogicSignal> AsLogicSignal => Children.OfType<vhdLogicSignal>();
	[JsonIgnore]
	public IEnumerable<vhdArrayTypeDeclaration> AsArrayTypeDeclaration => Children.OfType<vhdArrayTypeDeclaration>();
	[JsonIgnore]
	public IEnumerable<vhdSubTypeDeclaration> AsSubTypeDeclaration => Children.OfType<vhdSubTypeDeclaration>();
	[JsonIgnore]
	public IEnumerable<vhdFunction> AsFunction => Children.OfType<vhdFunction>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vhdNet> AsNet => Children.OfType<vhdNet>();
	[JsonIgnore]
	public IEnumerable<vhdTypeDeclaration> AsTypeDeclaration => Children.OfType<vhdTypeDeclaration>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdArchitectureImplementation
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vhdArchitectureImplementationBlock
{
	[JsonIgnore]
	public IEnumerable<vhdEntityInstance> AsEntityInstance => Children.OfType<vhdEntityInstance>();
	[JsonIgnore]
	public IEnumerable<vhdGenericBlock> AsGenericBlock => Children.OfType<vhdGenericBlock>();
	[JsonIgnore]
	public IEnumerable<vhdBlock> AsBlock => Children.OfType<vhdBlock>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractCollection> AsAbstractCollection => Children.OfType<vhdAbstractCollection>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdArrayTypeDeclaration
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdAssignExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Target != null) result.AddRange(Target.SelfWithChildren());
		if (Source != null) result.AddRange(Source.SelfWithChildren());
		return result;
	}
}
public partial class vhdAttribute
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdBinaryValueExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vhdBlock
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdIf> AsIf => Children.OfType<vhdIf>();
	[JsonIgnore]
	public IEnumerable<vhdCase> AsCase => Children.OfType<vhdCase>();
	[JsonIgnore]
	public IEnumerable<vhdProcess> AsProcess => Children.OfType<vhdProcess>();
	[JsonIgnore]
	public IEnumerable<vhdSyncBlock> AsSyncBlock => Children.OfType<vhdSyncBlock>();
	[JsonIgnore]
	public IEnumerable<vhdAssignExpression> AsAssignExpression => Children.OfType<vhdAssignExpression>();
	[JsonIgnore]
	public IEnumerable<vhdProcedureCall> AsProcedureCall => Children.OfType<vhdProcedureCall>();
	[JsonIgnore]
	public IEnumerable<vhdSimpleForLoop> AsSimpleForLoop => Children.OfType<vhdSimpleForLoop>();
	[JsonIgnore]
	public IEnumerable<vhdNull> AsNull => Children.OfType<vhdNull>();
	[JsonIgnore]
	public IEnumerable<vhdReturnExpression> AsReturnExpression => Children.OfType<vhdReturnExpression>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vhdExpression> AsExpression => Children.OfType<vhdExpression>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdCase
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Expression != null) result.AddRange(Expression.SelfWithChildren());
		if (Statements != null) result.AddRange(Statements.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdCaseStatement
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (When != null) result.AddRange(When.SelfWithChildren());
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vhdCastExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Source != null) result.AddRange(Source.SelfWithChildren());
		return result;
	}
}
public partial class vhdCastResizeExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Source != null) result.AddRange(Source.SelfWithChildren());
		if (Length != null) result.AddRange(Length.SelfWithChildren());
		return result;
	}
}
public partial class vhdComment
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdCompareExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vhdConditionalStatement
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Condition != null) result.AddRange(Condition.SelfWithChildren());
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vhdCustomDataType
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdCustomEntityPort
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdCustomNetType
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vhdDataTypeSource
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdDefaultDataType
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdDefaultNetType
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdDefaultSignal
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (NetType != null) result.AddRange(NetType.SelfWithChildren());
		if (DataType != null) result.AddRange(DataType.SelfWithChildren());
		return result;
	}
}
public partial class vhdEntity
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Interface != null) result.AddRange(Interface.SelfWithChildren());
		return result;
	}
}
public partial class vhdEntityInstance
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (GenericMappings != null) result.AddRange(GenericMappings.SelfWithChildren());
		if (PortMappings != null) result.AddRange(PortMappings.SelfWithChildren());
		return result;
	}
}
public abstract partial class vhdEntityInstanceGenericMapping
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdEntityInstanceGenericMappings
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdEntityInstanceNamedGenericMapping> AsEntityInstanceNamedGenericMapping => Children.OfType<vhdEntityInstanceNamedGenericMapping>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vhdEntityInstanceGenericMapping> AsEntityInstanceGenericMapping => Children.OfType<vhdEntityInstanceGenericMapping>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdEntityInstanceNamedGenericMapping
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (External != null) result.AddRange(External.SelfWithChildren());
		return result;
	}
}
public partial class vhdEntityInstanceNamedPortMapping
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Internal != null) result.AddRange(Internal.SelfWithChildren());
		if (External != null) result.AddRange(External.SelfWithChildren());
		return result;
	}
}
public abstract partial class vhdEntityInstancePortMapping
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdEntityInstancePortMappings
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdEntityInstanceNamedPortMapping> AsEntityInstanceNamedPortMapping => Children.OfType<vhdEntityInstanceNamedPortMapping>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vhdEntityInstancePortMapping> AsEntityInstancePortMapping => Children.OfType<vhdEntityInstancePortMapping>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdEntityInterface
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdCustomEntityPort> AsCustomEntityPort => Children.OfType<vhdCustomEntityPort>();
	[JsonIgnore]
	public IEnumerable<vhdStandardEntityPort> AsStandardEntityPort => Children.OfType<vhdStandardEntityPort>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vhdEntityPort> AsEntityPort => Children.OfType<vhdEntityPort>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public abstract partial class vhdEntityPort
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vhdExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdFile
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdLibraryReference> AsLibraryReference => Children.OfType<vhdLibraryReference>();
	[JsonIgnore]
	public IEnumerable<vhdUse> AsUse => Children.OfType<vhdUse>();
	[JsonIgnore]
	public IEnumerable<vhdEntity> AsEntity => Children.OfType<vhdEntity>();
	[JsonIgnore]
	public IEnumerable<vhdArchitecture> AsArchitecture => Children.OfType<vhdArchitecture>();
	[JsonIgnore]
	public IEnumerable<vhdAttribute> AsAttribute => Children.OfType<vhdAttribute>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdFunction
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Declaration != null) result.AddRange(Declaration.SelfWithChildren());
		if (TypeDeclarations != null) result.AddRange(TypeDeclarations.SelfWithChildren());
		if (Interface != null) result.AddRange(Interface.SelfWithChildren());
		if (Implementation != null) result.AddRange(Implementation.SelfWithChildren());
		return result;
	}
}
public partial class vhdFunctionCustomPortDeclaration
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdFunctionDeclaration
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdFunctionImplementation
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vhdFunctionImplementationBlock
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdAssignExpression> AsAssignExpression => Children.OfType<vhdAssignExpression>();
	[JsonIgnore]
	public IEnumerable<vhdIf> AsIf => Children.OfType<vhdIf>();
	[JsonIgnore]
	public IEnumerable<vhdReturnExpression> AsReturnExpression => Children.OfType<vhdReturnExpression>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vhdExpression> AsExpression => Children.OfType<vhdExpression>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdFunctionInterface
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdFunctionPortDeclaration> AsFunctionPortDeclaration => Children.OfType<vhdFunctionPortDeclaration>();
	[JsonIgnore]
	public IEnumerable<vhdFunctionCustomPortDeclaration> AsFunctionCustomPortDeclaration => Children.OfType<vhdFunctionCustomPortDeclaration>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdFunctionPortDeclaration
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdFunctionTypeDeclarations
{
	[JsonIgnore]
	public IEnumerable<vhdArrayTypeDeclaration> AsArrayTypeDeclaration => Children.OfType<vhdArrayTypeDeclaration>();
	[JsonIgnore]
	public IEnumerable<vhdSubTypeDeclaration> AsSubTypeDeclaration => Children.OfType<vhdSubTypeDeclaration>();
	[JsonIgnore]
	public IEnumerable<vhdTypeDeclaration> AsTypeDeclaration => Children.OfType<vhdTypeDeclaration>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdGenericBlock
{
	[JsonIgnore]
	public IEnumerable<vhdGenericBlock> AsGenericBlock => Children.OfType<vhdGenericBlock>();
	[JsonIgnore]
	public IEnumerable<vhdBlock> AsBlock => Children.OfType<vhdBlock>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractCollection> AsAbstractCollection => Children.OfType<vhdAbstractCollection>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdIdentifier
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Indexes != null) result.AddRange(Indexes.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdIdentifierExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Source != null) result.AddRange(Source.SelfWithChildren());
		return result;
	}
}
public partial class vhdIf
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Statements != null) result.AddRange(Statements.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdLibraryReference
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdLogicExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vhdLogicSignal
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (NetType != null) result.AddRange(NetType.SelfWithChildren());
		return result;
	}
}
public partial class vhdMathExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public abstract partial class vhdNet
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (NetType != null) result.AddRange(NetType.SelfWithChildren());
		return result;
	}
}
public abstract partial class vhdNetTypeSource
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdNull
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdOthersExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdParenthesizedExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Expression != null) result.AddRange(Expression.SelfWithChildren());
		return result;
	}
}
public partial class vhdPredefinedAttributeExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Source != null) result.AddRange(Source.SelfWithChildren());
		return result;
	}
}
public partial class vhdProcedureCall
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Parameters != null) result.AddRange(Parameters.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdProcedureCallExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Parameters != null) result.AddRange(Parameters.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdProcess
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (SensitivityList != null) result.AddRange(SensitivityList.SelectMany(c => c.SelfWithChildren()));
		if (Declarations != null) result.AddRange(Declarations.SelfWithChildren());
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vhdProcessDeclarations
{
	[JsonIgnore]
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	[JsonIgnore]
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	[JsonIgnore]
	public IEnumerable<vhdDefaultSignal> AsDefaultSignal => Children.OfType<vhdDefaultSignal>();
	[JsonIgnore]
	public IEnumerable<vhdLogicSignal> AsLogicSignal => Children.OfType<vhdLogicSignal>();
	[JsonIgnore]
	public IEnumerable<vhdArrayTypeDeclaration> AsArrayTypeDeclaration => Children.OfType<vhdArrayTypeDeclaration>();
	[JsonIgnore]
	public IEnumerable<vhdAlias> AsAlias => Children.OfType<vhdAlias>();
	[JsonIgnore]
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	[JsonIgnore]
	public IEnumerable<vhdNet> AsNet => Children.OfType<vhdNet>();
	[JsonIgnore]
	public IEnumerable<vhdTypeDeclaration> AsTypeDeclaration => Children.OfType<vhdTypeDeclaration>();
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Children != null) result.AddRange(Children.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdRange
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Indexes != null) result.AddRange(Indexes.SelectMany(c => c.SelfWithChildren()));
		return result;
	}
}
public partial class vhdResizeExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Source != null) result.AddRange(Source.SelfWithChildren());
		if (Length != null) result.AddRange(Length.SelfWithChildren());
		return result;
	}
}
public partial class vhdReturnExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Result != null) result.AddRange(Result.SelfWithChildren());
		return result;
	}
}
public partial class vhdShiftExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vhdSimpleForLoop
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vhdStandardEntityPort
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdSubTypeDeclaration
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdSyncBlock
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Source != null) result.AddRange(Source.SelfWithChildren());
		if (Block != null) result.AddRange(Block.SelfWithChildren());
		return result;
	}
}
public partial class vhdTernaryExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Condition != null) result.AddRange(Condition.SelfWithChildren());
		if (Lhs != null) result.AddRange(Lhs.SelfWithChildren());
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vhdText
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public abstract partial class vhdTypeDeclaration
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
public partial class vhdUnaryExpression
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		if (Rhs != null) result.AddRange(Rhs.SelfWithChildren());
		return result;
	}
}
public partial class vhdUse
{
	public override IEnumerable<vhdAbstractObject> SelfWithChildren()
	{
		var result = new List<vhdAbstractObject>() { this };
		return result;
	}
}
} // Quokka.RTL.VHDL
