﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.Tests
{
    public class NotGateInputs
    {
        public bool Input = false;
    }

    public class NotGateModule : RTLCombinationalModule<NotGateInputs>
    {
        public bool Output => !Inputs.Input;
    }

    class NotGateFeedbackInputs
    {

    }

    class NotGateFeedbackModule : RTLCombinationalModule<NotGateFeedbackInputs>
    {
        NotGateModule Inverter = new NotGateModule();

        protected override void OnSchedule(Func<NotGateFeedbackInputs> inputsFactory)
        {
            base.OnSchedule(inputsFactory);

            Inverter.Schedule(() => new NotGateInputs() { Input = Inverter.Output });
        }
    }
}