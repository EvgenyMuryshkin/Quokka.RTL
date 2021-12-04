namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgTernaryExpression : vlgExpression
    {
        public vlgExpression Condition { get; set; }
        public vlgExpression Lhs { get; set; }
        public vlgExpression Rhs { get; set; }
    }
}
