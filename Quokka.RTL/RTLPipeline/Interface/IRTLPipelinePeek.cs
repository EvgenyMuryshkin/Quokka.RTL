namespace Quokka.RTL
{
    public interface IRTLPipelinePeek<TState>
    {
        TState State { get; }
        TState NextState { get; }
        IRTLPipelineStageControlSignals Control { get; }
        IRTLPipelineStageRequestSignals Request { get; }
        IRTLPipelineStagePreviewSignals Preview { get; }
    }
}
