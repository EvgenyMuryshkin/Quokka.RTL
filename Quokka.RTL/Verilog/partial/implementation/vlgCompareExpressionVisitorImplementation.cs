using System.Collections.Generic;

namespace Quokka.RTL.Verilog.Implementation
{
	public partial class vlgMathExpressionVisitorImplementation
	{
		public override void OnVisit(vlgMathExpression obj)
		{
			var lookup = new Dictionary<vlgMathType, string>()
			{
				{ vlgMathType.Add, "+"},
				{ vlgMathType.Subtract, "-"},
				{ vlgMathType.Multiply, "*"},
				{ vlgMathType.Divide, "/"},
				{ vlgMathType.Remainder, "%"}
			};

			_builder.Append($"(({Raw(obj.Lhs)}) {lookup[obj.Type]} ({Raw(obj.Rhs)})");
		}
	}

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

			_builder.Append($"(({Raw(obj.Lhs)}) {lookup[obj.Type]} ({Raw(obj.Rhs)})");
		}
	}
}
