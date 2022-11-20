namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdAggregateBitConnection : vhdAggregateConnection
    {
        public int Bit { get; set; }
        public vhdExpression Value { get; set; }
    }
}
