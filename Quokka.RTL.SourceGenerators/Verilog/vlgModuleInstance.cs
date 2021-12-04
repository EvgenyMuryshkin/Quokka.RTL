namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgModuleInstance : vlgAbstractObject
    {
        public string Type { get; set; }
        public string Name { get; set; }

        [NoCtorInit]
        public vlgModuleInstanceParameters Parameters { get; set; }
        [NoCtorInit]
        public vlgModuleInstancePortMappings PortMappings { get; set; }
    }
}
