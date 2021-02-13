namespace Quokka.RTL
{
    public interface IRTLPipelinePreviewSignals
    {
        /// <summary>
        /// Flag indicates that pipeline will stall during current clock cycle
        /// </summary>
        bool PipelineWillStall { get; }
    }
}
