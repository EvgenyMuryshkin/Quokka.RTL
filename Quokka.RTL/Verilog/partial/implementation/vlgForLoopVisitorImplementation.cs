using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgForLoopVisitorImplementation
	{
		public override void OnVisit(vlgForLoop obj)
		{
			_builder.AppendLine($"for ({Raw(obj.Initializer)}; {Raw(obj.Condition)}; {Raw(obj.Increment)})");

			if (obj.Name.HasValue())
				_builder.AppendLine($"begin : {obj.Name}");
			else
				_builder.AppendLine("begin");

			using (_builder.Indent())
			{
				obj.Children.ForEach(Visit);
			}

			_builder.AppendLine("end");
		}
	}
}
