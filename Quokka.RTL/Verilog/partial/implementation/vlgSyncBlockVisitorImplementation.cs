using Quokka.RTL.Tools;
using System.Linq;
using System.Text;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgSyncBlockVisitorImplementation
	{
		public override void OnVisit(vlgSyncBlock obj)
		{
			_builder.AppendLine($"always @ ({obj.SensitivityList.Select(Raw).StringJoin(" or ")})");
			_builder.AppendLine("begin");
			using (_builder.Indent())
			{
				Visit(obj.Block);
			}
			_builder.AppendLine("end");
		}
	}
}
