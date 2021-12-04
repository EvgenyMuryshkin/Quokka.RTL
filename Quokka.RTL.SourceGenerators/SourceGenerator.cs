using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    [TestClass]
    public class SourceGenerator
    {
        void Save(string path, string content)
        {

        }

        void PartGenerator()
        {
            StringBuilder sb = new StringBuilder();

        }

        [TestMethod]
        public void Generate()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("// generated code, do not modify");
            result.AppendLine("using System;");
            result.AppendLine("namespace Quokka.RTL");
            result.AppendLine("{");
            result.AppendLine("\tpublic partial class RTLBitArray");
            result.AppendLine("\t{");


            foreach (var type in Tools.AllTypes)
            {
                result.AppendLine($"\t\t#region operators for {type}");

                // math ops
                result.AppendLine($"\t\t// math operators for {type}");
                foreach (var op in new[] { "+", "-", "*" })
                {
                    result.AppendLine($"\t\tpublic static RTLBitArray operator {op}(RTLBitArray op, {type} value)");
                    result.AppendLine($"\t\t\t=> op {op} new RTLBitArray(value);");
                    result.AppendLine($"\t\tpublic static RTLBitArray operator {op}({type} value, RTLBitArray op)");
                    result.AppendLine($"\t\t\t=> new RTLBitArray(value) {op} op;");
                }

                // logic ops
                result.AppendLine($"\t\t// logic operators for {type}");
                foreach (var op in new[] { "&", "|", "^" })
                {
                    result.AppendLine($"\t\tpublic static RTLBitArray operator {op}(RTLBitArray op, {type} value)");
                    result.AppendLine($"\t\t\t=> op {op} new RTLBitArray(value);");
                    result.AppendLine($"\t\tpublic static RTLBitArray operator {op}({type} value, RTLBitArray op)");
                    result.AppendLine($"\t\t\t=> new RTLBitArray(value) {op} op;");
                }

                // compare  ops
                result.AppendLine($"\t\t// comparison operators for {type}");
                foreach (var op in new[] { "==", "!=", "<", "<=", ">", ">=" })
                {
                    result.AppendLine($"\t\tpublic static bool operator {op}(RTLBitArray op, {type} value)");
                    result.AppendLine($"\t\t\t=> op {op} new RTLBitArray(value);");
                    result.AppendLine($"\t\tpublic static bool operator {op}({type} value, RTLBitArray op)");
                    result.AppendLine($"\t\t\t=> new RTLBitArray(value) {op} op;");
                }

                result.AppendLine($"\t\t#endregion operators for {type}");
            }

            result.AppendLine("\t}");
            result.AppendLine("}");

            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.BitArraySourcePath, $"RTLBitArray.generated.cs"),
                result.ToString()
                );
        }
    }
}
