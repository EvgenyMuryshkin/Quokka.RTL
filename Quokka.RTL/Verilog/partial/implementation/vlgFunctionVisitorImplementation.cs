namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgFunctionVisitorImplementation
    {
        public override void OnVisit(vlgFunction obj)
        {
            _builder.AppendLine($"function");
            Visit(obj.Declaration);
            using (_builder.Indent())
            {
                Visit(obj.Interface);
                Visit(obj.Implementation);
            }
            _builder.AppendLine("endfunction");
        }
    }
}
