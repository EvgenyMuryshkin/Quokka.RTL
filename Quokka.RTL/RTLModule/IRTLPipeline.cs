using System;
using System.Collections.Generic;

namespace Quokka.RTL
{
    public interface IRTLPipeline
    {
        void Setup();
        IRTLPipelineDiagnostics Diag { get; }
        IRTLPipelinePeek<TState> Peek<TState>();
    }

    public interface IRTLPipelinePeek<TState>
    {
        TState State { get; }
    }


    public interface IRTLPipelineHead : IRTLPipeline, IRTLControlFlow
    {
    }

    public interface IRTLPipelineHead<TSource> : IRTLPipelineHead
    {
        void Schedule(Func<TSource> inputsFactory);
        IRTLPipelineStage<TSource, TResult> Stage<TResult>(Func<TSource, TResult> map);
    }

    public interface IRTLPipeline<TSource> : IRTLPipeline
    {
        void Schedule(Func<TSource> inputsFactory);
    }

    public interface IRTLPipelineControlFlow
    {
        void StageSetup();
        void StageCommit();
        void StageReset();
        bool StageStage(int iteration);
    }

    public interface IRTLPipelineStage : IRTLPipeline, IRTLPipelineControlFlow
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
    }

    public interface IRTLPipelineStage<TSource, TInput, TOutput> :
        IRTLPipelineStage<TInput>,
        IRTLPipelineStage<TSource, TOutput>
    {
    }

    public interface IRTLPipelineDiagnostics
    {
        IRTLPipelineHead Head { get; }
        IRTLPipelineStage NextStage { get; }
        List<IRTLPipelineStage> Stages { get; }
        Type SourceType { get; }
        Type ResultType { get; }
    }
}
