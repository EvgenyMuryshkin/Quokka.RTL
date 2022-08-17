using Quokka.RTL.Verilog;
using Quokka.RTL.VHDL;
using System.Collections.Generic;

namespace Quokka.RTL
{
    public class ModuleTranslatorResult
    {
        public Dictionary<string, object> Result { get; set; } = new Dictionary<string, object>();

        public void Add(string name, vlgModuleImplementation implememntation)
        {
            Result[name] = implememntation;
        }

        public void Add(string name, vhdArchitectureImplementation implememntation)
        {
            Result[name] = implememntation;
        }
    }
}
