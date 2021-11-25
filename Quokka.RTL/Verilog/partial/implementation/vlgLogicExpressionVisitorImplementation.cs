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

			_builder.Append($"(({Raw(obj.Lhs)}) {lookup[obj.Type]} ({Raw(obj.Rhs)}))");
		}
	}
}
