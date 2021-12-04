using System;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgConditionalStatement : vlgAbstractObject
    {
        public vlgExpression Condition { get; set; }

        [NoCtorInit]
        public vlgGenericBlock Block { get; set; }
    }
}
