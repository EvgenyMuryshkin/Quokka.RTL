using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgCaseItem : vlgBlock
    {

    }

    public class vlgCaseStatement : vlgCaseItem
    {
        public List<vlgICaseStatement> Conditions { get; set; }
    }

    public class vlgCaseDefault : vlgCaseItem
    {

    }

    public class vlgCase : vlgAbstractObject
        , vlgIBlockChild
    {
        public vlgExpression Check { get; set; }
        public List<vlgCaseStatement> Statements { get; set; }
        [NoCtorInit]
        public vlgCaseDefault Default { get; set; }
    }
}
