using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    [NoImplicit]
    public class vhdIndexedExpression : vhdExpression
    {
        public vhdExpression Expression { get; set; }
        public List<vhdRange> Indexes { get; set; }
    }
}
