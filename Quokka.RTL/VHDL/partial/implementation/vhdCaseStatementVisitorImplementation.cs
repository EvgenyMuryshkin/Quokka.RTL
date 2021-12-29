namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdCaseStatementVisitorImplementation
	{
		public override void OnVisit(vhdCaseStatement obj)
		{
			_builder.AppendLine($"when {Raw(obj.When)} =>");
			using (_builder.Indent())
			{
				Visit(obj.Block);
			}
		}
	}
} // Quokka.RTL.VHDL
