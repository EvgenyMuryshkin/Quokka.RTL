using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFunctionInterfaceVisitorImplementation
    {
        public override void OnVisit(vhdFunctionInterface obj)
        {
            var parts = obj.Children.Select(Raw);
            _builder.Append(parts.StringJoin("; "));
        }
    }
} // Quokka.RTL.VHDL
