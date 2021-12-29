namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdCompareExpression : vhdExpression
    {
        public vhdExpression Lhs { get; set; }
        public vhdCompareType Type { get; set; }
        public vhdExpression Rhs { get; set; }
    }
}
