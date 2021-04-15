using System;

namespace Quokka.RTL.Tools
{
    public static class RTLCalculators
    {
        public static uint CalcBitsForValue(ulong value)
        {
            if (value < 2)
                return 1;

            if (value == ulong.MaxValue)
                return 64;

            return (uint)Math.Ceiling(Math.Log(value + 1, 2));
        }
    }
}
