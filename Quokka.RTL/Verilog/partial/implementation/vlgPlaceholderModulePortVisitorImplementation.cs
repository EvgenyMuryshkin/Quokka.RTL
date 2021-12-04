namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgPlaceholderModulePortVisitorImplementation
	{
		public override void OnVisit(vlgPlaceholderModulePort obj)
		{
			_builder.Append(obj.Name);
		}
	}
}
