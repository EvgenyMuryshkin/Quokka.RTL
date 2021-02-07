namespace Quokka.RTL
{
    public interface IRTLPipelineStageControlSignals : IRTLPipelineStageManagedSignals
    {
        /// <summary>
        /// Flag indicates that whole pipeline needs to stall 
        /// </summary>
        bool? StallPipeline { set; }

        /// <summary>
        /// Flag indicates that current stage needs to stall
        /// All previous stages will also stall 
        /// All subsequent stages will continue to push data through
        /// </summary>
        bool? StallSelf { set; }

        /// <summary>
        /// Flag indicates that previous stages need to stall
        /// Current stage will continue to work
        /// All subsequent stages will continue to push data through
        /// </summary>
        bool? StallPrev { set; }
    }
}
