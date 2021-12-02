namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleVisitorImplementation
	{
		public override void OnVisit(vlgModule obj)
		{
            _builder.AppendLine($"module {obj.Name}");

            Visit(obj.Parameters);
            Visit(obj.Interface);
            Visit(obj.Implementation);

            _builder.AppendLine("endmodule");

        }
    }
}
