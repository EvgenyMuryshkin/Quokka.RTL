namespace Quokka.RTL
{
    public interface IRTLPipelineStageControlSignals
    {
        /// <summary>
        /// Flag indicates that current stage has stalled
        /// </summary>
        bool StageStalled { get; }
    }
}
