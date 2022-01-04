using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdProcedureCallVisitorImplementation
	{
		public override void OnVisit(vhdProcedureCall obj)
		{
			_builder.AppendLine($"{obj.Proc}({string.Join(", ", obj.Parameters.Select(Raw))});");
		}
	}
} // Quokka.RTL.VHDL
