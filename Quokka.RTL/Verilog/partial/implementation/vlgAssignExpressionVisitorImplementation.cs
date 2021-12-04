using System;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgAssignExpressionVisitorImplementation
	{
		public override void OnVisit(vlgAssignExpression obj)
		{
			var target = Raw(obj.Target);
			var source = Raw(obj.Expression);

			switch (obj.Type)
			{
				case vlgAssignType.Assign:
					_builder.Append($"assign {target} = {source}");
					break;
				case vlgAssignType.Equal:
					_builder.Append($"{target} = {source}");
					break;
				case vlgAssignType.Blocking:
					_builder.Append($"{target} = {source}");
					break;
				case vlgAssignType.NonBlocking:
					_builder.Append($"{target} <= {source}");
					break;
				default:
					throw new Exception($"Assign type not supported: {target} {obj.Type} {source}");
			}

		}
	}
}
