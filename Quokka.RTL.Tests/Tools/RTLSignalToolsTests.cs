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

        [MemberIndex(0)]
        public bool boolValue;

        [MemberIndex(1)]
        public RTLBitArray bitArray;
    }

    class NestedClassL1
    {
        public NestedClassL1(int l2Size, int bitArray)
        {
            l2 = new NestedClassL2(bitArray);
            l2Array = Enumerable.Range(0, l2Size).Select(i => new NestedClassL2(bitArray)).ToArray();
        }

        [MemberIndex(0)]
        public NestedClassL2 l2;

        [MemberIndex(1)]
        public NestedClassL2[] l2Array;

        [MemberIndex(2)]
        public byte byteValue;
    }

    class TopLevelClass
    {
        public TopLevelClass(int l1Size, int l2Size, int bitArray)
        {
            l1 = new NestedClassL1(l2Size, bitArray);
            l1Array = Enumerable.Range(0, l1Size).Select(i => new NestedClassL1(l2Size, bitArray)).ToArray();
        }

        [MemberIndex(0)]
        public NestedClassL1 l1;

        [MemberIndex(1)]
        public NestedClassL1[] l1Array;

        [MemberIndex(2)]
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

    class BaseClassWithArray
    {
        [MemberIndex(0)]
        public byte[] baseArray = new byte[4];

        [MemberIndex(1)]
        public bool baseBoolean;
    }

    class ClassWithArray : BaseClassWithArray
    {
        [MemberIndex(0)]
        public byte[] topLevelArray = new byte[4];

        [MemberIndex(1)]
        public ClassWithTuple ClassWithTuple = new ClassWithTuple(2, 3, 8);
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
    }
}
