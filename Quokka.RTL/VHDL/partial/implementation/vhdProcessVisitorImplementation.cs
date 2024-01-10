using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdProcessVisitorImplementation
	{
		public override void OnVisit(vhdProcess obj)
		{
			var sensitivity = obj.SensitivityList.Select(Raw).Distinct().StringJoin(", ");
			if (string.IsNullOrWhiteSpace(sensitivity))
				sensitivity = "all";

            _builder.AppendLine($"process ({sensitivity})");
			using (_builder.Indent())
            {
				Visit(obj.Declarations);
			}
			_builder.AppendLine($"begin");
			using (_builder.Indent())
            {
				Visit(obj.Block);
            }
			_builder.AppendLine($"end process;");
		}
	}
} // Quokka.RTL.VHDL
