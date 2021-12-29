using System;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdShiftExpressionVisitorImplementation
	{
		public override void OnVisit(vhdShiftExpression obj)
		{
			switch (obj.Type)
            {
				case vhdShiftType.Left:
					_builder.Append($"shift_left({Raw(obj.Lhs)}, {Raw(obj.Rhs)})");
					break;
				case vhdShiftType.Right:
					_builder.Append($"shift_right({Raw(obj.Lhs)}, {Raw(obj.Rhs)})");
					break;
				default:
					throw new Exception($"unsupported shift type: {obj.Type}");
            }
		}
	}
} // Quokka.RTL.VHDL
