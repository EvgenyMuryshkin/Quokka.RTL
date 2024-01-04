using Quokka.RTL.Tools;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdDefaultSignalVisitorImplementation
	{
		public override void OnVisit(vhdDefaultSignal obj)
		{
			var parts = new string[]
			{
				_formatters.NetType(obj.Name, obj.NetType),
				$"{obj.Name} :",
                _formatters.DataType(obj.Name, obj.Width, obj.DataType),
                _formatters.Range(obj.Width, _formatters.IsBus(obj.DataType))
            };

			//var declaration = parts.StringJoin(" ");

            var declaration = $"{_formatters.NetType(obj.Name, obj.NetType)} {obj.Name} : {_formatters.DataType(obj.Name, obj.Width, obj.DataType)}{_formatters.Range(obj.Width, _formatters.IsBus(obj.DataType))}";

			switch (obj.Initializer.Count)
			{
				case 0:
				{
					_builder.AppendLine($"{declaration};");
				}
				break;
				case 1:
					{
						var initializer = obj.Initializer[0];
						if (_formatters.IsBus(obj.DataType))
						{
							if (initializer.StartsWith("'"))
                                initializer = initializer.Replace("'", "\"");
                        }

                        _builder.AppendLine($"{declaration} := {initializer};");
					}
					break;
				default:
				{
					_builder.AppendLine($"{declaration} := (");
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
} // Quokka.RTL.VHDL
