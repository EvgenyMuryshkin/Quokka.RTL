namespace Quokka.RTL
{
    public interface IRTLPipelineControlFlow
    {
        void StageSetup(IRTLCombinationalModule module);
        void StageCommit();
        void StageReset();
        bool StageStage(int iteration);
    }
}
