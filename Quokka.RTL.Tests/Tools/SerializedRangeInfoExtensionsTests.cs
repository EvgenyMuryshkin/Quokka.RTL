using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quokka.RTL.Tests
{
    public class SerializedRangeInfoExtensionsTestNestedBaseClass
    {
        public byte ByteValue;
        public byte[] ByteArray = new byte[] { 1, 2 };
        public (byte, bool) TupleValue = (0x81, true);
        public RTLBitArray BitArray = new RTLBitArray(0);
    }

    public class SerializedRangeInfoExtensionsTestNestedL2 : SerializedRangeInfoExtensionsTestNestedBaseClass
    {

    }

    class SerializedRangeInfoExtensionsTestNestedL1 : SerializedRangeInfoExtensionsTestNestedBaseClass
    {
        public SerializedRangeInfoExtensionsTestNestedL2 L2 = new SerializedRangeInfoExtensionsTestNestedL2();
    }

    class SerializedRangeInfoExtensionsTestBaseClass
    {
        public SerializedRangeInfoExtensionsTestNestedL1 Nested = new SerializedRangeInfoExtensionsTestNestedL1();
    }

    class SerializedRangeInfoExtensionsTestTopClass : SerializedRangeInfoExtensionsTestBaseClass
    {
        public byte ByteValue;
        public byte[] ByteArray = new byte[] { 1, 2 };
        public (byte, bool, SerializedRangeInfoExtensionsTestNestedBaseClass) TupleValue = (0x81, true, new SerializedRangeInfoExtensionsTestNestedBaseClass());
        public RTLBitArray BitArray = new RTLBitArray(0);
    }


    [TestClass]
    public class SerializedRangeInfoExtensionsTests : SerializedRangeInfoTestTemplate
    {
        [TestMethod]
        public override void SelfNative()
        {
            var data = 0;
            var path = data.FromExpression(d => d);
            Assert.IsTrue(path.Count == 0);
        }

        [TestMethod]
        public override void SelfArray()
        {
            var data = new[] { 0, 1 };
            var path = data.FromExpression(d => d);
            Assert.IsTrue(path.Count == 0);
        }

        [TestMethod]
        public override void ArrayIndex()
        {
            var data = new[] { 0, 1 };
            var path = data.FromExpression(d => d[1]);
            Assert.IsTrue(path.Count == 1);
            Assert.IsNull(path[0].Member);
            Assert.AreEqual(1, path[0].Index);
        }

        [TestMethod]
        public override void TupleItem()
        {
            var data = (true, (byte)42);
            var path = data.FromExpression(d => d.Item2);
            Assert.IsTrue(path.Count == 1);
            Assert.AreEqual("Item2", path[0].Member.Name);
            Assert.IsNull(path[0].Index);
        }

        [TestMethod]
        public override void TupleItemIndex()
        {
            var data = (new byte[] { 42, 0x81 }, true);
            var path = data.FromExpression(d => d.Item1[1]);
            Assert.IsTrue(path.Count == 1);
            Assert.AreEqual("Item1", path[0].Member.Name);
            Assert.AreEqual(1, path[0].Index);
        }

        [TestMethod]
        public override void TupleArrayItem()
        {
            var data = new[] 
            {
                (new byte[] { 42, 0x81 }, true),
                (new byte[] { 1, 0x82 }, false)
            };

            var path = data.FromExpression(d => d[1].Item1);
            Assert.IsTrue(path.Count == 2);
            Assert.IsNull(path[0].Member);
            Assert.AreEqual(1, path[0].Index);
            Assert.AreEqual("Item1", path[1].Member.Name);
            Assert.IsNull(path[1].Index);
        }

        [TestMethod]
        public override void TupleArrayItemIndex()
        {
            var data = new[]
            {
                (new byte[] { 42, 0x81 }, true),
                (new byte[] { 1, 0x82 }, false)
            };

            var path = data.FromExpression(d => d[1].Item1[1]);
            Assert.IsTrue(path.Count == 2);
            Assert.IsNull(path[0].Member);
            Assert.AreEqual(1, path[0].Index);
            Assert.AreEqual("Item1", path[1].Member.Name);
            Assert.AreEqual(1, path[1].Index);
        }


        [TestMethod]
        public override void ClassMember()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass();
            var path = data.FromExpression(d => d.ByteValue);
            Assert.IsTrue(path.Count == 1);
            Assert.AreEqual("ByteValue", path[0].Member.Name);
            Assert.IsNull(path[0].Index);
        }

        [TestMethod]
        public override void ClassMemberIndex()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass();
            var path = data.FromExpression(d => d.ByteArray[1]);
            Assert.IsTrue(path.Count == 1);
            Assert.AreEqual("ByteArray", path[0].Member.Name);
            Assert.AreEqual(1, path[0].Index);
        }

        [TestMethod]
        public override void ClassTupleValue()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass();
            var path = data.FromExpression(d => d.TupleValue.Item1);
            Assert.IsTrue(path.Count == 2);
            Assert.AreEqual("TupleValue", path[0].Member.Name);
            Assert.IsNull(path[0].Index);
            Assert.AreEqual("Item1", path[1].Member.Name);
            Assert.IsNull(path[1].Index);
        }

        [TestMethod]
        public override void ClassTupleNestedValue()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass();
            var path = data.FromExpression(d => d.TupleValue.Item3.ByteValue);
            Assert.IsTrue(path.Count == 3);
            Assert.AreEqual("TupleValue", path[0].Member.Name);
            Assert.IsNull(path[0].Index);
            Assert.AreEqual("Item3", path[1].Member.Name);
            Assert.IsNull(path[1].Index);
            Assert.AreEqual("ByteValue", path[2].Member.Name);
            Assert.IsNull(path[2].Index);
        }

        [TestMethod]
        public override void ClassTupleNestedIndex()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass();
            var path = data.FromExpression(d => d.TupleValue.Item3.ByteArray[1]);
            Assert.IsTrue(path.Count == 3);
            Assert.AreEqual("TupleValue", path[0].Member.Name);
            Assert.IsNull(path[0].Index);
            Assert.AreEqual("Item3", path[1].Member.Name);
            Assert.IsNull(path[1].Index);
            Assert.AreEqual("ByteArray", path[2].Member.Name);
            Assert.AreEqual(1, path[2].Index);
        }
    }
}
