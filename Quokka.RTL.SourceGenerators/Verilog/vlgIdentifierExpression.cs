namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgIdentifierExpression : vlgExpression
        , vlgICaseStatement
    {
        public vlgIdentifier Source { get; set; }
    }
}
