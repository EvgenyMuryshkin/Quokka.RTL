using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdIndexedExpression : vhdExpression
    {
        public vhdExpression Expression { get; set; }

        [RequiredList]
        public List<vhdRange> Indexes { get; set; }
    }
}
