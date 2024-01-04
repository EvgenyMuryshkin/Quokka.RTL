using Quokka.RTL.Tools;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFunctionPortDeclarationVisitorImplementation
    {
        public override void OnVisit(vhdFunctionPortDeclaration obj)
        {
            var parts = new string[]
            {
                obj.Name,
                ":",
                _formatters.DataType(obj.Name, obj.Width, obj.DataType)
                //,obj.Width == 1 ? null : $"({obj.Width - 1} downto {0})",
            };
            _builder.Append(parts.StringJoin(" "));
        }
    }
} // Quokka.RTL.VHDL
