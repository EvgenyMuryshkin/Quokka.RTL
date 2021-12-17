namespace Quokka.RTL.VHDL.Implementation
{
    using Quokka.RTL.Tools;

    public partial class vhdStandardEntityPortVisitorImplementation
	{
		public override void OnVisit(vhdStandardEntityPort obj)
		{
			var parts = new string[]
				{
					$"{obj.Name} :",
					_formatters.DirectionType(obj.Name, obj.Direction),
					_formatters.DataType(obj.Name, obj.Width, obj.Sign),
					obj.Width == 1 ? null : $"({obj.Width - 1} downto {0})",
					obj.Initializer.HasValue() ? $":= {obj.Initializer}" : null
				};

			_builder.AppendIndented(parts.StringJoin(" "));
		}
	}
} // Quokka.RTL.VHDL
