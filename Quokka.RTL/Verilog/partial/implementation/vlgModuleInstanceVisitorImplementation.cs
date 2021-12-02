namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInstanceVisitorImplementation
	{
		public override void OnVisit(vlgModuleInstance obj)
		{
			_builder.AppendLine($"{obj.Type}");
			Visit(obj.Parameters);
			_builder.AppendLine($"{obj.Name}");
			Visit(obj.PortMappings);
		}
	}
}
