namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgFileVisitorImplementation
	{
		public override void OnVisit(vlgFile obj)
		{
			obj.Children.ForEach(Visit);
		}
	}
}
