using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgIfVisitorImplementation
    {
        public override void OnVisit(vlgIf obj)
        {
            foreach (var statement in obj.Statements)
            {
                if (statement == obj.Statements.First())
                {
                    _builder.AppendLine($"if ({Raw(statement.Condition)})");
                }
                else if (statement.Condition != null)
                {
                    _builder.AppendLine($"else if ({Raw(statement.Condition)})");
                }
                else
                {
                    _builder.AppendLine($"else");
                }

                _builder.AppendLine($"begin");
                using (_builder.Indent())
                {
                    statement.Children.ForEach(Visit);
                }
                _builder.AppendLine($"end");
            }
        }
    }
}
