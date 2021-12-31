namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdAliasVisitorImplementation
	{
		public override void OnVisit(vhdAlias obj)
		{
			_builder.AppendLine($"alias {obj.Alias} is {Raw(obj.Expression)};");
		}
	}
} // Quokka.RTL.VHDL
