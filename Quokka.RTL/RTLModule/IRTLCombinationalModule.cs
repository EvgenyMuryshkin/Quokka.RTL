using Quokka.VCD;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Quokka.RTL
{
    public interface IRTLCombinationalModule : IRTLControlFlow
    {
        Type InputsType { get; }
        object RawInputs { get; }
        string ModuleName { get; }
        IEnumerable<MemberInfo> InputProps { get; }
        IEnumerable<MemberInfo> OutputProps { get; }
        IEnumerable<MemberInfo> InternalProps { get; }
        IEnumerable<MemberInfo> ModuleProps { get; }
        IEnumerable<IRTLCombinationalModule> Modules { get; }
        List<RTLModuleDetails> ModuleDetails { get; }

        void PopulateSnapshot(VCDSignalsSnapshot snapshot);
        void Setup();

        bool OnRelatedObjectCreating(object data);

        event EventHandler Scheduled;
    }

    public interface IRTLCombinationalModule<TInput> : IRTLCombinationalModule
    {
        TInput Inputs { get; }

        void Schedule(Func<TInput> inputsFactory);
    }
}
