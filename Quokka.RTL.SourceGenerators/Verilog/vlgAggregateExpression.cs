using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgAggregateExpression : vlgExpression
    {
        public List<vlgExpression> Expressions { get; set; }
    }

    public class vlgSizedAggregateExpression : vlgExpression
    {
        public int Size { get; set; }
        public List<vlgExpression> Expressions { get; set; }
    }
}
