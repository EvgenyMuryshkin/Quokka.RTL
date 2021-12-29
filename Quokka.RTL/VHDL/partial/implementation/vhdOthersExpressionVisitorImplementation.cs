namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdOthersExpressionVisitorImplementation
	{
		public override void OnVisit(vhdOthersExpression obj)
		{
			_builder.Append("others");
		}
	}
} // Quokka.RTL.VHDL
