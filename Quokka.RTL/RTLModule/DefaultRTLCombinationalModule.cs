﻿using Quokka.RTL.Tools;
using Quokka.RTL.Verilog;
using Quokka.RTL.VHDL;
using Quokka.VCD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL
{
    [RTLToolkitType]
    public abstract class DefaultRTLCombinationalModule<TInput> : IRTLCombinationalModule<TInput>
        where TInput : new()
    {
        public Type InputsType { get; } = typeof(TInput);
        //public virtual string ModuleName => GetType().Name;
        public virtual IEnumerable<MemberInfo> InputProps { get; private set; }
        public virtual IEnumerable<MemberInfo> OutputProps { get; private set; }
        public virtual IEnumerable<MemberInfo> InternalProps { get; private set; }
        public virtual IEnumerable<MemberInfo> ModuleProps { get; private set; }
        public virtual List<RTLModuleDetails> ModuleDetails { get; private set; } = new List<RTLModuleDetails>();
        public virtual IEnumerable<IRTLCombinationalModule> Modules => ModuleDetails.Select(m => m.Module);

        public event EventHandler Scheduled;

        protected void ThrowNotSetup()
        {
            throw new InvalidOperationException($"Module '{GetType().Name}' is not initialized. Please call .Setup() on module instance or top of the hierarchy.");
        }

        /// <summary>
        /// Method is called every time a new object inside module is created
        /// E.g. state, inputs, pipeilne stages etc
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool OnRelatedObjectCreating(object data) => false;

        void Initialize()
        {
            InputProps = RTLModuleHelper.SignalProperties(InputsType);
            OutputProps = RTLModuleHelper.OutputProperties(GetType());
            InternalProps = RTLModuleHelper.InternalProperties(GetType());
            ModuleProps = RTLModuleHelper.ModuleProperties(GetType());

            foreach (var m in ModuleProps.Where(m => RTLModuleHelper.IsField(m)))
            {
                var value = m.GetValue(this);

                if (value == null)
                {
                    throw new Exception($"Field {m.Name} returns null. Module should have an instance.");
                }

                var valueType = value.GetType();
                if (value is IRTLCombinationalModule module)
                {
                    ModuleDetails.Add(new RTLModuleDetails()
                    {
                        Module = module,
                        Member = m,
                        Name = m.Name
                    });
                    continue;
                }

                if (valueType.IsArray)
                {
                    var elementType = valueType.GetElementType();
                    if (typeof(IRTLCombinationalModule).IsAssignableFrom(elementType))
                    {
                        ModuleDetails.AddRange(
                            (value as IEnumerable).OfType<IRTLCombinationalModule>()
                            .Select((iteration, idx) =>
                            {
                                return new RTLModuleDetails()
                                {
                                    Module = iteration,
                                    Member = m,
                                    Name = $"{m.Name}{idx}"
                                };
                            }));
                        continue;
                    }
                }

                throw new Exception($"Field {m.Name} is not a module. Actual type is {(value?.GetType()?.Name ?? "null")}");
            }
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

        public virtual RTLModuleAnalizers Analizers => null;

        protected virtual void OnSchedule(Func<TInput> inputsFactory)
        {
            InputsFactory = inputsFactory;
        }

        public void Schedule(Func<TInput> inputsFactory)
        {
            OnSchedule(inputsFactory);

            Scheduled?.Invoke(this, new EventArgs());
        }

        public virtual bool DeepEquals(object lhs, object rhs) => DeepDiff.DeepEquals(lhs, rhs);
        protected virtual bool ShouldStage(TInput nextInputs)
        {
            if (InputProps == null)
                ThrowNotSetup();

            // check if given set of inputs was already processed on previous iteration
            return !DeepEquals(Inputs, nextInputs);
        }

        public virtual RTLModuleStageResult DeltaCycle(int deltaCycle)
        {
            if (InputsFactory == null)
                throw new InvalidOperationException($"InputsFactory is not specified. Did you forget to schedule module?");

            var nextInputs = InputsFactory();

            bool selfModified = deltaCycle == 0 || ShouldStage(nextInputs);
            bool childrenModified = false;

            Inputs = nextInputs;

            foreach (var child in Modules)
            {
                childrenModified |= child.DeltaCycle(deltaCycle) == RTLModuleStageResult.Unstable;
            }

            return (selfModified | childrenModified) ? RTLModuleStageResult.Unstable : RTLModuleStageResult.Stable;
        }

        public virtual void Commit()
        {
            foreach (var child in Modules)
            {
                child.Commit();
            }
        }

        public virtual void Reset(RTLModuleResetOptions resetOptions = null)
        {
            foreach (var child in Modules)
            {
                child.Reset(resetOptions);
            }
        }

        public virtual RTLSignalInfo SizeOfValue(object value) => RTLSignalTools.SizeOfValue(value);

        protected virtual IEnumerable<VCDVariable> ToVCDVariables(MemberInfo memberInfo, object value, string namePrefix = "")
        {
            switch (value)
            {
                case Enum v:
                    return new[]
                    {
                        new VCDVariable($"{namePrefix}{memberInfo.Name}ToString", value.ToString(), SizeOfValue("").Size),
                        new VCDVariable($"{namePrefix}{memberInfo.Name}", value, SizeOfValue(value).Size)
                    };
                case RTLBitArray b:
                    return new[]
                    {
                        new VCDVariable(memberInfo.Name, value, SizeOfValue(value).Size)
                    };
                default:
                    var valueType = value.GetType();
                    if (value.GetType().IsClass)
                    {
                        var result = new List<VCDVariable>();

                        var props = RTLReflectionTools.SynthesizableMembers(valueType);
                        foreach (var m in props)
                        {
                            result.AddRange(ToVCDVariables(m, m.GetValue(value), $"{namePrefix}{memberInfo.Name}_"));
                        }

                        return result;
                    }

                    return new[]
                    {
                        new VCDVariable($"{namePrefix}{memberInfo.Name}", value, SizeOfValue(value).Size)
                    };
            }
        }

        protected VCDSignalsSnapshot currentSnapshot = null;
        protected MemberInfo currentMember = null;

        protected void ThrowVCDException(Exception ex)
        {
            throw new VCDSnapshotException($"Failed to save snapshot of {GetType().Name}.{(currentSnapshot?.Name ?? "null")}.{(currentMember?.Name ?? "null")}", ex);
        }

        public virtual void PopulateSnapshot(VCDSignalsSnapshot snapshot, RTLModuleSnapshotConfig config = null)
        {
            config = config ?? RTLModuleSnapshotConfig.Default;
            try
            {
                if (config.IsIncluded(RTLModuleSnapshotConfigInclude.Inputs))
                {
                    currentSnapshot = snapshot.Scope("Inputs");
                    foreach (var prop in InputProps)
                    {
                        currentMember = prop;
                        var value = currentMember.GetValue(Inputs);
                        currentSnapshot.SetVariables(ToVCDVariables(currentMember, value));
                    }
                }

                if (config.IsIncluded(RTLModuleSnapshotConfigInclude.Outputs))
                {
                    currentSnapshot = snapshot.Scope("Outputs");
                    foreach (var prop in OutputProps)
                    {
                        currentMember = prop;
                        var value = currentMember.GetValue(this);
                        currentSnapshot.SetVariables(ToVCDVariables(currentMember, value));
                    }
                }

                if (config.IsIncluded(RTLModuleSnapshotConfigInclude.Modules))
                {
                    currentSnapshot = null;
                    foreach (var m in ModuleProps.Where(m => RTLModuleHelper.IsField(m)))
                    {
                        var value = m.GetValue(this);
                        currentMember = m;

                        if (value is IRTLCombinationalModule module)
                        {
                            var moduleScope = snapshot.Scope(m.Name);

                            module.PopulateSnapshot(moduleScope, config.Nested);
                            continue;
                        }

                        // TODO: support for modules array
                    }
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
            DeltaCycle(0);
            Commit();
        }

        public IRTLModuleTranslator InstanceTranslator(IRTLModuleTranslatorDeps deps) => null;

        public List<MemberInfo> GetMembers()
        {
            var members = GetType().GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy).ToList();// RTLReflectionTools.SerializableMembers(topType);
            return members;
        }
    }
}
