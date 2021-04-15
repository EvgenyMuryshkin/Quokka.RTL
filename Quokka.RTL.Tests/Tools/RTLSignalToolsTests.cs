using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;

namespace Quokka.RTL.Tests
{
    [TestClass]
    public class RTLSignalToolsTests
    {
        [TestMethod]
        public void SizeOfValue()
        {
            Assert.AreEqual(8, RTLSignalTools.SizeOfValue(byte.MinValue).Size);
            Assert.AreEqual(16, RTLSignalTools.SizeOfValue(short.MinValue).Size);
            Assert.AreEqual(32, RTLSignalTools.SizeOfValue(uint.MinValue).Size);
            Assert.AreEqual(20, RTLSignalTools.SizeOfValue(new RTLBitArray().Resized(20)).Size);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => RTLSignalTools.SizeOfValue(""));
        }
    }
}
