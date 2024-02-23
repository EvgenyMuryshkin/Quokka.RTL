using Quokka.RTL.Tools;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdSubTypeDeclarationVisitorImplementation
    {
        public override void OnVisit(vhdSubTypeDeclaration obj)
        {
            var parts = new[]
            {
                "subtype",
                obj.Name,
                "is",
                _formatters.DataType(obj.Name, obj.Width, obj.DataType),
                _formatters.Range(obj.Width, _formatters.IsBus(obj.DataType)),
                //obj.Width <= 1 ? null : $"({obj.Width - 1} downto 0)"
            };

            _builder.AppendLine($"{parts.StringJoin(" ")};");
        }
    }
} // Quokka.RTL.VHDL
