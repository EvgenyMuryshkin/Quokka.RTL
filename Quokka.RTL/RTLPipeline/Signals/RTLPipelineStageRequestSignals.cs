namespace Quokka.RTL
{
    public class RTLPipelineStageRequestSignals : IRTLPipelineStageRequestSignals
    {
        public bool? StallPipeline { get; set; }
        public bool? StallSelf { get; set; }
        public bool? StallPrev { get; set; }
    }
}
