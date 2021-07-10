using System;

namespace Quokka.RTL
{
    public interface IRTLPipelineStage : 
        IRTLPipeline, 
        IRTLPipelineStageControlFlow,
        IRTLPipelineStageHardwareSignals
    {
        Type InputsType { get; }
        Type StateType { get; }
        object StateValue { get; }
        object NextStateValue { get; }

        IRTLPipelineStageManagedSignals ManagedSignals { get; }

        IRTLPipelinePreviewSignals PipelinePreview { get; }
        IRTLPipelineControlSignals PipelineControl { get; }
    }

    public interface IRTLPipelineStage<TInput> : IRTLPipelineStage
    {
        void StageSchedule(Func<TInput> inputsFactory);
    }

    public interface IRTLPipelineStage<TSource, TOutput> : IRTLPipelineStage, IRTLPipeline<TSource>, IRTLPipelineConfig<TSource, TOutput>
    {
        TOutput State { get; }
        TOutput NextState { get; }
        IRTLPipelineStage<TSource, TOutput> Generate(int range, Func<int, TOutput, TOutput> map);
    }

    public interface IRTLPipelineStage<TSource, TInput, TOutput> :
        IRTLPipelineStage<TInput>,
        IRTLPipelineStage<TSource, TOutput>
    {
    }
}
