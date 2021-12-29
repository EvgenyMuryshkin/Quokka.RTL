namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdAggregateBitConnection : vhdAbstractObject
    {
        public int Bit { get; set; }
        public vhdExpression Value { get; set; }
    }
}
