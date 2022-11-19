namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdFunctionDeclaration : vhdAbstractObject
    {
        public string Name { get; set; }
        public vhdDataType Type { get; set; }
        public int Width { get; set; }
    }
}
