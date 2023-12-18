﻿namespace Quokka.RTL.SourceGenerators.Verilog
{
    public class vlgLogicSignal : vlgSignal
    {
        public vlgNetType NetType { get; set; }
        public vlgSignType Sign { get; set; }
        public vlgSignalType SignalType { get; set; }

        public string Name { get; set; }
        public int Width { get; set; }
        public string Initializer { get; set; }
    }
}
