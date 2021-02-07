namespace Quokka.RTL
{
    public interface IRTLPipelinePeek<TState> : IRTLPipelineStageManagedSignals
    {
        TState State { get; }
        TState NextState { get; }
    }
}
