using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.Verilog
{
using Quokka.RTL.Tools;
public interface vlgAggregateExpressionVisitorInterface : vlgVisitorInterface<vlgAggregateExpression> { }
public interface vlgAssignVisitorInterface : vlgVisitorInterface<vlgAssign> { }
public interface vlgAssignExpressionVisitorInterface : vlgVisitorInterface<vlgAssignExpression> { }
public interface vlgAttributeVisitorInterface : vlgVisitorInterface<vlgAttribute> { }
public interface vlgBinaryValueExpressionVisitorInterface : vlgVisitorInterface<vlgBinaryValueExpression> { }
public interface vlgCaseVisitorInterface : vlgVisitorInterface<vlgCase> { }
public interface vlgCaseDefaultVisitorInterface : vlgVisitorInterface<vlgCaseDefault> { }
public interface vlgCaseStatementVisitorInterface : vlgVisitorInterface<vlgCaseStatement> { }
public interface vlgCombBlockVisitorInterface : vlgVisitorInterface<vlgCombBlock> { }
public interface vlgCommentVisitorInterface : vlgVisitorInterface<vlgComment> { }
public interface vlgCompareExpressionVisitorInterface : vlgVisitorInterface<vlgCompareExpression> { }
public interface vlgConditionalStatementVisitorInterface : vlgVisitorInterface<vlgConditionalStatement> { }
public interface vlgCustomDeclarationVisitorInterface : vlgVisitorInterface<vlgCustomDeclaration> { }
public interface vlgCustomModulePortDeclarationVisitorInterface : vlgVisitorInterface<vlgCustomModulePortDeclaration> { }
public interface vlgFileVisitorInterface : vlgVisitorInterface<vlgFile> { }
public interface vlgForLoopVisitorInterface : vlgVisitorInterface<vlgForLoop> { }
public interface vlgGenerateVisitorInterface : vlgVisitorInterface<vlgGenerate> { }
public interface vlgGenericBlockVisitorInterface : vlgVisitorInterface<vlgGenericBlock> { }
public interface vlgGenvarVisitorInterface : vlgVisitorInterface<vlgGenvar> { }
public interface vlgIdentifierVisitorInterface : vlgVisitorInterface<vlgIdentifier> { }
public interface vlgIdentifierExpressionVisitorInterface : vlgVisitorInterface<vlgIdentifierExpression> { }
public interface vlgIfVisitorInterface : vlgVisitorInterface<vlgIf> { }
public interface vlgInitialVisitorInterface : vlgVisitorInterface<vlgInitial> { }
public interface vlgIteratorVisitorInterface : vlgVisitorInterface<vlgIterator> { }
public interface vlgLocalParamNameBinaryValueVisitorInterface : vlgVisitorInterface<vlgLocalParamNameBinaryValue> { }
public interface vlgLocalParamNameExplicitValueVisitorInterface : vlgVisitorInterface<vlgLocalParamNameExplicitValue> { }
public interface vlgLogicExpressionVisitorInterface : vlgVisitorInterface<vlgLogicExpression> { }
public interface vlgLogicSignalVisitorInterface : vlgVisitorInterface<vlgLogicSignal> { }
public interface vlgMathExpressionVisitorInterface : vlgVisitorInterface<vlgMathExpression> { }
public interface vlgMemoryBlockVisitorInterface : vlgVisitorInterface<vlgMemoryBlock> { }
public interface vlgModuleVisitorInterface : vlgVisitorInterface<vlgModule> { }
public interface vlgModuleImplementationVisitorInterface : vlgVisitorInterface<vlgModuleImplementation> { }
public interface vlgModuleImplementationBlockVisitorInterface : vlgVisitorInterface<vlgModuleImplementationBlock> { }
public interface vlgModuleInstanceVisitorInterface : vlgVisitorInterface<vlgModuleInstance> { }
public interface vlgModuleInstanceNamedPortMappingVisitorInterface : vlgVisitorInterface<vlgModuleInstanceNamedPortMapping> { }
public interface vlgModuleInstanceParameterVisitorInterface : vlgVisitorInterface<vlgModuleInstanceParameter> { }
public interface vlgModuleInstanceParametersVisitorInterface : vlgVisitorInterface<vlgModuleInstanceParameters> { }
public interface vlgModuleInstancePortMappingsVisitorInterface : vlgVisitorInterface<vlgModuleInstancePortMappings> { }
public interface vlgModuleInstanceSimplePortMappingVisitorInterface : vlgVisitorInterface<vlgModuleInstanceSimplePortMapping> { }
public interface vlgModuleInterfaceVisitorInterface : vlgVisitorInterface<vlgModuleInterface> { }
public interface vlgModuleParameterDeclarationVisitorInterface : vlgVisitorInterface<vlgModuleParameterDeclaration> { }
public interface vlgModuleParametersVisitorInterface : vlgVisitorInterface<vlgModuleParameters> { }
public interface vlgPlaceholderModulePortVisitorInterface : vlgVisitorInterface<vlgPlaceholderModulePort> { }
public interface vlgProcedureCallVisitorInterface : vlgVisitorInterface<vlgProcedureCall> { }
public interface vlgRangeVisitorInterface : vlgVisitorInterface<vlgRange> { }
public interface vlgShiftExpressionVisitorInterface : vlgVisitorInterface<vlgShiftExpression> { }
public interface vlgSimpleForLoopVisitorInterface : vlgVisitorInterface<vlgSimpleForLoop> { }
public interface vlgSizedAggregateExpressionVisitorInterface : vlgVisitorInterface<vlgSizedAggregateExpression> { }
public interface vlgStandardModulePortDeclarationVisitorInterface : vlgVisitorInterface<vlgStandardModulePortDeclaration> { }
public interface vlgStandardModulePortImplementationVisitorInterface : vlgVisitorInterface<vlgStandardModulePortImplementation> { }
public interface vlgSyncBlockVisitorInterface : vlgVisitorInterface<vlgSyncBlock> { }
public interface vlgSyncBlockSensitivityItemVisitorInterface : vlgVisitorInterface<vlgSyncBlockSensitivityItem> { }
public interface vlgTernaryExpressionVisitorInterface : vlgVisitorInterface<vlgTernaryExpression> { }
public interface vlgTextVisitorInterface : vlgVisitorInterface<vlgText> { }
public interface vlgUnaryExpressionVisitorInterface : vlgVisitorInterface<vlgUnaryExpression> { }
} // Quokka.RTL.Verilog
