namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdCastExpressionVisitorImplementation
	{
		public override void OnVisit(vhdCastExpression obj)
		{
			_builder.Append($"{_formatters.CastType(obj.Type)}({Raw(obj.Source)})");
		}
	}
} // Quokka.RTL.VHDL
