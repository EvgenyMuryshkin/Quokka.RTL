namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgIdentifierExpressionVisitorImplementation
	{
		public override void OnVisit(vlgIdentifierExpression obj)
		{
			_builder.Append(Raw(obj.Source));
		}
	}
}
