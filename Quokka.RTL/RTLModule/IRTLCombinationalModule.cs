using Quokka.VCD;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Quokka.RTL
{
    public interface IRTLCombinationalModule
    {
        Type InputsType { get; }
        object Inputs { get; }

        IEnumerable<MemberInfo> InputProps { get; }
        IEnumerable<MemberInfo> OutputProps { get; }
        IEnumerable<MemberInfo> InternalProps { get; }
        IEnumerable<MemberInfo> ModuleProps { get; }
        IEnumerable<IRTLCombinationalModule> Modules { get; }

        bool Stage(int iteration);
        void Commit();

        void PopulateSnapshot(VCDSignalsSnapshot snapshot);
        void Setup();
    }
}
