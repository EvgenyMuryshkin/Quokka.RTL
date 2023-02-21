using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Quokka.RTL.Tools
{
    public static class RTLReflectionTools
    {
        public static Type GetCollectionItemType(Type type)
        {
            if (type == null)
                return null;

            if (type.IsArray)
                return type.GetElementType();

            if (type.IsList())
                return type.GetGenericArguments()[0];

            return null;
        }

        public static IEnumerable<MemberInfo> RecursiveMembers(Type type, bool includeToolkitTypes = false)
        {
            if (type == null || type == typeof(object) || (!includeToolkitTypes && RTLTypeCheck.IsToolkitType(type)))
                return Enumerable.Empty<MemberInfo>();

            var baseMembers = RecursiveMembers(type.BaseType).ToList();

            var props = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            var fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            var thisMembers = props
                .Concat(fields)
                //.OrderBy(x => x.MetadataToken) // https://stackoverflow.com/questions/9062235/get-properties-in-order-of-declaration-using-reflection
                ;

            return baseMembers.Concat(thisMembers)
                //thisMembers
                // exclude backing fields
                .Where(p => p.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static IEnumerable<MemberInfo> SynthesizableMembers(Type type, bool includeToolkitTypes = false)
        {
            return RecursiveMembers(type, includeToolkitTypes)
                .Where(p =>
                {
                    if (!includeToolkitTypes && RTLTypeCheck.IsToolkitType(p.GetMemberType()))
                        return false;

                    if (p.GetCustomAttribute<NonSerializedAttribute>() != null)
                        return false;

                    if (p.GetMemberType().GetCustomAttribute<NonSerializedAttribute>() != null)
                        return false;

                    // TODO: should include members of interface
                    //if (p.IsAbstract())
                    //    return false;

                    return true;
                })
                ;
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
            types = null;
            if (!candidate.IsTuple())
                return false;

            types = candidate.GetGenericArguments().ToList();
            return true;
        }

        public static List<MemberInfo> SerializableMembers(Type type, bool throwIfNotSerializable = false)
        {
            var result = new List<MemberInfo>();

            var members = RecursiveMembers(type)
                .Where(m => !m.Name.Contains("__BackingField"))
                .Where(m => !m.Name.Contains("__Field"));

            if (type.IsTuple())
            {
                return members.Where(m => m.Name.StartsWith("Item")).ToList();
            }

            foreach (var m in members)
            {
                switch (m)
                {
                    case FieldInfo fi:
                        if (RTLTypeCheck.IsTypeSerializable(fi.FieldType))
                            result.Add(m);
                        else if (throwIfNotSerializable)
                            throw new Exception($"Member '{type.Name}.{m.Name}' of type '{fi.FieldType}' is not serializable");
                        break;
                    case PropertyInfo pi:
                        if (RTLTypeCheck.IsTypeSerializable(pi.PropertyType))
                            result.Add(m);
                        else if (throwIfNotSerializable)
                            throw new Exception($"Member '{type.Name}.{m.Name}' of type '{pi.PropertyType}' is not serializable");
                        break;
                    case ConstructorInfo ctor:
                        break;
                    default:
                        if (m.DeclaringType == typeof(object) || m.DeclaringType == typeof(ValueType))
                            continue;

                        if (RTLTypeCheck.IsAnonymousType(type))
                            continue;

                        // TODO: sort out getter and setter later
                        if (m.Name.StartsWith("<>c") || m.Name.StartsWith("get_") || m.Name.StartsWith("set_"))
                        {
                            continue;
                        }

                        if (throwIfNotSerializable)
                            throw new Exception($"Member '{type.Name}.{m.Name}' of type '{m.GetType().Name}' is not serializable");

                        continue;
                }
            }

            if (result.Any(m => m.GetCustomAttribute<MemberIndexAttribute>() != null))
            {
                var memberIndex = result.Select(m => new { m, index = m.GetCustomAttribute<MemberIndexAttribute>() }).ToList();
                var notIndexed = memberIndex.Where(m => m.index == null).Select(m => m.m.Name).ToCSV();
                if (notIndexed.HasValue())
                    throw new Exception($"Members of type '{type}' should have index: {notIndexed} (MemberIndexAttribute)");

                return memberIndex.OrderBy(m => m.index.Order).Select(m => m.m).ToList();
            }
            else
            {
                // default order by name
                //result = result.OrderBy(m => m.Name).ToList();
            }

            return result;
        }

        public static List<MemberInfo> OrderedSerializableMembers(Type type, bool throwIfNotSerializable = false)
        {
            var members = SerializableMembers(type, throwIfNotSerializable);

            return members;

            var memberIndex = members.Select(m => new { m, index = m.GetCustomAttribute<MemberIndexAttribute>() }).ToList();
            var notIndexed = memberIndex.Where(m => m.index == null).Select(m => m.m.Name).ToCSV();
            if (notIndexed.HasValue())
                throw new Exception($"Members of type '{type}' should have index: {notIndexed} (MemberIndexAttribute)");

            return memberIndex.OrderBy(m => m.index.Order).Select(m => m.m).ToList();
        }

        public static (int, int) SerializedRange(object target, MemberInfo mi)
        {
            if (target == null) throw new NullReferenceException(nameof(target));
            if (mi == null) throw new NullReferenceException(nameof(mi));

            var orderedMembers = OrderedSerializableMembers(target.GetType());

            var from = 0;
            var leading = orderedMembers.TakeWhile(m => m.Name != mi.Name);

            from = leading.Sum(m => RTLSignalTools.SizeOfValue(m.GetValue(target)).Size);

            return (from + RTLSignalTools.SizeOfValue(mi.GetValue(target)).Size - 1, from);
        }


        public static List<List<MemberInfo>> UnwrapMemberInfo(MemberInfo source)
        {
            switch (source)
            {
                case Type memberType:
                {
                    if (RTLTypeCheck.IsSynthesizableObject(memberType) || RTLTypeCheck.IsTuple(memberType))
                    {
                        var members = SerializableMembers(memberType, true);
                        return members.SelectMany(m => UnwrapMemberInfo(m)).ToList();
                    }
                }
                break;
                case MemberInfo memberInfo:
                {
                    var unwrapped = UnwrapMemberInfo(memberInfo.GetMemberType());
                    if (unwrapped.Any())
                    {
                        return unwrapped.Select(m =>
                        {
                            var result = new List<MemberInfo>() { memberInfo };
                            result.AddRange(m);
                            return result;
                        }).ToList();
                    }
                    else
                    {
                        return new List<List<MemberInfo>>() { new List<MemberInfo>() { memberInfo } };
                    }
                }
            }

            return new List<List<MemberInfo>>();
        }
    }
}
