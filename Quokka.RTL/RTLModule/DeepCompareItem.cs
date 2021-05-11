using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Rollout")]

namespace Quokka.RTL
{
    public class DeepCompareItem
    {
        public DeepCompareItem(IEnumerable<MemberInfo> path, object lhs, object rhs, params string[] messages)
        {
            Path = path ?? Enumerable.Empty<MemberInfo>();
            this.lhs = lhs;
            this.rhs = rhs;
            Messages = messages.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }

        public DeepCompareItem(IEnumerable<MemberInfo> path, object lhs, object rhs, IEnumerable<string> messages, params string[] extra)
        {
            Path = path ?? Enumerable.Empty<MemberInfo>();
            this.lhs = lhs;
            this.rhs = rhs;
            Messages = (messages ?? Enumerable.Empty<string>()).Concat(extra).Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        public IEnumerable<MemberInfo> Path { get; private set; }
        public object lhs { get; private set; }
        public object rhs { get; private set; }
        public IEnumerable<string> Messages { get; private set; }
    }
}
