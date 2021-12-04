using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgCustomModulePortDeclarationVisitorImplementation
	{
		public override void OnVisit(vlgCustomModulePortDeclaration obj)
		{
            var parts = new string[]
            {
                _formatters.DirectionType(obj.Name, obj.Direction),
                _formatters.NetType(obj.Name, obj.NetType),
                obj.DataType,
                obj.Name,
            };

            _builder.Append(parts.StringJoin(" "));
        }
    }
}
