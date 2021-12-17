using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdComment : vhdAbstractObject
    {
        public List<string> Lines { get; set; }
    }
}
