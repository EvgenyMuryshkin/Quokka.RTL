using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            builder.AppendLine("using System.Collections;");
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

        protected void Clone(GeneratorContext ctx)
        {
            var builder = ctx.builder;
            foreach (var e in ctx.objects)
            {
                builder.AppendLine($"public partial class {e.Name}");
                builder.AppendLine("{");
                if (e == ctx.baseType)
                {
                    builder.AppendLine($"\tpublic abstract {ctx.baseType.Name} UntypedClone();");
                }
                else if (!e.IsAbstract)
                {
                    builder.AppendLine($"\tpublic {e.Name} Clone() => UntypedClone() as {e.Name};");

                    builder.AppendLine($"\tpublic override {ctx.baseType.Name} UntypedClone()");
                    builder.AppendLine("\t{");
                    builder.AppendLine($"\t\tvar result = new {e.Name}();");
                    foreach (var p in ctx.AllProperties(e))
                    {
                        if (p.PropertyType.IsList())
                        {
                            var elementType = p.PropertyType.GetGenericArguments()[0];
                            if (ctx.baseType.IsAssignableFrom(elementType))
                            {
                                builder.AppendLine($"\t\tresult.{p.Name} = {p.Name}.Select(i => i.UntypedClone() as {elementType.Name}).ToList();");

                            }
                            else
                            {
                                builder.AppendLine($"\t\tresult.{p.Name} = {p.Name}.ToList();");
                            }
                        }
                        else if (ctx.baseType.IsAssignableFrom(p.PropertyType))
                        {
                            builder.AppendLine($"\t\tresult.{p.Name} = {p.Name}?.UntypedClone() as {p.PropertyType.Name};");
                        }
                        else
                        {
                            builder.AppendLine($"\t\tresult.{p.Name} = {p.Name};");
                        }
                    }

                    builder.AppendLine($"\t\treturn result;");
                    builder.AppendLine("\t}");
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
            builder.AppendLine($"using Newtonsoft.Json;");

            foreach (var obj in ctx.objects)
            {
                var props = ctx.AllProperties(obj);
                var singleModelObjProp = ctx.SingleModelProperty(obj);

                var isCollection = false;
                PropertyInfo singleObjCollection = null;
                PropertyInfo singleListProp = null;
                Type genericListParameter = null;
                string childrenInderface = null;

                isCollection = !obj.IsAbstract && ctx.IsCollection(obj);

                var objCollections = props.Where(p => ctx.IsCollection(p.PropertyType)).ToList();

                singleObjCollection = obj.IsAbstract
                    ? null
                    : objCollections.Count == 1 
                        ? objCollections[0]
                        : null;
                var listProps = props.Where(p => p.PropertyType.IsList() && ctx.objects.Contains(p.PropertyType.GetGenericArguments()[0])).ToList();
                singleListProp = !obj.IsAbstract && listProps.Count == 1
                    ? listProps[0]
                    : null;
                genericListParameter = singleListProp != null ? singleListProp.PropertyType.GetGenericArguments()[0] : null;

                if (obj.Name == "vlgFunction")
                    Debugger.Break();

                var ctorVariants = ctx.AllCtorVariants(obj);

                if (!obj.IsAbstract && ctx.IsCollection(obj))
                {
                    builder.AppendLine("/// <summary>");
                    var fluentTypes = ctx.FluentTypes(obj);
                    foreach (var t in fluentTypes)
                    {
                        builder.AppendLine($"/// {t.Name}");
                    }
                    builder.AppendLine("/// </summary>");
                    builder.AppendLine($"public interface {obj.Name}Child");
                    builder.AppendLine($"{{");
                    builder.AppendLine($"}}");
                }

                if (isCollection)
                {
                    childrenInderface = $"{obj.Name}Child";
                }
                else if (singleObjCollection != null)
                {
                    childrenInderface = $"{singleObjCollection.PropertyType.Name}Child";
                }
                else if (singleListProp != null)
                {
                    childrenInderface = $"{genericListParameter.Name}";
                }

                var modifiers = new List<string>();
                AccessModifiers(modifiers, obj);
                InstanceModifiers(modifiers, obj);

                var inheritance = new List<string>();
                ctx.Inheritance(inheritance, obj);
                ctx.FluentInterfaces(inheritance, obj);

                builder.AppendLine($"[JsonObjectAttribute]");
                builder.Append($"{string.Join(" ", modifiers)} partial class {obj.Name}");
                if (inheritance.Any())
                {
                    builder.Append($" : {inheritance.ToCSV()}");
                    if (childrenInderface != null)
                        builder.Append($", IEnumerable//<{childrenInderface}>");

                }
                else
                {
                    if (childrenInderface != null)
                        builder.Append($" : IEnumerable//<{childrenInderface}>");
                }

                builder.AppendLine();
                builder.AppendLine("{");

                builder.AppendLine($"\tpublic {obj.Name}() {{ }}");

                if (isCollection)
                {
                    var childrenType = ctx.ChildrenType(obj);
                    builder.AppendLine($"\t// {childrenType.Name} collection");
                    builder.AppendLine($"\tIEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();");

                    builder.AppendLine($"\t[Obsolete]public void Add(object obj) => Add(obj as {childrenType.Name});");
                    builder.AppendLine($"\tpublic void Add({childrenInderface} child)");
                    builder.AppendLine($"\t{{");
                    builder.AppendLine($"\t\tvar typed = child as {childrenType.Name};");
                    builder.AppendLine($"\t\tif (typed == null) throw new Exception($\"Type of child object is not expected: {{child?.GetType()}}\");");
                    builder.AppendLine($"\t\tChildren.Add(typed);");
                    builder.AppendLine($"\t}}");
                }
                else if (singleObjCollection != null)
                {
                    builder.AppendLine($"\t// {singleObjCollection.Name} single object collection");
                    builder.AppendLine($"\tIEnumerator IEnumerable.GetEnumerator() => ({singleObjCollection.Name} as IEnumerable).GetEnumerator();");

                    var childrenType = ctx.ChildrenType(singleObjCollection.PropertyType);

                    builder.AppendLine($"\t[Obsolete]public void Add(object obj) => Add(obj as {childrenType.Name});");
                    builder.AppendLine($"\tpublic void Add({childrenInderface} child)");
                    builder.AppendLine($"\t{{");
                    builder.AppendLine($"\t\t{singleObjCollection.Name}.Add(child);");
                    builder.AppendLine($"\t}}");
                }
                else if (singleListProp != null)
                {
                    builder.AppendLine($"\t// {genericListParameter.Name} single list member");
                    builder.AppendLine($"\tIEnumerator IEnumerable.GetEnumerator() => ({singleListProp.Name} as IEnumerable).GetEnumerator();");

                    var childrenType = genericListParameter;

                    builder.AppendLine($"\t[Obsolete]public void Add(object obj) => Add(obj as {childrenType.Name});");
                    builder.AppendLine($"\tpublic void Add({childrenInderface} child)");
                    builder.AppendLine($"\t{{");
                    builder.AppendLine($"\t\t{singleListProp.Name}.Add(child);");
                    builder.AppendLine($"\t}}");
                }

                if (singleModelObjProp != null)
                {
                    var singleCtorParamsTypes = ctx.CtorParameters(singleModelObjProp.PropertyType);

                    var asParamsOption = new List<bool>() { false };
                    if (singleCtorParamsTypes.Any() && singleCtorParamsTypes.Last().PropertyType.IsList())
                    {
                        //TODO: check that ctors do not overlap by parameters
                        if (ctorVariants.Count == 1 && ctorVariants[0].CtorVariantType == CtorVariantType.Direct)
                            asParamsOption.Add(true);
                    }

                    foreach (var asParam in asParamsOption)
                    {
                        var singleCtorArgs = ctx.CtorParamsDecl(singleModelObjProp.PropertyType, asParam);
                        var singleCtorParamsNames = ctx.CtorParamNames(singleModelObjProp.PropertyType);

                        if (singleCtorParamsTypes.Any())
                        {
                            builder.AppendLine($"\tpublic {obj.Name}({singleCtorArgs.ToCSV()})");
                            builder.AppendLine($"\t{{");
                            builder.AppendLine($"\t\tthis.{singleModelObjProp.Name} = new {singleModelObjProp.PropertyType.Name}({singleCtorParamsNames.ToCSV()});");
                            builder.AppendLine($"\t}}");
                            /*
                            if (singleCtorParamsTypes.Count > 1 && singleCtorParamsTypes.Last().PropertyType.IsList())
                            {
                                builder.AppendLine($"\tpublic {obj.Name}({singleCtorArgs.Take(singleCtorParamsTypes.Count - 1).ToCSV()})");
                                builder.AppendLine($"\t{{");
                                builder.AppendLine($"\t\tthis.{singleModelObjProp.Name} = new {singleModelObjProp.PropertyType.Name}({singleCtorParamsNames.Take(singleCtorParamsTypes.Count - 1).ToCSV()});");
                                builder.AppendLine($"\t}}");
                            }
                            */
                        }
                    }
                }

                // object ctor

                foreach (var ctorVariant in ctorVariants)
                {                   
                    switch (ctorVariant.CtorVariantType)
                    {
                        case CtorVariantType.Direct:
                        {
                            if (ctorVariant.IsCommented)
                            {
                                var ctorArgs = ctx.CtorParamsDecl(ctorVariant.Props, false);
                                builder.AppendLine($"\t// ignored {obj.Name}({ctorArgs.ToCSV()})");
                                continue;
                            }

                            var asParamsOption = new List<bool>() { false };
                            if (ctorVariant.Props.Last().PropertyType.IsList())
                            {
                                asParamsOption.Add(true);
                            }

                            foreach (var asParmas in asParamsOption)
                            {
                                var ctorArgs = ctx.CtorParamsDecl(ctorVariant.Props, asParmas);

                                builder.AppendLine($"\tpublic {obj.Name}({ctorArgs.ToCSV()})");
                                builder.AppendLine($"\t{{");
                                foreach (var p in ctorVariant.Props)
                                {
                                    if (p.PropertyType.IsList())
                                    {
                                        builder.AppendLine($"\t\tthis.{p.Name} = ({p.Name} ?? Enumerable.Empty<{ctx.PropertyType(p.PropertyType.GetGenericArguments()[0])}>()).Where(s => s != null).ToList();");
                                    }
                                    else
                                    {
                                        builder.AppendLine($"\t\tthis.{p.Name} = {p.Name};");
                                    }
                                }
                                builder.AppendLine($"\t}}");
                            }
                        }
                        break;
                        case CtorVariantType.SingleObject:
                        {
                            if (ctorVariant.IsCommented)
                            {
                                var derivedCtorArgs = ctx.CtorParamsDecl(ctorVariant.Props, false);
                                builder.AppendLine($"\t// from {ctorVariant.ObjectType.Name}");
                                builder.AppendLine($"\t// ignored {obj.Name}({derivedCtorArgs.ToCSV()})");
                                continue;
                            }

                            var asParamsOption = new List<bool>() { false };
                            if (ctorVariant.Props.Last().PropertyType.IsList())
                            {
                                //asParamsOption.Add(true);
                            }
                            foreach (var asParmas in asParamsOption)
                            {
                                var derivedCtorArgs = ctx.CtorParamsDecl(ctorVariant.Props, asParmas);
                                var derivedCtorParamNames = ctorVariant.Props.Select(p => p.Name).ToCSV();

                                builder.AppendLine($"\t/// <summary>");
                                builder.AppendLine($"\t/// from {ctorVariant.ObjectType.Name}");
                                builder.AppendLine($"\t/// </summary>");

                                foreach (var p in ctorVariant.Props)
                                {
                                    builder.AppendLine($"\t/// <param name=\"{p.Name}\"></param>");
                                }

                                builder.AppendLine($"\tpublic {obj.Name}({derivedCtorArgs.ToCSV()})");
                                builder.AppendLine($"\t{{");
                                builder.AppendLine($"\t\tthis.{ctorVariant.TargetProp.Name} = new {ctorVariant.ObjectType.Name}({derivedCtorParamNames});");
                                builder.AppendLine($"\t}}");
                            }
                        }
                        break;
                        case CtorVariantType.SingleCollection:
                        {
                            var derivedCtorArgs = ctx.CtorParamsDecl(ctorVariant.Props, false);
                            var derivedCtorParamNames = ctorVariant.Props.Select(p => p.Name).ToCSV();

                            if (ctorVariant.IsCommented)
                            {
                                builder.AppendLine($"\t// from {ctorVariant.ObjectType.Name}");
                                builder.AppendLine($"\t// ignored {obj.Name}({derivedCtorArgs.ToCSV()})");
                                continue;
                            }
                            else
                            {
                                builder.AppendLine($"\t/// <summary>");
                                builder.AppendLine($"\t/// from {ctorVariant.ObjectType.Name}");
                                builder.AppendLine($"\t/// </summary>");

                                foreach (var p in ctorVariant.Props)
                                {
                                    builder.AppendLine($"\t/// <param name=\"{p.Name}\"></param>");
                                }
                            }

                            builder.AppendLine($"\tpublic {obj.Name}({derivedCtorArgs.ToCSV()})");
                            builder.AppendLine($"\t{{");
                            builder.AppendLine($"\t\tthis.{ctorVariant.TargetProp.Name}.Add(new {ctorVariant.ObjectType.Name}({derivedCtorParamNames}));");
                            builder.AppendLine($"\t}}");

                        }
                        break;
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
                                builder.AppendLine($"\t///");
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
                    builder.AppendLine($"\t/// <summary>");
                    builder.AppendLine($"\t/// from {iop.ChainedTypes[0].Name}");
                    builder.AppendLine($"\t/// </summary>");

                    builder.AppendLine($"\tpublic static implicit operator {iop.TargetType.Name}({iop.ParamsLine})");
                    builder.AppendLine($"\t{{");

                    var leading = iop.ChainedTypes.Select(t =>
                    {
                        if (t.IsList())
                            return $"new [] {{ new {t.GetGenericArguments()[0].Name}(";

                        return $"new {t.Name}(";
                    }).StringJoin("");
                    var trailing = iop.ChainedTypes.AsEnumerable().Reverse().Select(t =>
                    {
                        if (t.IsList())
                            return $") }}";

                        return $")";
                    }).StringJoin("");
                    builder.AppendLine($"\t\treturn {leading}{iop.ArgsLine}{trailing};");


                    /*
                    if (iop.ChainedTypes.Count == 1)
                    {
                        var leading = iop.ChainedTypes.Select(t => $"new {t.Name}(").StringJoin("");
                        var trailing = iop.ChainedTypes.Select(t => $")").StringJoin("");
                        builder.AppendLine($"\t\treturn {leading}{iop.ArgsLine}{trailing};");
                    }
                    else
                    {
                        builder.AppendLine($"\t\treturn ({iop.ChainedTypes.Last().Name}){iop.ArgsLine};");
                    }
                    */
                    builder.AppendLine($"\t}}");
                }

                builder.AppendLine("}");
            }
        }


        protected void Queries(GeneratorContext ctx)
        {
            var builder = ctx.builder;
            builder.AppendLine($"using Newtonsoft.Json;");
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
                    builder.AppendLine($"\t[JsonIgnore]");
                    builder.AppendLine($"\tpublic IEnumerable<{child.Name}> As{child.Name.Substring(3)} => Children.OfType<{child.Name}>();");
                }

                if (obj == ctx.baseType)
                {
                    builder.AppendLine($"\tpublic abstract IEnumerable<{ctx.baseType.Name}> SelfWithChildren();");
                }
                else
                {
                    builder.AppendLine($"\tpublic override IEnumerable<{ctx.baseType.Name}> SelfWithChildren()");
                    builder.AppendLine("\t{");
                    builder.AppendLine($"\t\tvar result = new List<{ctx.baseType.Name}>() {{ this }};");

                    foreach (var prop in ctx.AllProperties(obj))
                    {
                        if (ctx.objects.Contains(prop.PropertyType))
                        {
                            builder.AppendLine($"\t\tif ({prop.Name} != null) result.AddRange({prop.Name}.SelfWithChildren());");
                        }
                        else if (prop.PropertyType.IsList() && ctx.objects.Contains(prop.PropertyType.GetGenericArguments()[0]))
                        {
                            builder.AppendLine($"\t\tif ({prop.Name} != null) result.AddRange({prop.Name}.SelectMany(c => c.SelfWithChildren()));");
                        }
                    }

                    builder.AppendLine("\t\treturn result;");
                    builder.AppendLine("\t}");
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
                    var childCtorParams = ctx.CtorParamsDecl(child, true);

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
                            var forwardCtorParams = ctx.CtorParamsDecl(forwardType, true);
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
