namespace Quokka.RTL
{
    public interface IRTLModuleTranslator
    {
        ModuleTranslatorResult ToRTL(IRTLModuleTranslatorDeps deps);
    }
}
