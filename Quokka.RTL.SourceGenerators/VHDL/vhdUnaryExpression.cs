namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdUnaryExpression : vhdExpression
    {
        public vhdUnaryType Type { get; set; }
        public vhdExpression Rhs { get; set; }
    }
}
