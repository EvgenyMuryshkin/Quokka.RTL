namespace Quokka.RTL.Verilog
{
    public class vlgVisitorImplementationDeps
    {
        public readonly vlgVisitorFactoryInterface VisitorFactory;
        public readonly vlgFormattersInterface Formatters;

        public vlgVisitorImplementationDeps(
            vlgVisitorFactoryInterface visitorFactory,
            vlgFormattersInterface formatters
            )
        {
            VisitorFactory = visitorFactory;
            Formatters = formatters;
        }
    }
}
