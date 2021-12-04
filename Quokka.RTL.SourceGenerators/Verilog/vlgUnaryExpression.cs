namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgUnaryExpression : vlgExpression
    {
        public vlgUnaryType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }
}
