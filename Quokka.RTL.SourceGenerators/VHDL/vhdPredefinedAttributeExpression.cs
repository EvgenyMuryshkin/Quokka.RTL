namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdPredefinedAttributeExpression : vhdExpression
    {
        public vhdExpression Source { get; set; }
        public vhdPredefinedAttribute Attribute { get; set; }
    }
}
