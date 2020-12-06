using System;

namespace Quokka.RTL.Tests
{
    class ParentModule : DefaultRTLCombinationalModule<TestInputs>
    {
        public KeepTestModule SingleChild1 = new KeepTestModule();
        public KeepTestModule SingleChild2 = new KeepTestModule();
        byte internalData => SingleChild1.Data;

        public byte Data => internalData;

        KeepTestModule[] children => new[]
        {
            SingleChild1,
            SingleChild2
        };

        protected override void OnSchedule(Func<TestInputs> inputsFactory)
        {
            base.OnSchedule(inputsFactory);

            SingleChild1.Schedule(inputsFactory);
            SingleChild2.Schedule(inputsFactory);
        }
    }
}
