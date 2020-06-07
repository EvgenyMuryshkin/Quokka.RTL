using Quokka.VCD;
using System;
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
            Modules = ModuleProps.Select(m =>
            {
                var value = m.GetValue(this);
                if (!(value is IRTLCombinationalModule))
                {
                    throw new Exception($"Property {m.Name} is not a module. Actual type is {(value?.GetType()?.Name ?? "null")}");
                }

                return (IRTLCombinationalModule)m.GetValue(this);
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

        public virtual void PopulateSnapshot(VCDSignalsSnapshot snapshot)
        {
            var inputs = snapshot.Scope("Inputs");
            foreach (var prop in InputProps)
            {
                var value = prop.GetValue(Inputs);
                inputs.SetVariables(ToVCDVariables(prop, value));
            }

            var outputs = snapshot.Scope("Outputs");
            foreach (var prop in OutputProps)
            {
                var value = prop.GetValue(this);
                outputs.SetVariables(ToVCDVariables(prop, value));
            }

            foreach (var m in ModuleProps)
            {
                var module = (IRTLCombinationalModule)m.GetValue(this);
                var moduleScope = snapshot.Scope(m.Name);

                module.PopulateSnapshot(moduleScope);
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
