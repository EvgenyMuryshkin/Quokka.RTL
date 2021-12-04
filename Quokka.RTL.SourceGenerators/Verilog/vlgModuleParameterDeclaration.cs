namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgModuleParameterDeclaration : vlgAbstractObject
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public MetadataRTLBitArray DefaultValue { get; set; }
    }
}
