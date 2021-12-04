using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgIdentifier : vlgAbstractObject
    {
        public string Name { get; set; }
        public List<vlgRange> Indexes { get; set; }
    }
}
