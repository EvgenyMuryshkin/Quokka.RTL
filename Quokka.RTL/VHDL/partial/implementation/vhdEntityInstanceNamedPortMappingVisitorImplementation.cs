namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdEntityInstanceNamedPortMappingVisitorImplementation
	{
		public override void OnVisit(vhdEntityInstanceNamedPortMapping obj)
		{
			_builder.Append($"{obj.Internal} => {Raw(obj.External)}");
		}
	}
} // Quokka.RTL.VHDL
