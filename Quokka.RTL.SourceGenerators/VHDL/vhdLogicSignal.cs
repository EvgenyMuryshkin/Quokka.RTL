using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdLogicSignal : vhdNet
    {
        public List<MetadataRTLBitArray> Initializer { get; set; }
    }
}
