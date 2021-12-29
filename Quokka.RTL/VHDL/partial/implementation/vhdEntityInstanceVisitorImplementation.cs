namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdEntityInstanceVisitorImplementation
	{
		public override void OnVisit(vhdEntityInstance obj)
		{
			_builder.AppendLine($"{obj.Name} : entity {obj.Type}");
			Visit(obj.PortMappings);
		}
	}
} // Quokka.RTL.VHDL
