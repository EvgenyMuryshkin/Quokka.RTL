﻿using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdIdentifierVisitorImplementation
	{
		public override void OnVisit(vhdIdentifier obj)
		{
			_builder.Append($"{obj.Name}{obj.Indexes.Select(Raw).StringJoin("")}");
		}
	}
} // Quokka.RTL.VHDL
