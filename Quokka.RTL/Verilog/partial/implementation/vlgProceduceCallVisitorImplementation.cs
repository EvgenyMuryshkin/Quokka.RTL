using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgProceduceCallVisitorImplementation
	{
		public override void OnVisit(vlgProceduceCall obj)
		{
			var args = obj.Parameters.Select(Raw);
			_builder.AppendLine($"{obj.Proc} {obj.Name}({args.StringJoin(", ")});");
		}
	}
}
