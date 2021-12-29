namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdArrayTypeDeclaration : vhdTypeDeclaration
    {
        public int Depth { get; set; }
        public vhdDataType Type { get; set; }
        public int Width { get; set; }
    }
}
