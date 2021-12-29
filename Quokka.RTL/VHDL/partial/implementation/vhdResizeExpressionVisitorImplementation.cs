namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdResizeExpressionVisitorImplementation
	{
		public override void OnVisit(vhdResizeExpression obj)
		{
			_builder.Append($"resize({Raw(obj.Source)}, {Raw(obj.Length)})");
		}
	}
} // Quokka.RTL.VHDL
