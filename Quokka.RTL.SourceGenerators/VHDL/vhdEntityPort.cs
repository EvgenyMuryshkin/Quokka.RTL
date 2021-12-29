namespace Quokka.RTL.SourceGenerators.VHDL
{
    public abstract class vhdEntityPort : vhdAbstractObject
    {
        public string Name { get; set; }
        public vhdPortDirection Direction { get; set; }
    }
}
