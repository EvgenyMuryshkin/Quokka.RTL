using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    public abstract class HDLModelGenerator
    {
        protected abstract string SourcePath { get; }

        protected void AccessModifiers(List<string> modifiers, Type obj)
        {
            if (obj.IsPublic)
                modifiers.Add("public");
        }

        protected void InstanceModifiers(List<string> modifiers, Type obj)
        {
            if (obj.IsAbstract)
                modifiers.Add("abstract");
        }

        protected void Usings(GeneratorContext ctx, string namespaceSuffix = "")
        {
            var builder = ctx.builder;

            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Linq;");
            builder.AppendLine($"namespace Quokka.RTL.{ctx.ns}{namespaceSuffix}");
        }

        protected void VisitorInterface(GeneratorContext ctx)
        {
            var builder = ctx.builder;

            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"public interface {obj.Name}VisitorInterface : {ctx.prefix}VisitorInterface<{obj.Name}> {{ }}");
            }
        }

        protected void VisitorImplementation(GeneratorContext ctx)
        {
            var builder = ctx.builder;

            builder.AppendLine($"// generated implementations");
            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"public abstract class {obj.Name}VisitorGeneratedImplementation : {ctx.prefix}VisitorImplementation<{obj.Name}>, {obj.Name}VisitorInterface");
                builder.AppendLine("{");
                builder.AppendLine($"\tpublic {obj.Name}VisitorGeneratedImplementation({ctx.prefix}VisitorImplementationDeps deps) : base(deps) {{ }}");
                builder.AppendLine("}");
            }

            builder.AppendLine($"// partial implementations");
            foreach (var obj in ctx.visitors)
            {
                builder.AppendLine($"public partial class {obj.Name}VisitorImplementation : {obj.Name}VisitorGeneratedImplementation");
                builder.AppendLine("{");
                builder.AppendLine($"\tpublic {obj.Name}VisitorImplementation({ctx.prefix}VisitorImplementationDeps deps) : base(deps) {{ }}");
                builder.AppendLine("}");
            }

            builder.AppendLine($"// visitor factory");
            builder.AppendLine($"public partial class {ctx.prefix}VisitorFactoryImplementation : {ctx.prefix}VisitorFactoryInterface");
            builder.AppendLine("{");
            builder.AppendLine($"\tpublic virtual {ctx.prefix}VisitorInterface Resolve(object obj)");
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
                builder.AppendLine($"\tprotected virtual {obj.Name}VisitorInterface {obj.Name}Visitor({ctx.prefix}VisitorImplementationDeps deps, {obj.Name} obj)");
                builder.AppendLine($"\t\t=> new {obj.Name}VisitorImplementation(deps);");
            }

            builder.AppendLine("}");
        }

        protected void VisitorImplementationTemplates(GeneratorContext ctx)
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

        protected void Enums(GeneratorContext ctx)
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

        protected void Interfaces(GeneratorContext ctx)
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

        protected void AST(GeneratorContext ctx)
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

                    /*
                    foreach (var iop in ctx.ImplicitOperators(obj).Where(i => i.Params.Count == 1 && ctx.objects.Contains(i.Params[0].Type)))
                    {
                        builder.AppendLine("/*");
                        foreach (var ctorVariant in ctx.CtorVariants(iop.Params[0].Type))
                        {
                            builder.AppendLine($"\t//{iop.ParamsLine}({ctorVariant.Select(p => p.PropertyType.Name).ToCSV()}");
                        }
                        builder.AppendLine("* /");
                    }
                    */
                }
                /*
                if (!obj.IsAbstract)
                {
                    var singleObjListModelProp = ctx.SingleModelListProperty(obj);
                    if (singleObjListModelProp != null)
                    {
                        var itemType = singleObjListModelProp.PropertyType.GetGenericArguments()[0];
                        var derived = ctx.DerivedNonAbstract(itemType);
                        foreach (var d in derived)
                        {
                            builder.AppendLine($"\t//{d.Name}");
                        }
                    }
                }
                */


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
                            builder.AppendLine($"\t\tthis.{p.Name} = ({p.Name} ?? Array.Empty<{ctx.PropertyType(p.PropertyType.GetGenericArguments()[0])}>()).Where(s => s != null).ToList();");
                        }
                        else
                        {
                            builder.AppendLine($"\t\tthis.{p.Name} = {p.Name};");
                        }
                    }
                    builder.AppendLine($"\t}}");

                    if (ctorParams.Count == 1)
                    {
                        if (ctx.objects.Contains(ctorParams[0].PropertyType))
                        {
                            var derived = ctx.DerivedNonAbstract(ctorParams[0].PropertyType).Where(t => t != ctorParams[0].PropertyType);
                            if (derived.Any())
                            {
                                foreach (var d in derived)
                                {
                                    foreach (var ctorVariant in ctx.CtorVariants(d))
                                    {
                                        var derivedCtorArgs = ctx.CtorParamsDecl(ctorVariant);
                                        var derivedCtorParamNames = ctorVariant.Select(p => p.Name).ToCSV();
                                        builder.AppendLine($"\t// from {d.Name}");
                                        builder.AppendLine($"\tpublic {obj.Name}({derivedCtorArgs.ToCSV()})");
                                        builder.AppendLine($"\t{{");
                                        builder.AppendLine($"\t\tthis.{ctorParams[0].Name} = new {d.Name}({derivedCtorParamNames});");
                                        builder.AppendLine($"\t}}");
                                    }
                                }
                            }
                        }

                        if (ctorParams[0].PropertyType.IsList())
                        {
                            var derived = ctx.DerivedNonAbstract(ctorParams[0].PropertyType.GetGenericArguments()[0]).Where(t => t != ctorParams[0].PropertyType);
                            if (derived.Any())
                            {
                                foreach (var d in derived)
                                {
                                    foreach (var ctorVariant in ctx.CtorVariants(d))
                                    {
                                        var derivedCtorArgs = ctx.CtorParamsDecl(ctorVariant);
                                        var derivedCtorParamNames = ctorVariant.Select(p => p.Name).ToCSV();
                                        builder.AppendLine($"\t// from {d.Name}");
                                        builder.AppendLine($"\tpublic {obj.Name}({derivedCtorArgs.ToCSV()})");
                                        builder.AppendLine($"\t{{");
                                        builder.AppendLine($"\t\tthis.{ctorParams[0].Name}.Add(new {d.Name}({derivedCtorParamNames}));");
                                        builder.AppendLine($"\t}}");
                                    }
                                }
                            }

                        }
                    }
                };

                // object ctor

                foreach (var ctorVariant in ctx.CtorVariants(obj))
                {
                    ctor(ctorVariant);
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

        protected void Implicit(GeneratorContext ctx)
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

                    var leading = iop.ChainedTypes.Select(t => $"new {t.Name}(").StringJoin("");
                    var trailing = iop.ChainedTypes.Select(t => $")").StringJoin("");
                    builder.AppendLine($"\t\treturn {leading}{iop.ArgsLine}{trailing};");

                    builder.AppendLine($"\t}}");

                    continue;
                    if (iop.Params.Count == 1)
                    {
                        var paramType = iop.Params[0].Type;
                        if (ctx.objects.Contains(paramType))
                        {
                            foreach (var parmTypeCtor in ctx.CtorVariants(paramType).Where(t => t.Count == 1))
                            {
                                var paramTypeCtorParams = ctx.CtorParamsDecl(parmTypeCtor);
                                var paramTypeCtorParamNames = parmTypeCtor.Select(p => p.Name);

                                builder.AppendLine($"\tpublic static implicit operator {iop.TargetType.Name}({paramTypeCtorParams.ToCSV()})");
                                builder.AppendLine($"\t{{");
                                builder.AppendLine($"\t\treturn new {iop.TargetType.Name}(new {paramType.Name}({paramTypeCtorParamNames.ToCSV()}));");
                                builder.AppendLine($"\t}}");
                            }

                            var paramTypeProps = ctx.CtorParameters(paramType);
                            if (paramTypeProps.Count == 1)
                            {
                                var paramTypeCtorParams = ctx.CtorParamsDecl(paramType);
                                var paramTypeCtorParamNames = ctx.CtorParamNames(paramType);

                                builder.AppendLine($"\tpublic static implicit operator {iop.TargetType.Name}({paramTypeCtorParams.ToCSV()})");
                                builder.AppendLine($"\t{{");
                                builder.AppendLine($"\t\treturn new {iop.TargetType.Name}(new {paramType.Name}({paramTypeCtorParamNames.ToCSV()}));");
                                builder.AppendLine($"\t}}");

                                var paramTypeCtorTypes = ctx.CtorVariants(paramType);

                                foreach (var ctorVariant in paramTypeCtorTypes.Where(t => t.Count == 1))
                                {
                                    if (ctx.objects.Contains(ctorVariant[0].PropertyType))
                                    {
                                        var derivedCtorVariants = ctx.CtorVariants(ctorVariant[0].PropertyType);
                                        foreach (var v in derivedCtorVariants.Where(t => t.Count == 1))
                                        {
                                            var derivedCtorArgs = ctx.CtorParamsDecl(v);
                                            var derivedCtorParamNames = v.Select(p => p.Name);

                                            builder.AppendLine($"\tpublic static implicit operator {iop.TargetType.Name}({derivedCtorArgs.ToCSV()})");
                                            builder.AppendLine($"\t{{");
                                            builder.AppendLine($"\t\treturn new {iop.TargetType.Name}(new {paramType.Name}({derivedCtorParamNames.ToCSV()}));");
                                            builder.AppendLine($"\t}}");


                                            //builder.AppendLine($"\t// {ctorVariant[0].PropertyType.Name} {derivedCtorArgs.ToCSV()}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                builder.AppendLine("}");
            }
        }


        protected void Queries(GeneratorContext ctx)
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

        protected void Fluent(GeneratorContext ctx)
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
                    var childCtorProps = ctx.CtorParameters(child);
                    var childCtorParams = ctx.CtorParamsDecl(child);

                    builder.AppendLine($"\t//{child.Name}");

                    builder.AppendLine($"\tpublic {obj.Name} With{child.Name.Substring(3)}({child.Name} obj)");
                    builder.AppendLine($"\t{{");
                    builder.AppendLine($"\t\tif (obj != null) Children.Add(obj);");
                    builder.AppendLine($"\t\treturn this;");
                    builder.AppendLine($"\t}}");

                    if (childCtorParams.Any())
                    {
                        builder.AppendLine($"\tpublic {obj.Name} With{child.Name.Substring(3)}({childCtorParams.ToCSV()})");
                        builder.AppendLine($"\t{{");
                        builder.AppendLine($"\t\tthis.Children.Add(new {child.Name}({ctx.CtorParamNames(child).ToCSV()}));");
                        builder.AppendLine($"\t\treturn this;");
                        builder.AppendLine($"\t}}");

                        if (childCtorProps.Count == 1 && ctx.objects.Contains(childCtorProps[0].PropertyType))
                        {
                            var forwardType = childCtorProps[0].PropertyType;
                            var forwardCtorParams = ctx.CtorParamsDecl(forwardType);
                            var forwardCtorParamNames = ctx.CtorParamNames(forwardType);

                            builder.AppendLine($"\tpublic {obj.Name} With{child.Name.Substring(3)}({forwardCtorParams.ToCSV()})");
                            builder.AppendLine($"\t{{");
                            builder.AppendLine($"\t\tthis.Children.Add(new {child.Name}({forwardCtorParamNames.ToCSV()}));");
                            builder.AppendLine($"\t\treturn this;");
                            builder.AppendLine($"\t}}");
                        }
                    }
                }

                builder.AppendLine("}");
            }
        }

        protected void GenerateFile(
            GeneratorContext ctx,
            Action<GeneratorContext> generator,
            string fileName,
            string namespaceSuffix = "")
        {
            ctx.builder = new StringBuilder();
            Usings(ctx, namespaceSuffix);

            var builder = ctx.builder;
            builder.AppendLine("{");
            builder.AppendLine($"using Quokka.RTL.Tools;");

            generator(ctx);

            builder.AppendLine($"}} // Quokka.RTL.{ctx.ns}");
            Tools.WriteAllTextIfChanged(Path.Combine(SourcePath, $"{fileName}.cs"), builder.ToString());
        }
    }
}
