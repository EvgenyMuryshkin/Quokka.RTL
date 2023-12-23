namespace Quokka.RTL.VHDL.Implementation
{
    using Quokka.RTL.Tools;

    public partial class vhdStandardEntityPortVisitorImplementation
	{
		public override void OnVisit(vhdStandardEntityPort obj)
		{
            var signalType = obj.SignalType;
            if (signalType == vhdSignalType.Auto)
            {
                if (obj.Width == 1)
                    signalType = vhdSignalType.Signal;
                else
                    signalType = vhdSignalType.Bus;
            }

            var parts = new string[]
			{
				$"{obj.Name} :",
				_formatters.DirectionType(obj.Name, obj.Direction),
				_formatters.DataType(obj.Name, obj.Width, new vhdDefaultDataType(obj.DataType, obj.SignalType)),
                signalType == vhdSignalType.Signal ? null : $"({obj.Width - 1} downto {0})",
				obj.Initializer.HasValue() ? $":= {obj.Initializer}" : null
			};

			_builder.AppendIndented(parts.StringJoin(" "));
		}
	}
} // Quokka.RTL.VHDL
