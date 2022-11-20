using Quokka.RTL.Tools;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFunctionCustomPortDeclarationVisitorImplementation
    {
        public override void OnVisit(vhdFunctionCustomPortDeclaration obj)
        {
            var parts = new string[]
            {
                obj.Name,
                ":",
                obj.Type
            };
            _builder.Append(parts.StringJoin(" "));
        }
    }
} // Quokka.RTL.VHDL
