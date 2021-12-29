namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdEntityInstanceNamedPortMapping : vhdEntityInstancePortMapping
    {
        public string Internal { get; set; }
        public vhdExpression External { get; set; }
    }
}
