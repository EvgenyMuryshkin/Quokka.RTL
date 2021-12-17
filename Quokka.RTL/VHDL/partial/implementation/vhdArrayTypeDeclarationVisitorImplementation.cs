using Quokka.RTL.Tools;
using System;

namespace Quokka.RTL.VHDL.Implementation
{
	/*
	public partial class vhdConstantDeclarationVisitorImplementation
	{
		public override void OnVisit(vhdConstantDeclaration obj)
		{
			switch (obj.Initializer.Count)
            {
				case 0:
                {
					throw new Exception($"constant {obj.Name} has no initializer");
                }
				case 1:
                {
					_builder.AppendLine($"constant {obj.Name} : {obj.Type} := {obj.Initializer[0]};");
				}
				break;
				default:
                {
					_builder.AppendLine($"constant {obj.Name} : {obj.Type} := (");
					using (_builder.Indent())
                    {
						for (var idx = 0; idx < obj.Initializer.Count; idx++)
                        {
							if (idx == obj.Initializer.Count - 1)
                            {
								_builder.AppendLine($"{obj.Initializer[idx]}");
							}
							else
                            {
								_builder.AppendLine($"{obj.Initializer[idx]},");
							}
						}
                    }
					_builder.AppendLine($");");
				}
				break;
            }
		}
	}
	*/

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
