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

        [TestMethod]
        public void MemoryElementInitializer()
        {
            Assert.AreEqual("bin:1", RTLSignalTools.MemoryElementInitializer(true));
            Assert.AreEqual("bin:10000010", RTLSignalTools.MemoryElementInitializer((byte)0x82));
            Assert.AreEqual("bin:1000000000000000", RTLSignalTools.MemoryElementInitializer(new RTLBitArray(short.MinValue)));

            var indexedClass = new IndexedClass() { 
                IntValue = 42, 
                BitArray = new RTLBitArray(short.MaxValue).Resized(10), 
                ByteValue = 0x82 
            };
            Assert.AreEqual("bin:10000010111111111100000000000000000000000000101010", RTLSignalTools.MemoryElementInitializer(indexedClass));
        }
    }
}
