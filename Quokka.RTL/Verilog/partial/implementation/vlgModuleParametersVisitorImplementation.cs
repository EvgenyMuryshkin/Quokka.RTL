using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleParametersVisitorImplementation
	{
		public override void OnVisit(vlgModuleParameters obj)
		{
            var parameters = obj.AsModuleParameterDeclaration.ToList();
            if (obj.Children.Any())
            {
                _builder.AppendLine("# (");
                using (_builder.Indent())
                {
                    obj.Children.ForEach(c =>
                    {
                        Visit(c);

                        if (c is vlgModuleParameterDeclaration)
                        {
                            if (c == parameters.Last())
                            {
                                _builder.AppendLine();
                            }
                            else
                            {
                                _builder.AppendUnindentedLine(",");
                            }
                        }
                    });
                }
                _builder.AppendLine(")");
            }

        }
    }
}
