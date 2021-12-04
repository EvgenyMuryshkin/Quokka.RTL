namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgModule : vlgAbstractObject
    {
        public string Name { get; set; }

        [NoCtorInit]
        public vlgModuleParameters Parameters { get; set; }

        [NoCtorInit]
        public vlgModuleInterface Interface { get; set; }

        [NoCtorInit]
        public vlgModuleImplementation Implementation { get; set; }
    }
}
