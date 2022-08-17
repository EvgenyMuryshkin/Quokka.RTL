namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdEntityInstanceNamedGenericMapping : vhdEntityInstanceGenericMapping
    {
        public string Internal { get; set; }
        public vhdExpression External { get; set; }
    }
}
