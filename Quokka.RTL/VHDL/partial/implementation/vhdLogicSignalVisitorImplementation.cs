using System;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdLogicSignalVisitorImplementation
	{
		public override void OnVisit(vhdLogicSignal obj)
		{
			switch (obj.Initializer.Count)
            {
				case 0:
                {
					throw new Exception($"No initializer for {obj.Name}");
                }
				case 1:
                {
					var initializer = obj.Initializer[0]; 
					_builder.AppendLine($"{_formatters.NetType(obj.Name, obj.NetType)} {obj.Name} : {_formatters.DataType(obj.Name, initializer)}{_formatters.Range(initializer.Size)} := {_formatters.RTLBitArray(initializer)};");
				}
				break;
				default:
                {
					var initializer = obj.Initializer[0];
					_builder.AppendLine($"{_formatters.NetType(obj.Name, obj.NetType)} {obj.Name} : {_formatters.DataType(obj.Name, initializer)}{_formatters.Range(initializer.Size)} := (");
					using (_builder.Indent())
					{
						for (var idx = 0; idx < obj.Initializer.Count; idx++)
						{
							if (idx == obj.Initializer.Count - 1)
							{
								_builder.AppendLine($"{_formatters.RTLBitArray(obj.Initializer[idx])}");
							}
							else
							{
								_builder.AppendLine($"{_formatters.RTLBitArray(obj.Initializer[idx])},");
							}
						}
					}
					_builder.AppendLine($");");
				}
				break;
            }
		}
	}
} // Quokka.RTL.VHDL
