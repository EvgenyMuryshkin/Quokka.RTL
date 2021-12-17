namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdArchitectureImplementationVisitorImplementation
	{
		public override void OnVisit(vhdArchitectureImplementation obj)
		{
			_builder.AppendLine("begin");
			using (_builder.Indent())
			{
				Visit(obj.Block);
			}
		}
	}
} // Quokka.RTL.VHDL
