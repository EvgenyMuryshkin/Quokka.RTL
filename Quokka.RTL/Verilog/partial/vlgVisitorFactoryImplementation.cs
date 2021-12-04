namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgVisitorFactoryImplementation
    {
        private readonly vlgFormattersInterface _formatters;

        public vlgVisitorFactoryImplementation(vlgFormattersInterface formatters) 
        {
            _formatters = formatters;
        }

        vlgVisitorImplementationDeps _deps => new vlgVisitorImplementationDeps(this, _formatters);
    }
}
