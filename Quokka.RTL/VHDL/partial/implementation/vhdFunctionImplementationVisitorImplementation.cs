namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFunctionImplementationVisitorImplementation
    {
        public override void OnVisit(vhdFunctionImplementation obj)
        {
            Visit(obj.Block);
        }
    }
} // Quokka.RTL.VHDL
