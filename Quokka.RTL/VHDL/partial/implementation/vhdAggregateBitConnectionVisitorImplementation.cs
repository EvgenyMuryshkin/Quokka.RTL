namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAggregateBitConnectionVisitorImplementation
	{
		public override void OnVisit(vhdAggregateBitConnection obj)
		{
			_builder.Append($"{obj.Bit} => {Raw(obj.Value)}");
		}
	}
} // Quokka.RTL.VHDL
