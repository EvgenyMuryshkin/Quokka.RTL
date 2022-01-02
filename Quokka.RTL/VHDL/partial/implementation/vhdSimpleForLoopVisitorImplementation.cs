namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdSimpleForLoopVisitorImplementation
	{
		public override void OnVisit(vhdSimpleForLoop obj)
		{
			if (obj.From > obj.To)
            {
				_builder.AppendLine($"for {obj.Iterator} in {obj.From} downto {obj.To} loop");
			}
			else
            {
				_builder.AppendLine($"for {obj.Iterator} in {obj.From} to {obj.To} loop");
			}

			using (_builder.Indent())
            {
				Visit(obj.Block);
			}

			_builder.AppendLine($"end loop;");
		}
	}
} // Quokka.RTL.VHDL
