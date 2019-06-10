using Newtonsoft.Json;
using Quokka.VCD;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Quokka.RTL
{
    public class RTLModuleTrace<TState, TInput>
    {
    }

    /// <summary>
    /// Base class for hardware state machine module, will be in toolkit
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TState"></typeparam>
    public abstract class RTLSynchronousModule<TState, TInput> : RTLCombinationalModule<TInput>, IRTLSynchronousModule
        where TInput : new()
        where TState : class, new()
    {
        public Type StateType { get; } = typeof(TState);
        public List<MemberInfo> StateProps { get; } = RTLModuleHelper.SignalProperties(typeof(TState));

        public TState State = new TState();
        public TState NextState = new TState();

        public RTLSynchronousModule()
        {
        }

        object IRTLSynchronousModule.State => State;

        public override void PopulateSnapshot(VCDSignalsSnapshot snapshot)
        {
            base.PopulateSnapshot(snapshot);

            var state = snapshot.Scope("State");
            foreach (var prop in StateProps)
            {
                var value = prop.GetValue(State);
                state.SetVariables(ToVCDVariables(prop, value));
            }

            var nextState = snapshot.Scope("NextState");
            foreach (var prop in StateProps)
            {
                var value = prop.GetValue(NextState);
                nextState.SetVariables(ToVCDVariables(prop, value));
            }
        }

        protected abstract void OnStage();

        protected TState CopyState()
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            var json = JsonConvert.SerializeObject(State, settings);
            return JsonConvert.DeserializeObject<TState>(json);
        }

        public override bool Stage(int iteration)
        {
            if (!base.Stage(iteration))
                return false;

            NextState = CopyState();
            OnStage();

            // indicated processed inputs
            return true;
        }

        public override void Commit()
        {
            base.Commit();
            State = NextState;
            NextState = null;
        }

        public void Cycle(TInput inputs)
        {
            Schedule(() => inputs);
            Stage(0);
            Commit();
        }
    }
}
