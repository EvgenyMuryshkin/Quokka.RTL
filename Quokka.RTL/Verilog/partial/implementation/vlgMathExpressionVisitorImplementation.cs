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

			_builder.Append($"({Brackets(obj.Lhs)} {lookup[obj.Type]} {Brackets(obj.Rhs)})");
		}
	}
}
