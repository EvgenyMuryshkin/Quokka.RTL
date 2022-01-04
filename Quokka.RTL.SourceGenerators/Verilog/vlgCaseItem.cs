namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgCaseItem : vlgAbstractObject
    {
        [NoCtorInit]
        public vlgGenericBlock Block { get; set; }
    }
}
