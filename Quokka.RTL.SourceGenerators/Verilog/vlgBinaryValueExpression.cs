namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgBinaryValueExpression : vlgExpression
        , vlgICaseStatement
    {
        public MetadataRTLBitArray Value { get; set; }
    }
}
