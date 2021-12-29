namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdShiftExpression : vhdExpression
    {
        public vhdExpression Lhs { get; set; }
        public vhdShiftType Type { get; set; }
        public vhdExpression Rhs { get; set; }
    }
}
