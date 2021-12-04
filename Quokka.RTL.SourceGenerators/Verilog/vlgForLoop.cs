namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgForLoop : vlgAbstractForLoop
    {
        public vlgExpression Initializer { get; set; }
        public vlgExpression Condition { get; set; }
        public vlgExpression Increment { get; set; }
    }
}
