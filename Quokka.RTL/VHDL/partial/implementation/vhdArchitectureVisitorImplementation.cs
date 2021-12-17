namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdArchitectureVisitorImplementation
	{
		public override void OnVisit(vhdArchitecture obj)
		{
			_builder.AppendLine($"architecture {obj.Type} of {obj.Entity} is");
			Visit(obj.Declarations);
			Visit(obj.Implementation);

			_builder.AppendLine($"end architecture;");
		}
	}
} // Quokka.RTL.VHDL
