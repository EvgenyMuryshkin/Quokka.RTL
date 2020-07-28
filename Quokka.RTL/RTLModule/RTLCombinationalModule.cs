﻿using Quokka.VCD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL
{
    public abstract class RTLCombinationalModule<TInput> : IRTLCombinationalModule<TInput>
        where TInput : new()
    {
        public Type InputsType { get; } = typeof(TInput);
        public virtual IEnumerable<MemberInfo> InputProps { get; private set; }
        public virtual IEnumerable<MemberInfo> OutputProps { get; private set; }
        public virtual IEnumerable<MemberInfo> InternalProps { get; private set; }
        public virtual IEnumerable<MemberInfo> ModuleProps { get; private set; }
        public virtual IEnumerable<IRTLCombinationalModule> Modules { get; private set; }

        public event EventHandler Scheduled;

        public RTLCombinationalModule()
        {
        }

        protected void ThrowNotSetup()
        {
            throw new InvalidOperationException($"Module '{GetType().Name}' is not initialized. Please call .Setup() on module instance or top of the hierarchy.");
        }

        void Initialize()
        {
            InputProps = RTLModuleHelper.SignalProperties(InputsType);
            OutputProps = RTLModuleHelper.OutputProperties(GetType());
            InternalProps = RTLModuleHelper.InternalProperties(GetType());
            ModuleProps = RTLModuleHelper.ModuleProperties(GetType());
            Modules = ModuleProps
                .Where(m => RTLModuleHelper.IsField(m))
                .SelectMany(m =>
                {
                    var value = m.GetValue(this);

                    if (value == null)
                    {
                        throw new Exception($"Field {m.Name} returns null. Module should have an instance.");
                    }

                    var valueType = value.GetType();
                    if (value is IRTLCombinationalModule module)
                    {
                        return new[] { module };
                    }

                    if (valueType.IsArray)
                    {
                        var elementType = valueType.GetElementType();
                        if (typeof(IRTLCombinationalModule).IsAssignableFrom(elementType))
                        {
                            return (value as IEnumerable).OfType<IRTLCombinationalModule>().ToArray();
                        }
                    }

                    throw new Exception($"Field {m.Name} is not a module. Actual type is {(value?.GetType()?.Name ?? "null")}");
                }).ToList();
        }

        public virtual void Setup()
        {
            Initialize();

            foreach (var child in Modules)
            {
                child.Setup();
            }

            Schedule(() => new TInput());
        }

        public TInput Inputs { get; private set; } = new TInput();
        object IRTLCombinationalModule.RawInputs => Inputs;
        protected Func<TInput> InputsFactory;

        protected virtual void OnSchedule(Func<TInput> inputsFactory)
        {
            InputsFactory = inputsFactory;
        }

        public void Schedule(Func<TInput> inputsFactory)
        {
            OnSchedule(inputsFactory);

            Scheduled?.Invoke(this, new EventArgs());
        }

        protected virtual bool ShouldStage(TInput nextInputs)
        {
            if (InputProps == null)
                ThrowNotSetup();

            // check if given set of inputs was already processed on previous iteration
            foreach (var prop in InputProps)
            {
                var currentValue = prop.GetValue(Inputs);
                var nextVaue = prop.GetValue(nextInputs);

                if (!currentValue.Equals(nextVaue))
                    return true;
            }

            return false;
        }

        public virtual bool Stage(int iteration)
        {
            if (InputsFactory == null)
                throw new InvalidOperationException($"InputsFactory is not specified. Did you forget to schedule module?");

            var nextInputs = InputsFactory();

            bool selfModified = iteration == 0 || ShouldStage(nextInputs);
            bool childrenModified = false;

            Inputs = nextInputs;

            foreach (var child in Modules)
            {
                childrenModified |= child.Stage(iteration);
            }

            return selfModified | childrenModified;
        }

        public virtual void Commit()
        {
            foreach (var child in Modules)
            {
                child.Commit();
            }
        }

        public virtual void Reset()
        {
            foreach (var child in Modules)
            {
                child.Commit();
            }
        }

        protected virtual int SizeOf(object value)
        {
            switch (value)
            {
                case Enum v:
                    return RTLModuleHelper.SizeOfEnum(value.GetType());
                default:
                    return VCDInteraction.SizeOf(value);
            }
        }

        protected virtual IEnumerable<VCDVariable> ToVCDVariables(MemberInfo memberInfo, object value)
        {
            switch(value)
            {
                case Enum v:
                    return new[]
                    {
                        new VCDVariable($"{memberInfo.Name}ToString", value.ToString(), SizeOf("")),
                        new VCDVariable(memberInfo.Name, value, SizeOf(value))
                    };
                default:
                    return new[]
                    {
                        new VCDVariable(memberInfo.Name, value, SizeOf(value))
                    };
            }
        }

        protected VCDSignalsSnapshot currentSnapshot = null;
        protected MemberInfo currentMember = null;

        protected void ThrowVCDException(Exception ex)
        {
            throw new Exception($"Failed to save snapshot of {GetType().Name}.{(currentSnapshot?.Name ?? "null")}.{(currentMember?.Name ?? "null")}", ex);
        }

        public virtual void PopulateSnapshot(VCDSignalsSnapshot snapshot)
        {
            try
            {
                currentSnapshot = snapshot.Scope("Inputs");
                foreach (var prop in InputProps)
                {
                    currentMember = prop;
                    var value = currentMember.GetValue(Inputs);
                    currentSnapshot.SetVariables(ToVCDVariables(currentMember, value));
                }

                currentSnapshot = snapshot.Scope("Outputs");
                foreach (var prop in OutputProps)
                {
                    currentMember = prop;
                    var value = currentMember.GetValue(this);
                    currentSnapshot.SetVariables(ToVCDVariables(currentMember, value));
                }

                currentSnapshot = null;
                foreach (var m in ModuleProps)
                {
                    currentMember = m;
                    var module = (IRTLCombinationalModule)m.GetValue(this);
                    var moduleScope = snapshot.Scope(m.Name);

                    module.PopulateSnapshot(moduleScope);
                }
            }
            catch (VCDSnapshotException)
            {
                throw;
            }
            catch (Exception ex)
            {
                ThrowVCDException(ex);
            }
        }

        public void Cycle(TInput inputs)
        {
            Schedule(() => inputs);
            Stage(0);
            Commit();
        }
    }
}
