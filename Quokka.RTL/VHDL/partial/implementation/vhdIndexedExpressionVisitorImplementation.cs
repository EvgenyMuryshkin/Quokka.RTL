using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdIndexedExpressionVisitorImplementation
    {
        public override void OnVisit(vhdIndexedExpression obj)
        {
            _builder.Append($"{Raw(obj.Expression)}{obj.Indexes.Select(Raw).StringJoin("")}");
        }
    }
} // Quokka.RTL.VHDL
