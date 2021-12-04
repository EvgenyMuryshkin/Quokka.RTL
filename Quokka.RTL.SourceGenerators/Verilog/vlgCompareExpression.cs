namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgCompareExpression : vlgExpression
    {
        public vlgExpression Lhs { get; set; }
        public vlgCompareType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }
}
