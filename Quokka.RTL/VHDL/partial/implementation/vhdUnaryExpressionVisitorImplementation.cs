using System.Collections.Generic;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdUnaryExpressionVisitorImplementation
	{
		public override void OnVisit(vhdUnaryExpression obj)
		{
			var lookup = new Dictionary<vhdUnaryType, string>()
			{
				{ vhdUnaryType.Not, "NOT" },
			};

			_builder.Append($"({lookup[obj.Type]} {Brackets(obj.Rhs)})");
		}
	}
} // Quokka.RTL.VHDL
