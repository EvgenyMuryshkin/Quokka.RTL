namespace Quokka.RTL
{
    public interface IRTLControlFlow
    {
        bool Stage(int iteration);
        void Commit();
        void Reset();
    }
}
