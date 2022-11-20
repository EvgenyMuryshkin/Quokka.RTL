namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFunctionImplementationBlockVisitorImplementation
    {
        public override void OnVisit(vhdFunctionImplementationBlock obj)
        {
            obj.Children.ForEach(Visit);
        }
    }
} // Quokka.RTL.VHDL
