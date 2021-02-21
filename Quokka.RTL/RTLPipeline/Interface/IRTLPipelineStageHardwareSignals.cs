namespace Quokka.RTL
{
    public interface IRTLPipelineStageHardwareSignals
    {
        bool PipelineStallRequested { get; }
        bool StageStallRequested { get; }
        bool StageWillStall { get; }
        bool PrevStageStallRequested { get; }
    }
}
