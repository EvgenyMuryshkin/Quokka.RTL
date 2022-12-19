using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdComponentInstanceVisitorImplementation
    {
        public override void OnVisit(vhdComponentInstance obj)
        {
            _builder.AppendLine($"{obj.Name} : {obj.Type}");
            if (obj.GenericMappings.Children.Any())
            {
                Visit(obj.GenericMappings);
            }

            Visit(obj.PortMappings);
            _builder.AppendLine(";");
        }
    }
} // Quokka.RTL.VHDL
