using Quokka.RTL.SourceGenerators.Verilog;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdFunction : vhdAbstractObject
    {
        public vhdFunctionDeclaration Declaration { get; set; }

        [NoCtorInit]
        public vhdFunctionInterface Interface { get; set; }

        [NoCtorInit]
        public vhdFunctionImplementation Implementation { get; set; }
    }
}
