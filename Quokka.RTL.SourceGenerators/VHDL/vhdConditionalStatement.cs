namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdConditionalStatement : vhdAbstractObject
    {
        public vhdExpression Condition { get; set; }

        [NoCtorInit]
        public vhdGenericBlock Block { get; set; }
    }
}
