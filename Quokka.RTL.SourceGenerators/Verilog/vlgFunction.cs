namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgFunction : vlgAbstractCollection
    {
        public vlgFunctionDeclaration Declaration { get; set; }

        [NoCtorInit]
        public vlgFunctionInterface Interface { get; set; }

        [NoCtorInit]
        public vlgFunctionImplementation Implementation { get; set; }
    }
}
