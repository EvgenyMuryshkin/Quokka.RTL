﻿using System;
using System.Collections.Generic;

namespace Quokka.RTL
{
    public interface IRTLPipelineDiagnostics
    {
        IRTLPipelineHead Head { get; }
        IRTLPipelineStage NextStage { get; }
        List<IRTLPipelineStage> Stages { get; }
        Type SourceType { get; }
        Type ResultType { get; }
        object Source { get; }
        object Result { get; }

        bool HasControlSignals { get; }
    }
}
