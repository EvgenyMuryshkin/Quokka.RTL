namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgSimpleForLoop : vlgAbstractForLoop
    {
        public string Iterator { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}
