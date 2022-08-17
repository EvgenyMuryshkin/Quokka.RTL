namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdEntityInstanceNamedGenericMappingVisitorImplementation
    {
		public override void OnVisit(vhdEntityInstanceNamedGenericMapping obj)
		{
			_builder.AppendIndented($"{obj.Internal} => {Raw(obj.External)}");
		}
	}
} // Quokka.RTL.VHDL
