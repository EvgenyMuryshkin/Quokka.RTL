using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    public class GeneratorContext
    {
        public readonly Type baseType;
        public readonly string ns;
        public readonly string prefix;
        public List<TypeInfo> enums;
        public List<TypeInfo> interfaces;
        public List<TypeInfo> objects;
        public List<TypeInfo> visitors;

        public StringBuilder builder = new StringBuilder();

        public GeneratorContext(string ns, string prefix, Type baseType)
        {
            this.baseType = baseType;
            this.ns = ns;
            this.prefix = prefix;

            objects = Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.IsClass && t.Name.StartsWith(prefix))
                .OrderBy(t => t.Name)
                .ToList();

            enums = Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.IsEnum && t.Name.StartsWith(prefix))
                .OrderBy(t => t.Name)
                .ToList();

            interfaces = Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.IsInterface && t.Name.StartsWith(prefix))
                .OrderBy(t => t.Name)
                .ToList();

            visitors = objects.Where(o => !o.IsAbstract && o.GetCustomAttribute< NoVisitorAttribute>(true) == null /*&& typeof(IVisitorInterface).IsAssignableFrom(o)*/).ToList();
        }

        public List<PropertyInfo> CtorParameters(Type obj)
        {
            return AllProperties(obj).Where(p => !PropertyAttributes<NoCtorInitAttribute>(p).Any()).ToList();
        }

        public List<string> CtorParamsDecl(List<PropertyInfo> props, bool asParams)
        {
            var listsCount = props.Where(p => p.PropertyType.IsList()).Count();

            return props.Select(p =>
            {
                if (p.PropertyType.IsList())
                {
                    if (asParams && listsCount == 1 && p == props.Last())
                    {
                        return $"params {PropertyType(p.PropertyType.GetGenericArguments()[0])}[] {p.Name}";
                    }

                    return $"IEnumerable<{PropertyType(p.PropertyType.GetGenericArguments()[0])}> {p.Name}";
                }

                return $"{PropertyType(p.PropertyType)} {p.Name}";
            }).ToList();
        }

        public MethodParam MethodParam(Type propertyType, string propertyName)
        {
            if (propertyType.IsList())
            {
                return new MethodParam()
                {
                    Type = propertyType,
                    ParamType = $"IEnumerable<{PropertyType(propertyType.GetGenericArguments()[0])}>",
                    ParamName = propertyName
                };
            }

            return new MethodParam()
            {
                Type = propertyType,
                ParamType = PropertyType(propertyType),
                ParamName = propertyName
            };
        }

        public MethodParam MethodParam(PropertyInfo p)
        {
            return MethodParam(p.PropertyType, p.Name);
        }

        public List<MethodParam> MethodParams(List<PropertyInfo> props)
        {
            var listsCount = props.Where(p => p.PropertyType.IsList()).Count();

            return props.Select(p => MethodParam(p)).ToList();
        }

        public List<string> CtorParamsDecl(Type obj, bool asParams)
        {
            var props = CtorParameters(obj);
            return CtorParamsDecl(props, asParams);
        }

        public List<string> CtorParamNames(Type obj)
        {
            return CtorParameters(obj).Select(p => p.Name).ToList();
        }

        public List<Type> UnwrapBaseTypes(IEnumerable<Type> objs)
        {
            if (!objs.Any()) return new List<Type>();

            var baseTypes = objs.Select(o => o.BaseType).Where(t => t != typeof(object)).ToList();
            return baseTypes.Concat(UnwrapBaseTypes(baseTypes)).Distinct().ToList();
        }

        public Type ImplementedCollectionType(Type p)
        {
            var childrenCollection = p.GetInterfaces().Where(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IMetadataChildrenCollection<>)).SingleOrDefault();

            return childrenCollection;
        }

        public bool IsCollection(Type p) => ImplementedCollectionType(p) != null;

        public Type ChildrenType(Type p)
        {
            var childrenCollection = ImplementedCollectionType(p);

            return childrenCollection?.GetGenericArguments()?.First();
        }

        public void Validate()
        {
            var wrongPrefix = objects.Where(o => !o.Name.StartsWith(prefix));
            if (wrongPrefix.Any())
                throw new Exception($"Found object with failed naming convention: {wrongPrefix.Select(o => o.Name).ToCSV()}");


            foreach (var obj in objects.Where(o => !o.IsAbstract))
            {
                var hierarchy = UnwrapBaseTypes(new List<Type>() { obj });
                var nonAbstract = hierarchy.Where(c => !c.IsAbstract);
                if (nonAbstract.Any())
                {
                    throw new Exception($"{obj.Name} should have only abstract base types. Found {nonAbstract.Select(t => t.Name).ToCSV()}");
                }
            }
        }

        public IEnumerable<Type> FluentTypes(Type parentType, bool inherit = false)
        {
            var fluentType = parentType.GetCustomAttributes<FluentTypeAttribute>(inherit);

            return fluentType.SelectMany(t => DerivedNonAbstract(t.Type));
        }

        public IEnumerable<Type> AsQueryTypes(Type parentType)
        {
            if (parentType == null || parentType == typeof(object))
                return Enumerable.Empty<Type>();

            var typedChildren = FluentTypes(parentType);

            var objQueryTypes = typedChildren
                .SelectMany(t => Derived(t))
                .Concat(UnwrapBaseTypes(typedChildren))
                .Distinct();

            var baseQueryTypes = AsQueryTypes(parentType.BaseType);

            return objQueryTypes.Except(baseQueryTypes);

        }
        public IEnumerable<Type> DerivedNonAbstract(Type baseType)
        {
            return objects.Where(t => !t.IsAbstract && baseType.IsAssignableFrom(t));
        }

        public IEnumerable<Type> Derived(Type baseType)
        {
            return objects.Where(t => baseType.IsAssignableFrom(t));
        }

        public List<PropertyInfo> OwnProperties(Type obj)
        {
            if (obj == null || obj == typeof(object))
                return new List<PropertyInfo>();

            return obj.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToList();
        }

        public List<PropertyInfo> AllProperties(Type obj)
        {
            if (obj == null || obj == typeof(object))
                return new List<PropertyInfo>();

            return AllProperties(obj.BaseType).Concat(OwnProperties(obj)).ToList();
        }

        public PropertyInfo SingleModelProperty(Type obj)
        {
            var props = AllProperties(obj).Where(p => p.GetCustomAttribute<NoCtorInitAttribute>() == null).ToList();

            if (props.Count == 1 && props[0].PropertyType.IsClass && !props[0].PropertyType.IsAbstract)
            {
                var singleObjProp = props[0];
                if (objects.Contains(singleObjProp.PropertyType) || interfaces.Contains(singleObjProp.PropertyType))
                    return singleObjProp;
            }

            return null;
        }

        public PropertyInfo SingleModelListProperty(Type obj)
        {
            var props = AllProperties(obj);
            if (props.Count == 1 && props[0].PropertyType.IsList() && objects.Contains(props[0].PropertyType.GetGenericArguments()[0]))
            {
                var singleObjProp = props[0];
                var modelType = singleObjProp.PropertyType.GetGenericArguments()[0];
                if (objects.Contains(modelType) || interfaces.Contains(modelType))
                    return singleObjProp;
            }

            return null;
        }

        List<T> PropertyAttributes<T>(PropertyInfo p)
            where T : Attribute
        {
            var declaringType = p.DeclaringType;
            var interfaceAttributes = declaringType
                .GetInterfaces()
                .Where(i => i.GetProperty(p.Name) != null)
                .SelectMany(i => i.GetProperty(p.Name).GetCustomAttributes<T>(true));

            var propertyAttributes = p.GetCustomAttributes<T>(true);

            return interfaceAttributes.Concat(propertyAttributes).ToList();
        }

        public void Inheritance(List<string> result, Type obj)
        {
            if (obj.BaseType != null && obj.BaseType != typeof(object))
                result.Add(PropertyType(obj.BaseType));

            foreach (var i in obj.GetInterfaces().Where(i => !typeof(IMetadataInterface).IsAssignableFrom(i)))
                result.Add(PropertyType(i));
        }

        public void FluentInterfaces(List<string> result, Type obj)
        {
            foreach (var tl in objects.Where(t => !t.IsAbstract))
            {
                var fluentTypes = FluentTypes(tl, true);
                if (fluentTypes.Contains(obj))
                {
                    result.Add($"{tl.Name}Child");
                }
            }
        }

        public string PropertyType(Type p)
        {
            if (p.IsGenericType)
            {
                var withoutArrity = p.Name.Substring(0, p.Name.IndexOf("`"));
                return $"{withoutArrity}<{p.GetGenericArguments().Select(a => PropertyType(a)).ToCSV()}>";
            }

            if (p == typeof(MetadataRTLBitArray))
                return "RTLBitArray";

            return p.Name;
        }

        public List<ImplicitOperator> ImplicitOperators(Type obj)
        {
            List<ImplicitOperator> all;
            if (obj.IsAbstract)
            {
                all = AbstractImplicitOperators(obj);
            }
            else
            {
                all = AllImplicitOperators(obj, null);
            }

            var groups = all
                .GroupBy(p => p.Params[0].Type)
                .Where(g => g.Count() == 1)
                .SelectMany(g => g)
                .Where(o => o.Params.Count != 1 || o.Params[0].Type != obj)
                .Where(o => o.Params[0].Type != obj.BaseType)
                .ToList();

            return groups;
        }
        List<ImplicitOperator> AbstractImplicitOperators(Type obj)
        {
            var result = new List<ImplicitOperator>();

            var derived = DerivedNonAbstract(obj);

            foreach (var d in derived)
            {
                var dimp = AllImplicitOperators(d, null);
                foreach (var i in dimp.Where(d => !obj.IsAssignableFrom(d.Params[0].Type)))
                {
                    i.TargetType = obj;
                    result.Add(i);
                }
            }

            return result;
        }

        List<ImplicitOperator> AllImplicitOperators(Type obj, List<Type> chainedTypes)
        {
            var result = new List<ImplicitOperator>();

            if (obj == null || !objects.Contains(obj))
                return result;

            if (obj.GetCustomAttribute<NoImplicitAttribute>() != null)
                return result;

            if (chainedTypes != null && chainedTypes.Contains(obj))
                return result;

            chainedTypes = (chainedTypes ?? new List<Type>()).ToList();

            //var chainedTypesWithList = (chainedTypes ?? new List<Type>()).ToList();

            chainedTypes.Add(obj);
            //chainedTypesWithList.Add(typeof(List<>).MakeGenericType(obj));

            foreach (var ctorVariant in ImplicitCtorVariants(obj))
            {
                var methodParams = MethodParams(ctorVariant);
                
                var singlePropType = ctorVariant[0].PropertyType;
                if (singlePropType.IsList())
                {
                    var elementType = singlePropType.GetGenericArguments()[0];
                    if (elementType.IsInterface)
                    {
                        var derived = DerivedNonAbstract(elementType);
                        foreach (var d in derived)
                        {
                            foreach (var op in AllImplicitOperators(d, chainedTypes))
                            {
                                op.ChainedTypes = op.ChainedTypes.ToList();
                                op.ChainedTypes[chainedTypes.Count] = typeof(List<>).MakeGenericType(op.ChainedTypes[chainedTypes.Count]);
                                result.Add(op);
                            }
                        }
                    }
                    else if (objects.Contains(elementType))
                    {
                        result.Add(new ImplicitOperator()
                        {
                            ChainedTypes = chainedTypes,
                            Params = { MethodParam(elementType, "source") },
                            Args = { "new [] { source }" }
                        });

                        foreach (var op in AllImplicitOperators(elementType, chainedTypes))
                        {
                            op.ChainedTypes = op.ChainedTypes.ToList();
                            op.ChainedTypes[chainedTypes.Count] = typeof(List<>).MakeGenericType(op.ChainedTypes[chainedTypes.Count]);
                            result.Add(op);
                        }
                    }
                }
                else if (singlePropType.IsAbstract)
                {
                    var derived = DerivedNonAbstract(singlePropType);
                    foreach (var d in derived)
                    {
                        result.Add(new ImplicitOperator()
                        {
                            ChainedTypes = chainedTypes,
                            Params = { MethodParam(d, "source") } ,
                            Args = { "source" }
                        });

                        result.AddRange(AllImplicitOperators(d, chainedTypes));
                    }
                }
                else if (objects.Contains(singlePropType))
                {
                    result.AddRange(AllImplicitOperators(singlePropType, chainedTypes));

                    result.Add(new ImplicitOperator()
                    {
                        ChainedTypes = chainedTypes,
                        Params = methodParams.ToList(),
                        Args = methodParams.Select(p => p.ParamName).ToList()
                    });
                }
                else
                {
                    result.Add(new ImplicitOperator()
                    {
                        ChainedTypes = chainedTypes,
                        Params = methodParams.ToList(),
                        Args = methodParams.Select(p => p.ParamName).ToList()
                    });
                }
            }

            return result;
        }

        public List<List<PropertyInfo>> ImplicitCtorVariants(Type obj)
        {
            var result = new List<List<PropertyInfo>>();

            var ctorParams = CtorParameters(obj);
            if (!ctorParams.Any())
                return result;

            if (ctorParams.Count == 1)
            {
                result.Add(ctorParams);
            }

            if (ctorParams.Count == 2 && ctorParams.Last().PropertyType.IsList())
            {
                if (ctorParams.Last().GetCustomAttribute<RequiredListAttribute>() == null)
                    result.Add(ctorParams.Take(ctorParams.Count - 1).ToList());
            }

            return result;

        }
        public List<List<PropertyInfo>> CtorVariants(Type obj)
        {
            var result = new List<List<PropertyInfo>>();

            var ctorParams = CtorParameters(obj);
            result.Add(ctorParams);

            if (ctorParams.Count > 1 && ctorParams.Last().PropertyType.IsList())
            {
                if (ctorParams.Last().GetCustomAttribute<RequiredListAttribute>() == null)
                    result.Add(ctorParams.Take(ctorParams.Count - 1).ToList());
            }

            return result;
        }

        public Type SingleListMemberElementType(Type obj)
        {
            var ctorParams = CtorParameters(obj);
            if (ctorParams.Count == 1 && ctorParams[0].PropertyType.IsList())
            {
                return ctorParams[0].PropertyType.GetGenericArguments()[0];
            }

            return null;
        }

        public List<CtorVariant> AllCtorVariants(Type obj)
        {
            var result = new List<CtorVariant>();

            var ctorVariants = CtorVariants(obj);

            foreach (var ctorParams in ctorVariants)
            {
                if (!ctorParams.Any())
                    continue;

                result.Add(new CtorVariant(CtorVariantType.Direct, ctorParams, obj));

                if (ctorParams.Count == 1)
                {
                    if (objects.Contains(ctorParams[0].PropertyType))
                    {
                        var derived = DerivedNonAbstract(ctorParams[0].PropertyType).Where(t => t != ctorParams[0].PropertyType);
                        if (derived.Any())
                        {
                            foreach (var d in derived)
                            {
                                foreach (var ctorVariant in CtorVariants(d).Where(p => p.Any()))
                                {
                                    result.Add(new CtorVariant(CtorVariantType.SingleObject, ctorVariant, obj, d, ctorParams[0]));
                                }
                            }
                        }
                    }

                    if (ctorParams[0].PropertyType.IsList())
                    {
                        var derived = DerivedNonAbstract(ctorParams[0].PropertyType.GetGenericArguments()[0]).Where(t => t != ctorParams[0].PropertyType);
                        if (derived.Any())
                        {
                            foreach (var d in derived)
                            {
                                foreach (var ctorVariant in CtorVariants(d).Where(p => p.Any()))
                                {
                                    result.Add(new CtorVariant(CtorVariantType.SingleCollection, ctorVariant, obj, d, ctorParams[0]));
                                }
                            }
                        }
                    }
                }
            }

            var childrenType = SingleListMemberElementType(obj);

            foreach (var c in result.Where(r => r.CtorVariantType != CtorVariantType.Direct))
            {
                if (c.Props.All(p => p.PropertyType == childrenType))
                {
                    c.IsCommented = true;
                    continue;
                }

                var sameCtors = result.Where(i => i.IsSame(c)).ToList();
                c.IsCommented = sameCtors.Count != 1;
            }

            return result;
        }
    }
}
