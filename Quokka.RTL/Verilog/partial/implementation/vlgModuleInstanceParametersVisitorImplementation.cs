using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgModuleInstanceParametersVisitorImplementation
	{
		public override void OnVisit(vlgModuleInstanceParameters obj)
		{
			var parameters = obj.AsModuleInstanceParameter.ToList();
			if (obj.Children.Any())
			{
				_builder.AppendLine("#(");
				using (_builder.Indent())
				{
					foreach (var p in obj.Children)
                    {
						Visit(p);
						if (p is vlgModuleInstanceParameter)
						{
							if (p == parameters.Last())
                            {
								_builder.AppendLine();
							}
							else
                            {
								_builder.AppendUnindentedLine(",");
							}
						}
					}
				}
				_builder.AppendLine(")");
			}
		}
	}
}
