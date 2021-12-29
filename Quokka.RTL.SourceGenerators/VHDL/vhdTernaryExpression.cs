namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdTernaryExpression : vhdExpression
    {
        public vhdExpression Condition { get; set; }
        public vhdExpression Lhs { get; set; }
        public vhdExpression Rhs { get; set; }
    }
}
