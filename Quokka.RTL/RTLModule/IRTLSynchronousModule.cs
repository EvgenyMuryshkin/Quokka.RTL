using System;
using System.Collections.Generic;
using System.Reflection;

namespace Quokka.RTL
{
    public interface IRTLSynchronousModule : IRTLCombinationalModule
    {
        Type StateType { get; }
        object RawState { get; }
        List<MemberInfo> StateProps { get; }
        List<MemberInfo> PipelineProps { get; }
    }

    public interface IRTLSynchronousModule<TInput, TState> : IRTLSynchronousModule, IRTLCombinationalModule<TInput>
    {
        TState State { get; }
    }
}
