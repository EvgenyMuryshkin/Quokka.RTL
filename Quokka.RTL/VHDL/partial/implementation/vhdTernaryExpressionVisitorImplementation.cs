namespace Quokka.RTL.VHDL.Implementation
{

    public partial class vhdTernaryExpressionVisitorImplementation
	{
		public override void OnVisit(vhdTernaryExpression obj)
		{
			_builder.Append($"{Brackets(obj.Lhs)} when {Brackets(obj.Condition)} else {Brackets(obj.Rhs)}");
		}
	}
} // Quokka.RTL.VHDL
