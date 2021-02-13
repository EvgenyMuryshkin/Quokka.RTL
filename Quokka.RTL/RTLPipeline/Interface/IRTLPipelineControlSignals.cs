namespace Quokka.RTL
{
    public interface IRTLPipelineControlSignals
    {
        /// <summary>
        /// Flag indicates that whole pipeline has stalled
        /// </summary>
        bool PipelineStalled { get; }
    }
}
