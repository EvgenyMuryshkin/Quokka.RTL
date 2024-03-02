using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;

namespace Quokka.RTL.Tests
{
    public class MemoryInitializerFlatClass
    {
        [MemberIndex(0)]
        public int IntValue;

        [MemberIndex(1)]
        public RTLBitArray BitArray { get; set; } = new RTLBitArray().Resized(10);

        [MemberIndex(2)]
        public byte ByteValue;

        [MemberIndex(3)]
        public (bool, byte) TupleBitByteValue;
    }

    public class MemoryInitializerBaseClass
    {
        [MemberIndex(0)]
        public bool BaseBoolean;

        [MemberIndex(1)]
        public byte BaseByte;
    }

    public class MemoryInitializerMidClass : MemoryInitializerBaseClass
    {
        [MemberIndex(0)]
        public (bool, byte) MidTuple;

        [MemberIndex(1)]
        public byte[] MidArray;
    }

    public class MemoryInitializerTopClass : MemoryInitializerMidClass
    {
        public byte[] TopArray;
    }

    public class MemoryInitializerTupleItemClass
    {
        public byte[] Data = new byte[] { 0x81, 0x7e };
    }

    public class MemoryInitializerTupleBaseClass
    {
        public (RTLBitArray, bool) BaseValue = (new RTLBitArray(RTLBitArrayInitType.MSB, "110010"), true);
    }

    public class MemoryInitializerTupleTopClass : MemoryInitializerTupleBaseClass
    {
        public (bool, byte, MemoryInitializerTupleItemClass) Value = (false, 42, new MemoryInitializerTupleItemClass());
    }

    public class MemoryInitializerClassWithClasses
    {
        public MemoryInitializerBaseClass[] Data = new[]
            {
                new MemoryInitializerBaseClass() { BaseBoolean = true, BaseByte = 0x81 },
                new MemoryInitializerBaseClass() { BaseBoolean = false, BaseByte = 0x7E }
            };
    }

    [TestClass]
    public class MemoryElementInitializerTest
    {
        void Test(object value, string expected)
        {
            var actual = RTLSignalTools.MemoryElementInitializer(value).Substring(4);

            expected = expected.Replace(" ", "");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Boolean() => Test(true, "1");

        [TestMethod]
        public void Byte() => Test((byte)0x82, "10000010");

        [TestMethod]
        public void BitArray() => Test(new RTLBitArray(short.MinValue), "10000000 00000000");

        [TestMethod]
        public void Tuple_Native() => Test((true, (byte)0x81), "1 10000001");

        [TestMethod]
        public void Tuple_Array() => Test((true, new byte[] { 1, 2, 3 }), "1 00000011 00000010 00000001");


        [TestMethod]
        public void FlatClass()
        {
            var indexedClass = new MemoryInitializerFlatClass()
            {
                IntValue = 42,
                BitArray = new RTLBitArray(short.MaxValue).Resized(10),
                ByteValue = 0x82,
                TupleBitByteValue = (true, 0x85)
            };
            Test(indexedClass, "1 10000101 10000010 1111111111 00000000 00000000 00000000 00101010");
        }

        [TestMethod]
        public void TopClass()
        {
            var topClass = new MemoryInitializerTopClass()
            {
                BaseBoolean = true,
                BaseByte = 42,
                MidTuple = (true, 0x7e),
                MidArray = new byte[] { 0x81, 0x85 },
                TopArray = new byte[] { 1, 2 }
            };

            Test(topClass, "00000010 00000001 10000101 10000001 1 01111110 00101010 1");
        }

        [TestMethod]
        public void NativeArray()
        {
            var data = new byte[] { 1, 2 };
            Test(data, "00000010 00000001");
        }

        [TestMethod]
        public void ClassArray()
        {
            var data = new[]
            {
                new MemoryInitializerBaseClass() { BaseBoolean = true, BaseByte = 0x81 },
                new MemoryInitializerBaseClass() { BaseBoolean = false, BaseByte = 0x7E }
            };

            Test(data, "01111110 0 10000001 1");
        }

        [TestMethod]
        public void ClassWithClasses()
        {
            var data = new MemoryInitializerClassWithClasses();
            Test(data, "01111110 0 10000001 1");
        }

        [TestMethod]
        public void TupleArray()
        {
            var data = new (bool, byte)[] { (true, 1), (false, 2) };
            Test(data, "0 00000010 1 00000001");
        }

        [TestMethod]
        public void TupleTopClass()
        {
            var data = new MemoryInitializerTupleTopClass()
            {
                Value = (false, 42, new MemoryInitializerTupleItemClass())
            };

            Test(data, "0 00101010 01111110 10000001 110010 1");
        }
    }
}
