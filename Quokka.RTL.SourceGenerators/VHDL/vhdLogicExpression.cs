namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdLogicExpression : vhdExpression
    {
        public vhdExpression Lhs { get; set; }
        public vhdLogicType Type { get; set; }
        public vhdExpression Rhs { get; set; }
    }
}
