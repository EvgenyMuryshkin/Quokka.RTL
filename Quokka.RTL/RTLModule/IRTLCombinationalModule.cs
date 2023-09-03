using Quokka.RTL.Tools;
using Quokka.VCD;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Quokka.RTL
{
    public interface IRTLCombinationalModule : IRTLModuleControlFlow, IRTLMembersProvider
    {
        RTLModuleAnalizers Analizers { get; }
        Type InputsType { get; }
        object RawInputs { get; }
        string ModuleName { get; }
        IEnumerable<MemberInfo> InputProps { get; }
        IEnumerable<MemberInfo> OutputProps { get; }
        IEnumerable<MemberInfo> InternalProps { get; }
        IEnumerable<MemberInfo> ModuleProps { get; }
        IEnumerable<IRTLCombinationalModule> Modules { get; }
        List<RTLModuleDetails> ModuleDetails { get; }

        void PopulateSnapshot(VCDSignalsSnapshot snapshot, RTLModuleSnapshotConfig config = null);
        void Setup();

        bool OnRelatedObjectCreating(object data);
        bool DeepEquals(object lhs, object rhs);

        RTLSignalInfo SizeOfValue(object value);

        event EventHandler Scheduled;
        IRTLModuleTranslator InstanceTranslator(IRTLModuleTranslatorDeps deps);
    }

    public interface IRTLCombinationalModule<TInput> : IRTLCombinationalModule
    {
        TInput Inputs { get; }

        void Schedule(Func<TInput> inputsFactory);
    }
}
