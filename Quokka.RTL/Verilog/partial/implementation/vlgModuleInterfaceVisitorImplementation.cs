using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInterfaceVisitorImplementation
	{
		public override void OnVisit(vlgModuleInterface obj)
		{
            var ports = obj.AsModulePort.ToList();
            _builder.AppendLine("(");
            using (_builder.Indent())
            {
                obj.Children.ForEach(c =>
                {
                    Visit(c);
                    if (c is vlgModulePort)
                    {
                        if (c == ports.Last())
                        {
                            _builder.AppendLine();
                        }
                        else
                        {
                            _builder.AppendLine(",");
                        }
                    }
                });
            }
            _builder.AppendLine(");");
        }
	}
}
