namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgGenerateVisitorImplementation
	{
		public override void OnVisit(vlgGenerate obj)
		{
			_builder.AppendLine($"generate");
			using (_builder.Indent())
            {
				Visit(obj.Block);
			}
			_builder.AppendLine($"endgenerate");
		}
	}
}
