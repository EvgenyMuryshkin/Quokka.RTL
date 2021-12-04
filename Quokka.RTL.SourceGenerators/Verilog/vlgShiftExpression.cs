namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgShiftExpression : vlgExpression
    {
        public vlgExpression Lhs { get; set; }
        public vlgShiftType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }
}
