using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgCase : vlgAbstractObject
    {
        public vlgExpression Check { get; set; }
        public List<vlgCaseStatement> Statements { get; set; }
        [NoCtorInit]
        public vlgCaseDefault Default { get; set; }
    }
}
