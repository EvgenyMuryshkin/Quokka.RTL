using System;

namespace Quokka.RTL
{
    public interface IRTLPipelineHead : IRTLPipeline, IRTLControlFlow
    {
        bool PipelineWillStall { get; }
        bool PipelineStalled { get; }
    }

    public interface IRTLPipelineHead<TSource> : IRTLPipelineHead
    {
        void Schedule(Func<TSource> inputsFactory);
        IRTLPipelineStage<TSource, TResult> Stage<TResult>(Func<TSource, TResult> map);
        IRTLPipelineStage<TSource, TResult> Stage<TResult>(Func<TSource, TResult, TResult> map);
    }
}
