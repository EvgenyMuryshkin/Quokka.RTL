using System;

namespace Quokka.RTL
{
    public interface IRTLPipelineStage : IRTLPipeline, IRTLPipelineControl
    {
        Type InputsType { get; }
        Type StateType { get; }
        object StateValue { get; }
        object NextStateValue { get; }
    }

    public interface IRTLPipelineStage<TInput> : IRTLPipelineStage
    {
        void StageSchedule(Func<TInput> inputsFactory);
    }

    public interface IRTLPipelineStage<TSource, TOutput> : IRTLPipelineStage, IRTLPipeline<TSource>
    {
        TOutput State { get; }
        TOutput NextState { get; }
        IRTLPipelineStage<TSource, TMap> Stage<TMap>(Func<TOutput, TMap> map);
        IRTLPipelineStage<TSource, TMap> Stage<TMap>(Func<TOutput, TMap, TMap> map);
        IRTLPipelineStage<TSource, TMap> Stage<TMap>(Func<TOutput, TMap, IRTLPipelineStageContol, TMap> map);
    }

    public interface IRTLPipelineStage<TSource, TInput, TOutput> :
        IRTLPipelineStage<TInput>,
        IRTLPipelineStage<TSource, TOutput>
    {
    }
}
