namespace Quokka.RTL
{
    [RTLToolkitType]
    public class RTLPipelineStageRequestSignals : IRTLPipelineStageRequestSignals
    {
        public bool? StallPipeline { get; set; }
        public bool? StallSelf { get; set; }
        public bool? StallPrev { get; set; }
    }
}
