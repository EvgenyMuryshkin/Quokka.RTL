using System.Collections.Generic;
using System.Reflection;

namespace Quokka.RTL
{
    public interface IRTLMembersProvider
    {
        List<MemberInfo> GetMembers();
    }
}
