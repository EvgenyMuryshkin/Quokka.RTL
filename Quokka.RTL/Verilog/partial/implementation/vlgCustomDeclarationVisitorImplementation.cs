using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgCustomDeclarationVisitorImplementation
	{
		public override void OnVisit(vlgCustomDeclaration obj)
		{
            var parts = new string[]
            {
                obj.Type,
                obj.Name,
                obj.Initializer == null ? null : $"= {obj.Initializer}"
            };
            _builder.AppendLine($"{parts.StringJoin(" ")};");
        }
    }
}
