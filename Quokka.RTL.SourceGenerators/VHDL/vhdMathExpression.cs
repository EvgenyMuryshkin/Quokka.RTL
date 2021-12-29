namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdMathExpression : vhdExpression
    {
        public vhdExpression Lhs { get; set; }
        public vhdMathType Type { get; set; }
        public vhdExpression Rhs { get; set; }
    }
}
