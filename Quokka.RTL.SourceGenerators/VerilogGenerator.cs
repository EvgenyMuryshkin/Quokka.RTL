using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            foreach (var obj in ctx.vlgVisitors)
            {
                builder.AppendLine($"public interface {obj.Name}VisitorInterface : {ctx.vlgPrefix}VisitorInterface<{obj.Name}> {{ }}");
            }
        }

        void VisitorImplementation(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            builder.AppendLine($"// generated implementations");
            foreach (var obj in ctx.vlgVisitors)
            {
                builder.AppendLine($"public abstract class {obj.Name}VisitorGeneratedImplementation : vlgVisitorImplementation<{obj.Name}>, {obj.Name}VisitorInterface");
                builder.AppendLine("{");
                builder.AppendLine($"\tpublic {obj.Name}VisitorGeneratedImplementation(vlgVisitorImplementationDeps deps) : base(deps) {{ }}");
                builder.AppendLine("}");
            }

            builder.AppendLine($"// partial implementations");
            foreach (var obj in ctx.vlgVisitors)
            {
                builder.AppendLine($"public partial class {obj.Name}VisitorImplementation : {obj.Name}VisitorGeneratedImplementation");
                builder.AppendLine("{");
                builder.AppendLine($"\tpublic {obj.Name}VisitorImplementation(vlgVisitorImplementationDeps deps) : base(deps) {{ }}");
                builder.AppendLine("}");
            }

            builder.AppendLine($"// visitor factory");
            builder.AppendLine($"public partial class {ctx.vlgPrefix}VisitorFactoryImplementation : {ctx.vlgPrefix}VisitorFactoryInterface");
            builder.AppendLine("{");
            builder.AppendLine($"\tpublic virtual vlgVisitorInterface Resolve(object obj)");
            builder.AppendLine("\t{");

            builder.AppendLine("\t\tswitch(obj)");
            builder.AppendLine("\t\t{");
            foreach (var obj in ctx.vlgVisitors)
            {
                builder.AppendLine($"\t\t\tcase {obj.Name} o: return {obj.Name}Visitor(o);");
            }
            builder.AppendLine($"\t\t\tdefault: return VisitorInterface(obj);");
            builder.AppendLine("\t\t}");

            builder.AppendLine("\t}");
            
            builder.AppendLine($"\tprotected virtual {ctx.vlgPrefix}VisitorInterface VisitorInterface(object obj)");
            builder.AppendLine("\t{");
            builder.AppendLine($"\t\tthrow new Exception($\"Unsupported object type '{{obj.GetType()}}' in visitor resolver '{{GetType()}}'\");");
            builder.AppendLine("\t}");

            foreach (var obj in ctx.vlgVisitors)
            {
                builder.AppendLine($"\tprivate {obj.Name}VisitorInterface {obj.Name}Visitor({obj.Name} obj)");
                builder.AppendLine("\t{");
                builder.AppendLine($"\t\treturn {obj.Name}Visitor(_deps, obj);");
                builder.AppendLine("\t}");
            }

            foreach (var obj in ctx.vlgVisitors)
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
            foreach (var obj in ctx.vlgVisitors)
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

        void TopLevelVisitor(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            foreach (var parent in ctx.vlgVisitors)
            {
                builder.AppendLine($"public abstract class {parent.Name}AbstractVisitor");
                builder.AppendLine("{");
                builder.AppendLine("\tprotected readonly IndentedStringBuilder _builder;");
                builder.AppendLine("\tprotected readonly vlgFormatters _formatters;");
                builder.AppendLine($"\tpublic {parent.Name}AbstractVisitor(IndentedStringBuilder builder)");
                builder.AppendLine("\t{");
                builder.AppendLine("\t\t_builder = builder;");
                builder.AppendLine("\t\t_formatters = new vlgFormatters();");
                builder.AppendLine("\t}");

                builder.AppendLine($"\tprotected abstract void OnVisit({parent.Name} obj);");
                builder.AppendLine($"\tpublic void Visit({parent.Name} obj) => OnVisit(obj);");

                var childrenType = ctx.ChildrenType(parent);
                if (childrenType != null)
                {
                    var typedChildren = ctx.DerivedNonAbstract(childrenType);

                    builder.AppendLine($"\tprotected virtual void OnUnsupported({childrenType.Name} obj)");
                    builder.AppendLine("\t{");
                    builder.AppendLine("\t\tthrow new NotImplementedException($\"Object type is not supported in visitor '{GetType().Name}': {obj.GetType().Name}\");");
                    builder.AppendLine("\t}");

                    foreach (var obj in typedChildren)
                    {
                        builder.AppendLine($"\tprotected abstract void OnVisit({obj.Name} obj);");
                    }

                    builder.AppendLine($"\tpublic void Visit({childrenType.Name} obj)");
                    builder.AppendLine("\t{");
                    builder.AppendLine("\t\tif (obj == null) return;");

                    builder.AppendLine("\t\tswitch(obj)");
                    builder.AppendLine("\t\t{");
                    foreach (var obj in typedChildren)
                    {
                        builder.AppendLine($"\t\t\tcase {obj.Name} o: OnVisit(o); break;");
                    }
                    builder.AppendLine($"\t\t\tdefault: OnUnsupported(obj); break;");
                    builder.AppendLine("\t\t} // switch");
                    builder.AppendLine("\t} // Visit");
                }

                builder.AppendLine($"}} // {parent.Name}Visitor");
            }
            /*
            foreach (var type in ctx.vlgDerivedVisitors)
            {
                var derivedTypes = ctx.DerivedNonAbstract(type);
                var abstractClassName = $"{type.Name}DerivedAbstractVisitor";
                builder.AppendLine($"public abstract class {abstractClassName}");
                builder.AppendLine($"{{");
                builder.AppendLine("\tprotected readonly vlgFormatters _formatters;");

                builder.AppendLine($"\tpublic {abstractClassName}()");
                builder.AppendLine("\t{");
                builder.AppendLine("\t\t_formatters = new vlgFormatters();");
                builder.AppendLine("\t}");


                builder.AppendLine($"\tpublic virtual void Visit({type.Name} obj)");
                builder.AppendLine($"\t{{");
                builder.AppendLine("\t\tswitch(obj)");
                builder.AppendLine("\t\t{");
                foreach (var obj in derivedTypes)
                {
                    builder.AppendLine($"\t\t\tcase {obj.Name} o: OnVisit(o); break;");
                }
                builder.AppendLine($"\t\t\tdefault: OnUnsupported(obj); break;");
                builder.AppendLine("\t\t} // switch");

                builder.AppendLine($"\t}}");
                
                foreach (var obj in derivedTypes)
                {
                    builder.AppendLine($"\tprotected abstract void OnVisit({obj.Name} obj);");
                }

                builder.AppendLine($"\tprotected virtual void OnUnsupported({type.Name} obj)");
                builder.AppendLine("\t{");
                builder.AppendLine("\t\tthrow new NotImplementedException($\"Object type is not supported in visitor '{GetType().Name}': {obj.GetType().Name}\");");
                builder.AppendLine("\t}");
                builder.AppendLine($"}} // {abstractClassName}");
            }
            */
            /*
            builder.AppendLine($"public abstract class vlgTopLevelVisitor");
            builder.AppendLine("{");
            foreach (var obj in ctx.topLevelObjects)
            {
                builder.AppendLine($"\tprotected abstract void OnVisit({obj.Name} obj);");
            }
            builder.AppendLine($"\tprotected abstract void OnUnsupported(vlgTopLevelObject obj);");

            builder.AppendLine($"\tpublic void Visit(vlgTopLevelObject obj)");
            builder.AppendLine("\t{");
            builder.AppendLine("\t\tif (obj == null) return;");

            builder.AppendLine("\t\tswitch(obj)");
            builder.AppendLine("\t\t{");
            foreach (var obj in ctx.topLevelObjects)
            {
                builder.AppendLine($"\t\t\tcase {obj.Name} o: OnVisit(o); break;");
            }
            builder.AppendLine($"\t\t\tdefault: OnUnsupported(obj); break;");
            builder.AppendLine("\t\t} // switch");
            builder.AppendLine("\t} // Visit");

            builder.AppendLine("} // vlgTopLevelVisitor");
            */
        }


        void VerilogEnums(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;
            foreach (var e in ctx.vlgEnums)
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
            foreach (var obj in ctx.vlgInterfaces)
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

            foreach (var obj in ctx.vlgObjects)
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
                            builder.AppendLine($"\t\tif ({p.Name} != null)");
                            builder.AppendLine($"\t\t\tthis.{p.Name} = {p.Name}.ToList();");
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

                if (!obj.IsAbstract && ctorParams.Count == 2 && ctorParams.Last().PropertyType.IsList())
                {
                    var ctorArgs = ctx.CtorParamsDecl(obj).Take(1); ;
                    builder.AppendLine($"\tpublic static implicit operator {obj.Name}({ctorArgs.ToCSV()})");
                    builder.AppendLine($"\t{{");
                    builder.AppendLine($"\t\treturn new {obj.Name}({ctorParams.Take(1).Select(p => p.Name).ToCSV()});");
                    builder.AppendLine($"\t}}");
                }


                if (!obj.IsAbstract && ctorParams.Count == 1)
                {
                    var singleProperty = ctorParams[0];

                    if (singleProperty.PropertyType.IsList())
                    {
                        var listItemType = singleProperty.PropertyType.GetGenericArguments()[0];

                        if (listItemType.IsInterface || listItemType.IsAbstract)
                        {
                            var derived = ctx.DerivedNonAbstract(listItemType);

                            foreach (var d in derived)
                            {
                                builder.AppendLine($"\tpublic static implicit operator {obj.Name}({ctx.PropertyType(d)} single)");
                                builder.AppendLine($"\t{{");
                                builder.AppendLine($"\t\treturn new {obj.Name}(new [] {{ single }});");
                                builder.AppendLine($"\t}}");
                            }
                        }
                        else
                        {
                            var singlePropertyTypeName = ctx.PropertyType(listItemType);

                            builder.AppendLine($"\tpublic static implicit operator {obj.Name}({singlePropertyTypeName} single)");
                            builder.AppendLine($"\t{{");
                            builder.AppendLine($"\t\treturn new {obj.Name}(new [] {{ single }});");
                            builder.AppendLine($"\t}}");
                        }
                    }
                    else
                    {
                        if (singleProperty.PropertyType.IsInterface || singleProperty.PropertyType.IsAbstract)
                        {
                            var derived = ctx.DerivedNonAbstract(singleProperty.PropertyType);

                            foreach (var d in derived)
                            {
                                builder.AppendLine($"\tpublic static implicit operator {obj.Name}({ctx.PropertyType(d)} {singleProperty.Name})");
                                builder.AppendLine($"\t{{");
                                builder.AppendLine($"\t\treturn new {obj.Name}({singleProperty.Name});");
                                builder.AppendLine($"\t}}");
                            }
                        }
                        else
                        {
                            var ctorArgs = ctx.CtorParamsDecl(obj);
                            builder.AppendLine($"\tpublic static implicit operator {obj.Name}({ctorArgs.ToCSV()})");
                            builder.AppendLine($"\t{{");
                            builder.AppendLine($"\t\treturn new {obj.Name}({ctorParams.Select(p => p.Name).ToCSV()});");
                            builder.AppendLine($"\t}}");
                        }
                    }
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

        void VerilogQueries(VerilogGeneratorContext ctx)
        {
            var builder = ctx.builder;

            foreach (var obj in ctx.vlgObjects)
            {
                var modifiers = new List<string>();
                AccessModifiers(modifiers, obj);
                InstanceModifiers(modifiers, obj);

                var inheritance = new List<string>();
                ctx.Inheritance(inheritance, obj);

                builder.AppendLine($"{string.Join(" ", modifiers)} partial class {obj.Name}");
                builder.AppendLine("{");

                if (!obj.IsAbstract)
                {
                    var childrenType = ctx.ChildrenType(obj);
                    if (childrenType != null)
                    {
                        var typedChildren = ctx.DerivedNonAbstract(childrenType);
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

                        foreach (var child in typedChildren)
                        {
                            builder.AppendLine($"\tpublic IEnumerable<{child.Name}> As{child.Name.Substring(3)} => Children.OfType<{child.Name}>();");
                        }

                        var baseTypes = ctx.UnwrapBaseTypes(typedChildren.ToList());
                        foreach (var child in baseTypes)
                        {
                            builder.AppendLine($"\tpublic IEnumerable<{child.Name}> As{child.Name.Substring(3)} => Children.OfType<{child.Name}>();");
                        }
                    }                    
                }

                builder.AppendLine("}");
            }
        }

        void GenerateEnums(VerilogGeneratorContext ctx)
        {
            ctx.builder = new StringBuilder();
            Usings(ctx);

            var builder = ctx.builder;
            builder.AppendLine("{");

            VerilogEnums(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"enums.cs"),
                builder.ToString()
            );
        }

        void GenerateInterface(VerilogGeneratorContext ctx)
        {
            ctx.builder = new StringBuilder();
            Usings(ctx);

            var builder = ctx.builder;
            builder.AppendLine("{");

            VerilogInterfaces(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"interface.cs"),
                builder.ToString()
            );
        }

        void GenerateAST(VerilogGeneratorContext ctx)
        {
            ctx.builder = new StringBuilder();
            Usings(ctx);

            var builder = ctx.builder;
            builder.AppendLine("{");

            VerilogAST(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"ast.cs"),
                builder.ToString()
            );
        }

        void GenerateQueries(VerilogGeneratorContext ctx)
        {
            ctx.builder = new StringBuilder();
            Usings(ctx);

            var builder = ctx.builder;
            builder.AppendLine("{");

            VerilogQueries(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"queries.cs"),
                builder.ToString()
            );
        }

        void GenerateVisitors(VerilogGeneratorContext ctx)
        {
            ctx.builder = new StringBuilder();
            Usings(ctx);

            var builder = ctx.builder;
            builder.AppendLine("{");
            builder.AppendLine($"using Quokka.RTL.Tools;");

            TopLevelVisitor(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"visitors.cs"),
                builder.ToString()
            );
        }

        void GenerateVisitorInterface(VerilogGeneratorContext ctx)
        {
            ctx.builder = new StringBuilder();
            Usings(ctx);

            var builder = ctx.builder;
            builder.AppendLine("{");
            builder.AppendLine($"using Quokka.RTL.Tools;");

            VisitorInterface(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"visitors.interface.cs"),
                builder.ToString()
            );
        }

        void GenerateVisitorImplementation(VerilogGeneratorContext ctx)
        {
            ctx.builder = new StringBuilder();
            Usings(ctx, ".Implementation");

            var builder = ctx.builder;
            builder.AppendLine("{");
            builder.AppendLine($"using Quokka.RTL.Tools;");

            VisitorImplementation(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"visitors.implementation.cs"),
                builder.ToString()
            );
        }

        void GenerateVisitorImplementationTemplates(VerilogGeneratorContext ctx)
        {
            ctx.builder = new StringBuilder();
            Usings(ctx, ".Implementation");

            var builder = ctx.builder;
            builder.AppendLine("{");
            builder.AppendLine($"using Quokka.RTL.Tools;");

            VisitorImplementationTemplates(ctx);

            builder.AppendLine("} // Quokka.RTL.Verilog");
            Tools.WriteAllTextIfChanged(
                Path.Combine(Tools.VerilogSourcePath, $"visitors.implementation.templates.cs"),
                builder.ToString()
            );
        }

        [TestMethod]
        public void Generate()
        {
            var ctx = new VerilogGeneratorContext();
            ctx.Validate();

            GenerateEnums(ctx);
            GenerateInterface(ctx);
            GenerateAST(ctx);
            GenerateQueries(ctx);
            GenerateVisitorInterface(ctx);
            GenerateVisitorImplementation(ctx);
            GenerateVisitorImplementationTemplates(ctx);
            //GenerateVisitors(ctx);
        }
    }
}
