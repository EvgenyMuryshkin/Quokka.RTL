namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgAssignExpression : vlgExpression
    {
        public vlgIdentifier Target { get; set; }
        public vlgAssignType Type { get; set; }
        public vlgExpression Expression { get; set; }

        [NoCtorInit]
        public bool Debugger { get; set; }
    }
}
