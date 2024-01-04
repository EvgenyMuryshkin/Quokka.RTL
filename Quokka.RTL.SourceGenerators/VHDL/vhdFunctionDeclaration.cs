namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdFunctionDeclaration : vhdAbstractObject
    {
        public string Name { get; set; }
        public vhdDataType DataType { get; set; }

        public int Width { get; set; }
        [NoCtorInit]
        public string CustomType { get; set; }
    }
}
