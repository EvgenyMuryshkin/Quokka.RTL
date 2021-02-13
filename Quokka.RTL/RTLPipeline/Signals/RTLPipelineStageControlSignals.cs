namespace Quokka.RTL
{
    [RTLToolkitType]
    public class RTLPipelineStageControlSignals : IRTLPipelineStageControlSignals
    {
        public bool StageStalled { get; set; }
    }
}
