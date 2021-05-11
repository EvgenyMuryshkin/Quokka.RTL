using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;

namespace Quokka.RTL.Tests
{
    [TestClass]
    public class PLLCalculatorTests
    {
        [TestMethod]
        public void GenerateTest()
        {
            var calc = new PLLCalculator(new PLLConfig()
            {
                SourceFreq = 125000000,
                VCO = new VCOConfig()
                {
                    FMin = 800000000,
                    FMax = 1600000000
                }
            });

            var p1 = calc.Generate(25125000);
            var p2 = calc.Generate(36000000);
            var p3 = calc.Generate(40000000);
        }
    }
}
