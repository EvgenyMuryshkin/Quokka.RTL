namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdAlias : vhdAbstractObject
    {
        public string Alias { get; set; }
        public vhdExpression Expression { get; set; }
    }
}
