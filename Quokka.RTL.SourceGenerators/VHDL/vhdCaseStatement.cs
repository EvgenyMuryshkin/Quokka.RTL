namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdCaseStatement : vhdAbstractObject
    {
        public vhdExpression When { get; set; }

        [NoCtorInit]
        public vhdGenericBlock Block { get; set; }
    }
}
