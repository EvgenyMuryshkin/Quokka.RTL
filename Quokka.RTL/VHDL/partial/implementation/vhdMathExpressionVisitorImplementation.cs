using System.Collections.Generic;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdMathExpressionVisitorImplementation
	{
		public override void OnVisit(vhdMathExpression obj)
		{
			var lookup = new Dictionary<vhdMathType, string>()
			{
				{ vhdMathType.Add, "+" },
				{ vhdMathType.Subtract, "-" },
				{ vhdMathType.Remainder, "rem" },
				{ vhdMathType.Multiply, "*" },
				{ vhdMathType.Divide, "/" },
			};

			_builder.Append($"{Brackets(obj.Lhs)} {lookup[obj.Type]} {Brackets(obj.Rhs)}");
		}
	}
} // Quokka.RTL.VHDL
