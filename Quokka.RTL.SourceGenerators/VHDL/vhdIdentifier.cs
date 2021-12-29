using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdIdentifier : vhdAbstractObject
    {
        public string Name { get; set; }
        public List<vhdRange> Indexes { get; set; }
    }
}
