namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgMemoryBlock : vlgSignal
    {
        public vlgNetType NetType { get; set; }
        public string Name { get; set; }
        public vlgDataType DataType { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
    }
}
