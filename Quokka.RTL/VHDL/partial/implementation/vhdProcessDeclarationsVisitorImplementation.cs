namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdProcessDeclarationsVisitorImplementation
	{
		public override void OnVisit(vhdProcessDeclarations obj)
		{
			obj.Children.ForEach(Visit);
		}
	}
} // Quokka.RTL.VHDL
