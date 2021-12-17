namespace Quokka.RTL.VHDL.Implementation
{
    using System.Linq;

    public partial class vhdEntityInterfaceVisitorImplementation
	{
		public override void OnVisit(vhdEntityInterface obj)
		{
			_builder.AppendLine("port");
			_builder.AppendLine("(");
			using (_builder.Indent())
            {
				var ports = obj.AsEntityPort.ToList();
				foreach (var child in obj.Children)
                {
					Visit(child);
					if (child is vhdEntityPort)
                    {
						if (child == ports.Last())
                        {
							_builder.AppendLine();
                        }
						else
                        {
							_builder.AppendUnindentedLine(";");
                        }
                    }
                }
            }
			_builder.AppendLine(");");
		}
	}
} // Quokka.RTL.VHDL
