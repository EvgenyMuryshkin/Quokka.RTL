namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgMemoryBlock : vlgSignal
    {
        public string Name { get; set; }
        public vlgSignType Sign { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
    }
}
