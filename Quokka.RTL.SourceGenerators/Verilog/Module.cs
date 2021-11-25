using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgModuleInstanceParameter : vlgAbstractObject
        , vlgIModuleInstanceParametersChild
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class vlgModuleInstanceParameters : vlgAbstractObject
        , IMetadataChildrenCollection<vlgIModuleInstanceParametersChild>
        , IVisitorInterface
    {
        public List<vlgIModuleInstanceParametersChild> Children { get; set; }
    }

    public abstract class vlgModuleInstancePortMapping : vlgAbstractObject
        , vlgIModuleInstancePortMappingsChild
        , IVisitorInterface
    {
    }

    public class vlgModuleInstanceNamedPortMapping : vlgModuleInstancePortMapping
    {
        public string Internal { get; set; }
        public vlgExpression External { get; set; }
    }

    public class vlgModuleInstanceSimplePortMapping : vlgModuleInstancePortMapping
    {
        public vlgExpression External { get; set; }
    }

    public class vlgModuleInstancePortMappings : vlgAbstractObject
        , IMetadataChildrenCollection<vlgIModuleInstancePortMappingsChild>
        , IVisitorInterface
    {
        public List<vlgIModuleInstancePortMappingsChild> Children { get; set; }
    }

    public class vlgModuleInstance : vlgAbstractObject
        , vlgIModuleImplementationChild
    {
        public string Type { get; set; }
        public string Name { get; set; }

        [NoCtorInit]
        public vlgModuleInstanceParameters Parameters { get; set; }
        [NoCtorInit]
        public vlgModuleInstancePortMappings PortMappings { get; set; }
    }

    public abstract class vlgModulePort : vlgAbstractObject
        , vlgIModuleInterfaceChild
    {
    }

    public class vlgPlaceholderModulePort : vlgModulePort
    {
        public string Name { get; set; }
    }

    public abstract class vlgDeclarationModulePort : vlgModulePort
    {
        public vlgPortDirection Direction { get; set; }
        public vlgNetType NetType { get; set; }
    }

    public class vlgCustomModulePort : vlgDeclarationModulePort
    {
        public string DataType { get; set; }
        public string Name { get; set; }
    }

    public abstract class vlgStandardModulePort : vlgDeclarationModulePort
    {
        public vlgSignType Sign { get; set; }
        public int Width { get; set; }
        public string Name { get; set; }
    }

    public class vlgStandardModulePortDeclaration : vlgStandardModulePort
        , vlgIModuleInterfaceChild
    {
    }

    public class vlgStandardModulePortImplementation : vlgStandardModulePort
    , vlgIModuleImplementationChild
    {
    }

    public class vlgModuleParameterDeclaration : vlgAbstractObject
        , vlgIModuleParametersChild
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public MetadataRTLBitArray DefaultValue { get; set; }
    }

    public class vlgModuleParameters : vlgAbstractObject
        , IMetadataChildrenCollection<vlgIModuleParametersChild>
        , IVisitorInterface
    {
        public List<vlgIModuleParametersChild> Children { get; set; }
    }

    public class vlgModuleInterface : vlgAbstractObject
        , IMetadataChildrenCollection<vlgIModuleInterfaceChild>
        , IVisitorInterface
    {
        public List<vlgIModuleInterfaceChild> Children { get; set; }
    }

    public class vlgModuleImplementation : vlgAbstractObject
        , IMetadataChildrenCollection<vlgIModuleImplementationChild>
        , IVisitorInterface
    {
        public List<vlgIModuleImplementationChild> Children { get; set; }
    }

    public class vlgModule : vlgAbstractObject
        , IVisitorInterface
        , vlgIFileChild
    {
        public string Name { get; set; }

        [NoCtorInit]
        public vlgModuleParameters Parameters { get; set; }

        [NoCtorInit]
        public vlgModuleInterface Interface { get; set; }

        [NoCtorInit]
        public vlgModuleImplementation Implementation { get; set; }
    }
}
