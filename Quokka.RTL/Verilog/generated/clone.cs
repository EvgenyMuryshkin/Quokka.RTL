using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
public partial class vlgAbstractCollection
{
}
public partial class vlgAbstractForLoop
{
}
public partial class vlgAbstractObject
{
	public abstract vlgAbstractObject UntypedClone();
}
public partial class vlgAggregateExpression
{
	public vlgAggregateExpression Clone() => UntypedClone() as vlgAggregateExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgAggregateExpression();
		result.Size = Size;
		result.Expressions = Expressions.Select(i => i.UntypedClone() as vlgExpression).ToList();
		return result;
	}
}
public partial class vlgAssign
{
	public vlgAssign Clone() => UntypedClone() as vlgAssign;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgAssign();
		result.Expression = Expression?.UntypedClone() as vlgAssignExpression;
		return result;
	}
}
public partial class vlgAssignExpression
{
	public vlgAssignExpression Clone() => UntypedClone() as vlgAssignExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgAssignExpression();
		result.Target = Target?.UntypedClone() as vlgIdentifier;
		result.Type = Type;
		result.Expression = Expression?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgAttribute
{
	public vlgAttribute Clone() => UntypedClone() as vlgAttribute;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgAttribute();
		result.Name = Name;
		result.Value = Value;
		return result;
	}
}
public partial class vlgBinaryValueExpression
{
	public vlgBinaryValueExpression Clone() => UntypedClone() as vlgBinaryValueExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgBinaryValueExpression();
		result.Value = Value;
		return result;
	}
}
public partial class vlgBlock
{
}
public partial class vlgCase
{
	public vlgCase Clone() => UntypedClone() as vlgCase;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgCase();
		result.Check = Check?.UntypedClone() as vlgExpression;
		result.Statements = Statements.Select(i => i.UntypedClone() as vlgCaseStatement).ToList();
		result.Default = Default?.UntypedClone() as vlgCaseDefault;
		return result;
	}
}
public partial class vlgCaseDefault
{
	public vlgCaseDefault Clone() => UntypedClone() as vlgCaseDefault;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgCaseDefault();
		result.Block = Block?.UntypedClone() as vlgGenericBlock;
		return result;
	}
}
public partial class vlgCaseItem
{
}
public partial class vlgCaseStatement
{
	public vlgCaseStatement Clone() => UntypedClone() as vlgCaseStatement;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgCaseStatement();
		result.Block = Block?.UntypedClone() as vlgGenericBlock;
		result.Conditions = Conditions.ToList();
		return result;
	}
}
public partial class vlgCombBlock
{
	public vlgCombBlock Clone() => UntypedClone() as vlgCombBlock;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgCombBlock();
		result.SensitivityList = SensitivityList.Select(i => i.UntypedClone() as vlgIdentifier).ToList();
		result.Block = Block?.UntypedClone() as vlgGenericBlock;
		return result;
	}
}
public partial class vlgComment
{
	public vlgComment Clone() => UntypedClone() as vlgComment;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgComment();
		result.Lines = Lines.ToList();
		return result;
	}
}
public partial class vlgCompareExpression
{
	public vlgCompareExpression Clone() => UntypedClone() as vlgCompareExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgCompareExpression();
		result.Lhs = Lhs?.UntypedClone() as vlgExpression;
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgConditionalStatement
{
	public vlgConditionalStatement Clone() => UntypedClone() as vlgConditionalStatement;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgConditionalStatement();
		result.Condition = Condition?.UntypedClone() as vlgExpression;
		result.Block = Block?.UntypedClone() as vlgGenericBlock;
		return result;
	}
}
public partial class vlgCustomDeclaration
{
	public vlgCustomDeclaration Clone() => UntypedClone() as vlgCustomDeclaration;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgCustomDeclaration();
		result.Type = Type;
		result.Name = Name;
		result.Initializer = Initializer;
		return result;
	}
}
public partial class vlgCustomModulePortDeclaration
{
	public vlgCustomModulePortDeclaration Clone() => UntypedClone() as vlgCustomModulePortDeclaration;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgCustomModulePortDeclaration();
		result.Direction = Direction;
		result.NetType = NetType;
		result.DataType = DataType;
		result.Name = Name;
		return result;
	}
}
public partial class vlgDeclarationModulePort
{
}
public partial class vlgExpression
{
}
public partial class vlgFile
{
	public vlgFile Clone() => UntypedClone() as vlgFile;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgFile();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		return result;
	}
}
public partial class vlgForLoop
{
	public vlgForLoop Clone() => UntypedClone() as vlgForLoop;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgForLoop();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		result.Name = Name;
		result.Initializer = Initializer?.UntypedClone() as vlgExpression;
		result.Condition = Condition?.UntypedClone() as vlgExpression;
		result.Increment = Increment?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgGenerate
{
	public vlgGenerate Clone() => UntypedClone() as vlgGenerate;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgGenerate();
		result.Block = Block?.UntypedClone() as vlgGenericBlock;
		return result;
	}
}
public partial class vlgGenericBlock
{
	public vlgGenericBlock Clone() => UntypedClone() as vlgGenericBlock;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgGenericBlock();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		return result;
	}
}
public partial class vlgGenvar
{
	public vlgGenvar Clone() => UntypedClone() as vlgGenvar;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgGenvar();
		result.Name = Name;
		return result;
	}
}
public partial class vlgIdentifier
{
	public vlgIdentifier Clone() => UntypedClone() as vlgIdentifier;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgIdentifier();
		result.Name = Name;
		result.Indexes = Indexes.Select(i => i.UntypedClone() as vlgRange).ToList();
		return result;
	}
}
public partial class vlgIdentifierExpression
{
	public vlgIdentifierExpression Clone() => UntypedClone() as vlgIdentifierExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgIdentifierExpression();
		result.Source = Source?.UntypedClone() as vlgIdentifier;
		return result;
	}
}
public partial class vlgIf
{
	public vlgIf Clone() => UntypedClone() as vlgIf;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgIf();
		result.Statements = Statements.Select(i => i.UntypedClone() as vlgConditionalStatement).ToList();
		return result;
	}
}
public partial class vlgInitial
{
	public vlgInitial Clone() => UntypedClone() as vlgInitial;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgInitial();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		result.Name = Name;
		return result;
	}
}
public partial class vlgIterator
{
	public vlgIterator Clone() => UntypedClone() as vlgIterator;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgIterator();
		result.Name = Name;
		return result;
	}
}
public partial class vlgLocalParam
{
}
public partial class vlgLocalParamName
{
}
public partial class vlgLocalParamNameBinaryValue
{
	public vlgLocalParamNameBinaryValue Clone() => UntypedClone() as vlgLocalParamNameBinaryValue;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgLocalParamNameBinaryValue();
		result.Name = Name;
		result.Value = Value;
		return result;
	}
}
public partial class vlgLocalParamNameExplicitValue
{
	public vlgLocalParamNameExplicitValue Clone() => UntypedClone() as vlgLocalParamNameExplicitValue;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgLocalParamNameExplicitValue();
		result.Name = Name;
		result.Value = Value;
		return result;
	}
}
public partial class vlgLogicExpression
{
	public vlgLogicExpression Clone() => UntypedClone() as vlgLogicExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgLogicExpression();
		result.Lhs = Lhs?.UntypedClone() as vlgExpression;
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgLogicSignal
{
	public vlgLogicSignal Clone() => UntypedClone() as vlgLogicSignal;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgLogicSignal();
		result.NetType = NetType;
		result.Sign = Sign;
		result.Name = Name;
		result.Width = Width;
		result.Initializer = Initializer;
		return result;
	}
}
public partial class vlgMathExpression
{
	public vlgMathExpression Clone() => UntypedClone() as vlgMathExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgMathExpression();
		result.Lhs = Lhs?.UntypedClone() as vlgExpression;
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgMemoryBlock
{
	public vlgMemoryBlock Clone() => UntypedClone() as vlgMemoryBlock;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgMemoryBlock();
		result.NetType = NetType;
		result.Name = Name;
		result.Sign = Sign;
		result.Width = Width;
		result.Depth = Depth;
		return result;
	}
}
public partial class vlgModule
{
	public vlgModule Clone() => UntypedClone() as vlgModule;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModule();
		result.Name = Name;
		result.Parameters = Parameters?.UntypedClone() as vlgModuleParameters;
		result.Interface = Interface?.UntypedClone() as vlgModuleInterface;
		result.Implementation = Implementation?.UntypedClone() as vlgModuleImplementation;
		return result;
	}
}
public partial class vlgModuleImplementation
{
	public vlgModuleImplementation Clone() => UntypedClone() as vlgModuleImplementation;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleImplementation();
		result.Block = Block?.UntypedClone() as vlgModuleImplementationBlock;
		return result;
	}
}
public partial class vlgModuleImplementationBlock
{
	public vlgModuleImplementationBlock Clone() => UntypedClone() as vlgModuleImplementationBlock;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleImplementationBlock();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		return result;
	}
}
public partial class vlgModuleInstance
{
	public vlgModuleInstance Clone() => UntypedClone() as vlgModuleInstance;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleInstance();
		result.Type = Type;
		result.Name = Name;
		result.Parameters = Parameters?.UntypedClone() as vlgModuleInstanceParameters;
		result.PortMappings = PortMappings?.UntypedClone() as vlgModuleInstancePortMappings;
		return result;
	}
}
public partial class vlgModuleInstanceNamedPortMapping
{
	public vlgModuleInstanceNamedPortMapping Clone() => UntypedClone() as vlgModuleInstanceNamedPortMapping;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleInstanceNamedPortMapping();
		result.Internal = Internal;
		result.External = External?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgModuleInstanceParameter
{
	public vlgModuleInstanceParameter Clone() => UntypedClone() as vlgModuleInstanceParameter;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleInstanceParameter();
		result.Name = Name;
		result.Value = Value;
		return result;
	}
}
public partial class vlgModuleInstanceParameters
{
	public vlgModuleInstanceParameters Clone() => UntypedClone() as vlgModuleInstanceParameters;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleInstanceParameters();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		return result;
	}
}
public partial class vlgModuleInstancePortMapping
{
}
public partial class vlgModuleInstancePortMappings
{
	public vlgModuleInstancePortMappings Clone() => UntypedClone() as vlgModuleInstancePortMappings;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleInstancePortMappings();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		return result;
	}
}
public partial class vlgModuleInstanceSimplePortMapping
{
	public vlgModuleInstanceSimplePortMapping Clone() => UntypedClone() as vlgModuleInstanceSimplePortMapping;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleInstanceSimplePortMapping();
		result.External = External?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgModuleInterface
{
	public vlgModuleInterface Clone() => UntypedClone() as vlgModuleInterface;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleInterface();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		return result;
	}
}
public partial class vlgModuleParameterDeclaration
{
	public vlgModuleParameterDeclaration Clone() => UntypedClone() as vlgModuleParameterDeclaration;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleParameterDeclaration();
		result.Name = Name;
		result.Width = Width;
		result.DefaultValue = DefaultValue;
		return result;
	}
}
public partial class vlgModuleParameters
{
	public vlgModuleParameters Clone() => UntypedClone() as vlgModuleParameters;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgModuleParameters();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		return result;
	}
}
public partial class vlgModulePort
{
}
public partial class vlgPlaceholderModulePort
{
	public vlgPlaceholderModulePort Clone() => UntypedClone() as vlgPlaceholderModulePort;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgPlaceholderModulePort();
		result.Name = Name;
		return result;
	}
}
public partial class vlgProcedureCall
{
	public vlgProcedureCall Clone() => UntypedClone() as vlgProcedureCall;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgProcedureCall();
		result.Proc = Proc;
		result.Name = Name;
		result.Parameters = Parameters.Select(i => i.UntypedClone() as vlgExpression).ToList();
		return result;
	}
}
public partial class vlgRange
{
	public vlgRange Clone() => UntypedClone() as vlgRange;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgRange();
		result.Indexes = Indexes.Select(i => i.UntypedClone() as vlgExpression).ToList();
		return result;
	}
}
public partial class vlgShiftExpression
{
	public vlgShiftExpression Clone() => UntypedClone() as vlgShiftExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgShiftExpression();
		result.Lhs = Lhs?.UntypedClone() as vlgExpression;
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgSignal
{
}
public partial class vlgSimpleForLoop
{
	public vlgSimpleForLoop Clone() => UntypedClone() as vlgSimpleForLoop;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgSimpleForLoop();
		result.Children = Children.Select(i => i.UntypedClone() as vlgAbstractObject).ToList();
		result.Name = Name;
		result.Iterator = Iterator;
		result.From = From;
		result.To = To;
		return result;
	}
}
public partial class vlgStandardModulePort
{
}
public partial class vlgStandardModulePortDeclaration
{
	public vlgStandardModulePortDeclaration Clone() => UntypedClone() as vlgStandardModulePortDeclaration;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgStandardModulePortDeclaration();
		result.Direction = Direction;
		result.NetType = NetType;
		result.Sign = Sign;
		result.Width = Width;
		result.Name = Name;
		return result;
	}
}
public partial class vlgStandardModulePortImplementation
{
	public vlgStandardModulePortImplementation Clone() => UntypedClone() as vlgStandardModulePortImplementation;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgStandardModulePortImplementation();
		result.Direction = Direction;
		result.NetType = NetType;
		result.Sign = Sign;
		result.Width = Width;
		result.Name = Name;
		return result;
	}
}
public partial class vlgSyncBlock
{
	public vlgSyncBlock Clone() => UntypedClone() as vlgSyncBlock;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgSyncBlock();
		result.SensitivityList = SensitivityList.Select(i => i.UntypedClone() as vlgSyncBlockSensitivityItem).ToList();
		result.Block = Block?.UntypedClone() as vlgGenericBlock;
		return result;
	}
}
public partial class vlgSyncBlockSensitivityItem
{
	public vlgSyncBlockSensitivityItem Clone() => UntypedClone() as vlgSyncBlockSensitivityItem;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgSyncBlockSensitivityItem();
		result.Edge = Edge;
		result.Identifier = Identifier?.UntypedClone() as vlgIdentifier;
		return result;
	}
}
public partial class vlgTernaryExpression
{
	public vlgTernaryExpression Clone() => UntypedClone() as vlgTernaryExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgTernaryExpression();
		result.Condition = Condition?.UntypedClone() as vlgExpression;
		result.Lhs = Lhs?.UntypedClone() as vlgExpression;
		result.Rhs = Rhs?.UntypedClone() as vlgExpression;
		return result;
	}
}
public partial class vlgText
{
	public vlgText Clone() => UntypedClone() as vlgText;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgText();
		result.Lines = Lines.ToList();
		return result;
	}
}
public partial class vlgUnaryExpression
{
	public vlgUnaryExpression Clone() => UntypedClone() as vlgUnaryExpression;
	public override vlgAbstractObject UntypedClone()
	{
		var result = new vlgUnaryExpression();
		result.Type = Type;
		result.Rhs = Rhs?.UntypedClone() as vlgExpression;
		return result;
	}
}
} // Quokka.RTL.Verilog
