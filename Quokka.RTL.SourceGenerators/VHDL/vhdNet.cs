namespace Quokka.RTL.SourceGenerators.VHDL
{
    public abstract class vhdNet : vhdAbstractObject
    {
        public vhdNetTypeSource NetType { get; set; }
        public string Name { get; set; }
    }
}
