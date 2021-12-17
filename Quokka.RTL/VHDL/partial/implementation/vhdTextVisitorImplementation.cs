namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdTextVisitorImplementation
	{
		public override void OnVisit(vhdText obj)
		{
			obj.Lines.ForEach(l => _builder.AppendUnindentedLine(l));
		}
	}
} // Quokka.RTL.VHDL
