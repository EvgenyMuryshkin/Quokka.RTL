namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInstanceNamedPortMappingVisitorImplementation
	{
		public override void OnVisit(vlgModuleInstanceNamedPortMapping obj)
		{
			_builder.AppendIndented($".{obj.Internal} ({Raw(obj.External)})");
		}
	}
}
