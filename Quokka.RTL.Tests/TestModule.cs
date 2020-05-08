using System;
using System.Linq;

namespace Quokka.RTL.Tests
{
    class TestInputs
    {
        public byte ReadAddress { get; set; }
        public bool WE { get; set; }
        public byte WriteAddress { get; set; }

        public byte WriteData { get; set; }
    }

    interface ITestState
    {
        byte Data { get; set; }
        byte[] Buff { get; set; }
    }

    abstract class TestModule<TState> : RTLSynchronousModule<TestInputs, TState>
        where TState : class, ITestState, new()
    {
        // output signals
        public byte Data => State.Data;
        public bool WillWrite => IsWriting;

        // internal signal;
        bool IsWriting => !Inputs.WE;

        protected override void OnStage()
        {
            NextState.Data = State.Buff[Inputs.ReadAddress];

            if (Inputs.WE)
                NextState.Buff[Inputs.WriteAddress] = Inputs.WriteData;
        }
    }

    class MissingBuffState : ITestState
    {
        public byte Data { get; set; }

        // no MemoryBlockResetType is defined, module will run in simulation, but Reset call will fail
        public byte[] Buff { get; set; } = new byte[256];
    }

    class MissingTestModule : TestModule<MissingBuffState>
    {

    }

    class KeepBuffState : ITestState
    {
        public byte Data { get; set; }

        [MemoryBlockResetType(rtlMemoryBlockResetType.Keep)]
        public byte[] Buff { get; set; } = new byte[256];
    }
    class KeepTestModule : TestModule<KeepBuffState>
    {
    }

    class ResetBuffState : ITestState
    {
        public byte Data { get; set; }

        [MemoryBlockResetType(rtlMemoryBlockResetType.Reset)]
        public byte[] Buff { get; set; } = Enumerable.Range(0, 256).Select(idx => (byte)idx).ToArray();
    }

    class ResetTestModule : TestModule<ResetBuffState>
    {

    }
}
