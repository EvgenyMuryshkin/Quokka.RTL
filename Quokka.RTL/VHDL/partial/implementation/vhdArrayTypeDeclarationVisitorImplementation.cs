using Quokka.RTL.Tools;
using System;

namespace Quokka.RTL.VHDL.Implementation
{
	public partial class vhdArrayTypeDeclarationVisitorImplementation
	{
		public override void OnVisit(vhdArrayTypeDeclaration obj)
		{
			var parts = new[]
			{
				"type",
				obj.Name,
				"is array",
				$"(0 to {obj.Depth - 1})",
				"of",
				_formatters.DataType(obj.Name, obj.Width, obj.Type),
				obj.Width <= 1 ? null : $"({obj.Width - 1} downto 0)"
			};

			_builder.AppendLine($"{parts.StringJoin(" ")};");
		}
	}
} // Quokka.RTL.VHDL
