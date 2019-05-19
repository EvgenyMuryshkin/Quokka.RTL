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
        [TestMethod]
        public void Serialization()
        {
            var data = new RTLBitArray(42);
            var serialized = JsonConvert.SerializeObject(data);
            var deserialized = JsonConvert.DeserializeObject<RTLBitArray>(serialized);

            Assert.IsNotNull(serialized);
            Assert.IsNotNull(deserialized);
            Assert.AreEqual(data.DataType, deserialized.DataType);
            Assert.AreEqual(data.Size, deserialized.Size);
            Assert.AreEqual((byte)data, (byte)deserialized);
        }
    }
}
