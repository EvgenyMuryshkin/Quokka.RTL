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
                _formatters.SignType(obj.Name, obj.Sign),
                Raw(new vlgRange(new vlgIdentifierExpression($"{obj.Width - 1}"), new vlgIdentifierExpression("0"))),
                obj.Name,
            };

            _builder.AppendLine($"{parts.StringJoin(" ")};");
        }
    }
}
