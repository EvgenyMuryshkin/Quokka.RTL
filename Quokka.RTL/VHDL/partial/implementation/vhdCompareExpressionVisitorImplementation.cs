using System.Collections.Generic;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdCompareExpressionVisitorImplementation
	{
		public override void OnVisit(vhdCompareExpression obj)
		{
			var lookup = new Dictionary<vhdCompareType, string>()
			{
				{ vhdCompareType.Equal, "=" },
				{ vhdCompareType.NotEqual, "/=" },
				{ vhdCompareType.Greater, ">" },
				{ vhdCompareType.GreaterOrEqual, ">=" },
				{ vhdCompareType.Less, "<" },
				{ vhdCompareType.LessOrEqual, "<=" }
			};

			_builder.Append($"{Brackets(obj.Lhs)} {lookup[obj.Type]} {Brackets(obj.Rhs)}");
		}
	}
} // Quokka.RTL.VHDL
