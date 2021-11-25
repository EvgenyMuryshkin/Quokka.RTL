using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgIdentifierVisitorImplementation
	{
		public override void OnVisit(vlgIdentifier obj)
		{
			var formatted = $"{obj.Name}{obj.Indexes.Select(Raw).StringJoin("")}";
			_builder.Append(formatted);
		}
	}
}
