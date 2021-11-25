namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgIteratorVisitorImplementation
	{
		public override void OnVisit(vlgIterator obj)
		{
			_builder.AppendLine($"integer {obj.Name}");
		}
	}
}
