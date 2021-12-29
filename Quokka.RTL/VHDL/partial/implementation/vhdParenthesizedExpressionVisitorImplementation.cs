namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdParenthesizedExpressionVisitorImplementation
	{
		public override void OnVisit(vhdParenthesizedExpression obj)
		{
			_builder.Append($"({Raw(obj.Expression)})");
		}
	}
} // Quokka.RTL.VHDL
