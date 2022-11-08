namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgFunctionImplementationVisitorImplementation
    {
        public override void OnVisit(vlgFunctionImplementation obj)
        {
            _builder.AppendLine("begin");
            using (_builder.Indent())
            {
                Visit(obj.Block);
            }
            _builder.AppendLine("end");
        }
    }
}
