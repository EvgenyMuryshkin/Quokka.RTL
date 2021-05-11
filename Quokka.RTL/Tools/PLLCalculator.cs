using System;
using System.Linq;

namespace Quokka.RTL.Tools
{
    public class VCOConfig
    {
        public int FMin;
        public int FMax;
    }

    public class PLLConfig
    {
        public int SourceFreq;
        public VCOConfig VCO;
    }

    public class PLLInstance
    {
        public int F;
        public int M;
        public int D;
        public double Acc;
    }

    public class PLLCalculator
    {
        private readonly PLLConfig _config;
        public PLLCalculator(PLLConfig config)
        {
            _config = config;
        }

        public PLLInstance Generate(int resultFreq)
        {
            var sourceFreq = _config.SourceFreq;
            var multMin = (int)Math.Ceiling(_config.VCO.FMin / (double)sourceFreq);
            var multMax = (int)Math.Floor(_config.VCO.FMax / (double)sourceFreq);

            var divMin = (int)Math.Ceiling(sourceFreq * multMin / (double)resultFreq);
            var divMax = (int)Math.Floor(sourceFreq * multMax / (double)resultFreq);

            var options = Enumerable
                .Range(multMin, multMax - multMin + 1)
                .SelectMany(m => Enumerable
                    .Range(divMin, divMax - divMin + 1)
                    .Select(d =>
                    {
                        var f = (int)((double)sourceFreq * m / d);
                        var acc = Math.Abs(((double)f - resultFreq) / resultFreq);

                        return new PLLInstance
                        {
                            M = m,
                            D = d,
                            F = f,
                            Acc = acc
                        };
                    }))
                .OrderBy(r => r.Acc)
                .ToList();

            var bestOption = options.First();

            return bestOption;
        }
    }
}
