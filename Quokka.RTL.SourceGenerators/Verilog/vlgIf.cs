using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgIf : vlgAbstractObject
    {
        [NoCtorInit]
        public List<vlgConditionalStatement> Statements { get; set; }
    }
}
