using Quokka.RTL.Tools;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFunctionVisitorImplementation
    {
        public override void OnVisit(vhdFunction obj)
        {
            var parts = new string[]
            {
                obj.Declaration.CustomType ?? _formatters.DataType(
                    obj.Declaration.Name, 
                    obj.Declaration.Width, 
                    new vhdDefaultDataType(obj.Declaration.DataType, obj.Declaration.SignalType))
                //,obj.Declaration.Width == 1 ? null : $"({obj.Declaration.Width - 1} downto {0})",
            };

            _builder.AppendLine($"function {obj.Declaration.Name}({Raw(obj.Interface)}) return {parts.StringJoin(" ")} is");
            _builder.AppendLine("begin");
            using (_builder.Indent())
            {
                Visit(obj.Implementation);
            }
            _builder.AppendLine("end function;");
        }
    }
} // Quokka.RTL.VHDL
