namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgFunctionInterfaceVisitorImplementation
    {
        public override void OnVisit(vlgFunctionInterface obj)
        {
            obj.Children.ForEach(Visit);
        }
    }
}
