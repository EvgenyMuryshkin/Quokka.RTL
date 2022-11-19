namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdFunctionPortDeclaration : vhdAbstractObject
    {
        public string Name { get; set; }
        public vhdDataType Type { get; set; }
        public int Width { get; set; }

    }
}
