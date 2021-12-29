using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdIfVisitorImplementation
	{
		public override void OnVisit(vhdIf obj)
		{
			if (!obj.Statements.Any())
				return;

			foreach (var statement in obj.Statements)
			{
				if (statement == obj.Statements.First())
				{
					_builder.AppendLine($"if ({Raw(statement.Condition)}) then");
				}
				else if (statement.Condition != null)
				{
					_builder.AppendLine($"elsif ({Raw(statement.Condition)}) then");
				}
				else
				{
					_builder.AppendLine($"else");
				}

				using (_builder.Indent())
				{
					Visit(statement.Block);
				}
			}

			_builder.AppendLine($"end if;");
		}
	}
} // Quokka.RTL.VHDL
