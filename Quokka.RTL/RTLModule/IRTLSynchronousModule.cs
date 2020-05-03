using System;
using System.Collections.Generic;
using System.Reflection;

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

    public interface IRTLSynchronousModule : IRTLCombinationalModule
    {
        Type StateType { get; }
        List<MemberInfo> StateProps { get; }
        object State { get; }
    }
}
