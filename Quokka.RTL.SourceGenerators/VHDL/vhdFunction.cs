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

    public class vhdFunctionDeclaration : vhdAbstractObject
    {
        public string Name { get; set; }
        public vhdDataType Type { get; set; }
        public int Width { get; set; }
    }

    public class vhdFunctionPortDeclaration : vhdAbstractObject
    {
        public string Name { get; set; }
        public vhdDataType Type { get; set; }
        public int Width { get; set; }

    }

    [FluentType(typeof(vhdComment))]
    [FluentType(typeof(vhdText))]
    [FluentType(typeof(vhdFunctionPortDeclaration))]
    public class vhdFunctionInterface : vhdAbstractCollection
    {
    }

    [FluentType(typeof(vhdComment))]
    [FluentType(typeof(vhdText))]
    [FluentType(typeof(vhdAssignExpression))]
    [FluentType(typeof(vhdIf))]
    public class vhdFunctionImplementationBlock : vhdAbstractCollection
    {

    }

    public class vhdFunctionImplementation : vhdAbstractObject
    {
        public vhdFunctionImplementationBlock Block { get; set; }
    }
}
