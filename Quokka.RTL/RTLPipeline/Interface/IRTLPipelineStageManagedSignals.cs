namespace Quokka.RTL
{
    public interface IRTLPipelineStageManagedSignals
    {
        IRTLPipelineStageControlSignals Control { get; }
        IRTLPipelineStageRequestSignals Request { get; }
        IRTLPipelineStagePreviewSignals Preview { get; }
    }
}
