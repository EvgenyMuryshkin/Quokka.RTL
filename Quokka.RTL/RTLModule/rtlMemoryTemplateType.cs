using System;

namespace Quokka.RTL
{
    public enum rtlMemoryTemplateType
    {
        Undefined,
        Logic, // memory block is built using logic and registers
        ROM, // synchronous ROM
        RAM_SDP_RF, // simple dual port, read first
        RAM_SDP_WF, // simple dual port, write first
        RAM_SP_RF, // single port, read first
        RAM_SP_WF, // single port, write first
        RAM_TDP, // true dual port 
    }

    [AttributeUsage(validOn: AttributeTargets.Property | AttributeTargets.Field)]
    public class MemoryTemplateTypeAttribute : Attribute
    {
        public rtlMemoryTemplateType MemoryTemplateType { get; set; }
        public MemoryTemplateTypeAttribute(rtlMemoryTemplateType memoryTemplateType)
        {
            MemoryTemplateType = memoryTemplateType;
        }
    }
}
