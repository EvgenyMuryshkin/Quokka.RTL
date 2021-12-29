using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdProcessVisitorImplementation
	{
		public override void OnVisit(vhdProcess obj)
		{
			_builder.AppendLine($"process ({obj.SensitivityList.Select(Raw).StringJoin(", ")})");
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
