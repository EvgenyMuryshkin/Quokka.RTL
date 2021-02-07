namespace Quokka.RTL
{
    public interface IRTLPipelinePeek<TState>
    {
        TState State { get; }
        TState NextState { get; }
    }
}
