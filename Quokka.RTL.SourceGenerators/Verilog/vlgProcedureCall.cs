using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgProcedureCall : vlgAbstractObject
    {
        public string Proc { get; set; }
        public string Name { get; set; }
        public List<vlgExpression> Parameters { get; set; }
    }
}
