using System.Collections.Generic;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgUnaryExpressionVisitorImplementation
	{
		public override void OnVisit(vlgUnaryExpression obj)
		{
			var lookup = new Dictionary<vlgUnaryType, string>()
			{
				{ vlgUnaryType.Not, "~"}
			};

			_builder.Append($"({lookup[obj.Type]}{Brackets(obj.Rhs)})");
		}
	}
}
