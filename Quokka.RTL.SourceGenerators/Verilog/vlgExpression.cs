using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgExpression : vlgAbstractObject
    {
        [NoCtorInit]
        public vlgSignType? ExpressionSignType { get; set; }
        [NoCtorInit]
        public int? ExpressionSize { get; set; }
    }
}
