using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgLogicSignalVisitorImplementation
	{
		public override void OnVisit(vlgLogicSignal obj)
		{
			var parts = new string[]
			{
				_formatters.NetType(obj.Name, obj.NetType),
				_formatters.SignType(obj.Name, obj.Sign),
				obj.Width == 1 ? "" : $"[{obj.Width - 1}: 0]",
				obj.Name,
				obj.Initializer == null ? null : $"= {obj.Initializer}"
			};

			_builder.AppendLine($"{parts.StringJoin(" ")};");
		}
	}
}
