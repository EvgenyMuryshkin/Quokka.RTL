namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgTextVisitorImplementation
	{
		public override void OnVisit(vlgText obj)
		{
			obj.Lines.ForEach(l => _builder.AppendUnindentedLine(l));
		}
	}
}
