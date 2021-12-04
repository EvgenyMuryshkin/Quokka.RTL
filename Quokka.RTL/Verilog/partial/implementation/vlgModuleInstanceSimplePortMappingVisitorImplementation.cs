namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInstanceSimplePortMappingVisitorImplementation
	{
		public override void OnVisit(vlgModuleInstanceSimplePortMapping obj)
		{
			_builder.AppendIndented($"{Raw(obj.External)}");
		}
	}
}
