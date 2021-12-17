namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdLibraryReferenceVisitorImplementation
	{
		public override void OnVisit(vhdLibraryReference obj)
		{
			_builder.AppendLine($"library {obj.Name};");
		}
	}
} // Quokka.RTL.VHDL
