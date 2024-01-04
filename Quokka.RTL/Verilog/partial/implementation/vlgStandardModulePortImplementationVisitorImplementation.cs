using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgStandardModulePortImplementationVisitorImplementation
    {
		public override void OnVisit(vlgStandardModulePortImplementation obj)
		{
            var parts = new string[]
            {
                _formatters.DirectionType(obj.Name, obj.Direction),
                _formatters.NetType(obj.Name, obj.NetType),
                _formatters.DataType(obj.Name, obj.DataType),
                Raw(new vlgRange(new vlgExpression[] { $"{obj.Width - 1}", "0" })),
                obj.Name,
            };

            _builder.AppendLine($"{parts.StringJoin(" ")};");
        }
    }
}
