namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdNullVisitorImplementation
	{
		public override void OnVisit(vhdNull obj)
		{
			_builder.AppendLine($"null;");
		}
	}
} // Quokka.RTL.VHDL
