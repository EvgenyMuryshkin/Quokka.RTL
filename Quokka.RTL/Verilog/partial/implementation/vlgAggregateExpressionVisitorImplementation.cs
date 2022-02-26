using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgAggregateExpressionVisitorImplementation
	{
		public override void OnVisit(vlgAggregateExpression obj)
		{
			_builder.Append($"{{ {obj.Expressions.Select(Raw).ToCSV()} }}");
		}
	}
}
