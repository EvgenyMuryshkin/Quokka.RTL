namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAggregateExpressionVisitorImplementation
	{
		public override void OnVisit(vhdAggregateExpression obj)
		{
			_builder.Append(Raw(obj.Aggregate));
		}
	}
} // Quokka.RTL.VHDL
