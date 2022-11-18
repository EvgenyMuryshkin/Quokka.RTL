namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdReturnExpressionVisitorImplementation
    {
        public override void OnVisit(vhdReturnExpression obj)
        {
            _builder.AppendLine($"return {Raw(obj.Result)};");
        }
    }
} // Quokka.RTL.VHDL
