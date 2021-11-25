namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgLocalParamNameBinaryValueVisitorImplementation
	{
		public override void OnVisit(vlgLocalParamNameBinaryValue obj)
		{
			_builder.AppendLine($"localparam {obj.Name} = {_formatters.RTLBitArray(obj.Value)};");
		}
	}
}
