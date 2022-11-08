namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgIntegerExpressionVisitorImplementation
    {
        public override void OnVisit(vlgIntegerExpression obj)
        {
            _builder.Append(obj.Value.ToString());
        }
    }
}
