namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInstanceParameterVisitorImplementation
	{
		public override void OnVisit(vlgModuleInstanceParameter obj)
		{
			_builder.AppendIndented($".{obj.Name} ({obj.Value})");
		}
	}
}
