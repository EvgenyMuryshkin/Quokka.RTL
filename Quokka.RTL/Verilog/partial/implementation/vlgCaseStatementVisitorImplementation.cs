namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgCaseStatementVisitorImplementation
	{
		public override void OnVisit(vlgCaseStatement obj)
		{
			obj.Conditions.ForEach(c => _builder.AppendLine($"{Raw(c)}:"));
			_builder.AppendLine("begin");
			using (_builder.Indent())
			{
				obj.Children.ForEach(Visit);
			}
			_builder.AppendLine("end");
		}
	}
}
