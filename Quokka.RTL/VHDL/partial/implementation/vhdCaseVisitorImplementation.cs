namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdCaseVisitorImplementation
	{
		public override void OnVisit(vhdCase obj)
		{
			_builder.AppendLine($"case {Raw(obj.Expression)} is");

			using (_builder.Indent())
            {
				foreach (var statement in obj.Statements)
				{
					Visit(statement);
				}
			}

			_builder.AppendLine($"end case;");
		}
	}
} // Quokka.RTL.VHDL
