namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgAttributeVisitorImplementation
	{
		public override void OnVisit(vlgAttribute obj)
		{
			_builder.AppendLine($"`{obj.Name} {obj.Value}");
		}
	}
}
