using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL
{
    public class ModuleException : Exception
    {
        IRTLCombinationalModule _module;
        public ModuleException(IRTLCombinationalModule module, string exception) : base(exception)
        {
            _module = module;
        }

        public IRTLCombinationalModule Module => _module;
    }
}
