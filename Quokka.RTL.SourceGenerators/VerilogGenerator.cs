﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.SourceGenerators.Verilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    [TestClass]
    public class VerilogGenerator
    {
        void AccessModifiers(List<string> modifiers, Type obj)
        {
            if (obj.IsPublic)
                modifiers.Add("public");
        }

        void InstanceModifiers(List<string> modifiers, Type obj)
        {
            if (obj.IsAbstract)
                modifiers.Add("abstract");
        }


        void Usings(VerilogGeneratorContext ctx, string namespaceSuffix = "")
        {
            var builder = ctx.builder;

            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Linq;");
            builder.AppendLine($"namespace Quokka.RTL.Verilog{namespaceSuffix}");
        }

        void VisitorInterface(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"public interface {obj.Name}VisitorInterface : {ctx.prefix}VisitorInterface<{obj.Name}> {{ }}");
            }
        }

        void VisitorImplementation(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            builder.AppendLine($"// generated implementations");
            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"public abstract class {obj.Name}VisitorGeneratedImplementation : vlgVisitorImplementation<{obj.Name}>, {obj.Name}VisitorInterface");
                builder.AppendLine("{");
                builder.AppendLine($"\tpublic {obj.Name}VisitorGeneratedImplementation(vlgVisitorImplementationDeps deps) : base(deps) {{ }}");
                builder.AppendLine("}");
            }

            builder.AppendLine($"// partial implementations");
            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"public partial class {obj.Name}VisitorImplementation : {obj.Name}VisitorGeneratedImplementation");
                builder.AppendLine("{");
                builder.AppendLine($"\tpublic {obj.Name}VisitorImplementation(vlgVisitorImplementationDeps deps) : base(deps) {{ }}");
                builder.AppendLine("}");
            }

            builder.AppendLine($"// visitor factory");
            builder.AppendLine($"public partial class {ctx.prefix}VisitorFactoryImplementation : {ctx.prefix}VisitorFactoryInterface");
            builder.AppendLine("{");
            builder.AppendLine($"\tpublic virtual vlgVisitorInterface Resolve(object obj)");
            builder.AppendLine("\t{");

            builder.AppendLine("\t\tswitch(obj)");
            builder.AppendLine("\t\t{");
            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"\t\t\tcase {obj.Name} o: return {obj.Name}Visitor(o);");
            }
            builder.AppendLine($"\t\t\tdefault: return VisitorInterface(obj);");
            builder.AppendLine("\t\t}");

            builder.AppendLine("\t}");
            
            builder.AppendLine($"\tprotected virtual {ctx.prefix}VisitorInterface VisitorInterface(object obj)");
            builder.AppendLine("\t{");
            builder.AppendLine($"\t\tthrow new Exception($\"Unsupported object type '{{obj.GetType()}}' in visitor resolver '{{GetType()}}'\");");
            builder.AppendLine("\t}");

            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"\tprivate {obj.Name}VisitorInterface {obj.Name}Visitor({obj.Name} obj)");
                builder.AppendLine("\t{");
                builder.AppendLine($"\t\treturn {obj.Name}Visitor(_deps, obj);");
                builder.AppendLine("\t}");
            }

            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"\tprotected virtual {obj.Name}VisitorInterface {obj.Name}Visitor(vlgVisitorImplementationDeps deps, {obj.Name} obj)");
                builder.AppendLine($"\t\t=> new {obj.Name}VisitorImplementation(deps);");
            }

            builder.AppendLine("}");
        }

        void VisitorImplementationTemplates(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;
            builder.AppendLine("/*");
            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"public partial class {obj.Name}VisitorImplementation");
                builder.AppendLine("{");
                builder.AppendLine($"\tpublic override void OnVisit({obj.Name} obj)");
                builder.AppendLine($"\t{{");
                builder.AppendLine($"\t}}");
                builder.AppendLine("}");
            }
            builder.AppendLine("*/");
        }

        void VerilogEnums(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;
            foreach (var e in ctx.enums)
            {
                builder.AppendLine($"public enum {e.Name}");
                builder.AppendLine("{");
                var names = Enum.GetNames(e);
                var values = Enum.GetValues(e).OfType<object>();
                var pairs = names.Zip(values, (n, v) => new { n, v });
                foreach (var p in pairs)
                {
                    builder.AppendLine($"\t{p.n} = {(int)p.v},");
                }
                builder.AppendLine("}");
            }
        }

        void VerilogInterfaces(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;
            foreach (var obj in ctx.interfaces)
            {
                var inheritance = new List<string>();
                ctx.Inheritance(inheritance, obj);

                builder.Append($"public partial interface {obj.Name}");
                if (inheritance.Any())
                {
                    builder.Append($" : {inheritance.ToCSV()}");
                }
                builder.AppendLine();
                builder.AppendLine("{");

                foreach (var p in ctx.OwnProperties(obj))
                {
                    var propertyTypeName = ctx.PropertyType(p.PropertyType);
                    builder.AppendLine($"\t{propertyTypeName} {p.Name} {{ get; set; }}");
                }
                builder.AppendLine("}");
            }
        }

        void VerilogAST(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            foreach (var obj in ctx.objects)
            {
                var modifiers = new List<string>();
                AccessModifiers(modifiers, obj);
                InstanceModifiers(modifiers, obj);

                var inheritance = new List<string>();
                ctx.Inheritance(inheritance, obj);

                builder.Append($"{string.Join(" ", modifiers)} partial class {obj.Name}");
                if (inheritance.Any())
                {
                    builder.Append($" : {inheritance.ToCSV()}");
                }
                builder.AppendLine();
                builder.AppendLine("{");

                builder.AppendLine($"\tpublic {obj.Name}() {{ }}");

                var props = ctx.AllProperties(obj);

                var singleModelObjProp = ctx.SingleModelProperty(obj);
                if (singleModelObjProp != null)
                {
                    var singleCtorArgs = ctx.CtorParamsDecl(singleModelObjProp.PropertyType);
                    var singleCtorParamsNames = ctx.CtorParamNames(singleModelObjProp.PropertyType);
                    var singleCtorParamsTypes = ctx.CtorParameters(singleModelObjProp.PropertyType);

                    if (singleCtorParamsTypes.Any())
                    {
                        builder.AppendLine($"\tpublic {obj.Name}({singleCtorArgs.ToCSV()})");
                        builder.AppendLine($"\t{{");
                        builder.AppendLine($"\t\tthis.{singleModelObjProp.Name} = new {singleModelObjProp.PropertyType.Name}({singleCtorParamsNames.ToCSV()});");
                        builder.AppendLine($"\t}}");

                        if (singleCtorParamsTypes.Count > 1 && singleCtorParamsTypes.Last().PropertyType.IsList())
                        {
                            builder.AppendLine($"\tpublic {obj.Name}({singleCtorArgs.Take(singleCtorParamsTypes.Count - 1).ToCSV()})");
                            builder.AppendLine($"\t{{");
                            builder.AppendLine($"\t\tthis.{singleModelObjProp.Name} = new {singleModelObjProp.PropertyType.Name}({singleCtorParamsNames.Take(singleCtorParamsTypes.Count - 1).ToCSV()});");
                            builder.AppendLine($"\t}}");
                        }
                    }
                }
                
                Action<List<PropertyInfo>> ctor = (ctorParams) =>
                {
                    if (!ctorParams.Any())
                        return;

                    var ctorArgs = ctx.CtorParamsDecl(ctorParams);
                    builder.AppendLine($"\tpublic {obj.Name}({ctorArgs.ToCSV()})");
                    builder.AppendLine($"\t{{");
                    foreach (var p in ctorParams)
                    {
                        if (p.PropertyType.IsList())
                        {
                            builder.AppendLine($"\t\tthis.{p.Name} = {p.Name}?.ToList() ?? new List<{ctx.PropertyType(p.PropertyType.GetGenericArguments()[0])}>();");
                        }
                        else
                        {
                            builder.AppendLine($"\t\tthis.{p.Name} = {p.Name};");
                        }
                    }
                    builder.AppendLine($"\t}}");
                };

                // object ctor
                var ctorParams = ctx.CtorParameters(obj);
                ctor(ctorParams);

                if (ctorParams.Count > 1 && ctorParams.Last().PropertyType.IsList())
                {
                    ctor(ctorParams.Take(ctorParams.Count - 1).ToList());
                }

                // object properties
                foreach (var p in ctx.OwnProperties(obj))
                {
                    var propertyTypeName = ctx.PropertyType(p.PropertyType);

                    if (p.PropertyType.IsList())
                    {
                        var elementType = p.PropertyType.GetGenericArguments()[0];
                        if (elementType.IsAbstract || elementType.IsInterface)
                        {
                            builder.AppendLine("\t/// <summary>");
                            var derived = ctx.DerivedNonAbstract(p.PropertyType.GetGenericArguments()[0]);
                            foreach (var d in derived)
                            {
                                builder.AppendLine($"\t/// {d.Name}");
                            }
                            builder.AppendLine("\t/// </summary>");
                        }
                    }

                    builder.Append($"\tpublic {propertyTypeName} {p.Name} {{ get; set; }}");

                    if (p.PropertyType.IsClass && !p.PropertyType.IsAbstract && p.PropertyType != typeof(string))
                    {
                        builder.Append($" = new {propertyTypeName}();");
                    }

                    builder.AppendLine();
                }

                builder.AppendLine("}");
            }
        }

        void VerilogImplicit(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            foreach (var obj in ctx.objects)
            {
                var modifiers = new List<string>();
                AccessModifiers(modifiers, obj);
                InstanceModifiers(modifiers, obj);

                var inheritance = new List<string>();
                ctx.Inheritance(inheritance, obj);

                builder.Append($"{string.Join(" ", modifiers)} partial class {obj.Name}");
                if (inheritance.Any())
                {
                    builder.Append($" : {inheritance.ToCSV()}");
                }
                builder.AppendLine();
                builder.AppendLine("{");

                var implicitOperators = ctx.ImplicitOperators(obj);

                foreach (var iop in implicitOperators)
                {
                    builder.AppendLine($"\tpublic static implicit operator {iop.TargetType.Name}({iop.ParamsLine})");
                    builder.AppendLine($"\t{{");
                    builder.AppendLine($"\t\treturn new {iop.TargetType.Name}({iop.ArgsLine});");
                    builder.AppendLine($"\t}}");
                }

                builder.AppendLine("}");
            }
        }


        void VerilogQueries(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            foreach (var obj in ctx.objects)
            {
                var modifiers = new List<string>();
                AccessModifiers(modifiers, obj);
                InstanceModifiers(modifiers, obj);

                var inheritance = new List<string>();
                ctx.Inheritance(inheritance, obj);

                builder.AppendLine($"{string.Join(" ", modifiers)} partial class {obj.Name}");
                builder.AppendLine("{");

                var asQueryTypes = ctx.AsQueryTypes(obj);

                foreach (var child in asQueryTypes)
                {
                    builder.AppendLine($"\tpublic IEnumerable<{child.Name}> As{child.Name.Substring(3)} => Children.OfType<{child.Name}>();");
                }

                builder.AppendLine("}");
            }
        }

        void VerilogFluent(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            foreach (var obj in ctx.objects)
            {
                var modifiers = new List<string>();
                AccessModifiers(modifiers, obj);
                InstanceModifiers(modifiers, obj);

                var inheritance = new List<string>();
                ctx.Inheritance(inheritance, obj);

                builder.AppendLine($"{string.Join(" ", modifiers)} partial class {obj.Name}");
                builder.AppendLine("{");

                var typedChildren = ctx.FluentTypes(obj);

                foreach (var child in typedChildren)
                {
                    var childCtorParams = ctx.CtorParamsDecl(child);

                    if (childCtorParams.Any())
                    {
                        builder.AppendLine($"\t//{child.Name}");
                        builder.AppendLine($"\tpublic {obj.Name} With{child.Name.Substring(3)}({childCtorParams.ToCSV()})");
                        builder.AppendLine($"\t{{");
                        builder.AppendLine($"\t\tthis.Children.Add(new {child.Name}({ctx.CtorParamNames(child).ToCSV()}));");
                        builder.AppendLine($"\t\treturn this;");
                        builder.AppendLine($"\t}}");
                    }

                    builder.AppendLine($"\tpublic {obj.Name} With{child.Name.Substring(3)}({child.Name} obj)");
                    builder.AppendLine($"\t{{");
                    builder.AppendLine($"\t\tif (obj != null) Children.Add(obj);");
                    builder.AppendLine($"\t\treturn this;");
                    builder.AppendLine($"\t}}");
                }

                builder.AppendLine("}");
            }
        }

        void GenerateFile(
            VerilogGeneratorContext ctx, 
            Action<VerilogGeneratorContext> generator, 
            string fileName, 
            string namespaceSuffix = "")
        {
            ctx.builder = new StringBuilder();
            Usings(ctx, namespaceSuffix);

            var builder = ctx.builder;
            builder.AppendLine("{");
            builder.AppendLine($"using Quokka.RTL.Tools;");

            generator(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"{fileName}.cs"),
                builder.ToString()
            );
        }

        [TestMethod]
        public void Generate()
        {
            var ctx = new VerilogGeneratorContext();
            ctx.Validate();

            GenerateFile(ctx, VisitorImplementationTemplates, "visitors.implementation.templates", ".Implementation");
            GenerateFile(ctx, VisitorImplementation, "visitors.implementation", ".Implementation");
            GenerateFile(ctx, VisitorInterface, "visitors.interface");
            GenerateFile(ctx, VerilogQueries, "queries");
            GenerateFile(ctx, VerilogFluent, "fluent");
            GenerateFile(ctx, VerilogAST, "ast");
            GenerateFile(ctx, VerilogImplicit, "implicit");
            GenerateFile(ctx, VerilogInterfaces, "interface");
            GenerateFile(ctx, VerilogEnums, "enums");
        }
    }
}
