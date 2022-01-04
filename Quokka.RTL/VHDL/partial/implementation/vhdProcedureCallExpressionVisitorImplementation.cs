using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdProcedureCallExpressionVisitorImplementation
	{
		public override void OnVisit(vhdProcedureCallExpression obj)
		{
			_builder.Append($"{obj.Proc}({string.Join(", ", obj.Parameters.Select(Raw))})");
		}
	}
} // Quokka.RTL.VHDL
