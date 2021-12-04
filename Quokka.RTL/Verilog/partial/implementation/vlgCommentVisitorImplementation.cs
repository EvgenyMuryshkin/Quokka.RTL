using System.Linq;

namespace Quokka.RTL.Verilog.Implementation
{
    public partial class vlgCommentVisitorImplementation
	{
		public override void OnVisit(vlgComment obj)
		{
			var singleLines = obj.Lines.SelectMany(l => l.Split('\n').Select(sl => sl.TrimEnd())).ToList();
			singleLines.ForEach(l => _builder.AppendLine($"// {l}"));
		}
	}
}
