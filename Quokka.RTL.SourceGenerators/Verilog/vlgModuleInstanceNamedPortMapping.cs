namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgModuleInstanceNamedPortMapping : vlgModuleInstancePortMapping
    {
        public string Internal { get; set; }
        public vlgExpression External { get; set; }
    }
}
