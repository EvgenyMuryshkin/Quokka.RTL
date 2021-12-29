namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdBinaryValueExpressionVisitorImplementation
	{
		public override void OnVisit(vhdBinaryValueExpression obj)
		{
			_builder.Append(_formatters.RTLBitArray(obj.Value));
		}
	}
} // Quokka.RTL.VHDL
