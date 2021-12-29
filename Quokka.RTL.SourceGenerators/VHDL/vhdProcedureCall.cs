using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdProcedureCall : vhdAbstractObject
    {
        public string Proc { get; set; }
        public List<vhdExpression> Parameters { get; set; }
    }
}
