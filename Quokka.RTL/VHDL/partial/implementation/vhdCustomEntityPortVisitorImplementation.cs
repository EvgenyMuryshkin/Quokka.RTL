namespace Quokka.RTL.VHDL.Implementation
{
    using Quokka.RTL.Tools;

    public partial class vhdCustomEntityPortVisitorImplementation
	{
		public override void OnVisit(vhdCustomEntityPort obj)
		{
            var parts = new string[]
                {
					$"{obj.Name} :",
					_formatters.DirectionType(obj.Name, obj.Direction),
					obj.Declaration,
					obj.Initializer.HasValue() ? $":= {obj.Initializer}" : null
				};

			_builder.AppendIndented(parts.StringJoin(" "));
		}
	}
} // Quokka.RTL.VHDL
