using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdProcedureCallExpression : vhdExpression
    {
        public string Proc { get; set; }

        [RequiredList]
        public List<vhdExpression> Parameters { get; set; }
    }
}
