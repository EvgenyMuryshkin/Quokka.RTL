namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdEntity : vhdAbstractObject
    {
        public string Name { get; set; }

        [NoCtorInit]
        public vhdEntityInterface Interface { get; set; }
    }
}
