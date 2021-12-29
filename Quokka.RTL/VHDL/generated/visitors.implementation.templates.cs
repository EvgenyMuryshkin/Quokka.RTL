using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL.Implementation
{
using Quokka.RTL.Tools;
/*
public partial class vhdAggregateVisitorImplementation
{
	public override void OnVisit(vhdAggregate obj)
	{
	}
}
public partial class vhdAggregateBitConnectionVisitorImplementation
{
	public override void OnVisit(vhdAggregateBitConnection obj)
	{
	}
}
public partial class vhdAggregateExpressionVisitorImplementation
{
	public override void OnVisit(vhdAggregateExpression obj)
	{
	}
}
public partial class vhdAggregateOthersConnectionVisitorImplementation
{
	public override void OnVisit(vhdAggregateOthersConnection obj)
	{
	}
}
public partial class vhdAliasVisitorImplementation
{
	public override void OnVisit(vhdAlias obj)
	{
	}
}
public partial class vhdArchitectureVisitorImplementation
{
	public override void OnVisit(vhdArchitecture obj)
	{
	}
}
public partial class vhdArchitectureDeclarationsVisitorImplementation
{
	public override void OnVisit(vhdArchitectureDeclarations obj)
	{
	}
}
public partial class vhdArchitectureImplementationVisitorImplementation
{
	public override void OnVisit(vhdArchitectureImplementation obj)
	{
	}
}
public partial class vhdArchitectureImplementationBlockVisitorImplementation
{
	public override void OnVisit(vhdArchitectureImplementationBlock obj)
	{
	}
}
public partial class vhdArrayTypeDeclarationVisitorImplementation
{
	public override void OnVisit(vhdArrayTypeDeclaration obj)
	{
	}
}
public partial class vhdAssignExpressionVisitorImplementation
{
	public override void OnVisit(vhdAssignExpression obj)
	{
	}
}
public partial class vhdAttributeVisitorImplementation
{
	public override void OnVisit(vhdAttribute obj)
	{
	}
}
public partial class vhdBinaryValueExpressionVisitorImplementation
{
	public override void OnVisit(vhdBinaryValueExpression obj)
	{
	}
}
public partial class vhdCaseVisitorImplementation
{
	public override void OnVisit(vhdCase obj)
	{
	}
}
public partial class vhdCaseStatementVisitorImplementation
{
	public override void OnVisit(vhdCaseStatement obj)
	{
	}
}
public partial class vhdCastExpressionVisitorImplementation
{
	public override void OnVisit(vhdCastExpression obj)
	{
	}
}
public partial class vhdCastResizeExpressionVisitorImplementation
{
	public override void OnVisit(vhdCastResizeExpression obj)
	{
	}
}
public partial class vhdCommentVisitorImplementation
{
	public override void OnVisit(vhdComment obj)
	{
	}
}
public partial class vhdCompareExpressionVisitorImplementation
{
	public override void OnVisit(vhdCompareExpression obj)
	{
	}
}
public partial class vhdConditionalStatementVisitorImplementation
{
	public override void OnVisit(vhdConditionalStatement obj)
	{
	}
}
public partial class vhdCustomEntityPortVisitorImplementation
{
	public override void OnVisit(vhdCustomEntityPort obj)
	{
	}
}
public partial class vhdDefaultSignalVisitorImplementation
{
	public override void OnVisit(vhdDefaultSignal obj)
	{
	}
}
public partial class vhdEntityVisitorImplementation
{
	public override void OnVisit(vhdEntity obj)
	{
	}
}
public partial class vhdEntityInstanceVisitorImplementation
{
	public override void OnVisit(vhdEntityInstance obj)
	{
	}
}
public partial class vhdEntityInstanceNamedPortMappingVisitorImplementation
{
	public override void OnVisit(vhdEntityInstanceNamedPortMapping obj)
	{
	}
}
public partial class vhdEntityInstancePortMappingsVisitorImplementation
{
	public override void OnVisit(vhdEntityInstancePortMappings obj)
	{
	}
}
public partial class vhdEntityInterfaceVisitorImplementation
{
	public override void OnVisit(vhdEntityInterface obj)
	{
	}
}
public partial class vhdFileVisitorImplementation
{
	public override void OnVisit(vhdFile obj)
	{
	}
}
public partial class vhdGenericBlockVisitorImplementation
{
	public override void OnVisit(vhdGenericBlock obj)
	{
	}
}
public partial class vhdIdentifierVisitorImplementation
{
	public override void OnVisit(vhdIdentifier obj)
	{
	}
}
public partial class vhdIdentifierExpressionVisitorImplementation
{
	public override void OnVisit(vhdIdentifierExpression obj)
	{
	}
}
public partial class vhdIfVisitorImplementation
{
	public override void OnVisit(vhdIf obj)
	{
	}
}
public partial class vhdLibraryReferenceVisitorImplementation
{
	public override void OnVisit(vhdLibraryReference obj)
	{
	}
}
public partial class vhdLogicExpressionVisitorImplementation
{
	public override void OnVisit(vhdLogicExpression obj)
	{
	}
}
public partial class vhdLogicSignalVisitorImplementation
{
	public override void OnVisit(vhdLogicSignal obj)
	{
	}
}
public partial class vhdMathExpressionVisitorImplementation
{
	public override void OnVisit(vhdMathExpression obj)
	{
	}
}
public partial class vhdNullVisitorImplementation
{
	public override void OnVisit(vhdNull obj)
	{
	}
}
public partial class vhdOthersExpressionVisitorImplementation
{
	public override void OnVisit(vhdOthersExpression obj)
	{
	}
}
public partial class vhdPredefinedAttributeExpressionVisitorImplementation
{
	public override void OnVisit(vhdPredefinedAttributeExpression obj)
	{
	}
}
public partial class vhdProcedureCallVisitorImplementation
{
	public override void OnVisit(vhdProcedureCall obj)
	{
	}
}
public partial class vhdProcessVisitorImplementation
{
	public override void OnVisit(vhdProcess obj)
	{
	}
}
public partial class vhdProcessDeclarationsVisitorImplementation
{
	public override void OnVisit(vhdProcessDeclarations obj)
	{
	}
}
public partial class vhdRangeVisitorImplementation
{
	public override void OnVisit(vhdRange obj)
	{
	}
}
public partial class vhdResizeExpressionVisitorImplementation
{
	public override void OnVisit(vhdResizeExpression obj)
	{
	}
}
public partial class vhdShiftExpressionVisitorImplementation
{
	public override void OnVisit(vhdShiftExpression obj)
	{
	}
}
public partial class vhdSimpleForLoopVisitorImplementation
{
	public override void OnVisit(vhdSimpleForLoop obj)
	{
	}
}
public partial class vhdStandardEntityPortVisitorImplementation
{
	public override void OnVisit(vhdStandardEntityPort obj)
	{
	}
}
public partial class vhdSyncBlockVisitorImplementation
{
	public override void OnVisit(vhdSyncBlock obj)
	{
	}
}
public partial class vhdTernaryExpressionVisitorImplementation
{
	public override void OnVisit(vhdTernaryExpression obj)
	{
	}
}
public partial class vhdTextVisitorImplementation
{
	public override void OnVisit(vhdText obj)
	{
	}
}
public partial class vhdUnaryExpressionVisitorImplementation
{
	public override void OnVisit(vhdUnaryExpression obj)
	{
	}
}
public partial class vhdUseVisitorImplementation
{
	public override void OnVisit(vhdUse obj)
	{
	}
}
*/
} // Quokka.RTL.VHDL
