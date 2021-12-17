namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdVisitorFactoryImplementation
    {
        private readonly vhdFormattersInterface _formatters;

        public vhdVisitorFactoryImplementation(vhdFormattersInterface formatters) 
        {
            _formatters = formatters;
        }

        vhdVisitorImplementationDeps _deps => new vhdVisitorImplementationDeps(this, _formatters);
    }
}
