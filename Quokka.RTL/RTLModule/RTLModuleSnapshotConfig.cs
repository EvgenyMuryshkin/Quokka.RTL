using System;

namespace Quokka.RTL
{
    public enum RTLModuleSnapshotConfigInclude
    {
        Inputs = 1,
        Outputs = 2,
        Internals = 4,
        Modules = 8,
        State = 16,
        NextState = 32,
        Pipelines = 64
    }

    public class RTLModuleSnapshotConfig
    {
        public static RTLModuleSnapshotConfig Default => new RTLModuleSnapshotConfig();

        public RTLModuleSnapshotConfigInclude Include =
            RTLModuleSnapshotConfigInclude.Inputs |
            RTLModuleSnapshotConfigInclude.Outputs |
            RTLModuleSnapshotConfigInclude.Internals |
            RTLModuleSnapshotConfigInclude.Modules |
            RTLModuleSnapshotConfigInclude.State |
            RTLModuleSnapshotConfigInclude.NextState |
            RTLModuleSnapshotConfigInclude.Pipelines;

        public int MaxNestingLevel = int.MaxValue;

        public bool IsIncluded(RTLModuleSnapshotConfigInclude type)
        {
            if (type == RTLModuleSnapshotConfigInclude.Modules)
            {
                return MaxNestingLevel > 0 && (Include & type) != 0;
            }

            return (Include & type) != 0;
        }

        public RTLModuleSnapshotConfig Nested => new RTLModuleSnapshotConfig()
        {
            Include = Include,
            MaxNestingLevel = MaxNestingLevel == int.MaxValue ? int.MaxValue : Math.Max(0, MaxNestingLevel - 1)
        };
    }
}
