namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgCaseDefaultVisitorImplementation
	{
		public override void OnVisit(vlgCaseDefault obj)
		{
			_builder.AppendLine("default:");
			_builder.AppendLine("begin");
			using (_builder.Indent())
            {
				obj.Children.ForEach(Visit);
			}
			_builder.AppendLine("end");
		}
	}
}
