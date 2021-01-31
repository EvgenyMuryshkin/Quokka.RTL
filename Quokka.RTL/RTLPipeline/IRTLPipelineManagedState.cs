namespace Quokka.RTL
{
    /// <summary>
    /// Pipeline state class must implement this interface in order to enable automatic stall management
    /// </summary>
    public interface IRTLPipelineManagedState
    {
        /// <summary>
        /// Flag indicates that stage has stalled. 
        /// Can be set in any stage
        /// All previous stages will freeze. 
        /// All subsequent stages will continue to push data throught
        /// </summary>
        bool? Stall { set; }

        /// <summary>
        /// Flag indicates that subsequent stage has stalled
        /// </summary>
        bool? Stalled { get; }
    }
}
