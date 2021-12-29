using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdRange : vhdAbstractObject
    {
        public List<vhdExpression> Indexes { get; set; }
    }
}
