using Quokka.RTL.Tools;
using System;
using System.Reflection;

namespace Quokka.RTL
{
    public class CombinationalUnrollItem
    {
        public Type Type { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public int ArrayIndex { get; set; }
        public bool IsArrayItem { get; set; }
        public object OriginalValue { get; set; }
        public string OriginalName { get; set; }
        public MemberInfo MemberInfo { get; set; }

        public CombinationalUnrollItem(
            Type type, 
            string name, 
            object value, 
            bool isArrayItem = false, 
            int arrayIndex = 0,
            MemberInfo memberInfo = null
        )
        {
            Type = type;
            Name = name;
            Value = value;
            IsArrayItem = isArrayItem;
            ArrayIndex = arrayIndex;
            MemberInfo = memberInfo;
        }

        // tools
        public bool IsArray => Type.IsArray;
        public RTLSignalInfo ArrayElementSize { get; set; }
        public int ArrayDepth { get; set; }
        public bool IsTuple => RTLTypeCheck.IsTuple(Type);
        public bool IsNative => RTLTypeCheck.IsNative(Type);
    }
}
