namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdCastExpression : vhdExpression
    {
        public vhdCastType Type { get; set; }
        public vhdExpression Source { get; set; }
    }
}
