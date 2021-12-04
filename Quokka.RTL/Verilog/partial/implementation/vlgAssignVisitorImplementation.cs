namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgAssignVisitorImplementation
	{
		public override void OnVisit(vlgAssign obj)
		{
			_builder.AppendLine($"{Raw(obj.Expression)};");
		}
	}
}
