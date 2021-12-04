namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgLocalParamNameExplicitValueVisitorImplementation
	{
		public override void OnVisit(vlgLocalParamNameExplicitValue obj)
		{
			_builder.AppendLine($"localparam {obj.Name} = {obj.Value};");
		}
	}
}
