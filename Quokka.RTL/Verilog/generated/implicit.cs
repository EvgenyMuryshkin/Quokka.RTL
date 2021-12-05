using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
public abstract partial class vlgAbstractCollection : vlgAbstractObject
{
}
public abstract partial class vlgAbstractForLoop : vlgAbstractCollection
{
}
public abstract partial class vlgAbstractObject
{
}
public partial class vlgAssign : vlgAbstractObject
{
	public static implicit operator vlgAssign(vlgAssignExpression Expression)
	{
		return new vlgAssign(Expression);
	}
}
public partial class vlgAssignExpression : vlgExpression
{
}
public partial class vlgAttribute : vlgAbstractObject
{
}
public partial class vlgBinaryValueExpression : vlgExpression, vlgICaseStatement
{
	public static implicit operator vlgBinaryValueExpression(RTLBitArray Value)
	{
		return new vlgBinaryValueExpression(Value);
	}
}
public abstract partial class vlgBlock : vlgAbstractCollection
{
}
public partial class vlgCase : vlgAbstractObject
{
	public static implicit operator vlgCase(vlgExpression Check)
	{
		return new vlgCase(Check);
	}
}
public partial class vlgCaseDefault : vlgCaseItem
{
}
public abstract partial class vlgCaseItem
{
}
public partial class vlgCaseStatement : vlgCaseItem
{
	public static implicit operator vlgCaseStatement(vlgBinaryValueExpression single)
	{
		return new vlgCaseStatement(new [] { single });
	}
	public static implicit operator vlgCaseStatement(vlgIdentifierExpression single)
	{
		return new vlgCaseStatement(new [] { single });
	}
}
public partial class vlgCombBlock : vlgAbstractObject
{
	public static implicit operator vlgCombBlock(vlgIdentifier single)
	{
		return new vlgCombBlock(new [] { single });
	}
}
public partial class vlgComment : vlgAbstractObject
{
	public static implicit operator vlgComment(String single)
	{
		return new vlgComment(new [] { single });
	}
}
public partial class vlgCompareExpression : vlgExpression
{
}
public partial class vlgConditionalStatement : vlgAbstractObject
{
	public static implicit operator vlgConditionalStatement(vlgAssignExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
	public static implicit operator vlgConditionalStatement(vlgBinaryValueExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
	public static implicit operator vlgConditionalStatement(vlgCompareExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
	public static implicit operator vlgConditionalStatement(vlgIdentifierExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
	public static implicit operator vlgConditionalStatement(vlgLogicExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
	public static implicit operator vlgConditionalStatement(vlgMathExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
	public static implicit operator vlgConditionalStatement(vlgShiftExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
	public static implicit operator vlgConditionalStatement(vlgTernaryExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
	public static implicit operator vlgConditionalStatement(vlgUnaryExpression Condition)
	{
		return new vlgConditionalStatement(Condition);
	}
}
public partial class vlgCustomDeclaration : vlgAbstractObject
{
}
public partial class vlgCustomModulePortDeclaration : vlgDeclarationModulePort
{
}
public abstract partial class vlgDeclarationModulePort : vlgModulePort
{
}
public abstract partial class vlgExpression : vlgAbstractObject
{
}
public partial class vlgFile : vlgAbstractCollection
{
}
public partial class vlgForLoop : vlgAbstractForLoop
{
}
public partial class vlgGenerate : vlgAbstractObject
{
	public static implicit operator vlgGenerate(vlgGenericBlock Block)
	{
		return new vlgGenerate(Block);
	}
}
public partial class vlgGenericBlock : vlgBlock
{
}
public partial class vlgGenvar : vlgAbstractObject
{
	public static implicit operator vlgGenvar(String Name)
	{
		return new vlgGenvar(Name);
	}
}
public partial class vlgIdentifier : vlgAbstractObject
{
	public static implicit operator vlgIdentifier(String Name)
	{
		return new vlgIdentifier(Name);
	}
}
public partial class vlgIdentifierExpression : vlgExpression, vlgICaseStatement
{
	public static implicit operator vlgIdentifierExpression(vlgIdentifier Source)
	{
		return new vlgIdentifierExpression(Source);
	}
}
public partial class vlgIf : vlgAbstractObject
{
}
public partial class vlgInitial : vlgAbstractCollection
{
	public static implicit operator vlgInitial(String Name)
	{
		return new vlgInitial(Name);
	}
}
public partial class vlgIterator : vlgAbstractObject
{
	public static implicit operator vlgIterator(String Name)
	{
		return new vlgIterator(Name);
	}
}
public abstract partial class vlgLocalParam : vlgAbstractObject
{
}
public abstract partial class vlgLocalParamName : vlgLocalParam
{
}
public partial class vlgLocalParamNameBinaryValue : vlgLocalParamName
{
}
public partial class vlgLocalParamNameExplicitValue : vlgLocalParamName
{
}
public partial class vlgLogicExpression : vlgExpression
{
}
public partial class vlgLogicSignal : vlgSignal
{
}
public partial class vlgMathExpression : vlgExpression
{
}
public partial class vlgMemoryBlock : vlgSignal
{
}
public partial class vlgModule : vlgAbstractObject
{
	public static implicit operator vlgModule(String Name)
	{
		return new vlgModule(Name);
	}
}
public partial class vlgModuleImplementation : vlgAbstractObject
{
	public static implicit operator vlgModuleImplementation(vlgModuleImplementationBlock Block)
	{
		return new vlgModuleImplementation(Block);
	}
}
public partial class vlgModuleImplementationBlock : vlgBlock
{
}
public partial class vlgModuleInstance : vlgAbstractObject
{
}
public partial class vlgModuleInstanceNamedPortMapping : vlgModuleInstancePortMapping
{
}
public partial class vlgModuleInstanceParameter : vlgAbstractObject
{
}
public partial class vlgModuleInstanceParameters : vlgAbstractCollection
{
}
public abstract partial class vlgModuleInstancePortMapping : vlgAbstractObject
{
}
public partial class vlgModuleInstancePortMappings : vlgAbstractCollection
{
}
public partial class vlgModuleInstanceSimplePortMapping : vlgModuleInstancePortMapping
{
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgAssignExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgBinaryValueExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgCompareExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgIdentifierExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgLogicExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgMathExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgShiftExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgTernaryExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgUnaryExpression External)
	{
		return new vlgModuleInstanceSimplePortMapping(External);
	}
}
public partial class vlgModuleInterface : vlgAbstractCollection
{
}
public partial class vlgModuleParameterDeclaration : vlgAbstractObject
{
}
public partial class vlgModuleParameters : vlgAbstractCollection
{
}
public abstract partial class vlgModulePort : vlgAbstractObject
{
}
public partial class vlgPlaceholderModulePort : vlgModulePort
{
	public static implicit operator vlgPlaceholderModulePort(String Name)
	{
		return new vlgPlaceholderModulePort(Name);
	}
}
public partial class vlgProcedureCall : vlgAbstractObject
{
}
public partial class vlgRange : vlgAbstractObject
{
	public static implicit operator vlgRange(vlgAssignExpression single)
	{
		return new vlgRange(new [] { single });
	}
	public static implicit operator vlgRange(vlgBinaryValueExpression single)
	{
		return new vlgRange(new [] { single });
	}
	public static implicit operator vlgRange(vlgCompareExpression single)
	{
		return new vlgRange(new [] { single });
	}
	public static implicit operator vlgRange(vlgIdentifierExpression single)
	{
		return new vlgRange(new [] { single });
	}
	public static implicit operator vlgRange(vlgLogicExpression single)
	{
		return new vlgRange(new [] { single });
	}
	public static implicit operator vlgRange(vlgMathExpression single)
	{
		return new vlgRange(new [] { single });
	}
	public static implicit operator vlgRange(vlgShiftExpression single)
	{
		return new vlgRange(new [] { single });
	}
	public static implicit operator vlgRange(vlgTernaryExpression single)
	{
		return new vlgRange(new [] { single });
	}
	public static implicit operator vlgRange(vlgUnaryExpression single)
	{
		return new vlgRange(new [] { single });
	}
}
public partial class vlgShiftExpression : vlgExpression
{
}
public abstract partial class vlgSignal : vlgAbstractObject
{
}
public partial class vlgSimpleForLoop : vlgAbstractForLoop
{
}
public abstract partial class vlgStandardModulePort : vlgDeclarationModulePort
{
}
public partial class vlgStandardModulePortDeclaration : vlgStandardModulePort
{
}
public partial class vlgStandardModulePortImplementation : vlgStandardModulePort
{
}
public partial class vlgSyncBlock : vlgAbstractObject
{
	public static implicit operator vlgSyncBlock(vlgSyncBlockSensitivityItem single)
	{
		return new vlgSyncBlock(new [] { single });
	}
}
public partial class vlgSyncBlockSensitivityItem : vlgAbstractObject
{
}
public partial class vlgTernaryExpression : vlgExpression
{
}
public partial class vlgText : vlgAbstractObject
{
	public static implicit operator vlgText(String single)
	{
		return new vlgText(new [] { single });
	}
}
public partial class vlgUnaryExpression : vlgExpression
{
}
} // Quokka.RTL.Verilog
