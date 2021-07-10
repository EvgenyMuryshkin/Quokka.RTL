using System;

namespace Quokka.RTL
{
    public interface IRTLPipelineHead : IRTLPipeline, IRTLModuleControlFlow
    {
        IRTLPipelinePreviewSignals PipelinePreview { get; }
        IRTLPipelineControlSignals PipelineControl { get; }
    }

    public interface IRTLPipelineHead<TSource> : IRTLPipelineHead, IRTLPipelineConfig<TSource, TSource>
    {
        void Schedule(Func<TSource> inputsFactory);
        IRTLPipelineStage<TSource, TSource> Generate(int range, Func<int, TSource, TSource> map);
    }
}
