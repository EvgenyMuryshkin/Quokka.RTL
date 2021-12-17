using System.Collections.Generic;

namespace Quokka.RTL.SourceGenerators.VHDL
{
    public abstract class vhdAbstractCollection : vhdAbstractObject, IMetadataChildrenCollection<vhdAbstractObject>
    {
        public List<vhdAbstractObject> Children { get; set; }
    }
}
