namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdIdentifierExpressionVisitorImplementation
	{
		public override void OnVisit(vhdIdentifierExpression obj)
		{
			_builder.Append(Raw(obj.Source));
		}
	}
} // Quokka.RTL.VHDL
