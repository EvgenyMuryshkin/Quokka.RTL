using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgFunctionPortDeclarationVisitorImplementation
    {
        public override void OnVisit(vlgFunctionPortDeclaration obj)
        {
            var parts = new string[]
            {
                _formatters.DirectionType(obj.Name, obj.Direction),
                _formatters.NetType(obj.Name, obj.NetType),
                _formatters.SignType(obj.Name, obj.Sign),
                obj.Width == 1 ? "" : Raw(new vlgRange(new vlgExpression[] { $"{obj.Width - 1}", "0" })),
                obj.Name,
            };

            _builder.AppendLine($"{parts.StringJoin(" ")};");
        }
    }
}
