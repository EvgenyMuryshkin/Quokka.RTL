﻿using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAggregateVisitorImplementation
	{
		public override void OnVisit(vhdAggregate obj)
		{
            var sources = obj.Children.Select(Raw).ToList();
			_builder.AppendLine("(");
            using (_builder.Indent())
            {
                for (var idx = 0; idx < sources.Count; idx++)
                {
                    _builder.AppendIndented(sources[idx]);
                    if (idx == sources.Count - 1)
                    {
                        _builder.AppendUnindentedLine("");
                    }
                    else
                    {
                        _builder.AppendUnindentedLine(",");
                    }
                }
            }

            _builder.AppendLine(")");
		}
	}
} // Quokka.RTL.VHDL
