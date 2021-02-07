namespace Quokka.RTL
{
    [RTLToolkitType]
    public class RTLPipelineStageControlSignals : IRTLPipelineStageControlSignals
    {
        public bool? StallPipeline { get; set; }
        public bool? StallSelf { get; set; }
        public bool? StallPrev { get; set; }
        public bool PrevStageWillStall { get; set; }
        public bool StageWillStall { get; set; }
        public bool StageStalled { get; set; }
    }
}
