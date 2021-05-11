using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    [TestClass]
    public class DeepReflectionCopyTests
    {
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
