namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdEntityInstanceNamedPortMapping : vhdEntityInstancePortMapping
    {
        public vhdIdentifier Internal { get; set; }
        public vhdExpression External { get; set; }
    }
}
