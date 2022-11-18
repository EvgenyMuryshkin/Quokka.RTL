using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public partial class vhdAbstractCollection
{
}
public partial class vhdAbstractObject
{
	public abstract vhdAbstractObject UntypedClone();
}
public partial class vhdAggregate
{
	public vhdAggregate Clone() => UntypedClone() as vhdAggregate;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdAggregate();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdAggregateBitConnection
{
	public vhdAggregateBitConnection Clone() => UntypedClone() as vhdAggregateBitConnection;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdAggregateBitConnection();
		result.Bit = Bit;
		result.Value = Value?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdAggregateConnection
{
}
public partial class vhdAggregateExpression
{
	public vhdAggregateExpression Clone() => UntypedClone() as vhdAggregateExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdAggregateExpression();
		result.Aggregate = Aggregate?.UntypedClone() as vhdAggregate;
		return result;
	}
}
public partial class vhdAggregateOthersConnection
{
	public vhdAggregateOthersConnection Clone() => UntypedClone() as vhdAggregateOthersConnection;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdAggregateOthersConnection();
		result.Expression = Expression?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdAlias
{
	public vhdAlias Clone() => UntypedClone() as vhdAlias;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdAlias();
		result.Alias = Alias;
		result.Expression = Expression?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdArchitecture
{
	public vhdArchitecture Clone() => UntypedClone() as vhdArchitecture;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdArchitecture();
		result.Type = Type;
		result.Entity = Entity;
		result.Declarations = Declarations?.UntypedClone() as vhdArchitectureDeclarations;
		result.Implementation = Implementation?.UntypedClone() as vhdArchitectureImplementation;
		return result;
	}
}
public partial class vhdArchitectureDeclarations
{
	public vhdArchitectureDeclarations Clone() => UntypedClone() as vhdArchitectureDeclarations;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdArchitectureDeclarations();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdArchitectureImplementation
{
	public vhdArchitectureImplementation Clone() => UntypedClone() as vhdArchitectureImplementation;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdArchitectureImplementation();
		result.Block = Block?.UntypedClone() as vhdArchitectureImplementationBlock;
		return result;
	}
}
public partial class vhdArchitectureImplementationBlock
{
	public vhdArchitectureImplementationBlock Clone() => UntypedClone() as vhdArchitectureImplementationBlock;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdArchitectureImplementationBlock();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdArrayTypeDeclaration
{
	public vhdArrayTypeDeclaration Clone() => UntypedClone() as vhdArrayTypeDeclaration;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdArrayTypeDeclaration();
		result.Name = Name;
		result.Depth = Depth;
		result.Type = Type;
		result.Width = Width;
		return result;
	}
}
public partial class vhdAssignExpression
{
	public vhdAssignExpression Clone() => UntypedClone() as vhdAssignExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdAssignExpression();
		result.Target = Target?.UntypedClone() as vhdExpression;
		result.Type = Type;
		result.Source = Source?.UntypedClone() as vhdExpression;
		result.Debugger = Debugger;
		return result;
	}
}
public partial class vhdAttribute
{
	public vhdAttribute Clone() => UntypedClone() as vhdAttribute;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdAttribute();
		result.Name = Name;
		result.Target = Target;
		result.Value = Value;
		return result;
	}
}
public partial class vhdBinaryValueExpression
{
	public vhdBinaryValueExpression Clone() => UntypedClone() as vhdBinaryValueExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdBinaryValueExpression();
		result.Value = Value;
		return result;
	}
}
public partial class vhdBlock
{
}
public partial class vhdCase
{
	public vhdCase Clone() => UntypedClone() as vhdCase;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdCase();
		result.Expression = Expression?.UntypedClone() as vhdExpression;
		result.Statements = Statements.Select(i => i.UntypedClone() as vhdCaseStatement).ToList();
		return result;
	}
}
public partial class vhdCaseStatement
{
	public vhdCaseStatement Clone() => UntypedClone() as vhdCaseStatement;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdCaseStatement();
		result.When = When?.UntypedClone() as vhdExpression;
		result.Block = Block?.UntypedClone() as vhdGenericBlock;
		return result;
	}
}
public partial class vhdCastExpression
{
	public vhdCastExpression Clone() => UntypedClone() as vhdCastExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdCastExpression();
		result.Type = Type;
		result.Source = Source?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdCastResizeExpression
{
	public vhdCastResizeExpression Clone() => UntypedClone() as vhdCastResizeExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdCastResizeExpression();
		result.Type = Type;
		result.Source = Source?.UntypedClone() as vhdExpression;
		result.Length = Length?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdComment
{
	public vhdComment Clone() => UntypedClone() as vhdComment;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdComment();
		result.Lines = Lines.ToList();
		return result;
	}
}
public partial class vhdCompareExpression
{
	public vhdCompareExpression Clone() => UntypedClone() as vhdCompareExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdCompareExpression();
		result.Lhs = Lhs?.UntypedClone() as vhdExpression;
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdConditionalStatement
{
	public vhdConditionalStatement Clone() => UntypedClone() as vhdConditionalStatement;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdConditionalStatement();
		result.Condition = Condition?.UntypedClone() as vhdExpression;
		result.Block = Block?.UntypedClone() as vhdGenericBlock;
		return result;
	}
}
public partial class vhdCustomDataType
{
	public vhdCustomDataType Clone() => UntypedClone() as vhdCustomDataType;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdCustomDataType();
		result.DataType = DataType;
		return result;
	}
}
public partial class vhdCustomEntityPort
{
	public vhdCustomEntityPort Clone() => UntypedClone() as vhdCustomEntityPort;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdCustomEntityPort();
		result.Name = Name;
		result.Direction = Direction;
		result.Declaration = Declaration;
		result.Initializer = Initializer;
		return result;
	}
}
public partial class vhdCustomNetType
{
	public vhdCustomNetType Clone() => UntypedClone() as vhdCustomNetType;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdCustomNetType();
		result.NetType = NetType;
		return result;
	}
}
public partial class vhdDataTypeSource
{
}
public partial class vhdDefaultDataType
{
	public vhdDefaultDataType Clone() => UntypedClone() as vhdDefaultDataType;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdDefaultDataType();
		result.DataType = DataType;
		return result;
	}
}
public partial class vhdDefaultNetType
{
	public vhdDefaultNetType Clone() => UntypedClone() as vhdDefaultNetType;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdDefaultNetType();
		result.NetType = NetType;
		return result;
	}
}
public partial class vhdDefaultSignal
{
	public vhdDefaultSignal Clone() => UntypedClone() as vhdDefaultSignal;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdDefaultSignal();
		result.NetType = NetType?.UntypedClone() as vhdNetTypeSource;
		result.Name = Name;
		result.DataType = DataType?.UntypedClone() as vhdDataTypeSource;
		result.Width = Width;
		result.Initializer = Initializer.ToList();
		return result;
	}
}
public partial class vhdEntity
{
	public vhdEntity Clone() => UntypedClone() as vhdEntity;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdEntity();
		result.Name = Name;
		result.Interface = Interface?.UntypedClone() as vhdEntityInterface;
		return result;
	}
}
public partial class vhdEntityInstance
{
	public vhdEntityInstance Clone() => UntypedClone() as vhdEntityInstance;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdEntityInstance();
		result.Name = Name;
		result.Type = Type;
		result.GenericMappings = GenericMappings?.UntypedClone() as vhdEntityInstanceGenericMappings;
		result.PortMappings = PortMappings?.UntypedClone() as vhdEntityInstancePortMappings;
		return result;
	}
}
public partial class vhdEntityInstanceGenericMapping
{
}
public partial class vhdEntityInstanceGenericMappings
{
	public vhdEntityInstanceGenericMappings Clone() => UntypedClone() as vhdEntityInstanceGenericMappings;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdEntityInstanceGenericMappings();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdEntityInstanceNamedGenericMapping
{
	public vhdEntityInstanceNamedGenericMapping Clone() => UntypedClone() as vhdEntityInstanceNamedGenericMapping;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdEntityInstanceNamedGenericMapping();
		result.Internal = Internal;
		result.External = External?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdEntityInstanceNamedPortMapping
{
	public vhdEntityInstanceNamedPortMapping Clone() => UntypedClone() as vhdEntityInstanceNamedPortMapping;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdEntityInstanceNamedPortMapping();
		result.Internal = Internal?.UntypedClone() as vhdIdentifier;
		result.External = External?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdEntityInstancePortMapping
{
}
public partial class vhdEntityInstancePortMappings
{
	public vhdEntityInstancePortMappings Clone() => UntypedClone() as vhdEntityInstancePortMappings;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdEntityInstancePortMappings();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdEntityInterface
{
	public vhdEntityInterface Clone() => UntypedClone() as vhdEntityInterface;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdEntityInterface();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdEntityPort
{
}
public partial class vhdExpression
{
}
public partial class vhdFile
{
	public vhdFile Clone() => UntypedClone() as vhdFile;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdFile();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdFunction
{
	public vhdFunction Clone() => UntypedClone() as vhdFunction;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdFunction();
		result.Declaration = Declaration?.UntypedClone() as vhdFunctionDeclaration;
		result.Interface = Interface?.UntypedClone() as vhdFunctionInterface;
		result.Implementation = Implementation?.UntypedClone() as vhdFunctionImplementation;
		return result;
	}
}
public partial class vhdFunctionDeclaration
{
	public vhdFunctionDeclaration Clone() => UntypedClone() as vhdFunctionDeclaration;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdFunctionDeclaration();
		result.Name = Name;
		result.Type = Type;
		result.Width = Width;
		return result;
	}
}
public partial class vhdFunctionImplementation
{
	public vhdFunctionImplementation Clone() => UntypedClone() as vhdFunctionImplementation;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdFunctionImplementation();
		result.Block = Block?.UntypedClone() as vhdFunctionImplementationBlock;
		return result;
	}
}
public partial class vhdFunctionImplementationBlock
{
	public vhdFunctionImplementationBlock Clone() => UntypedClone() as vhdFunctionImplementationBlock;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdFunctionImplementationBlock();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdFunctionInterface
{
	public vhdFunctionInterface Clone() => UntypedClone() as vhdFunctionInterface;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdFunctionInterface();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdFunctionPortDeclaration
{
	public vhdFunctionPortDeclaration Clone() => UntypedClone() as vhdFunctionPortDeclaration;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdFunctionPortDeclaration();
		result.Name = Name;
		result.Type = Type;
		result.Width = Width;
		return result;
	}
}
public partial class vhdGenericBlock
{
	public vhdGenericBlock Clone() => UntypedClone() as vhdGenericBlock;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdGenericBlock();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdIdentifier
{
	public vhdIdentifier Clone() => UntypedClone() as vhdIdentifier;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdIdentifier();
		result.Name = Name;
		result.Indexes = Indexes.Select(i => i.UntypedClone() as vhdRange).ToList();
		return result;
	}
}
public partial class vhdIdentifierExpression
{
	public vhdIdentifierExpression Clone() => UntypedClone() as vhdIdentifierExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdIdentifierExpression();
		result.Source = Source?.UntypedClone() as vhdIdentifier;
		return result;
	}
}
public partial class vhdIf
{
	public vhdIf Clone() => UntypedClone() as vhdIf;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdIf();
		result.Statements = Statements.Select(i => i.UntypedClone() as vhdConditionalStatement).ToList();
		return result;
	}
}
public partial class vhdLibraryReference
{
	public vhdLibraryReference Clone() => UntypedClone() as vhdLibraryReference;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdLibraryReference();
		result.Name = Name;
		return result;
	}
}
public partial class vhdLogicExpression
{
	public vhdLogicExpression Clone() => UntypedClone() as vhdLogicExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdLogicExpression();
		result.Lhs = Lhs?.UntypedClone() as vhdExpression;
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdLogicSignal
{
	public vhdLogicSignal Clone() => UntypedClone() as vhdLogicSignal;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdLogicSignal();
		result.NetType = NetType?.UntypedClone() as vhdNetTypeSource;
		result.Name = Name;
		result.Initializer = Initializer.ToList();
		return result;
	}
}
public partial class vhdMathExpression
{
	public vhdMathExpression Clone() => UntypedClone() as vhdMathExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdMathExpression();
		result.Lhs = Lhs?.UntypedClone() as vhdExpression;
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdNet
{
}
public partial class vhdNetTypeSource
{
}
public partial class vhdNull
{
	public vhdNull Clone() => UntypedClone() as vhdNull;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdNull();
		return result;
	}
}
public partial class vhdOthersExpression
{
	public vhdOthersExpression Clone() => UntypedClone() as vhdOthersExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdOthersExpression();
		return result;
	}
}
public partial class vhdParenthesizedExpression
{
	public vhdParenthesizedExpression Clone() => UntypedClone() as vhdParenthesizedExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdParenthesizedExpression();
		result.Expression = Expression?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdPredefinedAttributeExpression
{
	public vhdPredefinedAttributeExpression Clone() => UntypedClone() as vhdPredefinedAttributeExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdPredefinedAttributeExpression();
		result.Source = Source?.UntypedClone() as vhdExpression;
		result.Attribute = Attribute;
		return result;
	}
}
public partial class vhdProcedureCall
{
	public vhdProcedureCall Clone() => UntypedClone() as vhdProcedureCall;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdProcedureCall();
		result.Proc = Proc;
		result.Parameters = Parameters.Select(i => i.UntypedClone() as vhdExpression).ToList();
		return result;
	}
}
public partial class vhdProcedureCallExpression
{
	public vhdProcedureCallExpression Clone() => UntypedClone() as vhdProcedureCallExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdProcedureCallExpression();
		result.Proc = Proc;
		result.Parameters = Parameters.Select(i => i.UntypedClone() as vhdExpression).ToList();
		return result;
	}
}
public partial class vhdProcess
{
	public vhdProcess Clone() => UntypedClone() as vhdProcess;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdProcess();
		result.SensitivityList = SensitivityList.Select(i => i.UntypedClone() as vhdIdentifier).ToList();
		result.Declarations = Declarations?.UntypedClone() as vhdProcessDeclarations;
		result.Block = Block?.UntypedClone() as vhdGenericBlock;
		return result;
	}
}
public partial class vhdProcessDeclarations
{
	public vhdProcessDeclarations Clone() => UntypedClone() as vhdProcessDeclarations;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdProcessDeclarations();
		result.Children = Children.Select(i => i.UntypedClone() as vhdAbstractObject).ToList();
		return result;
	}
}
public partial class vhdRange
{
	public vhdRange Clone() => UntypedClone() as vhdRange;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdRange();
		result.Indexes = Indexes.Select(i => i.UntypedClone() as vhdExpression).ToList();
		return result;
	}
}
public partial class vhdResizeExpression
{
	public vhdResizeExpression Clone() => UntypedClone() as vhdResizeExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdResizeExpression();
		result.Source = Source?.UntypedClone() as vhdExpression;
		result.Length = Length?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdReturnExpression
{
	public vhdReturnExpression Clone() => UntypedClone() as vhdReturnExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdReturnExpression();
		result.Result = Result?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdShiftExpression
{
	public vhdShiftExpression Clone() => UntypedClone() as vhdShiftExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdShiftExpression();
		result.Lhs = Lhs?.UntypedClone() as vhdExpression;
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdSimpleForLoop
{
	public vhdSimpleForLoop Clone() => UntypedClone() as vhdSimpleForLoop;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdSimpleForLoop();
		result.Iterator = Iterator;
		result.From = From;
		result.To = To;
		result.Block = Block?.UntypedClone() as vhdGenericBlock;
		return result;
	}
}
public partial class vhdStandardEntityPort
{
	public vhdStandardEntityPort Clone() => UntypedClone() as vhdStandardEntityPort;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdStandardEntityPort();
		result.Name = Name;
		result.Direction = Direction;
		result.Sign = Sign;
		result.Width = Width;
		result.Initializer = Initializer;
		return result;
	}
}
public partial class vhdSyncBlock
{
	public vhdSyncBlock Clone() => UntypedClone() as vhdSyncBlock;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdSyncBlock();
		result.Type = Type;
		result.Source = Source?.UntypedClone() as vhdExpression;
		result.Block = Block?.UntypedClone() as vhdGenericBlock;
		return result;
	}
}
public partial class vhdTernaryExpression
{
	public vhdTernaryExpression Clone() => UntypedClone() as vhdTernaryExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdTernaryExpression();
		result.Condition = Condition?.UntypedClone() as vhdExpression;
		result.Lhs = Lhs?.UntypedClone() as vhdExpression;
		result.Rhs = Rhs?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdText
{
	public vhdText Clone() => UntypedClone() as vhdText;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdText();
		result.Lines = Lines.ToList();
		return result;
	}
}
public partial class vhdTypeDeclaration
{
}
public partial class vhdUnaryExpression
{
	public vhdUnaryExpression Clone() => UntypedClone() as vhdUnaryExpression;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdUnaryExpression();
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vhdExpression;
		return result;
	}
}
public partial class vhdUse
{
	public vhdUse Clone() => UntypedClone() as vhdUse;
	public override vhdAbstractObject UntypedClone()
	{
		var result = new vhdUse();
		result.Value = Value;
		return result;
	}
}
} // Quokka.RTL.VHDL
