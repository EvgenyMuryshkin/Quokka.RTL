using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;

namespace Quokka.RTL.Tests
{
    [TestClass]
    public class RTLCalculatorsTests
    {
        [TestMethod]
        public void CalcBitsForValue()
        {
            Assert.AreEqual(1U, RTLCalculators.CalcBitsForValue(0));
            Assert.AreEqual(1U, RTLCalculators.CalcBitsForValue(1));
            Assert.AreEqual(2U, RTLCalculators.CalcBitsForValue(2));
            Assert.AreEqual(2U, RTLCalculators.CalcBitsForValue(3));
            Assert.AreEqual(16U, RTLCalculators.CalcBitsForValue(ushort.MaxValue));
            Assert.AreEqual(17U, RTLCalculators.CalcBitsForValue(ushort.MaxValue + 1));
            Assert.AreEqual(32U, RTLCalculators.CalcBitsForValue(uint.MaxValue));
            Assert.AreEqual(33U, RTLCalculators.CalcBitsForValue(uint.MaxValue + 1UL));
            Assert.AreEqual(64U, RTLCalculators.CalcBitsForValue(ulong.MaxValue));
        }
    }
}
