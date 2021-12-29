using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
public abstract partial class vlgAbstractCollection : vlgAbstractObject
{
	public static implicit operator vlgAbstractCollection(String Name)
	{
		return new vlgInitial(Name);
	}
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
	public static implicit operator vlgCase(vlgAssignExpression source)
	{
		return new vlgCase(source);
	}
	public static implicit operator vlgCase(vlgBinaryValueExpression source)
	{
		return new vlgCase(source);
	}
	public static implicit operator vlgCase(RTLBitArray Value)
	{
		return new vlgCase(new vlgBinaryValueExpression(Value));
	}
	public static implicit operator vlgCase(vlgCompareExpression source)
	{
		return new vlgCase(source);
	}
	public static implicit operator vlgCase(vlgIdentifierExpression source)
	{
		return new vlgCase(source);
	}
	public static implicit operator vlgCase(String Name)
	{
		return new vlgCase(new vlgIdentifierExpression(new vlgIdentifier(Name)));
	}
	public static implicit operator vlgCase(vlgIdentifier Source)
	{
		return new vlgCase(new vlgIdentifierExpression(Source));
	}
	public static implicit operator vlgCase(vlgLogicExpression source)
	{
		return new vlgCase(source);
	}
	public static implicit operator vlgCase(vlgMathExpression source)
	{
		return new vlgCase(source);
	}
	public static implicit operator vlgCase(vlgShiftExpression source)
	{
		return new vlgCase(source);
	}
	public static implicit operator vlgCase(vlgTernaryExpression source)
	{
		return new vlgCase(source);
	}
	public static implicit operator vlgCase(vlgUnaryExpression source)
	{
		return new vlgCase(source);
	}
}
public partial class vlgCaseDefault : vlgCaseItem
{
}
public abstract partial class vlgCaseItem
{
	public static implicit operator vlgCaseItem(RTLBitArray Value)
	{
		return new vlgCaseStatement(new vlgBinaryValueExpression(Value));
	}
	public static implicit operator vlgCaseItem(String Name)
	{
		return new vlgCaseStatement(new vlgIdentifierExpression(new vlgIdentifier(Name)));
	}
	public static implicit operator vlgCaseItem(vlgIdentifier Source)
	{
		return new vlgCaseStatement(new vlgIdentifierExpression(Source));
	}
}
public partial class vlgCaseStatement : vlgCaseItem
{
	public static implicit operator vlgCaseStatement(RTLBitArray Value)
	{
		return new vlgCaseStatement(new vlgBinaryValueExpression(Value));
	}
	public static implicit operator vlgCaseStatement(String Name)
	{
		return new vlgCaseStatement(new vlgIdentifierExpression(new vlgIdentifier(Name)));
	}
	public static implicit operator vlgCaseStatement(vlgIdentifier Source)
	{
		return new vlgCaseStatement(new vlgIdentifierExpression(Source));
	}
}
public partial class vlgCombBlock : vlgAbstractObject
{
	public static implicit operator vlgCombBlock(vlgIdentifier source)
	{
		return new vlgCombBlock(source);
	}
	public static implicit operator vlgCombBlock(String Name)
	{
		return new vlgCombBlock(new vlgIdentifier(Name));
	}
}
public partial class vlgComment : vlgAbstractObject
{
}
public partial class vlgCompareExpression : vlgExpression
{
}
public partial class vlgConditionalStatement : vlgAbstractObject
{
	public static implicit operator vlgConditionalStatement(vlgAssignExpression source)
	{
		return new vlgConditionalStatement(source);
	}
	public static implicit operator vlgConditionalStatement(vlgBinaryValueExpression source)
	{
		return new vlgConditionalStatement(source);
	}
	public static implicit operator vlgConditionalStatement(RTLBitArray Value)
	{
		return new vlgConditionalStatement(new vlgBinaryValueExpression(Value));
	}
	public static implicit operator vlgConditionalStatement(vlgCompareExpression source)
	{
		return new vlgConditionalStatement(source);
	}
	public static implicit operator vlgConditionalStatement(vlgIdentifierExpression source)
	{
		return new vlgConditionalStatement(source);
	}
	public static implicit operator vlgConditionalStatement(String Name)
	{
		return new vlgConditionalStatement(new vlgIdentifierExpression(new vlgIdentifier(Name)));
	}
	public static implicit operator vlgConditionalStatement(vlgIdentifier Source)
	{
		return new vlgConditionalStatement(new vlgIdentifierExpression(Source));
	}
	public static implicit operator vlgConditionalStatement(vlgLogicExpression source)
	{
		return new vlgConditionalStatement(source);
	}
	public static implicit operator vlgConditionalStatement(vlgMathExpression source)
	{
		return new vlgConditionalStatement(source);
	}
	public static implicit operator vlgConditionalStatement(vlgShiftExpression source)
	{
		return new vlgConditionalStatement(source);
	}
	public static implicit operator vlgConditionalStatement(vlgTernaryExpression source)
	{
		return new vlgConditionalStatement(source);
	}
	public static implicit operator vlgConditionalStatement(vlgUnaryExpression source)
	{
		return new vlgConditionalStatement(source);
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
	public static implicit operator vlgExpression(RTLBitArray Value)
	{
		return new vlgBinaryValueExpression(Value);
	}
	public static implicit operator vlgExpression(String Name)
	{
		return new vlgIdentifierExpression(new vlgIdentifier(Name));
	}
	public static implicit operator vlgExpression(vlgIdentifier Source)
	{
		return new vlgIdentifierExpression(Source);
	}
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
	public static implicit operator vlgIdentifierExpression(String Name)
	{
		return new vlgIdentifierExpression(new vlgIdentifier(Name));
	}
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
	public static implicit operator vlgModuleInstancePortMapping(vlgAssignExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgBinaryValueExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstancePortMapping(RTLBitArray Value)
	{
		return new vlgModuleInstanceSimplePortMapping(new vlgBinaryValueExpression(Value));
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgCompareExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgIdentifierExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstancePortMapping(String Name)
	{
		return new vlgModuleInstanceSimplePortMapping(new vlgIdentifierExpression(new vlgIdentifier(Name)));
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgIdentifier Source)
	{
		return new vlgModuleInstanceSimplePortMapping(new vlgIdentifierExpression(Source));
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgLogicExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgMathExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgShiftExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgTernaryExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstancePortMapping(vlgUnaryExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
}
public partial class vlgModuleInstancePortMappings : vlgAbstractCollection
{
}
public partial class vlgModuleInstanceSimplePortMapping : vlgModuleInstancePortMapping
{
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgAssignExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgBinaryValueExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(RTLBitArray Value)
	{
		return new vlgModuleInstanceSimplePortMapping(new vlgBinaryValueExpression(Value));
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgCompareExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgIdentifierExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(String Name)
	{
		return new vlgModuleInstanceSimplePortMapping(new vlgIdentifierExpression(new vlgIdentifier(Name)));
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgIdentifier Source)
	{
		return new vlgModuleInstanceSimplePortMapping(new vlgIdentifierExpression(Source));
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgLogicExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgMathExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgShiftExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgTernaryExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
	}
	public static implicit operator vlgModuleInstanceSimplePortMapping(vlgUnaryExpression source)
	{
		return new vlgModuleInstanceSimplePortMapping(source);
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
	public static implicit operator vlgModulePort(String Name)
	{
		return new vlgPlaceholderModulePort(Name);
	}
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
	public static implicit operator vlgRange(vlgExpression source)
	{
		return new vlgRange(source);
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
	public static implicit operator vlgSyncBlock(vlgSyncBlockSensitivityItem source)
	{
		return new vlgSyncBlock(source);
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
}
public partial class vlgUnaryExpression : vlgExpression
{
}
} // Quokka.RTL.Verilog