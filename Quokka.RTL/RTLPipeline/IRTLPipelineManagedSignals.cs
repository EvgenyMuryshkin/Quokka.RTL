namespace Quokka.RTL
{
    public interface IRTLPipelineManagedSignals
    {
        /// <summary>
        /// Flag indicates that pipeline will stall during current clock cycle
        /// </summary>
        bool PipelineWillStall { get; }

        /// <summary>
        /// Flag indicates that whole pipeline has stalled
        /// </summary>
        bool PipelineStalled { get; }
    }
}
