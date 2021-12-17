using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public abstract class vhdTypeDeclaration : vhdAbstractObject
    {
        public string Name { get; set; }
    }

    public class vhdArrayTypeDeclaration : vhdTypeDeclaration
    {
        public int Depth { get; set; }
        public vhdDataType Type { get; set; }
        public int Width { get; set; }
    }

    [FluentType(typeof(vhdComment))]
    [FluentType(typeof(vhdText))]
    public abstract class vhdBlock : vhdAbstractCollection
    {
    }
}
