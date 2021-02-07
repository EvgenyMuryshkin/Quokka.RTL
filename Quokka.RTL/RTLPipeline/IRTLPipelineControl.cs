namespace Quokka.RTL
{
    public interface IRTLPipelineControl
    {
        void StageSetup(IRTLCombinationalModule module);
        void StageCommit();
        void StageReset();
        RTLModuleStageResult StageStage(int iteration);
    }
}
