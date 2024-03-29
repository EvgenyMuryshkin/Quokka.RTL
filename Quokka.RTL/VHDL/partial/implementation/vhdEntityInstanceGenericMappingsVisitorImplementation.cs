﻿using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdEntityInstanceGenericMappingsVisitorImplementation
    {
        public override void OnVisit(vhdEntityInstanceGenericMappings obj)
        {
			var portMappings = obj.AsEntityInstanceGenericMapping.ToList();
			_builder.AppendLine("generic map");
			_builder.AppendLine("(");
			using (_builder.Indent())
			{
				foreach (var c in obj.Children)
				{
					Visit(c);

					if (c is vhdEntityInstanceGenericMapping)
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
			_builder.AppendLine(")");
		}
    }
} // Quokka.RTL.VHDL
