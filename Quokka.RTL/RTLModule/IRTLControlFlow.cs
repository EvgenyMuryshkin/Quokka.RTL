namespace Quokka.RTL
{
    public enum RTLModuleStageResult
    {
        Stable,
        Unstable
    }

    public interface IRTLControlFlow
    {
        RTLModuleStageResult Stage(int iteration);
        void Commit();
        void Reset();
    }
}
