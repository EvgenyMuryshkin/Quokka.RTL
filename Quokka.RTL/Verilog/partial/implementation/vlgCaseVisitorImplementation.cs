namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgCaseVisitorImplementation
	{
		public override void OnVisit(vlgCase obj)
		{
			_builder.AppendLine($"case ({Raw(obj.Check)})");
			using (_builder.Indent())
            {
				obj.Statements.ForEach(Visit);
				Visit(obj.Default);
			}
			_builder.AppendLine("endcase");
		}
	}
}
