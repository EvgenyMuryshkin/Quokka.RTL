using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.RTLBitArrayTests
{
    [TestClass]
    public class JsonTests
    {
        void AssertEquals(RTLBitArray expected, RTLBitArray actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.DataType, actual.DataType);
            Assert.AreEqual(expected.Size, actual.Size);
            Assert.AreEqual((byte)expected, (byte)actual);
        }

        [TestMethod]
        public void SerializationEmpty()
        {
            var data = new RTLBitArray().Resized(0);
            var serialized = JsonConvert.SerializeObject(data);
            var deserialized = JsonConvert.DeserializeObject<RTLBitArray>(serialized);

            AssertEquals(data, deserialized);
        }

        [TestMethod]
        public void Serialization()
        {
            var data = new RTLBitArray(42);
            var serialized = JsonConvert.SerializeObject(data);
            Assert.IsNotNull(serialized);

            var deserialized = JsonConvert.DeserializeObject<RTLBitArray>(serialized);

            AssertEquals(data, deserialized);
        }
    }
}
