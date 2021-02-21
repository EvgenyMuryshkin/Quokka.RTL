namespace Quokka.RTL
{
    [RTLToolkitType]
    public class RTLPipelineStagePreviewSignals : IRTLPipelineStagePreviewSignals
    {
        public bool StageWillStall { get; set; }
    }
}
