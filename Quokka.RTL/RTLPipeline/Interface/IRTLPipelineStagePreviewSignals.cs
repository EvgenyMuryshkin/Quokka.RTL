namespace Quokka.RTL
{
    public interface IRTLPipelineStagePreviewSignals
    {
        /// <summary>
        /// Flag indicates that stage will stall during current clock cycle
        /// </summary>
        bool StageWillStall { get; }
    }
}
