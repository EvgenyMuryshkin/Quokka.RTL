using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgRange : vlgAbstractObject
    {
        public List<vlgExpression> Indexes { get; set; }
    }
}
