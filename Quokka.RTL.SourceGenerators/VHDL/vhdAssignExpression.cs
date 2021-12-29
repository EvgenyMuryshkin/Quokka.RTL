namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdAssignExpression : vhdExpression
    {
        public vhdExpression Target { get; set; }
        public vhdAssignType Type { get; set; }
        public vhdExpression Source { get; set; }
    }
}
