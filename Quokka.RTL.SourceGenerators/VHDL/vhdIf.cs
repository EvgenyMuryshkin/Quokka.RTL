using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdIf : vhdAbstractObject
    {
        [NoCtorInit]
        public List<vhdConditionalStatement> Statements { get; set; }
    }
}
