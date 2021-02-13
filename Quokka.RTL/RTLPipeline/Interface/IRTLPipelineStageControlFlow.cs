namespace Quokka.RTL
{
    public interface IRTLPipelineStageControlFlow
    {
        void StageSetup(IRTLCombinationalModule module);
        void StageCommit();
        void StageReset();
        RTLModuleStageResult StageDeltaCycle(int deltaCycle);
    }
}
