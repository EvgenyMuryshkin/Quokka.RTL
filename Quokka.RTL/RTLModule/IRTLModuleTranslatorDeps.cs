namespace Quokka.RTL
{
    public interface IRTLModuleTranslatorDeps
    {
        string ControllerName { get; }
        T Resolve<T>();
    }
}
