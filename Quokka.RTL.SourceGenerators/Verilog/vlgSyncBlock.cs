using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgSyncBlock : vlgAbstractObject
    {
        public List<vlgSyncBlockSensitivityItem> SensitivityList { get; set; }

        [NoCtorInit]
        public vlgGenericBlock Block { get; set; }
    }
}
