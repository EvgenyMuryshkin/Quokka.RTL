using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgCombBlock : vlgAbstractObject
    {
        public List<vlgIdentifier> SensitivityList { get; set; }
        [NoCtorInit]
        public vlgGenericBlock Block { get; set; }
    }
}
