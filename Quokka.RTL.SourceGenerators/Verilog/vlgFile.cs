using System;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    [FluentType(typeof(vlgComment))]
    [FluentType(typeof(vlgText))]
    [FluentType(typeof(vlgModule))]
    [FluentType(typeof(vlgAttribute))]
    public class vlgFile : vlgAbstractCollection
    {
    }
}
