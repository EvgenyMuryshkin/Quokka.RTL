using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Quokka.RTL.Tools
{
    public class StateBitArrayMembers
    {
        public List<MemberInfo> Members { get; set; } = new List<MemberInfo>();
    }

    public class StateBitArrayAdjust<TState>
    {
        private readonly List<StateBitArrayMembers> _bitArrayMembers;
        public StateBitArrayAdjust()
        {
            _bitArrayMembers = Extract(typeof(TState));
        }

        static List<StateBitArrayMembers> Extract(Type type, HashSet<Type> reentry = null)
        {
            if (type == null) throw new NullReferenceException(nameof(type));
            reentry = reentry ?? new HashSet<Type>();

            if (reentry.Contains(type))
                throw new InvalidOperationException($"Type '{type.AssemblyQualifiedName}' was already processed, should not contain same type as member");

            var result = new List<StateBitArrayMembers>();

            try
            {
                reentry.Add(type);

                var members = RTLReflectionTools.SynthesizableMembers(type).ToList();

                foreach (var member in members)
                {
                    var memberType = member.GetMemberType();
                    if (memberType.IsArray || memberType.IsList())
                    {
                        var elementType = memberType.GetCollectionItemType();

                        if (elementType.IsRTLBitArray())
                        {
                            result.Add(new StateBitArrayMembers() { Members = { member } });
                        }
                        else if (RTLTypeCheck.IsSynthesizableObject(elementType))
                        {
                            var elementBitArrayMembers = Extract(elementType, reentry);

                            foreach (var elementBitArrayMember in elementBitArrayMembers)
                            {
                                var i = new StateBitArrayMembers() { Members = { member } };
                                i.Members.AddRange(elementBitArrayMember.Members);

                                result.Add(i);
                            }
                        }
                    }
                    else if (memberType.IsRTLBitArray())
                    {
                        result.Add(new StateBitArrayMembers() { Members = { member } });
                    }
                    else if (RTLTypeCheck.IsSynthesizableObject(memberType))
                    {
                        var objectMembers = Extract(memberType);
                        foreach (var objectMember in objectMembers)
                        {
                            var i = new StateBitArrayMembers() { Members = { member } };
                            i.Members.AddRange(objectMember.Members);

                            result.Add(i);
                        }
                    }
                }
            }
            finally
            {
                reentry.Remove(type);
            }

            return result;
        }

        void RunMembers(List<MemberInfo> members, object reference, object target)
        {
            if (reference == null || target == null)
                return;

            var referenceType = reference.GetType();
            if (referenceType.IsRTLBitArray())
            {
                var referenceBitArray = reference as RTLBitArray;
                var targetBitArray = target as RTLBitArray;

                targetBitArray.internalAdjust(referenceBitArray);
            }
            else if (referenceType.IsArray || referenceType.IsList())
            {
                var referenceArrayItems = reference as IList;
                var targetArrayItems = target as IList;

                if (referenceArrayItems.Count != targetArrayItems.Count)
                    throw new Exception($"Array size does not match");

                for (var i = 0; i < referenceArrayItems.Count; i++)
                    RunMembers(members, referenceArrayItems[i], targetArrayItems[i]);
            }
            else if (members.Any())
            {
                var member = members[0];
                var remainingMembers = members.Skip(1).ToList();

                RunMembers(remainingMembers, member.GetValue(reference), member.GetValue(target));
            }
            else
            {
                throw new Exception($"StateBitArrayAdjust: should not be there - no members access on object {referenceType.AssemblyQualifiedName}");
            }
        }

        public void Run(TState reference, TState target)
        {
            foreach (var members in _bitArrayMembers)
            {
                RunMembers(members.Members, reference, target);

            }
        }
    }
}
