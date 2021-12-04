using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgCaseStatement : vlgCaseItem
    {
        public List<vlgICaseStatement> Conditions { get; set; }
    }
}
