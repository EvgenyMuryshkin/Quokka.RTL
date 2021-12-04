namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgConditionalStatementVisitorImplementation
    {
        public override void OnVisit(vlgConditionalStatement obj)
        {
            Visit(obj.Block);
        }
    }
}
