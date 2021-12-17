namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdUseVisitorImplementation
	{
		public override void OnVisit(vhdUse obj)
		{
			_builder.AppendLine($"use {obj.Value};");
		}
	}
} // Quokka.RTL.VHDL
