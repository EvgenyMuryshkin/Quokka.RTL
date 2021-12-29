namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAssignExpressionVisitorImplementation
	{
		public override void OnVisit(vhdAssignExpression obj)
		{
			var assignType = obj.Type == vhdAssignType.Signal ? "<=" : ":=";
			_builder.AppendLine($"{Raw(obj.Target)} {assignType} {Raw(obj.Source)};");
		}
	}
} // Quokka.RTL.VHDL
