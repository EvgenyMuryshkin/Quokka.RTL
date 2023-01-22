using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Linq;

namespace Quokka.RTL.Tests
{
    // L2 size is 1 + bitArraySize
    class NestedClassL2
    {
        public NestedClassL2(int bitArraySize)
        {
            bitArray = new RTLBitArray().Resized(bitArraySize);
        }

        public bool boolValue;
        public RTLBitArray bitArray;
    }

    class NestedClassL1
    {
        public NestedClassL1(int l2Size, int bitArray)
        {
            l2 = new NestedClassL2(bitArray);
            l2Array = Enumerable.Range(0, l2Size).Select(i => new NestedClassL2(bitArray)).ToArray();
        }

        public NestedClassL2 l2;

        public NestedClassL2[] l2Array;
        public byte byteValue;
    }

    class TopLevelClass
    {
        public TopLevelClass(int l1Size, int l2Size, int bitArray)
        {
            l1 = new NestedClassL1(l2Size, bitArray);
            l1Array = Enumerable.Range(0, l1Size).Select(i => new NestedClassL1(l2Size, bitArray)).ToArray();
        }

        public NestedClassL1 l1;

        public NestedClassL1[] l1Array;
        public int intValue;
    }

    class ClassWithTuple
    {
        public ClassWithTuple(int l1Size, int l2Size, int bitArray)
        {
            Tuple = new Tuple<bool, byte, TopLevelClass>(false, 0, new TopLevelClass(l1Size, l2Size, bitArray));
        }

        public Tuple<bool, byte, TopLevelClass> Tuple;
    }

    [TestClass]
    public class RTLSignalToolsTests
    {
        [TestMethod]
        public void SizeOfClassWithTuple()
        {
            // 164 + 8 + 1
            Assert.AreEqual(173, RTLSignalTools.SizeOfValue(new ClassWithTuple(2, 3, 8)).Size);

        }

        [TestMethod]
        public void SizeOfClass()
        {
            // TL: 32 + (1 + 1) * ( 8 + (1 + 2) * (1 + 5) )
            Assert.AreEqual(84, RTLSignalTools.SizeOfValue(new TopLevelClass(1, 2, 5)).Size);

            // 32 + (1 + 2) * ( 8 + (1 + 3) * (1 + 8))
            Assert.AreEqual(164, RTLSignalTools.SizeOfValue(new TopLevelClass(2, 3, 8)).Size);
        }

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
