namespace Quokka.RTL.SourceGenerators.VHDL
{
    [FluentType(typeof(vhdComment))]
    [FluentType(typeof(vhdText))]
    [FluentType(typeof(vhdIf))]
    [FluentType(typeof(vhdCase))]
    [FluentType(typeof(vhdProcess))]
    [FluentType(typeof(vhdSyncBlock))]
    [FluentType(typeof(vhdAssignExpression))]
    [FluentType(typeof(vhdProcedureCall))]
    [FluentType(typeof(vhdSimpleForLoop))]
    [FluentType(typeof(vhdNull))]
    public abstract class vhdBlock : vhdAbstractCollection
    {
    }
}
