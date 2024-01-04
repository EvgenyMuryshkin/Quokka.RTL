namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdStandardEntityPort : vhdEntityPort
    {
        public vhdDataType DataType { get; set; }
        public int Width { get; set; }
        public string Initializer { get; set; }
    }
}
