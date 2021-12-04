namespace Quokka.RTL.SourceGenerators.Verilog
{
    [FluentType(typeof(vlgComment))]
    [FluentType(typeof(vlgText))]
    [FluentType(typeof(vlgSimpleForLoop))]
    [FluentType(typeof(vlgAssign))]
    public class vlgInitial : vlgAbstractCollection
    {
        public string Name { get; set; }
    }
}
