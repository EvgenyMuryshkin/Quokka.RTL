namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdGenericBlockVisitorImplementation
	{
		public override void OnVisit(vhdGenericBlock obj)
		{
			obj.Children.ForEach(Visit);
		}
	}
} // Quokka.RTL.VHDL
