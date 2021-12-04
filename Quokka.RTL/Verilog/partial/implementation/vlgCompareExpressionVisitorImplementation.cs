using System.Collections.Generic;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgCompareExpressionVisitorImplementation
	{
		public override void OnVisit(vlgCompareExpression obj)
		{
			var lookup = new Dictionary<vlgCompareType, string>()
			{
				{ vlgCompareType.Equal, "=="},
				{ vlgCompareType.NotEqual, "!="},
				{ vlgCompareType.Greater, ">"},
				{ vlgCompareType.GreaterOrEqual, ">="},
				{ vlgCompareType.Less, "<"},
				{ vlgCompareType.LessOrEqual, "<="},
			};

			_builder.Append($"({Brackets(obj.Lhs)} {lookup[obj.Type]} {Brackets(obj.Rhs)})");
		}
	}
}
