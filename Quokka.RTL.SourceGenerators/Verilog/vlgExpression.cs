using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgExpression : vlgAbstractObject
    {
        [NoCtorInit]
        public vlgDataType? ExpressionDataType { get; set; }
        [NoCtorInit]
        public int? ExpressionSize { get; set; }
    }
}
