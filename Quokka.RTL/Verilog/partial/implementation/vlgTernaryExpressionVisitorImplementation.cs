namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgTernaryExpressionVisitorImplementation
	{
		public override void OnVisit(vlgTernaryExpression obj)
		{
			_builder.Append($"(({Raw(obj.Condition)}) ? ({Raw(obj.Lhs)}) : ({Raw(obj.Rhs)}))");
		}
	}
}
