namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInstanceNamedPortMappingVisitorImplementation
	{
		public override void OnVisit(vlgModuleInstanceNamedPortMapping obj)
		{
			_builder.Append($".{obj.Internal} ({Raw(obj.External)})");
		}
	}
}
