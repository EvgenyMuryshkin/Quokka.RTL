namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdComponentInstance : vhdAbstractObject
    {
        public string Name { get; set; }
        public string Type { get; set; }

        [NoCtorInit]
        public vhdEntityInstanceGenericMappings GenericMappings { get; set; }


        [NoCtorInit]
        public vhdEntityInstancePortMappings PortMappings { get; set; }
    }
}
