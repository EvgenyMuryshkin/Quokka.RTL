namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFileVisitorImplementation
	{
		public override void OnVisit(vhdFile obj)
		{
			obj.Children.ForEach(Visit);
		}
	}
} // Quokka.RTL.VHDL
