using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInstancePortMappingsVisitorImplementation
	{
		public override void OnVisit(vlgModuleInstancePortMappings obj)
		{
			_builder.AppendLine("(");

			var portMappings = obj.AsModuleInstancePortMapping.ToList();

			using (_builder.Indent())
			{
				foreach (var c in obj.Children)
				{
					Visit(c);

					if (c is vlgModuleInstancePortMapping)
					{
						if (c == portMappings.Last())
						{
							_builder.AppendLine();
						}
						else
						{
							_builder.AppendUnindentedLine(",");
						}
					}
				}
			}

			_builder.AppendLine(");");
		}
	}
}
