namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgBinaryValueExpressionVisitorImplementation
	{
		public override void OnVisit(vlgBinaryValueExpression obj)
		{
			_builder.Append(_formatters.RTLBitArray(obj.Value));
		}
	}
}
