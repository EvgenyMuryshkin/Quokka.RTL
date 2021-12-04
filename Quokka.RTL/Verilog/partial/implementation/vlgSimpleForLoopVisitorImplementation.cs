using Quokka.RTL.Tools;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgSimpleForLoopVisitorImplementation
	{
		public override void OnVisit(vlgSimpleForLoop obj)
		{
			_builder.AppendLine($"for ({obj.Iterator} = {obj.From}; {obj.Iterator} < {obj.To}; {obj.Iterator} = {obj.Iterator} + 1)");

			if (obj.Children.Count > 1)
            {
				if (obj.Name.HasValue())
					_builder.AppendLine($"begin : {obj.Name}");
				else
					_builder.AppendLine("begin");
			}

			using (_builder.Indent())
			{
				obj.Children.ForEach(Visit);
			}

			if (obj.Children.Count > 1)
				_builder.AppendLine("end");
		}
	}
}
