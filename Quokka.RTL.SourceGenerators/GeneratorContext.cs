using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    public class MethodParam
    {
        public Type Type { get; set; }
        public string ParamType { get; set; }
        public string ParamName { get; set; }
    }

    public class ImplicitOperator
    {
        public List<Type> ChainedTypes { get; set; } = new List<Type>();

        Type _targetTypeOverride;
        public Type TargetType
        {
            get => _targetTypeOverride ?? ChainedTypes[0];
            set
            {
                _targetTypeOverride = value;
            }
        }
        public List<MethodParam> Params { get; set; } = new List<MethodParam>();
        public List<string> Args { get; set; } = new List<string>();

        public string ParamsLine => Params.Select(p => $"{p.ParamType} {p.ParamName}").ToCSV();
        public string ArgsLine => Args.ToCSV();
    }

    public class GeneratorContext
    {
        public readonly string prefix;
        public List<TypeInfo> enums;
        public List<TypeInfo> interfaces;
        public List<TypeInfo> objects;
        public List<TypeInfo> visitors;

        public StringBuilder builder = new StringBuilder();

        public GeneratorContext(string prefix)
        {
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

            visitors = objects.Where(o => !o.IsAbstract /*&& typeof(IVisitorInterface).IsAssignableFrom(o)*/).ToList();
        }

        public List<PropertyInfo> CtorParameters(Type obj)
        {
            return AllProperties(obj).Where(p => !PropertyAttributes<NoCtorInitAttribute>(p).Any()).ToList();
        }

        public List<string> CtorParamsDecl(List<PropertyInfo> props)
        {
            var listsCount = props.Where(p => p.PropertyType.IsList()).Count();

            return props.Select(p =>
            {
                if (p.PropertyType.IsList())
                {
                    if (listsCount == 1 && p == props.Last())
                    {
                        return $"params {PropertyType(p.PropertyType.GetGenericArguments()[0])}[] {p.Name}";
                    }

                    return $"IEnumerable<{PropertyType(p.PropertyType.GetGenericArguments()[0])}> {p.Name}";
                }

                return $"{PropertyType(p.PropertyType)} {p.Name}";
            }).ToList();
        }

        public MethodParam MethodParam(Type propertyType, string propertyName, bool asParams = false)
        {
            if (propertyType.IsList())
            {
                if (asParams)
                {
                    return new MethodParam()
                    {
                        Type = propertyType,
                        ParamType = $"params {PropertyType(propertyType.GetGenericArguments()[0])}[]",
                        ParamName = propertyName
                    };
                }

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

        public MethodParam MethodParam(PropertyInfo p, bool asParams = false)
        {
            return MethodParam(p.PropertyType, p.Name, asParams);

            if (p.PropertyType.IsList())
            {
                if (asParams)
                {
                    return new MethodParam()
                    {
                        Type = p.PropertyType,
                        ParamType = $"params {PropertyType(p.PropertyType.GetGenericArguments()[0])}[]",
                        ParamName = p.Name
                    };
                }

                return new MethodParam()
                {
                    Type = p.PropertyType,
                    ParamType = $"IEnumerable<{PropertyType(p.PropertyType.GetGenericArguments()[0])}>",
                    ParamName = p.Name
                };
            }

            return new MethodParam()
            {
                Type = p.PropertyType,
                ParamType = PropertyType(p.PropertyType),
                ParamName = p.Name
            };
        }

        public List<MethodParam> MethodParams(List<PropertyInfo> props)
        {
            var listsCount = props.Where(p => p.PropertyType.IsList()).Count();

            return props.Select(p => MethodParam(p, listsCount == 1 && p == props.Last())).ToList();
        }

        public List<string> CtorParamsDecl(Type obj)
        {
            var props = CtorParameters(obj);
            return CtorParamsDecl(props);
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

        public Type ChildrenType(Type p)
        {
            var childrenCollection = p.GetInterfaces().Where(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IMetadataChildrenCollection<>)).SingleOrDefault();

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

        public IEnumerable<Type> FluentTypes(Type parentType)
        {
            var fluentType = parentType.GetCustomAttributes<FluentTypeAttribute>(false);

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
            var props = AllProperties(obj);

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
            var all = AllImplicitOperators(obj, null);
            var groups = all.GroupBy(p => p.Params[0].Type).Where(g => g.Count() == 1).SelectMany(g => g).ToList();
            return groups;
        }

        List<ImplicitOperator> AllImplicitOperators(Type obj, List<Type> chainedTypes)
        {
            var result = new List<ImplicitOperator>();

            if (obj == null || !objects.Contains(obj))
                return result;

            // top level abstract object
            if (obj.IsAbstract && chainedTypes == null)
            {
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

            chainedTypes = (chainedTypes ?? new List<Type>()).ToList();
            chainedTypes.Add(obj);

            foreach (var ctorVariant in CtorVariants(obj).Where(v => v.Count == 1))
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
                            result.AddRange(AllImplicitOperators(d, chainedTypes));
                        }
                    }
                    else if (objects.Contains(elementType))
                    {
                        result.Add(new ImplicitOperator()
                        {
                            ChainedTypes = chainedTypes,
                            Params = { MethodParam(elementType, "source") },
                            Args = { "source" }
                        });

                        result.AddRange(AllImplicitOperators(elementType, chainedTypes));
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
            /*
            var ctorParamProps = CtorParameters(obj);
            var ctopParamArgs = MethodParams(ctorParamProps);

            if (ctorParamProps.Count == 2 && ctorParamProps.Last().PropertyType.IsList())
            {
                // object consists of two properties, last is list.
                // Implicit operator from first property

                result.Add(new ImplicitOperator()
                {
                    TargetType = obj,
                    Params = ctopParamArgs.Take(1).ToList(),
                    Args = ctopParamArgs.Take(1).Select(p => p.ParamName).ToList()
                });

                result.AddRange(ImplicitOperators(ctorParamProps[0].PropertyType));
            }

            if (ctorParamProps.Count == 1)
            {
                var singleProperty = ctorParamProps[0];

                if (singleProperty.PropertyType.IsList())
                {
                    var listItemType = singleProperty.PropertyType.GetGenericArguments()[0];

                    if (listItemType.IsInterface || listItemType.IsAbstract)
                    {
                        // implicit conversion from all derived interfaces or concrete classes
                        var derived = DerivedNonAbstract(listItemType);

                        foreach (var d in derived)
                        {
                            result.Add(new ImplicitOperator()
                            {
                                TargetType = obj,
                                Params =
                                {
                                    new MethodParam()
                                    {
                                        Type = d,
                                        ParamType = PropertyType(d),
                                        ParamName= "single"
                                    }
                                },
                                Args =
                                {
                                    $"new [] {{ single }}"
                                }
                            });
                        }
                    }
                    else
                    {
                        result.Add(new ImplicitOperator()
                        {
                            TargetType = obj,
                            Params =
                            {
                                new MethodParam()
                                {
                                    Type = listItemType,
                                    ParamType = PropertyType(listItemType),
                                    ParamName= "single"
                                }
                            },
                            Args =
                            {
                                $"new [] {{ single }}"
                            }
                        });
                    }
                }
                else
                {
                    if (singleProperty.PropertyType.IsInterface || singleProperty.PropertyType.IsAbstract)
                    {
                        var derived = DerivedNonAbstract(singleProperty.PropertyType);

                        foreach (var d in derived)
                        {
                            result.Add(new ImplicitOperator()
                            {
                                TargetType = obj,
                                Params =
                                {
                                    new MethodParam()
                                    {
                                        Type = d,
                                        ParamType = PropertyType(d),
                                        ParamName = singleProperty.Name
                                    }
                                },
                                Args =
                                {
                                    singleProperty.Name
                                }
                            });
                        }
                    }
                    else
                    {
                        result.Add(new ImplicitOperator()
                        {
                            TargetType = obj,
                            Params =
                            {
                                MethodParam(singleProperty)
                            },
                            Args =
                            {
                                singleProperty.Name
                            }
                        });
                    }
                }
            }

            return result;
            */
        }

        public List<List<PropertyInfo>> CtorVariants(Type obj)
        {
            var result = new List<List<PropertyInfo>>();

            var ctorParams = CtorParameters(obj);
            result.Add(ctorParams);

            if (ctorParams.Count > 1 && ctorParams.Last().PropertyType.IsList())
            {
                result.Add(ctorParams.Take(ctorParams.Count - 1).ToList());
            }

            return result;
        }
    }
}
