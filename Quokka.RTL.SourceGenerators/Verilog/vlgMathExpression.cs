namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgMathExpression : vlgExpression
    {
        public vlgExpression Lhs { get; set; }
        public vlgMathType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }
}
