namespace Quokka.RTL
{
    [RTLToolkitType]
    public class RTLPipelineStageControl : IRTLPipelineStageContol
    {
        public bool? StallPipeline { get; set; }
        public bool? StallSelf { get; set; }
        public bool? StallPrev { get; set; }

        public bool StageStalled { get; set; }

        public bool PipelineStalled { get; set; }

        public bool StageWillStall { get; set; }
    }
}
