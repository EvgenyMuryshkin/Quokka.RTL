namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdSyncBlockVisitorImplementation
	{
		public override void OnVisit(vhdSyncBlock obj)
		{
			var source = Raw(obj.Source);
			_builder.AppendLine($"if {_formatters.EdgeType(source, obj.Type)}({source}) then");
			using (_builder.Indent())
            {
				Visit(obj.Block);
            }
			_builder.AppendLine($"end if;");
		}
	}
} // Quokka.RTL.VHDL
