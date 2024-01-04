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
                _formatters.DataType(obj.Name, obj.DataType),
                _formatters.IsBus(obj.DataType) ? $"[{obj.Width - 1}:0]" : "",
                obj.Name,
            };

            _builder.AppendLine($"{parts.StringJoin(" ")};");
        }
    }
}
