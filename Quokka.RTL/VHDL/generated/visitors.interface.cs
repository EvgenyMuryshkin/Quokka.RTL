using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public interface vhdAggregateVisitorInterface : vhdVisitorInterface<vhdAggregate> { }
public interface vhdAggregateBitConnectionVisitorInterface : vhdVisitorInterface<vhdAggregateBitConnection> { }
public interface vhdAggregateExpressionVisitorInterface : vhdVisitorInterface<vhdAggregateExpression> { }
public interface vhdAggregateOthersConnectionVisitorInterface : vhdVisitorInterface<vhdAggregateOthersConnection> { }
public interface vhdAliasVisitorInterface : vhdVisitorInterface<vhdAlias> { }
public interface vhdArchitectureVisitorInterface : vhdVisitorInterface<vhdArchitecture> { }
public interface vhdArchitectureDeclarationsVisitorInterface : vhdVisitorInterface<vhdArchitectureDeclarations> { }
public interface vhdArchitectureImplementationVisitorInterface : vhdVisitorInterface<vhdArchitectureImplementation> { }
public interface vhdArchitectureImplementationBlockVisitorInterface : vhdVisitorInterface<vhdArchitectureImplementationBlock> { }
public interface vhdArrayTypeDeclarationVisitorInterface : vhdVisitorInterface<vhdArrayTypeDeclaration> { }
public interface vhdAssignExpressionVisitorInterface : vhdVisitorInterface<vhdAssignExpression> { }
public interface vhdAttributeVisitorInterface : vhdVisitorInterface<vhdAttribute> { }
public interface vhdBinaryValueExpressionVisitorInterface : vhdVisitorInterface<vhdBinaryValueExpression> { }
public interface vhdCaseVisitorInterface : vhdVisitorInterface<vhdCase> { }
public interface vhdCaseStatementVisitorInterface : vhdVisitorInterface<vhdCaseStatement> { }
public interface vhdCastExpressionVisitorInterface : vhdVisitorInterface<vhdCastExpression> { }
public interface vhdCastResizeExpressionVisitorInterface : vhdVisitorInterface<vhdCastResizeExpression> { }
public interface vhdCommentVisitorInterface : vhdVisitorInterface<vhdComment> { }
public interface vhdCompareExpressionVisitorInterface : vhdVisitorInterface<vhdCompareExpression> { }
public interface vhdConditionalStatementVisitorInterface : vhdVisitorInterface<vhdConditionalStatement> { }
public interface vhdCustomEntityPortVisitorInterface : vhdVisitorInterface<vhdCustomEntityPort> { }
public interface vhdDefaultSignalVisitorInterface : vhdVisitorInterface<vhdDefaultSignal> { }
public interface vhdEntityVisitorInterface : vhdVisitorInterface<vhdEntity> { }
public interface vhdEntityInstanceVisitorInterface : vhdVisitorInterface<vhdEntityInstance> { }
public interface vhdEntityInstanceNamedPortMappingVisitorInterface : vhdVisitorInterface<vhdEntityInstanceNamedPortMapping> { }
public interface vhdEntityInstancePortMappingsVisitorInterface : vhdVisitorInterface<vhdEntityInstancePortMappings> { }
public interface vhdEntityInterfaceVisitorInterface : vhdVisitorInterface<vhdEntityInterface> { }
public interface vhdFileVisitorInterface : vhdVisitorInterface<vhdFile> { }
public interface vhdGenericBlockVisitorInterface : vhdVisitorInterface<vhdGenericBlock> { }
public interface vhdIdentifierVisitorInterface : vhdVisitorInterface<vhdIdentifier> { }
public interface vhdIdentifierExpressionVisitorInterface : vhdVisitorInterface<vhdIdentifierExpression> { }
public interface vhdIfVisitorInterface : vhdVisitorInterface<vhdIf> { }
public interface vhdIndexedExpressionVisitorInterface : vhdVisitorInterface<vhdIndexedExpression> { }
public interface vhdLibraryReferenceVisitorInterface : vhdVisitorInterface<vhdLibraryReference> { }
public interface vhdLogicExpressionVisitorInterface : vhdVisitorInterface<vhdLogicExpression> { }
public interface vhdLogicSignalVisitorInterface : vhdVisitorInterface<vhdLogicSignal> { }
public interface vhdMathExpressionVisitorInterface : vhdVisitorInterface<vhdMathExpression> { }
public interface vhdNullVisitorInterface : vhdVisitorInterface<vhdNull> { }
public interface vhdOthersExpressionVisitorInterface : vhdVisitorInterface<vhdOthersExpression> { }
public interface vhdParenthesizedExpressionVisitorInterface : vhdVisitorInterface<vhdParenthesizedExpression> { }
public interface vhdPredefinedAttributeExpressionVisitorInterface : vhdVisitorInterface<vhdPredefinedAttributeExpression> { }
public interface vhdProcedureCallVisitorInterface : vhdVisitorInterface<vhdProcedureCall> { }
public interface vhdProcessVisitorInterface : vhdVisitorInterface<vhdProcess> { }
public interface vhdProcessDeclarationsVisitorInterface : vhdVisitorInterface<vhdProcessDeclarations> { }
public interface vhdRangeVisitorInterface : vhdVisitorInterface<vhdRange> { }
public interface vhdResizeExpressionVisitorInterface : vhdVisitorInterface<vhdResizeExpression> { }
public interface vhdShiftExpressionVisitorInterface : vhdVisitorInterface<vhdShiftExpression> { }
public interface vhdSimpleForLoopVisitorInterface : vhdVisitorInterface<vhdSimpleForLoop> { }
public interface vhdStandardEntityPortVisitorInterface : vhdVisitorInterface<vhdStandardEntityPort> { }
public interface vhdSyncBlockVisitorInterface : vhdVisitorInterface<vhdSyncBlock> { }
public interface vhdTernaryExpressionVisitorInterface : vhdVisitorInterface<vhdTernaryExpression> { }
public interface vhdTextVisitorInterface : vhdVisitorInterface<vhdText> { }
public interface vhdUnaryExpressionVisitorInterface : vhdVisitorInterface<vhdUnaryExpression> { }
public interface vhdUseVisitorInterface : vhdVisitorInterface<vhdUse> { }
} // Quokka.RTL.VHDL
