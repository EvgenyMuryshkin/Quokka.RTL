using System.Collections.Generic;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgLogicExpressionVisitorImplementation
	{
		public override void OnVisit(vlgLogicExpression obj)
		{
			var lookup = new Dictionary<vlgLogicType, string>()
			{
				{ vlgLogicType.And, "&"},
				{ vlgLogicType.Or, "|"},
				{ vlgLogicType.Xor, "^"},
			};

			_builder.Append($"({Brackets(obj.Lhs)} {lookup[obj.Type]} {Brackets(obj.Rhs)})");
		}
	}
}
