using Quokka.RTL.Tools;
using Quokka.RTL.Verilog;
using System.Linq;

namespace Quokka.RTL.VHDL.Implementation
{
    public partial class vhdArchitectureDeclarationsVisitorImplementation
	{
		public override void OnVisit(vhdArchitectureDeclarations obj)
		{
			using (_builder.Indent())
			{
				var functions = obj.AsFunction;
				var subTypes = obj.AsSubTypeDeclaration.Select(t => t.Name).ToHashSet();
				var arrayTypes = obj.AsArrayTypeDeclaration.Select(t => t.Name).ToHashSet();

                foreach (var child in obj.Children)
				{
					if (child is vhdFunction)
						continue;

                    Visit(child);
                }

				var funtionSubTypes = functions
					.SelectMany(f => f.TypeDeclarations.AsSubTypeDeclaration)
					.GroupBy(f => f.Name)
					.Select(g => g.First())
					.Where(subType => !subTypes.Contains(subType.Name));

				foreach (var subType in funtionSubTypes)
				{
                    Visit(subType);
                }

                var functionArrayTypes = functions
                    .SelectMany(f => f.TypeDeclarations.AsArrayTypeDeclaration)
                    .GroupBy(f => f.Name)
                    .Select(g => g.First())
                    .Where(subType => !arrayTypes.Contains(subType.Name));

                foreach (var arrayType in functionArrayTypes)
                {
                    Visit(arrayType);
                }

                foreach (var function in functions)
                {
                    Visit(function);
                }
            }
		}
	}
} // Quokka.RTL.VHDL
