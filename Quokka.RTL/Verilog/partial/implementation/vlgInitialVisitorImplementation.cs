namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgInitialVisitorImplementation
	{
		public override void OnVisit(vlgInitial obj)
		{
			_builder.AppendLine("initial");
			if (string.IsNullOrWhiteSpace(obj.Name))
			{
				_builder.AppendLine("begin");
			}
			else
			{
				_builder.AppendLine($"begin : {obj.Name}");
			}

			using (_builder.Indent())
			{
				obj.Children.ForEach(Visit);
			}

			_builder.AppendLine("end");
		}
	}
}
