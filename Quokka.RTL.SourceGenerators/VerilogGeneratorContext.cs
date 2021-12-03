using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    public class VerilogGeneratorContext
    {
        public string vlgPrefix = "vlg";

        public List<TypeInfo> vlgEnums;
        public List<TypeInfo> vlgInterfaces;
        public List<TypeInfo> vlgObjects;
        public List<TypeInfo> vlgVisitors;

        public StringBuilder builder = new StringBuilder();

        public VerilogGeneratorContext()
        {
            vlgObjects = Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.IsClass && t.Name.StartsWith(vlgPrefix))
                .OrderBy(t => t.Name)
                .ToList();

            vlgEnums = Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.IsEnum && t.Name.StartsWith(vlgPrefix))
                .OrderBy(t => t.Name)
                .ToList();

            vlgInterfaces = Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.IsInterface && t.Name.StartsWith(vlgPrefix))
                .OrderBy(t => t.Name)
                .ToList();

            vlgVisitors = vlgObjects.Where(o => !o.IsAbstract /*&& typeof(IVisitorInterface).IsAssignableFrom(o)*/).ToList();
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

        public List<string> CtorParamsDecl(Type obj)
        {
            var props = CtorParameters(obj);
            return CtorParamsDecl(props);

        }

        public List<string> CtorParamNames(Type obj)
        {
            return CtorParameters(obj).Select(p => p.Name).ToList();
        }

        public List<Type> UnwrapBaseTypes(List<Type> objs)
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
            var wrongPrefix = vlgObjects.Where(o => !o.Name.StartsWith(vlgPrefix));
            if (wrongPrefix.Any())
                throw new Exception($"Found object with failed naming convention: {wrongPrefix.Select(o => o.Name).ToCSV()}");


            foreach (var obj in vlgObjects.Where(o => !o.IsAbstract))
            {
                var hierarchy = UnwrapBaseTypes(new List<Type>() { obj });
                var nonAbstract = hierarchy.Where(c => !c.IsAbstract);
                if (nonAbstract.Any())
                {
                    throw new Exception($"{obj.Name} should have only abstract base types. Found {nonAbstract.Select(t => t.Name).ToCSV()}");
                }
            }
        }

        
        public IEnumerable<Type> DerivedNonAbstract(Type baseType)
        {
            return vlgObjects.Where(t => !t.IsAbstract && baseType.IsAssignableFrom(t));
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
                if (vlgObjects.Contains(singleObjProp.PropertyType) || vlgInterfaces.Contains(singleObjProp.PropertyType))
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
    }
}
