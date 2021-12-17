namespace Quokka.RTL.SourceGenerators.VHDL
{
    public abstract class vhdEntityPort : vhdAbstractObject
    {
        public string Name { get; set; }
        public vhdPortDirection Direction { get; set; }
    }

    public class vhdStandardEntityPort : vhdEntityPort
    {
        public vhdDataType Sign { get; set; }
        public int Width { get; set; }
        public string Initializer { get; set; }
    }

    public class vhdCustomEntityPort : vhdEntityPort
    {
        public string Declaration { get; set; }
        public string Initializer { get; set; }
    }

    [FluentType(typeof(vhdComment))]
    [FluentType(typeof(vhdText))]
    [FluentType(typeof(vhdEntityPort))]
    public class vhdEntityInterface : vhdAbstractCollection
    {
    }

    public class vhdEntity : vhdAbstractObject
    {
        public string Name { get; set; }

        [NoCtorInit]
        public vhdEntityInterface Interface { get; set; }
    }
}
