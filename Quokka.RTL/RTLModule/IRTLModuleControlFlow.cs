namespace Quokka.RTL
{
    public enum RTLModuleStageResult
    {
        Stable,
        Unstable
    }

    public class RTLModuleResetOptions
    {
        public MemoryBlockResetTypeAttribute MemoryBlockResetType { get; set; }
    }

    public interface IRTLModuleControlFlow
    {
        RTLModuleStageResult DeltaCycle(int deltaCycle);
        void Commit();
        void Reset(RTLModuleResetOptions resetOptions = null);
    }
}
