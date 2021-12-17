using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdDefaultSignal : vhdNet
    {
        public vhdDataTypeSource DataType { get; set; }
        public int Width { get; set; }
        public List<string> Initializer { get; set; }
    }
}
