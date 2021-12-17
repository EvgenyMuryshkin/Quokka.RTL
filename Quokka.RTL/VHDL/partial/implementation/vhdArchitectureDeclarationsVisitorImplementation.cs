namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdArchitectureDeclarationsVisitorImplementation
	{
		public override void OnVisit(vhdArchitectureDeclarations obj)
		{
			using (_builder.Indent())
			{
				obj.Children.ForEach(Visit);
			}
		}
	}
} // Quokka.RTL.VHDL
