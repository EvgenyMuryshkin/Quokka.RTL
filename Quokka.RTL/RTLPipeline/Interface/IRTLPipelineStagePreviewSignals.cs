namespace Quokka.RTL
{
    public interface IRTLPipelineStagePreviewSignals
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
        /// Flag indicates that pipeline will stall during current clock cycle
        /// </summary>
        bool PipelineWillStall { get; }
    }
}
