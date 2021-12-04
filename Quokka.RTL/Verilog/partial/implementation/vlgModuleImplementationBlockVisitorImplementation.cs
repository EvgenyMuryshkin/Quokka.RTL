namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleImplementationBlockVisitorImplementation
	{
		public override void OnVisit(vlgModuleImplementationBlock obj)
		{
			obj.Children.ForEach(Visit);
		}
	}
	
}
