using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdRangeVisitorImplementation
	{
		public override void OnVisit(vhdRange obj)
		{
			if (!obj.Indexes.Any())
				return;

			var indexes = obj.Indexes.Select(Raw);
			var numeric = indexes.Select(i =>
			{
				var parsed = int.TryParse(i, out var value);
				return new { i, parsed, value };
			}).ToList();

			if (numeric.All(i => i.parsed) && numeric.Count == 2)
            {
				if (numeric[0].value >= numeric[1].value)
                {
					_builder.Append($"({string.Join(" downto ", indexes)})");
				}
				else
				{
					_builder.Append($"({string.Join(" to ", indexes)})");
				}
			}
			else
            {
				_builder.Append($"({string.Join(" downto ", indexes)})");
			}
		}
	}
} // Quokka.RTL.VHDL
