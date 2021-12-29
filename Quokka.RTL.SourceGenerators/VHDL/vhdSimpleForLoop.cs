namespace Quokka.RTL.SourceGenerators.VHDL
{
    public class vhdSimpleForLoop : vhdAbstractObject
    {
        public string Iterator { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        [NoCtorInit]
        public vhdGenericBlock Block { get; set; }
    }
}
