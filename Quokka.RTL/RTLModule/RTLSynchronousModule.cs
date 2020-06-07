using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Quokka.VCD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
    public abstract class RTLSynchronousModule<TInput, TState> : RTLCombinationalModule<TInput>, IRTLSynchronousModule<TInput, TState>
        where TInput : new()
        where TState : new()
    {
        public Type StateType { get; } = typeof(TState);
        public List<MemberInfo> StateProps { get; } = RTLModuleHelper.SignalProperties(typeof(TState));

        TState DefaultState;
        public TState State { get; private set; } = new TState();
        object IRTLSynchronousModule.RawState => State;
        public TState NextState = new TState();

        public override void Setup()
        {
            base.Setup();

            // store default state for reset logic
            DefaultState = CopyState();
        }

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
            return RTLModuleHelper.DeepCopy(State);
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

        public override void Reset()
        {
            base.Reset();
            
            if (Equals(DefaultState, default(TState)))
            {
                ThrowNotSetup();
            }

            foreach (var prop in StateProps)
            {
                var memberType = prop.GetMemberType();
                var defaultValue = prop.GetValue(DefaultState);
                var clonable = defaultValue as ICloneable;

                if (memberType.IsArray && clonable != null)
                {
                    var resetTypeAttribute = prop.GetCustomAttribute<MemoryBlockResetTypeAttribute>();
                    if (resetTypeAttribute == null)
                    {
                        throw new Exception($"No reset type is defined for {StateType.Name}.{prop.Name}. Use [MemoryBlockResetType] on property to declare behavious");
                    }

                    switch(resetTypeAttribute.ResetType)
                    {
                        case rtlMemoryBlockResetType.Keep:
                            break;
                        case rtlMemoryBlockResetType.Reset:
                            prop.SetValue(State, clonable.Clone());
                            break;
                    }
                }
                else if (clonable != null)
                {
                    prop.SetValue(State, clonable.Clone());
                }
                else if (memberType.IsValueType)
                {
                    prop.SetValue(State, defaultValue);
                }
                else
                {
                    throw new Exception($"Reference types note supported in reset logic: {StateType.Name}.{prop.Name}");
                }
            }
        }
        public override void Commit()
        {
            base.Commit();
            State = NextState;
            NextState = default;
        }
    }
}
