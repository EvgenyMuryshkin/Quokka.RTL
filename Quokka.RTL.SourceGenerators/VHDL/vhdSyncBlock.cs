namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdSyncBlock : vhdAbstractObject
    {
        public vhdEdgeType Type { get; set; }
        public vhdExpression Source { get; set; }

        [NoCtorInit]
        public vhdGenericBlock Block { get; set; }
    }
}
