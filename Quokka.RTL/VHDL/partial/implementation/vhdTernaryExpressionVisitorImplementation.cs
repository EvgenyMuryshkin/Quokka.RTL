namespace Quokka.RTL.VHDL.Implementation
{

    public partial class vhdTernaryExpressionVisitorImplementation
	{
		public override void OnVisit(vhdTernaryExpression obj)
		{
			_builder.Append($"{Raw(obj.Lhs)} when {Raw(obj.Condition)} else {Raw(obj.Rhs)}");
		}
	}
} // Quokka.RTL.VHDL
