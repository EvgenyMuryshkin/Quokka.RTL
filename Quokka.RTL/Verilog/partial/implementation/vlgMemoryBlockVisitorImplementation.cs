using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgMemoryBlockVisitorImplementation
	{
		public override void OnVisit(vlgMemoryBlock obj)
		{
			var parts = new[]
			{
				"reg",
				_formatters.SignType(obj.Name, obj.Sign),
				obj.Width == 1 ? "" : $"[{obj.Width - 1} : 0]",
				obj.Name,
				$"[0 : {obj.Depth - 1}]"
			};

			_builder.AppendLine($"{parts.StringJoin(" ")};");
		}
	}
}
