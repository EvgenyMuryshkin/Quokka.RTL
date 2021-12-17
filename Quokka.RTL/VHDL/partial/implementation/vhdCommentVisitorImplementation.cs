using System.Linq;
namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdCommentVisitorImplementation
	{
		public override void OnVisit(vhdComment obj)
		{
			var singleLines = obj.Lines.SelectMany(l => l.Split('\n').Select(sl => sl.TrimEnd())).ToList();
			singleLines.ForEach(l => _builder.AppendLine($"-- {l}"));
		}
	}
} // Quokka.RTL.VHDL
