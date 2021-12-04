namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgDeclarationModulePort : vlgModulePort
    {
        public vlgPortDirection Direction { get; set; }
        public vlgNetType NetType { get; set; }
    }
}
