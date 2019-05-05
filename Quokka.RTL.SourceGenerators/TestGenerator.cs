using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    [TestClass]
    public class TestGenerator
    {
        void PartGenerator(string part, Action<StringBuilder> generator)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("// generated code, do not modify");
            result.AppendLine("using Microsoft.VisualStudio.TestTools.UnitTesting;");
            result.AppendLine("using Quokka.RTL;");
            result.AppendLine("namespace Quokka.RTL.RTLBitArrayTests");
            result.AppendLine("{");

            StringBuilder namespaceContent = new StringBuilder();

            generator(namespaceContent);
            Indent(result, namespaceContent, 1);

            result.AppendLine("}");

            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.TestsPath, $"{part}Tests.cs"),
                result.ToString()
                );
        }

        void Indent(StringBuilder target, StringBuilder source, int indent)
        {
            var lines = source.ToString().Split(new[] { '\n' }).Select(v => v.TrimEnd()).ToList();
            if (lines.Last() == "")
                lines.RemoveAt(lines.Count - 1);

            var indentLine = string.Join("", Enumerable.Range(0, indent).Select(_ => "\t"));

            foreach (var line in lines)
            {
                if (line == "")
                {
                    target.AppendLine();
                }
                else
                {
                    target.AppendLine($"{indentLine}{line}");
                }
            }
        }

        void OpValues(
            StringBuilder result,
            string name, 
            string type)
        {
            if (type == "bool")
            {
                result.AppendLine($"var {name} = new {type}[] {{ true, false }};");
            }
            else if (Tools.signedTypes.Contains(type))
            {
                result.AppendLine($"var {name} = new {type}[] {{ {type}.MinValue, {type}.MinValue + 1, -1, 0, 1, {type}.MaxValue - 1, {type}.MaxValue }};");
            }
            else
            {
                result.AppendLine($"var {name} = new {type}[] {{ 0, 1, {type}.MaxValue / 2, {type}.MaxValue / 2 + 1, {type}.MaxValue - 1, {type}.MaxValue }};");
            }
        }

        void MathOp(StringBuilder result, string from, string to, string op)
        {
            if (from == "bool")
            {
                if (to == "bool")
                {
                    result.AppendLine($"\t\tAssert.AreEqual((long)(v1 ? 1 : 0) {op} (long)(v2 ? 1 : 0), (long)(o1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                    result.AppendLine($"\t\tAssert.AreEqual((long)(v1 ? 1 : 0) {op} (long)(v2 ? 1 : 0), (long)(v1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                    result.AppendLine($"\t\tAssert.AreEqual((long)(v1 ? 1 : 0) {op} (long)(v2 ? 1 : 0), (long)(o1 {op} v2), $\"{{v1}} {op} {{v2}}\");");
                }
                else
                {
                    result.AppendLine($"\t\tAssert.AreEqual((long)(v1 ? 1 : 0) {op} (long)v2, (long)(o1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                    result.AppendLine($"\t\tAssert.AreEqual((long)(v1 ? 1 : 0) {op} (long)v2, (long)(v1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                    result.AppendLine($"\t\tAssert.AreEqual((long)(v1 ? 1 : 0) {op} (long)v2, (long)(o1 {op} v2), $\"{{v1}} {op} {{v2}}\");");
                }
            }
            else
            {
                if (to == "bool")
                {
                    result.AppendLine($"\t\tAssert.AreEqual((long)v1 {op} (long)(v2 ? 1 : 0), (long)(o1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                    result.AppendLine($"\t\tAssert.AreEqual((long)v1 {op} (long)(v2 ? 1 : 0), (long)(v1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                    result.AppendLine($"\t\tAssert.AreEqual((long)v1 {op} (long)(v2 ? 1 : 0), (long)(o1 {op} v2), $\"{{v1}} {op} {{v2}}\");");
                }
                else
                {
                    result.AppendLine($"\t\tAssert.AreEqual((long)v1 {op} (long)v2, (long)(o1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                    result.AppendLine($"\t\tAssert.AreEqual((long)v1 {op} (long)v2, (long)(v1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                    result.AppendLine($"\t\tAssert.AreEqual((long)v1 {op} (long)v2, (long)(o1 {op} v2), $\"{{v1}} {op} {{v2}}\");");
                }
            }
        }

        void Add(StringBuilder result)
        {
            MathTest(result, "Add", "+");
        }

        void Sub(StringBuilder result)
        {
            MathTest(result, "Sub", "-");
        }

        void Mult(StringBuilder result)
        {
            MathTest(result, "Mult", "*");
        }

        void Logic(StringBuilder result)
        {
            BeginClass(result, "Logic");

            var classBody = new StringBuilder();

            var ops = new Dictionary<string, string>()
            {
                { "&", "And" },
                { "|", "Or" },
                { "^", "Xor" },
            };

            foreach (var from in Tools.AllTypes)
            {
                foreach (var to in Tools.AllTypes)
                {
                    var fromCap = Cap(from);
                    var toCap = Cap(to);

                    var fromSigned = Tools.signedTypes.Contains(from);
                    var toSigned = Tools.signedTypes.Contains(to);
                    // apply only to same signature type
                    if (fromSigned == toSigned)
                    {
                        foreach (var pair in ops)
                        {
                            var op = pair.Key;

                            var boundingType = Tools.BoundingType(from, to);

                            var method = new StringBuilder();

                            method.AppendLine("[TestMethod]");
                            method.AppendLine($"public void {fromCap}{pair.Value}{toCap}()");
                            method.AppendLine("{");

                            var methodBody = new StringBuilder();

                            OpValues(methodBody, "op1", from);
                            OpValues(methodBody, "op2", to);

                            methodBody.AppendLine("foreach (var v1 in op1)");
                            methodBody.AppendLine("{");
                            methodBody.AppendLine("\tvar o1 = new RTLBitArray(v1);");
                            methodBody.AppendLine("\tforeach (var v2 in op2)");
                            methodBody.AppendLine("\t{");
                            methodBody.AppendLine("\t\tvar o2 = new RTLBitArray(v2);");

                            if (from == "bool")
                            {
                                if (to == "bool")
                                {
                                    methodBody.AppendLine($"\t\tAssert.AreEqual((byte)(v1 ? 1 : 0) {op} (byte)(v2 ? 1 : 0), (byte)(o1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                                    methodBody.AppendLine($"\t\tAssert.AreEqual((byte)(v1 ? 1 : 0) {op} (byte)(v2 ? 1 : 0), (byte)(v1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                                    methodBody.AppendLine($"\t\tAssert.AreEqual((byte)(v1 ? 1 : 0) {op} (byte)(v2 ? 1 : 0), (byte)(o1 {op} v2), $\"{{v1}} {op} {{v2}}\");");
                                }
                                else
                                {
                                    methodBody.AppendLine($"\t\tAssert.AreEqual((byte)(v1 ? 1 : 0) {op} v2, ({boundingType})(o1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                                    methodBody.AppendLine($"\t\tAssert.AreEqual((byte)(v1 ? 1 : 0) {op} v2, ({boundingType})(v1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                                    methodBody.AppendLine($"\t\tAssert.AreEqual((byte)(v1 ? 1 : 0) {op} v2, ({boundingType})(o1 {op} v2), $\"{{v1}} {op} {{v2}}\");");
                                }
                            }
                            else
                            {
                                if (to == "bool")
                                {
                                    methodBody.AppendLine($"\t\tAssert.AreEqual(v1 {op} (byte)(v2 ? 1 : 0), ({boundingType})(o1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                                    methodBody.AppendLine($"\t\tAssert.AreEqual(v1 {op} (byte)(v2 ? 1 : 0), ({boundingType})(v1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                                    methodBody.AppendLine($"\t\tAssert.AreEqual(v1 {op} (byte)(v2 ? 1 : 0), ({boundingType})(o1 {op} v2), $\"{{v1}} {op} {{v2}}\");");
                                }
                                else
                                {
                                    methodBody.AppendLine($"\t\tAssert.AreEqual(v1 {op} v2, ({boundingType})(o1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                                    methodBody.AppendLine($"\t\tAssert.AreEqual(v1 {op} v2, ({boundingType})(v1 {op} o2), $\"{{v1}} {op} {{v2}}\");");
                                    methodBody.AppendLine($"\t\tAssert.AreEqual(v1 {op} v2, ({boundingType})(o1 {op} v2), $\"{{v1}} {op} {{v2}}\");");
                                }
                            }
                            methodBody.AppendLine("\t}");
                            methodBody.AppendLine("}");

                            Indent(method, methodBody, 1);

                            method.AppendLine("}");

                            Indent(classBody, method, 0);
                        }
                    }
                }
            }

            Indent(result, classBody, 1);

            EndClass(result, "Logic");
        }

        void BeginClass(StringBuilder result, string name)
        {
            result.AppendLine("[TestClass]");
            result.AppendLine($"public class {name}");
            result.AppendLine("{");
        }

        void EndClass(StringBuilder result, string name)
        {
            result.AppendLine("}");
        }

        string Cap(string name)
        {
            return new string(name[0], 1).ToUpper() + string.Join("", name.Skip(1));
        }

        void MathTest(StringBuilder result, string name, string op)
        {
            BeginClass(result, name);

            var classBody = new StringBuilder();

            foreach (var from in Tools.OpTypes)
            {
                foreach (var to in Tools.OpTypes)
                {
                    var fromCap = Cap(from);
                    var toCap = Cap(to);

                    var method = new StringBuilder();

                    method.AppendLine("[TestMethod]");
                    method.AppendLine($"public void {fromCap}To{toCap}()");
                    method.AppendLine("{");

                    var methodBody = new StringBuilder();

                    OpValues(methodBody, "op1", from);
                    OpValues(methodBody, "op2", to);

                    methodBody.AppendLine("foreach (var v1 in op1)");
                    methodBody.AppendLine("{");
                    methodBody.AppendLine("\tvar o1 = new RTLBitArray(v1);");
                    methodBody.AppendLine("\tforeach (var v2 in op2)");
                    methodBody.AppendLine("\t{");
                    methodBody.AppendLine("\t\tvar o2 = new RTLBitArray(v2);");

                    MathOp(methodBody, from, to, op);

                    methodBody.AppendLine("\t}");
                    methodBody.AppendLine("}");

                    Indent(method, methodBody, 1);

                    method.AppendLine("}");

                    Indent(classBody, method, 0);
                }
            }

            Indent(result, classBody, 1);

            EndClass(result, name);
        }

        void Init(StringBuilder result)
        {
            BeginClass(result, "Init");
            var classBody = new StringBuilder();

            foreach (var from in Tools.AllTypes)
            {
                var fromCap = Cap(from);

                var method = new StringBuilder();

                method.AppendLine("[TestMethod]");
                method.AppendLine($"public void From{fromCap}()");
                method.AppendLine("{");

                var methodBody = new StringBuilder();

                OpValues(methodBody, "op1", from);

                methodBody.AppendLine("foreach (var v1 in op1)");
                methodBody.AppendLine("{");
                methodBody.AppendLine("\tvar o1 = new RTLBitArray(v1);");
                methodBody.AppendLine($"\tAssert.AreEqual(v1, ({from})o1, $\"{{v1}}\");");
                methodBody.AppendLine("}");

                Indent(method, methodBody, 1);

                method.AppendLine("}");

                Indent(classBody, method, 0);
            }

            Indent(result, classBody, 1);
            EndClass(result, "Init");
        }

        void Shift(StringBuilder result)
        {
            BeginClass(result, "Shift");
            var classBody = new StringBuilder();

            foreach (var from in Tools.AllTypes)
            {
                var fromCap = Cap(from);

                var ops = new Dictionary<string, string>()
                {
                    { "<<", "Left" },
                    { ">>", "Right" }
                };

                foreach (var op in ops)
                {
                    var method = new StringBuilder();

                    method.AppendLine("[TestMethod]");
                    method.AppendLine($"public void {fromCap}Shift{op.Value}()");
                    method.AppendLine("{");

                    var methodBody = new StringBuilder();

                    OpValues(methodBody, "op1", from);

                    methodBody.AppendLine("foreach (var v1 in op1)");
                    methodBody.AppendLine("{");
                    methodBody.AppendLine("\tvar o1 = new RTLBitArray(v1);");
                    if (from == "bool")
                    {
                        methodBody.AppendLine($"\tAssert.AreEqual((long)((v1 ? 1 : 0) {op.Key} 1), (long)(o1 {op.Key} 1), $\"{{v1}}\");");
                    }
                    else if (Tools.signedTypes.Contains(from))
                    {
                        methodBody.AppendLine($"\tAssert.AreEqual((long)v1 {op.Key} 1, (long)(o1 {op.Key} 1), $\"{{v1}}\");");
                    }
                    else
                    {
                        methodBody.AppendLine($"\tAssert.AreEqual((ulong)v1 {op.Key} 1, (ulong)(o1 {op.Key} 1), $\"{{v1}}\");");
                    }
                    methodBody.AppendLine("}");

                    Indent(method, methodBody, 1);

                    method.AppendLine("}");

                    Indent(classBody, method, 0);
                }
            }

            Indent(result, classBody, 1);
            EndClass(result, "Shift");
        }

        void ToString(StringBuilder result)
        {
            BeginClass(result, "ToString");
            var classBody = new StringBuilder();

            foreach (var from in Tools.AllTypes)
            {
                var fromCap = Cap(from);

                var method = new StringBuilder();

                method.AppendLine("[TestMethod]");
                method.AppendLine($"public void {fromCap}ToString()");
                method.AppendLine("{");

                var methodBody = new StringBuilder();

                OpValues(methodBody, "op1", from);

                methodBody.AppendLine("foreach (var v1 in op1)");
                methodBody.AppendLine("{");
                methodBody.AppendLine("\tvar o1 = new RTLBitArray(v1);");
                if (from == "bool")
                {
                    methodBody.AppendLine($"\tAssert.AreEqual((v1 ? 1 : 0).ToString(\"X\"), o1.ToString(), $\"{{v1}}\");");
                }
                else
                {
                    methodBody.AppendLine($"\tAssert.AreEqual(v1.ToString(\"X\"), o1.ToString(), $\"{{v1}}\");");
                }
                methodBody.AppendLine("}");

                Indent(method, methodBody, 1);

                method.AppendLine("}");

                Indent(classBody, method, 0);
            }

            Indent(result, classBody, 1);
            EndClass(result, "ToString");
        }

        void Compare(StringBuilder result)
        {
            BeginClass(result, "Compare");

            var classBody = new StringBuilder();

            foreach (var from in Tools.OpTypes)
            {
                foreach (var to in Tools.OpTypes)
                {
                    var fromCap = Cap(from);
                    var toCap = Cap(to);

                    var ops = new Dictionary<string, string>()
                    {
                        { "==", "Equal" },
                        { "!=", "NotEqual" },
                        { "<", "Less" },
                        { "<=", "LessOrEqual" },
                        { ">", "Greater" },
                        { ">=", "GreaterOrEqual" },
                    };

                    foreach (var op in ops)
                    {
                        var type = op.Key;
                        var method = new StringBuilder();

                        method.AppendLine("[TestMethod]");
                        method.AppendLine($"public void {fromCap}{op.Value}{toCap}()");
                        method.AppendLine("{");

                        var methodBody = new StringBuilder();

                        OpValues(methodBody, "op1", from);
                        OpValues(methodBody, "op2", to);

                        methodBody.AppendLine("foreach (var v1 in op1)");
                        methodBody.AppendLine("{");
                        methodBody.AppendLine("\tvar o1 = new RTLBitArray(v1);");
                        methodBody.AppendLine("\tforeach (var v2 in op2)");
                        methodBody.AppendLine("\t{");
                        methodBody.AppendLine("\t\tvar o2 = new RTLBitArray(v2);");


                        var fromCast = "long";
                        var toCast = "long";

                        if (from == "bool")
                        {
                            if (to == "bool")
                            {
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})(v1 ? 1 : 0) {type} ({toCast})(v2 ? 1 : 0), o1 {type} o2, $\"{{v1}} {type} {{v2}}\");");
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})(v1 ? 1 : 0) {type} ({toCast})(v2 ? 1 : 0), v1 {type} o2, $\"{{v1}} {type} {{v2}}\");");
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})(v1 ? 1 : 0) {type} ({toCast})(v2 ? 1 : 0), o1 {type} v2, $\"{{v1}} {type} {{v2}}\");");
                            }
                            else
                            {
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})(v1 ? 1 : 0) {type} ({toCast})v2, o1 {type} o2, $\"{{v1}} {type} {{v2}}\");");
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})(v1 ? 1 : 0) {type} ({toCast})v2, v1 {type} o2, $\"{{v1}} {type} {{v2}}\");");
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})(v1 ? 1 : 0) {type} ({toCast})v2, o1 {type} v2, $\"{{v1}} {type} {{v2}}\");");
                            }
                        }
                        else
                        {
                            if (to == "bool")
                            {
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})v1 {type} ({toCast})(v2 ? 1 : 0), o1 {type} o2, $\"{{v1}} {type} {{v2}}\");");
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})v1 {type} ({toCast})(v2 ? 1 : 0), v1 {type} o2, $\"{{v1}} {type} {{v2}}\");");
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})v1 {type} ({toCast})(v2 ? 1 : 0), o1 {type} v2, $\"{{v1}} {type} {{v2}}\");");
                            }
                            else
                            {
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})v1 {type} ({toCast})v2, o1 {type} o2, $\"{{v1}} {type} {{v2}}\");");
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})v1 {type} ({toCast})v2, v1 {type} o2, $\"{{v1}} {type} {{v2}}\");");
                                methodBody.AppendLine($"\t\tAssert.AreEqual(({fromCast})v1 {type} ({toCast})v2, o1 {type} v2, $\"{{v1}} {type} {{v2}}\");");
                            }
                        }
                        methodBody.AppendLine("\t}");
                        methodBody.AppendLine("}");

                        Indent(method, methodBody, 1);

                        method.AppendLine("}");

                        Indent(classBody, method, 0);
                    }
                }
            }

            Indent(result, classBody, 1);

            EndClass(result, "Compare");
        }

        void Cast(StringBuilder result)
        {
            BeginClass(result, "Cast");
            var classBody = new StringBuilder();

            foreach (var from in Tools.AllTypes)
            {
                foreach (var to in Tools.AllTypes)
                {
                    var fromCap = Cap(from);
                    var toCap = Cap(to);

                    var method = new StringBuilder();

                    method.AppendLine("[TestMethod]");
                    method.AppendLine($"public void {fromCap}To{toCap}()");
                    method.AppendLine("{");

                    var methodBody = new StringBuilder();

                    OpValues(methodBody, "op1", from);

                    methodBody.AppendLine("foreach (var v1 in op1)");
                    methodBody.AppendLine("{");
                    if (from == "bool")
                    {
                        if (to == "bool")
                        {
                            methodBody.AppendLine($"\tAssert.AreEqual(v1, ({to})(new RTLBitArray(v1)));");
                        }
                        else
                        {
                            methodBody.AppendLine($"\tAssert.AreEqual(({to})(v1 ? 1 : 0), ({to})(new RTLBitArray(v1)));");
                        }
                    }
                    else
                    {
                        if (to == "bool")
                        {
                            methodBody.AppendLine($"\tAssert.AreEqual(((v1 & 1) == 1) ? true : false, ({to})(new RTLBitArray(v1)));");
                        }
                        else
                        {
                            methodBody.AppendLine($"\tAssert.AreEqual(({to})v1, ({to})(new RTLBitArray(v1)));");
                        }
                    }
                    methodBody.AppendLine("}");

                    Indent(method, methodBody, 1);

                    method.AppendLine("}");

                    Indent(classBody, method, 0);
                }
            }

            Indent(result, classBody, 1);

            EndClass(result, "Cast");
        }

        [TestMethod]
        public void Generate()
        {
            PartGenerator("Add", Add);
            PartGenerator("Sub", Sub);
            PartGenerator("Mult", Mult);
            PartGenerator("Compare", Compare);
            PartGenerator("Init", Init);
            PartGenerator("ToString", ToString);
            PartGenerator("Cast", Cast);
            PartGenerator("Shift", Shift);
            PartGenerator("Logic", Logic);

        }
    }
}
