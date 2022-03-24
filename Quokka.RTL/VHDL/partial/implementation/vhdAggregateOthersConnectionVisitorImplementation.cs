namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAggregateOthersConnectionVisitorImplementation
	{
		public override void OnVisit(vhdAggregateOthersConnection obj)
		{
			_builder.Append($"others => {Raw(obj.Expression)}");
		}
	}
} // Quokka.RTL.VHDL
