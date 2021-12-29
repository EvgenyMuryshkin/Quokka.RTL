using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdCase : vhdAbstractObject
    {
        public vhdExpression Expression { get; set; }

        [NoCtorInit]
        public List<vhdCaseStatement> Statements { get; set; }
    }
}
