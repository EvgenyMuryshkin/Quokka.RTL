namespace Quokka.RTL
{
    public class RTLPipelineStageManagedSignals : IRTLPipelineStageManagedSignals
    {
        public IRTLPipelineStageControlSignals Control { get; set;  }
        public IRTLPipelineStageRequestSignals Request { get; set; }
        public IRTLPipelineStagePreviewSignals Preview { get; set; }
    }
}
