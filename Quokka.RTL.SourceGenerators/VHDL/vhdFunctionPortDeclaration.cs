namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdFunctionPortDeclaration : vhdAbstractObject
    {
        public string Name { get; set; }
        public vhdDataType DataType { get; set; }
        public vhdSignalType SignalType { get; set; }

        public int Width { get; set; }
    }
}
