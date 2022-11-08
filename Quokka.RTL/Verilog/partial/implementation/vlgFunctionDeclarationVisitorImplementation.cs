namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgFunctionDeclarationVisitorImplementation
    {
        public override void OnVisit(vlgFunctionDeclaration obj)
        {
            _builder.AppendLine($"[{obj.Width - 1}: 0] {obj.Name};");
        }
    }
}
