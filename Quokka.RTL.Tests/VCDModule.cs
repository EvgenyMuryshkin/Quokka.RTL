using Quokka.RTL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.VCD.Tests
{
    public class VCDModuleInputs
    {
        public bool WE;
        public bool Overwrite;
        public RTLBitArray Offset = new RTLBitArray(uint.MinValue);
    }

    public class VCDModuleState
    {
        public RTLBitArray PC = new RTLBitArray(uint.MinValue);
    }

    public class VCDModule : DefaultRTLSynchronousModule<VCDModuleInputs, VCDModuleState>
    {
        RTLBitArray internalNextPC => Inputs.Overwrite ? Inputs.Offset : State.PC + Inputs.Offset;
        public bool PCMisaligned => new RTLBitArray(internalNextPC[1, 0]) != 0;
        public RTLBitArray PC => State.PC;

        protected override void OnStage()
        {
            if (Inputs.WE)
            {
                NextState.PC = internalNextPC;
            }
        }
    }
}
