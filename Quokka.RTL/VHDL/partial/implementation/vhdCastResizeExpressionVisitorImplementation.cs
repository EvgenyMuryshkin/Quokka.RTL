namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdCastResizeExpressionVisitorImplementation
	{
		public override void OnVisit(vhdCastResizeExpression obj)
		{
			_builder.Append($"to_{_formatters.CastType(obj.Type)}({Raw(obj.Source)}, {Raw(obj.Length)})");
		}
	}
} // Quokka.RTL.VHDL
