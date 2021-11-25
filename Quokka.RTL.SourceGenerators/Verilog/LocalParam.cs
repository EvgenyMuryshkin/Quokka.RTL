using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgLocalParam : vlgAbstractObject
    , vlgIModuleImplementationChild
    {
    }

    public abstract class vlgLocalParamName : vlgLocalParam
    {
        public string Name { get; set; }
    }

    public class vlgLocalParamNameBinaryValue : vlgLocalParamName
    {
        public MetadataRTLBitArray Value { get; set; }
    }

    public class vlgLocalParamNameExplicitValue : vlgLocalParamName
    {
        public string Value { get; set; }
    }
}
