namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdFunctionVariablesVisitorImplementation
    {
        public override void OnVisit(vhdFunctionVariables obj)
        {
            foreach (var v in obj)
                Visit(v);
        }
    }
} // Quokka.RTL.VHDL
