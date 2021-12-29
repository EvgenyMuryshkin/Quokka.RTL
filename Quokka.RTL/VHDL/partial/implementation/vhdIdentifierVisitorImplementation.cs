using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdIdentifierVisitorImplementation
	{
		public override void OnVisit(vhdIdentifier obj)
		{
			var formatted = $"{obj.Name}{obj.Indexes.Select(Raw).StringJoin("")}";
			_builder.Append(formatted);
		}
	}
} // Quokka.RTL.VHDL
