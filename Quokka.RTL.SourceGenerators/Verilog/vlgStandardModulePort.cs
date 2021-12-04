namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgStandardModulePort : vlgDeclarationModulePort
    {
        public vlgSignType Sign { get; set; }
        public int Width { get; set; }
        public string Name { get; set; }
    }
}
