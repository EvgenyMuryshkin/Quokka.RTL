namespace Quokka.RTL
{
    public enum RTLModuleStageResult
    {
        Stable,
        Unstable
    }

    public interface IRTLModuleControlFlow
    {
        RTLModuleStageResult DeltaCycle(int deltaCycle);
        void Commit();
        void Reset();
    }
}
