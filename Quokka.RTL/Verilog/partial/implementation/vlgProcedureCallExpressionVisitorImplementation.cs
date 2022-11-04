using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgProcedureCallExpressionVisitorImplementation
    {
        public override void OnVisit(vlgProcedureCallExpression obj)
        {
            var args = obj.Call.Parameters.Select(Raw);

            _builder.Append($"{obj.Call.Name}({args.StringJoin(", ")})");
        }
    }
}
