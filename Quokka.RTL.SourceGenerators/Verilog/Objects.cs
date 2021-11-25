using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.SourceGenerators.Verilog
{
    public abstract class vlgAbstractObject
    {
    }

    public class vlgComment : vlgAbstractObject
        , vlgIModuleInstanceChild
        , vlgIModuleInterfaceChild
        , vlgIFileChild
        , vlgIModuleImplementationChild
        , vlgIModuleParametersChild
        , vlgIBlockChild
        , IVisitorInterface
        , vlgIModuleInstancePortMappingsChild
    {
        public List<string> Lines { get; set; }
    }

    public class vlgText : vlgAbstractObject
        , vlgIModuleInstanceChild
        , vlgIModuleInterfaceChild
        , vlgIFileChild
        , vlgIModuleImplementationChild
        , vlgIModuleParametersChild
        , vlgIInitialChild
        , vlgIBlockChild
        , IVisitorInterface
        , vlgIModuleInstancePortMappingsChild
    {
        public List<string> Lines { get; set; }
    }

    public class vlgAttribute : vlgAbstractObject
        , vlgIFileChild
        , IVisitorInterface
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class vlgCustomDeclaration : vlgAbstractObject
        , vlgIModuleImplementationChild
        , IVisitorInterface
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Initializer { get; set; }
    }

    public abstract class vlgSignal : vlgAbstractObject
        , vlgIModuleImplementationChild
    {
    }

    public class vlgMemoryBlock : vlgSignal
    {
        public string Name { get; set; }
        public vlgSignType Sign { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
    }

    public class vlgLogicSignal : vlgSignal
    {
        public vlgNetType NetType { get; set; }
        public vlgSignType Sign { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public string Initializer { get; set; }
    }

    public class vlgInitial : vlgAbstractObject
        , IMetadataChildrenCollection<vlgIInitialChild>
        , vlgIModuleImplementationChild
        , IVisitorInterface
    {
        public string Name { get; set; }
        public List<vlgIInitialChild> Children { get; set; }
    }

    public class vlgIterator : vlgAbstractObject
        , vlgIModuleImplementationChild
        , IVisitorInterface
    {
        public string Name { get; set; }
    }

    public abstract class vlgAbstractForLoop : vlgAbstractObject
        , IMetadataChildrenCollection<vlgILoopChild>
        , vlgIBlockChild
        , vlgIModuleImplementationChild
        , IVisitorInterface
    {
        public List<vlgILoopChild> Children { get; set; }
    }

    public class vlgSimpleForLoop : vlgAbstractForLoop
        , vlgIInitialChild
    {
        public string Iterator { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }

    public class vlgForLoop : vlgAbstractForLoop
    {
        public vlgExpression Initializer { get; set; }
        public vlgExpression Condition { get; set; }
        public vlgExpression Increment { get; set; }
    }

    public class vlgRange : vlgAbstractObject
    {
        public List<vlgExpression> Indexes { get; set; }
    }

    public class vlgIdentifier : vlgAbstractObject
    {
        public string Name { get; set; }
        public List<vlgRange> Indexes { get; set; }
    }

    public class vlgAssign : vlgAbstractObject
        , vlgIModuleImplementationChild
        , vlgIInitialChild
        , vlgILoopChild
        , vlgIBlockChild
        , IVisitorInterface
    {
        public vlgAssignExpression Expression { get; set; }
    }

    public abstract class vlgBlock : vlgAbstractObject
        , vlgIModuleImplementationChild
        , IDerivedVisitorInterface
        , IMetadataChildrenCollection<vlgIBlockChild>
    {
        public List<vlgIBlockChild> Children { get; set; }
    }

    public class vlgGenericBlock : vlgBlock
        , vlgIBlockChild
        , vlgILoopChild
        , IVisitorInterface
    {
    }

    public class vlgCombBlock : vlgBlock
        , IVisitorInterface
    {
        public List<vlgIdentifier> SensitivityList { get; set; }
    }

    public class vlgSyncBlockSensitivityItem : vlgAbstractObject
        , IVisitorInterface
    {
        public vlgEdgeType Edge { get; set; }
        public vlgIdentifier Identifier { get; set; }

    }

    public class vlgSyncBlock : vlgBlock
        , IVisitorInterface
    {
        public List<vlgSyncBlockSensitivityItem> SensitivityList { get; set; }
    }

    public class vlgFile : vlgAbstractObject
        , IMetadataChildrenCollection<vlgIFileChild>
        , IVisitorInterface
    {
        public List<vlgIFileChild> Children { get; set; }
    }
}
