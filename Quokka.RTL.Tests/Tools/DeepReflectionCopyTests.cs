using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Quokka.RTL.Tests
{
    enum DeepReflectionCopyTestEnum
    {
        V1,
        V2,
        V3
    }

    class DeepReflectionCopyTestChildClass
    {
        public int Value;
    }

    struct DeepReflectionCopyTestChildStruct
    {
        public int Value { get; set; }
    }

    class DeepReflectionCopyTestClass
    {
        public int Field;
        public int Property { get; set; }
        public DeepReflectionCopyTestEnum Enum;
        public byte[] ArrayOfBytes { get; set; }
        public DeepReflectionCopyTestChildClass[] ArrayOfClasses { get; set; }
        public DeepReflectionCopyTestChildStruct[] ArrayOfStructs { get; set; }
        public RTLBitArray BitArray { get; set; }
        public RTLBitArray[] ArrayOfBitArrays;
        public int Getter => Field + Property;
    }


    class ArrayOfArraysClass
    {
        public ArrayOfArraysClass()
        {
            Data = Enumerable.Range(0, 255).Select(i => new byte[] { (byte)i, 1, 2, 3 }).ToArray();
        }

        public byte[][] Data;
    }

    class ClassWithTupleForReflCopy
    {
        public Tuple<bool, int> Value = new Tuple<bool, int>(true, 42);
    }

    [TestClass]
    public class DeepReflectionCopyTests
    {
        [TestMethod]
        public void TupleCopy()
        {
            var reflCopy = DeepReflectionCopy.DeepCopy(new Tuple<bool, int>(true, 42));
            Assert.AreEqual(true, reflCopy.Item1);
            Assert.AreEqual(42, reflCopy.Item2);

            var classCopy = DeepReflectionCopy.DeepCopy(new ClassWithTupleForReflCopy());
            Assert.AreEqual(true, classCopy.Value.Item1);
            Assert.AreEqual(42, classCopy.Value.Item2);
        }

        [TestMethod]
        public void ArrayOfArrays()
        {
            var source = new ArrayOfArraysClass();
            var jsonCopy = DeepJSONCopy.DeepCopy(source);
            var reflCopy = DeepReflectionCopy.DeepCopy(source);

            var sourcePayload = DeepJSONCopy.Serialize(source);
            var jsonCopyPayload = DeepJSONCopy.Serialize(jsonCopy);
            var reflCopyPayload = DeepJSONCopy.Serialize(reflCopy);

            Assert.AreEqual(sourcePayload, jsonCopyPayload, "JSON payload does not match for json copy");
            Assert.AreEqual(sourcePayload, reflCopyPayload, "JSON payload does not match for reflection copy");
        }

        [TestMethod]
        public void Test()
        {
            var source = new DeepReflectionCopyTestClass()
            {
                Field = 1,
                Property = 2,
                Enum = DeepReflectionCopyTestEnum.V3,
                BitArray = new RTLBitArray(int.MaxValue),
                ArrayOfBitArrays = Enumerable.Range(0, 10).Select(i => new RTLBitArray(i)).ToArray(),
                ArrayOfBytes = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray(),
                ArrayOfStructs = Enumerable.Range(0, 10).Select(i => new DeepReflectionCopyTestChildStruct() { Value = i }).ToArray(),
                ArrayOfClasses = Enumerable.Range(0, 10).Select(i => new DeepReflectionCopyTestChildClass() { Value = i }).ToArray()
            };

            var jsonCopy = DeepJSONCopy.DeepCopy(source);
            var reflCopy = DeepReflectionCopy.DeepCopy(source);

            var sourcePayload = DeepJSONCopy.Serialize(source);
            var jsonCopyPayload = DeepJSONCopy.Serialize(jsonCopy);
            var reflCopyPayload = DeepJSONCopy.Serialize(reflCopy);

            Assert.AreEqual(sourcePayload, jsonCopyPayload, "JSON payload does not match for json copy");
            Assert.AreEqual(sourcePayload, reflCopyPayload, "JSON payload does not match for reflection copy");
        }
    }
}
