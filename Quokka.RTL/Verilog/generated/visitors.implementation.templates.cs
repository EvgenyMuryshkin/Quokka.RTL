using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog.Implementation
{
using Quokka.RTL.Tools;
/*
public partial class vlgAggregateExpressionVisitorImplementation
{
	public override void OnVisit(vlgAggregateExpression obj)
	{
	}
}
public partial class vlgAssignVisitorImplementation
{
	public override void OnVisit(vlgAssign obj)
	{
	}
}
public partial class vlgAssignExpressionVisitorImplementation
{
	public override void OnVisit(vlgAssignExpression obj)
	{
	}
}
public partial class vlgAttributeVisitorImplementation
{
	public override void OnVisit(vlgAttribute obj)
	{
	}
}
public partial class vlgBinaryValueExpressionVisitorImplementation
{
	public override void OnVisit(vlgBinaryValueExpression obj)
	{
	}
}
public partial class vlgCaseVisitorImplementation
{
	public override void OnVisit(vlgCase obj)
	{
	}
}
public partial class vlgCaseDefaultVisitorImplementation
{
	public override void OnVisit(vlgCaseDefault obj)
	{
	}
}
public partial class vlgCaseStatementVisitorImplementation
{
	public override void OnVisit(vlgCaseStatement obj)
	{
	}
}
public partial class vlgCombBlockVisitorImplementation
{
	public override void OnVisit(vlgCombBlock obj)
	{
	}
}
public partial class vlgCommentVisitorImplementation
{
	public override void OnVisit(vlgComment obj)
	{
	}
}
public partial class vlgCompareExpressionVisitorImplementation
{
	public override void OnVisit(vlgCompareExpression obj)
	{
	}
}
public partial class vlgConditionalStatementVisitorImplementation
{
	public override void OnVisit(vlgConditionalStatement obj)
	{
	}
}
public partial class vlgCustomDeclarationVisitorImplementation
{
	public override void OnVisit(vlgCustomDeclaration obj)
	{
	}
}
public partial class vlgCustomModulePortDeclarationVisitorImplementation
{
	public override void OnVisit(vlgCustomModulePortDeclaration obj)
	{
	}
}
public partial class vlgFileVisitorImplementation
{
	public override void OnVisit(vlgFile obj)
	{
	}
}
public partial class vlgForLoopVisitorImplementation
{
	public override void OnVisit(vlgForLoop obj)
	{
	}
}
public partial class vlgGenerateVisitorImplementation
{
	public override void OnVisit(vlgGenerate obj)
	{
	}
}
public partial class vlgGenericBlockVisitorImplementation
{
	public override void OnVisit(vlgGenericBlock obj)
	{
	}
}
public partial class vlgGenvarVisitorImplementation
{
	public override void OnVisit(vlgGenvar obj)
	{
	}
}
public partial class vlgIdentifierVisitorImplementation
{
	public override void OnVisit(vlgIdentifier obj)
	{
	}
}
public partial class vlgIdentifierExpressionVisitorImplementation
{
	public override void OnVisit(vlgIdentifierExpression obj)
	{
	}
}
public partial class vlgIfVisitorImplementation
{
	public override void OnVisit(vlgIf obj)
	{
	}
}
public partial class vlgInitialVisitorImplementation
{
	public override void OnVisit(vlgInitial obj)
	{
	}
}
public partial class vlgIteratorVisitorImplementation
{
	public override void OnVisit(vlgIterator obj)
	{
	}
}
public partial class vlgLocalParamNameBinaryValueVisitorImplementation
{
	public override void OnVisit(vlgLocalParamNameBinaryValue obj)
	{
	}
}
public partial class vlgLocalParamNameExplicitValueVisitorImplementation
{
	public override void OnVisit(vlgLocalParamNameExplicitValue obj)
	{
	}
}
public partial class vlgLogicExpressionVisitorImplementation
{
	public override void OnVisit(vlgLogicExpression obj)
	{
	}
}
public partial class vlgLogicSignalVisitorImplementation
{
	public override void OnVisit(vlgLogicSignal obj)
	{
	}
}
public partial class vlgMathExpressionVisitorImplementation
{
	public override void OnVisit(vlgMathExpression obj)
	{
	}
}
public partial class vlgMemoryBlockVisitorImplementation
{
	public override void OnVisit(vlgMemoryBlock obj)
	{
	}
}
public partial class vlgModuleVisitorImplementation
{
	public override void OnVisit(vlgModule obj)
	{
	}
}
public partial class vlgModuleImplementationVisitorImplementation
{
	public override void OnVisit(vlgModuleImplementation obj)
	{
	}
}
public partial class vlgModuleImplementationBlockVisitorImplementation
{
	public override void OnVisit(vlgModuleImplementationBlock obj)
	{
	}
}
public partial class vlgModuleInstanceVisitorImplementation
{
	public override void OnVisit(vlgModuleInstance obj)
	{
	}
}
public partial class vlgModuleInstanceNamedPortMappingVisitorImplementation
{
	public override void OnVisit(vlgModuleInstanceNamedPortMapping obj)
	{
	}
}
public partial class vlgModuleInstanceParameterVisitorImplementation
{
	public override void OnVisit(vlgModuleInstanceParameter obj)
	{
	}
}
public partial class vlgModuleInstanceParametersVisitorImplementation
{
	public override void OnVisit(vlgModuleInstanceParameters obj)
	{
	}
}
public partial class vlgModuleInstancePortMappingsVisitorImplementation
{
	public override void OnVisit(vlgModuleInstancePortMappings obj)
	{
	}
}
public partial class vlgModuleInstanceSimplePortMappingVisitorImplementation
{
	public override void OnVisit(vlgModuleInstanceSimplePortMapping obj)
	{
	}
}
public partial class vlgModuleInterfaceVisitorImplementation
{
	public override void OnVisit(vlgModuleInterface obj)
	{
	}
}
public partial class vlgModuleParameterDeclarationVisitorImplementation
{
	public override void OnVisit(vlgModuleParameterDeclaration obj)
	{
	}
}
public partial class vlgModuleParametersVisitorImplementation
{
	public override void OnVisit(vlgModuleParameters obj)
	{
	}
}
public partial class vlgPlaceholderModulePortVisitorImplementation
{
	public override void OnVisit(vlgPlaceholderModulePort obj)
	{
	}
}
public partial class vlgProcedureCallVisitorImplementation
{
	public override void OnVisit(vlgProcedureCall obj)
	{
	}
}
public partial class vlgProcedureCallExpressionVisitorImplementation
{
	public override void OnVisit(vlgProcedureCallExpression obj)
	{
	}
}
public partial class vlgRangeVisitorImplementation
{
	public override void OnVisit(vlgRange obj)
	{
	}
}
public partial class vlgShiftExpressionVisitorImplementation
{
	public override void OnVisit(vlgShiftExpression obj)
	{
	}
}
public partial class vlgSimpleForLoopVisitorImplementation
{
	public override void OnVisit(vlgSimpleForLoop obj)
	{
	}
}
public partial class vlgSizedAggregateExpressionVisitorImplementation
{
	public override void OnVisit(vlgSizedAggregateExpression obj)
	{
	}
}
public partial class vlgStandardModulePortDeclarationVisitorImplementation
{
	public override void OnVisit(vlgStandardModulePortDeclaration obj)
	{
	}
}
public partial class vlgStandardModulePortImplementationVisitorImplementation
{
	public override void OnVisit(vlgStandardModulePortImplementation obj)
	{
	}
}
public partial class vlgSyncBlockVisitorImplementation
{
	public override void OnVisit(vlgSyncBlock obj)
	{
	}
}
public partial class vlgSyncBlockSensitivityItemVisitorImplementation
{
	public override void OnVisit(vlgSyncBlockSensitivityItem obj)
	{
	}
}
public partial class vlgTernaryExpressionVisitorImplementation
{
	public override void OnVisit(vlgTernaryExpression obj)
	{
	}
}
public partial class vlgTextVisitorImplementation
{
	public override void OnVisit(vlgText obj)
	{
	}
}
public partial class vlgUnaryExpressionVisitorImplementation
{
	public override void OnVisit(vlgUnaryExpression obj)
	{
	}
}
*/
} // Quokka.RTL.Verilog
