namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgLogicExpression : vlgExpression
    {
        public vlgExpression Lhs { get; set; }
        public vlgLogicType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }
}
