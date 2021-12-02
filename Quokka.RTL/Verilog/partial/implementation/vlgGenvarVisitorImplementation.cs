namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgGenvarVisitorImplementation
	{
		public override void OnVisit(vlgGenvar obj)
		{
			_builder.AppendLine($"genvar {obj.Name};");
		}
	}
}
