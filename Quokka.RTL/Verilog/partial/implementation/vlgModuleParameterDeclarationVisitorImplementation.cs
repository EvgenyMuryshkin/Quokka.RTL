using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleParameterDeclarationVisitorImplementation
	{
		public override void OnVisit(vlgModuleParameterDeclaration obj)
		{
            var parts = new[]
            {
                "parameter",
                $"[{obj.Width - 1}: 0]",
                obj.Name,
                obj.DefaultValue == null ? null : $" = {_formatters.RTLBitArray(obj.DefaultValue)}"
            };

            _builder.Append($"{parts.StringJoin(" ")}");
        }
    }
}
