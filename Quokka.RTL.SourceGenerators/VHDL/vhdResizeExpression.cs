namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdResizeExpression : vhdExpression
    {
        public vhdExpression Source { get; set; }
        public vhdExpression Length { get; set; }
    }
}
