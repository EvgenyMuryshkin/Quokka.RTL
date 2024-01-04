using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgMemoryBlockVisitorImplementation
	{
		public override void OnVisit(vlgMemoryBlock obj)
		{
			var parts = new[]
			{
			 	_formatters.NetType(obj.Name, obj.NetType),
				_formatters.DataType(obj.Name, obj.DataType),
                _formatters.IsBus(obj.DataType) ? $"[{obj.Width - 1} : 0]" : "",
				obj.Name,
				$"[0 : {obj.Depth - 1}]"
			};

			_builder.AppendLine($"{parts.StringJoin(" ")};");
		}
	}
}
