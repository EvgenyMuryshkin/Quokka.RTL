using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Quokka.RTL.Tools
{
    public static class RTLReflectionTools
    {
        public static IEnumerable<MemberInfo> RecursiveMembers(Type type)
        {
            if (type == null || type == typeof(object))
                return Enumerable.Empty<MemberInfo>();

            var baseMembers = SynthesizableMembers(type.BaseType);

            var props = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            var fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();

            return baseMembers
                .Concat(props)
                .Concat(fields)
                // exclude backing fields
                .Where(p => p.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static IEnumerable<MemberInfo> SynthesizableMembers(Type type, bool includeToolkitTypes = false)
        {
            if (!includeToolkitTypes && RTLTypeCheck.IsToolkitType(type))
                return Enumerable.Empty<MemberInfo>();

            return RecursiveMembers(type)
                .Where(p => !p.IsAbstract());
        }

        public static bool TryGetNullableType(Type type, out Type actualType)
        {
            actualType = null;
            if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                actualType = type.GetGenericArguments()[0];

            return actualType != null;
        }

        public static bool TryResolveTuple(Type candidate, out List<Type> types)
        {
            if (candidate.IsConstructedGenericType)
            {
                var generic = candidate.GetGenericTypeDefinition();
                if (generic.Name.StartsWith(nameof(ValueTuple)))
                {
                    types = candidate.GetGenericArguments().ToList();
                    return true;
                }
            }

            types = null;
            return false;
        }

        public static List<MemberInfo> SerializableMembers(Type type, bool throwIfNotSerializable = false)
        {
            var result = new List<MemberInfo>();
            var members = type
                .GetMembers(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(m => !m.Name.Contains("__BackingField"))
                .Where(m => !m.Name.Contains("__Field"));

            foreach (var m in members)
            {
                switch (m)
                {
                    case FieldInfo fi:
                        if (RTLTypeCheck.IsTypeSerializable(fi.FieldType) || RTLTypeCheck.IsSynthesizableObject(fi.FieldType))
                            result.Add(m);
                        else if (throwIfNotSerializable)
                            throw new Exception($"Member '{type.Name}.{m.Name}' of type '{fi.FieldType}' is not serializable");
                        break;
                    case PropertyInfo pi:
                        if (RTLTypeCheck.IsTypeSerializable(pi.PropertyType) || RTLTypeCheck.IsSynthesizableObject(pi.PropertyType))
                            result.Add(m);
                        else if (throwIfNotSerializable)
                            throw new Exception($"Member '{type.Name}.{m.Name}' of type '{pi.PropertyType}' is not serializable");
                        break;
                    default:
                        if (m.DeclaringType == typeof(object) || m.DeclaringType == typeof(ValueType))
                            continue;

                        if (RTLTypeCheck.IsAnonymousType(type))
                            continue;

                        if (m is ConstructorInfo c)
                        {
                            continue;
                        }


                        // TODO: sort out getter and setter later
                        if (m.Name.StartsWith("get_") || m.Name.StartsWith("set_"))
                        {
                            continue;
                        }

                        if (throwIfNotSerializable)
                            throw new Exception($"Member '{type.Name}.{m.Name}' of type '{m.GetType().Name}' is not serializable");


                        continue;
                }
            }

            return result;
        }
    }
}
