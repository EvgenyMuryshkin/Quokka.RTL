using Quokka.RTL.SourceGenerators.VHDL;

namespace Quokka.RTL.SourceGenerators
{
    public class VHDLGeneratorContext : GeneratorContext
    {
        public VHDLGeneratorContext() : base("VHDL", "vhd", typeof(vhdAbstractObject)) { }
    }
}
