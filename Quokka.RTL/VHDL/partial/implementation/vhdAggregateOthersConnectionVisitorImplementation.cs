namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAggregateOthersConnectionVisitorImplementation
	{
		public override void OnVisit(vhdAggregateOthersConnection obj)
		{
			_builder.Append($"others => '{(obj.Value ? "1" : "0")}'");
		}
	}
} // Quokka.RTL.VHDL
