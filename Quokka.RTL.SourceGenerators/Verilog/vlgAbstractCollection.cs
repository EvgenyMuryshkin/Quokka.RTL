using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgAbstractCollection : vlgAbstractObject, IMetadataChildrenCollection<vlgAbstractObject>
    {
        public List<vlgAbstractObject> Children { get; set; }
    }
}
