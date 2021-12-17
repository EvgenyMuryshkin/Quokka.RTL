namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdArchitectureImplementationBlockVisitorImplementation
	{
		public override void OnVisit(vhdArchitectureImplementationBlock obj)
		{
			obj.Children.ForEach(Visit);
		}
	}
} // Quokka.RTL.VHDL
