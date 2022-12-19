namespace Quokka.RTL.SourceGenerators.VHDL
{
    [FluentType(typeof(vhdGenericBlock))]
    public class vhdGenericBlock : vhdBlock
    {
        [NoCtorInit]
        public bool IsDefaultValuesAssign { get; set; }
    }
}
