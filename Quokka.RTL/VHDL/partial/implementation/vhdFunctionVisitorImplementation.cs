using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFunctionVisitorImplementation
    {
        public override void OnVisit(vhdFunction obj)
        {
            var parts = new string[]
            {
                _formatters.DataType(obj.Declaration.Name, obj.Declaration.Width, obj.Declaration.Type),
                obj.Declaration.Width == 1 ? null : $"({obj.Declaration.Width - 1} downto {0})",
            };

            _builder.AppendLine($"function {obj.Declaration.Name}({Raw(obj.Interface)}) return {parts.StringJoin(" ")} is");
            _builder.AppendLine("begin");
            using (_builder.Indent())
            {
                Visit(obj.Implementation);
            }
            _builder.AppendLine("end function");
        }
    }

    public partial class vhdFunctionDeclarationVisitorImplementation
    {
        public override void OnVisit(vhdFunctionDeclaration obj)
        {
            // processed inside vhdFunctionVisitorImplementation
        }
    }

    public partial class vhdFunctionImplementationVisitorImplementation
    {
        public override void OnVisit(vhdFunctionImplementation obj)
        {
            Visit(obj.Block);
        }
    }
    public partial class vhdFunctionImplementationBlockVisitorImplementation
    {
        public override void OnVisit(vhdFunctionImplementationBlock obj)
        {
            obj.Children.ForEach(Visit);
        }
    }
    public partial class vhdFunctionInterfaceVisitorImplementation
    {
        public override void OnVisit(vhdFunctionInterface obj)
        {
            var parts = obj.Children.Select(Raw);
            _builder.Append(parts.StringJoin(", "));
        }
    }
    public partial class vhdFunctionPortDeclarationVisitorImplementation
    {
        public override void OnVisit(vhdFunctionPortDeclaration obj)
        {
            var parts = new string[]
            {
                obj.Name,
                _formatters.DataType(obj.Name, obj.Width, obj.Type),
                obj.Width == 1 ? null : $"({obj.Width - 1} downto {0})",
            };
            _builder.Append(parts.StringJoin(" "));
        }
    }
} // Quokka.RTL.VHDL
