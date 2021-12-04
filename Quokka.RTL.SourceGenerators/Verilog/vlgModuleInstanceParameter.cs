using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgModuleInstanceParameter : vlgAbstractObject
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
