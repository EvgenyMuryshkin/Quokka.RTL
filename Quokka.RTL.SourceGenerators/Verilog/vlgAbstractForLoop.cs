namespace Quokka.RTL.SourceGenerators.Verilog
{
    [FluentType(typeof(vlgAssign))]
    [FluentType(typeof(vlgGenericBlock))]
    public abstract class vlgAbstractForLoop : vlgAbstractCollection
    {
        [NoCtorInit]
        public string Name { get; set; }
    }
}
