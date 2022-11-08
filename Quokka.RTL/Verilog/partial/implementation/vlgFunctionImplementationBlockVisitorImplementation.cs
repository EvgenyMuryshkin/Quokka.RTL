namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgFunctionImplementationBlockVisitorImplementation
    {
        public override void OnVisit(vlgFunctionImplementationBlock obj)
        {
            obj.Children.ForEach(Visit);
        }
    }
}
