using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL
{
    public class CombinationalUnroll
    {
        public CombinationalUnroll() { }

        public List<CombinationalUnrollSet> UnrollInstance(object instance)
        {
            return UnrollInstance("", instance);
        }
        public List<CombinationalUnrollSet> UnrollInstance(string instanceName, object instance)
        {
            return UnrollInstance(instanceName, null, instance);
        }

        public List<CombinationalUnrollSet> UnrollInstance(
            string instanceName,
            MemberInfo memberInfo,
            object instance)
        {
            var result = new List<CombinationalUnrollSet>();
            var type = instance.GetType();

            if (RTLTypeCheck.IsNative(type))
            {
                var set = new CombinationalUnrollSet();
                set.Add(new CombinationalUnrollItem(type, instanceName, instance, memberInfo: memberInfo));
                result.Add(set);
                return result;
            }

            if (RTLReflectionTools.TryResolveTuple(type, out var types))
            {
                for (var idx = 0; idx < types.Count; idx++)
                {
                    var tupleItemName = $"Item{idx + 1}";

                    var tupleItemMember = type.GetField(tupleItemName) ?? type.SingleOrDefaultMember(tupleItemName);
                    var tupleItemValue = tupleItemMember.GetValue(instance);

                    if (tupleItemValue != null)
                    {
                        var unrolled = UnrollInstance(tupleItemName, tupleItemMember, tupleItemValue);

                        foreach (var p in unrolled)
                        {
                            var set = new CombinationalUnrollSet();
                            set.Add(new CombinationalUnrollItem(type, instanceName, instance, memberInfo: memberInfo));

                            foreach (var i in p.Items)
                            {
                                set.Add(i);
                            }
                            result.Add(set);
                        }
                    }
                }
                return result;
            }

            if (type.IsCollection())
            {
                var elementType = type.GetElementType();

                //if (RTLTypeCheck.IsSynthesizableObject(elementType))
                //    throw new Exception("Array");

                var enumerable = (instance as IEnumerable).OfType<object>();
                if (enumerable.Count() == 0)
                    throw new Exception($"Array should have size: {type.Name}");

                // uniform array is expected
                var firstElement = enumerable.First();
                var elementSize = RTLSignalTools.SizeOfValue(firstElement);

                var set = new CombinationalUnrollSet();
                set.Add(new CombinationalUnrollItem(type, instanceName, instance, memberInfo: memberInfo));
                set.Last.ArrayDepth = enumerable.Count();
                set.Last.ArrayElementSize = elementSize;
                set.Last.OriginalValue = instance;
                set.Last.OriginalName = instanceName;

                result.Add(set);
                return result;
            }

            if (RTLTypeCheck.IsSynthesizableObject(type))
            {
                var members = RTLReflectionTools.SerializableMembers(type).Where(m => m is FieldInfo || m is PropertyInfo);

                foreach (var member in members)
                {
                    var memberType = member.GetMemberType();
                    var memberValue = member.GetValue(instance);

                    if (memberValue == null && RTLReflectionTools.TryGetNullableType(memberType, out var actualType))
                        memberValue = Activator.CreateInstance(actualType);

                    if (memberValue == null)
                        throw new Exception($"Member value is null: {member.Name}");

                    var unrolled = UnrollInstance(member.Name, member, memberValue);

                    foreach (var p in unrolled)
                    {
                        var set = new CombinationalUnrollSet();
                        set.Add(new CombinationalUnrollItem(type, instanceName, instance, memberInfo: memberInfo));
                        set.AddRange(p.Items);
                        result.Add(set);
                    }
                }

                return result;
            }

            throw new Exception($"Object {type.Name} is not synthesizable");
        }
    }
}
