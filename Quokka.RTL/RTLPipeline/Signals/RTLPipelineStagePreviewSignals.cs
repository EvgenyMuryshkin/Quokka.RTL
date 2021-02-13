namespace Quokka.RTL
{
    [RTLToolkitType]
    public class RTLPipelineStagePreviewSignals : IRTLPipelineStagePreviewSignals
    {
        public bool PrevStageWillStall { get; set; }
        public bool StageWillStall { get; set; }
        public bool PipelineWillStall { get; set; }
    }
}
