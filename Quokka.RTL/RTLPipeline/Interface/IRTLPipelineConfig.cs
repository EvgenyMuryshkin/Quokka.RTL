using System;

namespace Quokka.RTL
{
    public interface IRTLPipelineConfig<TSource, TOutput>
    {
        IRTLPipelineStage<TSource, TMap> Stage<TMap>(Func<TOutput, TMap> map);
        IRTLPipelineStage<TSource, TMap> Stage<TMap>(Func<TOutput, TMap, TMap> map);
        IRTLPipelineStage<TSource, TMap> Stage<TMap>(Func<TOutput, TMap, IRTLPipelineStageManagedSignals, TMap> map);
    }
}
