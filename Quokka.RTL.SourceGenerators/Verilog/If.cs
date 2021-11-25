using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgConditionalStatement : vlgBlock
    {
        public vlgExpression Condition { get; set; }
    }

    public class vlgIf : vlgAbstractObject
        , IVisitorInterface
        , vlgIBlockChild
        , vlgIModuleImplementationChild
    {
        [NoCtorInit]
        public List<vlgConditionalStatement> Statements { get; set; }
    }
}
