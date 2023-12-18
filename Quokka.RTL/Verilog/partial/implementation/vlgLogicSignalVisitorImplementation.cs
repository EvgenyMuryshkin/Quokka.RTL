﻿using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgLogicSignalVisitorImplementation
	{
		public override void OnVisit(vlgLogicSignal obj)
		{
			var signalType = obj.SignalType;
			if (signalType == vlgSignalType.Auto)
			{
				if (obj.Width == 1)
					signalType = vlgSignalType.Signal;
				else
					signalType = vlgSignalType.Bus;
			}

			var parts = new string[]
			{
				_formatters.NetType(obj.Name, obj.NetType),
				_formatters.SignType(obj.Name, obj.Sign),
                signalType == vlgSignalType.Signal ? "" : $"[{obj.Width - 1}: 0]",
				obj.Name,
				obj.Initializer == null ? null : $"= {obj.Initializer}"
			};

			_builder.AppendLine($"{parts.StringJoin(" ")};");
		}
	}
}
