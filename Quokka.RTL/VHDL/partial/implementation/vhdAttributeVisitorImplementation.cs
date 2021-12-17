namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAttributeVisitorImplementation
	{
		public override void OnVisit(vhdAttribute obj)
		{
			_builder.AppendLine($"attribute {obj.Name} of {obj.Target} : {obj.Value};");
		}
	}
} // Quokka.RTL.VHDL
