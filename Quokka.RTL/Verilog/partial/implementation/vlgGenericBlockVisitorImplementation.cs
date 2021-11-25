namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgGenericBlockVisitorImplementation
	{
		public override void OnVisit(vlgGenericBlock obj)
		{
			obj.Children.ForEach(Visit);
		}
	}
}
