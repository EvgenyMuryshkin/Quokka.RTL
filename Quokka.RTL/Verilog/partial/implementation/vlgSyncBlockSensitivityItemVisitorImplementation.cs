namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgSyncBlockSensitivityItemVisitorImplementation
    {
        public override void OnVisit(vlgSyncBlockSensitivityItem obj)
        {
			var signal = Raw(obj.Identifier);
			_builder.Append($"{_formatters.EdgeType(signal, obj.Edge)} {signal}");
        }
    }
}
