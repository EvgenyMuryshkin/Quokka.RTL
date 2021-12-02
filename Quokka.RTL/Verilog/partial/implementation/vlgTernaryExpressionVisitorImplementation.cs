namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgTernaryExpressionVisitorImplementation
	{
		public override void OnVisit(vlgTernaryExpression obj)
		{
			_builder.Append($"({Brackets(obj.Condition)} ? {Brackets(obj.Lhs)} : {Brackets(obj.Rhs)})");
		}
	}
}
