namespace Quokka.RTL.SourceGenerators.Verilog
{
    [FluentType(typeof(vlgComment))]
    [FluentType(typeof(vlgText))]
    [FluentType(typeof(vlgAbstractForLoop))]
    [FluentType(typeof(vlgAssign))]
    [FluentType(typeof(vlgGenericBlock))]
    [FluentType(typeof(vlgProcedureCall))]
    [FluentType(typeof(vlgGenvar))]
    [FluentType(typeof(vlgGenerate))]
    [FluentType(typeof(vlgModuleInstance))]
    [FluentType(typeof(vlgCase))]
    [FluentType(typeof(vlgIf))]
    public abstract class vlgBlock : vlgAbstractCollection
    {
    }
}
