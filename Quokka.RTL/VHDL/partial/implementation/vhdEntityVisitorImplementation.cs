using System;
using System.Collections.Generic;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdEntityVisitorImplementation
	{
		public override void OnVisit(vhdEntity obj)
		{
			_builder.AppendLine($"entity {obj.Name} is");
			using (_builder.Indent())
            {
				Visit(obj.Interface);
			}
			_builder.AppendLine($"end entity;");
		}
	}
} // Quokka.RTL.VHDL
