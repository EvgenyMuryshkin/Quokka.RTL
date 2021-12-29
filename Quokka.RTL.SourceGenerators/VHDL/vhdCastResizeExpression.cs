namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdCastResizeExpression : vhdExpression
    {
        public vhdCastType Type { get; set; }
        public vhdExpression Source { get; set; }
        public vhdExpression Length { get; set; }
    }
}
