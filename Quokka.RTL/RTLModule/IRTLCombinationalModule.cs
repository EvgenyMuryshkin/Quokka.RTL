using Quokka.RTL.Tools;
using Quokka.VCD;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Quokka.RTL
{
    public interface IRTLCombinationalModule : IRTLModuleControlFlow
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
        bool DeepEquals(object lhs, object rhs);

        RTLSignalInfo SizeOfValue(object value);

        event EventHandler Scheduled;
    }

    public interface IRTLCombinationalModule<TInput> : IRTLCombinationalModule
    {
        TInput Inputs { get; }

        void Schedule(Func<TInput> inputsFactory);
    }
}
