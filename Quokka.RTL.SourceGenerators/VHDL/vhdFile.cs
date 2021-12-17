using System;
using System.Text;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    [FluentType(typeof(vhdComment))]
    [FluentType(typeof(vhdText))]
    [FluentType(typeof(vhdLibraryReference))]
    [FluentType(typeof(vhdUse))]
    [FluentType(typeof(vhdEntity))]
    [FluentType(typeof(vhdArchitecture))]
    [FluentType(typeof(vhdAttribute))]
    public class vhdFile : vhdAbstractCollection
    {
    }
}
