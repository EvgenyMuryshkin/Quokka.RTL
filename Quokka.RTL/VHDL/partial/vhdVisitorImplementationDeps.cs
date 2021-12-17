namespace Quokka.RTL.VHDL
{
    public class vhdVisitorImplementationDeps
    {
        public readonly vhdVisitorFactoryInterface VisitorFactory;
        public readonly vhdFormattersInterface Formatters;

        public vhdVisitorImplementationDeps(
            vhdVisitorFactoryInterface visitorFactory,
            vhdFormattersInterface formatters
            )
        {
            VisitorFactory = visitorFactory;
            Formatters = formatters;
        }
    }
}
