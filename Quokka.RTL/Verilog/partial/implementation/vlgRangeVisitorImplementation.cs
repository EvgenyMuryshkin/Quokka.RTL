using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgRangeVisitorImplementation
	{
		public override void OnVisit(vlgRange obj)
		{
			if (!obj.Indexes.Any())
				return;

			var indexes = obj.Indexes.Select(Raw).Distinct();
			_builder.Append($"[{string.Join(":", indexes)}]");
		}
	}
}
