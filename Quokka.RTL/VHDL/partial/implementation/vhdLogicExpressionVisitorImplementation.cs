using System.Collections.Generic;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdLogicExpressionVisitorImplementation
	{
		public override void OnVisit(vhdLogicExpression obj)
		{
			var lookup = new Dictionary<vhdLogicType, string>()
			{
				{ vhdLogicType.And, "AND" },
				{ vhdLogicType.Or, "OR" },
				{ vhdLogicType.Xor, "XOR" },
			};

			_builder.Append($"({Brackets(obj.Lhs)} {lookup[obj.Type]} {Brackets(obj.Rhs)})");
		}
	}
} // Quokka.RTL.VHDL
