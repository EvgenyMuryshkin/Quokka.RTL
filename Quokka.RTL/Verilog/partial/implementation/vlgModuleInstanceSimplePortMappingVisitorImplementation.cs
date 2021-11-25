namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInstanceSimplePortMappingVisitorImplementation
	{
		public override void OnVisit(vlgModuleInstanceSimplePortMapping obj)
		{
			_builder.Append($"{Raw(obj.External)}");
		}
	}
}
