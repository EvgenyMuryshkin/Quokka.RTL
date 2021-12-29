namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdPredefinedAttributeExpressionVisitorImplementation
	{
		public override void OnVisit(vhdPredefinedAttributeExpression obj)
		{
			_builder.Append($"{Raw(obj.Source)}'{obj.Attribute}");
		}
	}
} // Quokka.RTL.VHDL
