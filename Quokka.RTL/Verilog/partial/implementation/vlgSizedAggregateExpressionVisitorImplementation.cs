using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgSizedAggregateExpressionVisitorImplementation
	{
		public override void OnVisit(vlgSizedAggregateExpression obj)
		{
			_builder.Append($"{{{obj.Size}{{{obj.Expressions.Select(Raw).ToCSV()}}}}}");
		}
	}
}
