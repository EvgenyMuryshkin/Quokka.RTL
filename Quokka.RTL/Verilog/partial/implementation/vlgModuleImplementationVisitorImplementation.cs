namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleImplementationVisitorImplementation
	{
		public override void OnVisit(vlgModuleImplementation obj)
		{
			using (_builder.Indent())
			{
				obj.Children.ForEach(Visit);
			}
		}
	}
}
