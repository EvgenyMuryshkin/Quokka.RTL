namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdArchitecture : vhdAbstractObject
    {
        public string Type { get; set; }
        public string Entity { get; set; }

        [NoCtorInit]
        public vhdArchitectureDeclarations Declarations { get; set; }

        [NoCtorInit]
        public vhdArchitectureImplementation Implementation { get; set; }
    }
}
