namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdConditionalStatementVisitorImplementation
	{
		public override void OnVisit(vhdConditionalStatement obj)
		{
			Visit(obj.Block);
		}
	}
} // Quokka.RTL.VHDL
