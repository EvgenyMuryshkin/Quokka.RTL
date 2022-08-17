using System;

namespace Quokka.RTL
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MemberIndexAttribute : Attribute
    {
        public MemberIndexAttribute(int index)
        {
            Index = index;
        }

        public int Index { get; set; }
    }
}
