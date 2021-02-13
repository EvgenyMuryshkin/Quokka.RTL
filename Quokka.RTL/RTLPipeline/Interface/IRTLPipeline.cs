using System;

namespace Quokka.RTL
{
    public interface IRTLPipeline
    {
        void Setup(IRTLCombinationalModule module);
        IRTLPipelineDiagnostics Diag { get; }
        IRTLPipelinePeek<TState> Peek<TState>();
    }

    public interface IRTLPipeline<TSource> : IRTLPipeline
    {
        void Schedule(Func<TSource> inputsFactory);
    }
}
