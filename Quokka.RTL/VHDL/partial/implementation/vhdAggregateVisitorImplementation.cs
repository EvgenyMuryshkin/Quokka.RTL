using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAggregateVisitorImplementation
	{
		public override void OnVisit(vhdAggregate obj)
		{
			_builder.Append($"({obj.Children.Select(Raw).StringJoin(", ")})");
		}
	}
} // Quokka.RTL.VHDL
