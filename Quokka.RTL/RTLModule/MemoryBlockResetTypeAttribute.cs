using System;

namespace Quokka.RTL
{
    public enum rtlMemoryBlockResetType
    {
        Reset,
        Keep
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MemoryBlockResetTypeAttribute : Attribute
    {
        public rtlMemoryBlockResetType ResetType { get; set; }
        public MemoryBlockResetTypeAttribute(rtlMemoryBlockResetType resetType)
        {
            ResetType = resetType;
        }
    }
}
