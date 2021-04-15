﻿using System;

namespace Quokka.RTL
{
    public interface IRTLPipelineHead : IRTLPipeline, IRTLModuleControlFlow
    {
        IRTLPipelinePreviewSignals PipelinePreview { get; }
        IRTLPipelineControlSignals PipelineControl { get; }
    }

    public interface IRTLPipelineHead<TSource> : IRTLPipelineHead
    {
        void Schedule(Func<TSource> inputsFactory);
        IRTLPipelineStage<TSource, TResult> Stage<TResult>(Func<TSource, TResult> map);
        IRTLPipelineStage<TSource, TResult> Stage<TResult>(Func<TSource, TResult, TResult> map);
        IRTLPipelineStage<TSource, TResult> Stage<TResult>(Func<TSource, TResult, IRTLPipelineStageManagedSignals, TResult> map);
    }
}