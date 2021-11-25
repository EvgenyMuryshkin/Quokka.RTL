using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgCombBlockVisitorImplementation
	{
		public override void OnVisit(vlgCombBlock obj)
		{
			_builder.AppendLine($"always @ ({(obj.SensitivityList.Any() ? obj.SensitivityList.Select(Raw).StringJoin(" or ") : "*")})");
			_builder.AppendLine("begin");
			using (_builder.Indent())
            {
				obj.Children.ForEach(Visit);
            }
			_builder.AppendLine("end");
		}
	}
}
