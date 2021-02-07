namespace Quokka.RTL
{
    public interface IRTLPipelineStageManagedSignals
    {
        /// <summary>
        /// Flag indicates that previous stage was requested to stall
        /// </summary>
        bool PrevStageWillStall { get; }

        /// <summary>
        /// Flag indicates that stage will stall during current clock cycle
        /// </summary>
        bool StageWillStall { get; }

        /// <summary>
        /// Flag indicates that current stage has stalled
        /// </summary>
        bool StageStalled { get; }
    }
}
