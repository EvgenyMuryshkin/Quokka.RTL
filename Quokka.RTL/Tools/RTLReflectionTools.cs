using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Quokka.RTL.Tools
{
    public class SerializedRangeResult
    {
        public SerializedRangeResult(int index)
        {
            From = index;
            To = index;
            IsRange = false;
        }

        public SerializedRangeResult(int from, int to)
        {
            From = from;
            To = to;
            IsRange = true;
        }

        public int From { get; set; }
        public int To { get; set; }
        public bool IsRange { get; set; }

        public static implicit operator int[] (SerializedRangeResult r)
        {
            if (r.IsRange)
                return new[] { r.From, r.To };
        
           return new[] { r.From };
        }

        public (int, int) FromTo()
        {
            return (From, To);
        }
    }

    public class SerializedRangeInfo
    {
        public MemberInfo Member { get; set; }
        public int? Index { get; set; }

        public bool MemberOnly => Member != null && Index == null;
        public bool IndexOnly => Member == null && Index != null;

        public static implicit operator SerializedRangeInfo(MemberInfo member)
        {
            return new SerializedRangeInfo() { Member = member };
        }

        public static implicit operator SerializedRangeInfo(int index)
        {
            return new SerializedRangeInfo() { Index = index };
        }

        public static implicit operator SerializedRangeInfo((MemberInfo, int) set)
        {
            return new SerializedRangeInfo() { Member = set.Item1, Index = set.Item2 };
        }
    }

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

        public static IEnumerable<MemberInfo> RecursiveMembers(
            Type type, 
            bool includeToolkitTypes = false,
            bool sort = true)
        {
            if (type == null || type == typeof(object) || (!includeToolkitTypes && RTLTypeCheck.IsToolkitType(type)))
                return Enumerable.Empty<MemberInfo>();

            var baseMembers = RecursiveMembers(type.BaseType, includeToolkitTypes, sort).ToList();

            var props = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            var fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OfType<MemberInfo>();
            
            var thisMembers = props
                .Concat(fields)
                .Where(p => RTLModuleHelper.CompilerGenerated(p) == null)
                .Where(m => !m.Name.Contains("__BackingField"))
                .Where(m => !m.Name.Contains("__Field"))
                //.OrderBy(x => x.MetadataToken) // https://stackoverflow.com/questions/9062235/get-properties-in-order-of-declaration-using-reflection
                ;

            if (sort)
            {
                if (thisMembers.Any(m => RTLModuleHelper.MemberIndex(m) != null))
                {
                    var memberIndex = thisMembers.Select(m => new { m, index = RTLModuleHelper.MemberIndex(m) }).ToList();
                    var notIndexed = memberIndex.Where(m => m.index == null).Select(m => m.m.Name).ToCSV();
                    if (notIndexed.HasValue())
                        throw new Exception($"Members of type '{type}' should have index: {notIndexed} (MemberIndexAttribute)");

                    thisMembers = memberIndex.OrderBy(m => m.index.Order).Select(m => m.m).ToList();
                }
                else
                {
                    // default order by name
                    thisMembers = thisMembers.OrderBy(m => m.Name).ToList();
                }
            }

            return baseMembers.Concat(thisMembers);
        }

        public static IEnumerable<MemberInfo> SynthesizableMembers(
            Type type, 
            bool includeToolkitTypes = false,
            bool sort = true)
        {
            var members = new List<MemberInfo>();

            if (type.IsTuple())
            {
                members.AddRange(SerializableMembers(type));
            }
            else
            {
                members.AddRange(RecursiveMembers(type, includeToolkitTypes, sort));
            }

            return members
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

            var members = RecursiveMembers(type);

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

            return result;
        }

        static SerializedRangeResult ToSerializedRangeResult(object target, int from, int to)
        {
            if (target is bool)
                return new SerializedRangeResult(from);

            return new SerializedRangeResult(from, to);
        }

        static SerializedRangeResult ToSerializedRangeResultExact(bool isRange, int from, int to)
        {
            if (isRange)
                return new SerializedRangeResult(from, to);

            return new SerializedRangeResult(from);
        }

        public static SerializedRangeResult SerializedRange(object target, params SerializedRangeInfo[] path)
        {
            if (target == null) throw new NullReferenceException(nameof(target));
            if (path == null) throw new NullReferenceException(nameof(path));

            var sizeOfTarget = RTLSignalTools.SizeOfValue(target);

            if (!path.Any())
                return ToSerializedRangeResult(target, sizeOfTarget.Size - 1, 0);

            var firstMember = path.First();
            var targetType = target.GetType();

            if (targetType.IsCollection())
            {
                if (firstMember.Member != null)
                    throw new Exception($"Collection target range should not have member. Got {firstMember.Member.Name}");

                if (firstMember.Index == null)
                    return ToSerializedRangeResult(target, sizeOfTarget.Size - 1, 0);

                var collection = (target as IEnumerable).OfType<object>().ToList();
                if (firstMember.Index < 0 || firstMember.Index >= collection.Count)
                    throw new IndexOutOfRangeException($"Index: {firstMember.Index}, collection size: {collection.Count}");

                var collectionItem = collection[firstMember.Index.Value];
                var collectionItemSize = RTLSignalTools.SizeOfValue(collectionItem).Size;
                var from = firstMember.Index.Value * collectionItemSize;

                var collectionItemRange = SerializedRange(collectionItem, path.Skip(1).ToArray());
                return ToSerializedRangeResultExact(collectionItemRange.IsRange, from + collectionItemRange.From, from + collectionItemRange.To);
            }
            else
            {
                if (firstMember.Member == null)
                    throw new Exception($"Object target range needs member accessor");

                var firstMemberValue = firstMember.Member.GetValue(target);
                if (firstMemberValue == null)
                    throw new NullReferenceException($"{firstMember.Member.Name} is null");

                var orderedMembers = SerializableMembers(targetType);
                if (targetType.IsTuple())
                    orderedMembers.Reverse();

                var leading = orderedMembers.TakeWhile(m => m.Name != firstMember.Member.Name);
                var from = leading.Sum(m => RTLSignalTools.SizeOfValue(m.GetValue(target)).Size);

                if (firstMemberValue.GetType().IsCollection())
                {
                    var chainedRange = new List<SerializedRangeInfo>();
                    chainedRange.Add(new SerializedRangeInfo() { Index = firstMember.Index });
                    chainedRange.AddRange(path.Skip(1));

                    var collectionItemRange = SerializedRange(firstMemberValue, chainedRange.ToArray());
                    return ToSerializedRangeResultExact(collectionItemRange.IsRange, from + collectionItemRange.From, from + collectionItemRange.To);
                }
                else
                {
                    if (firstMember.Index != null)
                        throw new Exception($"Non-collection range should not have index, got {firstMember.Index}");

                    var memberRange = SerializedRange(firstMemberValue, path.Skip(1).ToArray());
                    return ToSerializedRangeResultExact(memberRange.IsRange, from + memberRange.From, from + memberRange.To);
                }
            }
        }

        public static List<List<MemberInfo>> UnwrapOrderedMemberInfo(MemberInfo source)
        {
            switch (source)
            {
                case Type memberType:
                    {
                        if (RTLTypeCheck.IsSynthesizableObject(memberType))
                        {
                            var members = SerializableMembers(memberType, true);
                            return members.SelectMany(m => UnwrapOrderedMemberInfo(m)).ToList();
                        }

                        if (RTLTypeCheck.IsTuple(memberType))
                        {
                            var members = SerializableMembers(memberType, true);
                            members.Reverse();
                            return members.SelectMany(m => UnwrapOrderedMemberInfo(m)).ToList();
                        }
                    }
                    break;
                case MemberInfo memberInfo:
                    {
                        var unwrapped = UnwrapOrderedMemberInfo(memberInfo.GetMemberType());
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
