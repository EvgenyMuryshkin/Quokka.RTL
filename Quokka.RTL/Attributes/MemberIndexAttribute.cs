using System;
using System.Runtime.CompilerServices;

namespace Quokka.RTL
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MemberIndexAttribute : Attribute
    {
        public MemberIndexAttribute([CallerFilePath] string sourcePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            FilePath = sourcePath ?? "";
            LineNumber = lineNumber;
        }

        public MemberIndexAttribute(int index)
        {
            Index = index;
        }

        int LineNumber { get; set; }
        string FilePath { get; set; }
        int? Index { get; set; }

        public string Order => Index.HasValue 
            ? Index.Value.ToString() 
            : $"{FilePath}_{LineNumber.ToString().PadLeft(10, '0')}";
    }
}
