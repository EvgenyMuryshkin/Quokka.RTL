using Quokka.RTL.SourceGenerators.Verilog;

namespace Quokka.RTL.SourceGenerators
{
    public class VerilogGeneratorContext : GeneratorContext
    {
        public VerilogGeneratorContext() : base("Verilog", "vlg", typeof(vlgAbstractObject)) { }
    }
}
