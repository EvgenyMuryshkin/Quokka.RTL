using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgExpression : vlgAbstractObject
        , IDerivedVisitorInterface
    {

    }
    public class vlgAssignExpression : vlgExpression
    {
        public vlgIdentifier Target { get; set; }
        public vlgAssignType Type { get; set; }
        public vlgExpression Expression { get; set; }
    }

    public class vlgIdentifierExpression : vlgExpression
        , vlgICaseStatement
    {
        public vlgIdentifier Source { get; set; }
    }


    public class vlgBinaryValueExpression : vlgExpression
        , vlgICaseStatement
    {
        public MetadataRTLBitArray Value { get; set; }
    }

    public class vlgUnaryExpression : vlgExpression
    {
        public vlgUnaryType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }

    public class vlgLogicExpression : vlgExpression
    {
        public vlgExpression Lhs { get; set; }
        public vlgLogicType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }

    public class vlgCompareExpression : vlgExpression
    {
        public vlgExpression Lhs { get; set; }
        public vlgCompareType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }

    public class vlgMathExpression : vlgExpression
    {
        public vlgExpression Lhs { get; set; }
        public vlgMathType Type { get; set; }
        public vlgExpression Rhs { get; set; }
    }

    public class vlgTernaryExpression : vlgExpression
    {
        public vlgExpression Condition { get; set; }
        public vlgExpression Lhs { get; set; }
        public vlgExpression Rhs { get; set; }
    }
}
