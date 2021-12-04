using System.Collections.Generic;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgShiftExpressionVisitorImplementation
	{
		public override void OnVisit(vlgShiftExpression obj)
		{
			var lookup = new Dictionary<vlgShiftType, string>()
			{
				{ vlgShiftType.RightLogic, ">>"},
				{ vlgShiftType.RightArith, ">>>"},
				{ vlgShiftType.Left, "<<"},
			};

			_builder.Append($"({Brackets(obj.Lhs)} {lookup[obj.Type]} {Brackets(obj.Rhs)})");
		}
	}
}
