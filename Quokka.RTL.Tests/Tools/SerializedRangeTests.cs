using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Quokka.RTL.Tests
{
    [TestClass]
    public class SerializedRangeTests : SerializedRangeInfoTestTemplate
    {
        void TestRange<T, TResult>(T source, Expression<Func<T, TResult>> expression, string expected)
        {
            var value = RTLSignalTools.MemoryElementInitializer(source).Substring(4);
            var reversed = string.Join("", value.Reverse());

            var path = source.FromExpression(expression);
            var (from, to) = RTLReflectionTools.SerializedRange(source, path.ToArray());
            var actual = string.Join("", reversed.Skip(to).Take(from - to + 1).Reverse());

            expected = expected.Replace(" ", "");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public override void SelfNative()
        {
            var data = byte.MaxValue;
            TestRange(data, data => data, "11111111");
        }

        [TestMethod]
        public override void SelfArray()
        {
            var data = new byte[] { 1, 2 };
            TestRange(data, data => data, "00000010 00000001");
        }

        [TestMethod]
        public override void ArrayIndex()
        {
            var data = new byte[] { 1, 2 };
            TestRange(data, data => data[1], "00000010");
        }

        [TestMethod]
        public override void TupleItem()
        {
            var data = (true, (byte)42);
            TestRange(data, data => data.Item2, "00101010");
        }

        [TestMethod]
        public override void TupleItemIndex()
        {
            var data = (new byte[] { 0, 0x81 }, false);
            TestRange(data, data => data.Item1[1], "10000001");
        }

        [TestMethod]
        public override void TupleArrayItem()
        {
            var data = new[]
            {
                (new byte[] { 42, 0x81 }, true),
                (new byte[] { 1, 0x82 }, false)
            };

            TestRange(data, data => data[1], "10000010 00000001 0");
            TestRange(data, data => data[1].Item1, "10000010 00000001");
        }

        [TestMethod]
        public override void TupleArrayItemIndex()
        {
            var data = new[]
            {
                (new byte[] { 42, 0x81 }, true),
                (new byte[] { 1, 0x82 }, false)
            };
            TestRange(data, data => data[1].Item1[1], "10000010");
        }

        [TestMethod]
        public override void ClassMember()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass() { ByteValue = 0x81 };
            TestRange(data, data => data.ByteValue, "10000001");
        }

        [TestMethod]
        public override void ClassMemberIndex()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass() { ByteArray = new byte[] { 0x81, 0x7e } };
            TestRange(data, data => data.ByteArray[1], "01111110");
        }

        [TestMethod]
        public override void ClassTupleValue()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass()
            {
                TupleValue = (42, true, new SerializedRangeInfoExtensionsTestNestedBaseClass())
            };
            TestRange(data, data => data.TupleValue.Item1, "00101010");
            TestRange(data, data => data.TupleValue.Item2, "1");
        }

        [TestMethod]
        public override void ClassTupleNestedValue()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass();
            data.TupleValue.Item3.ByteValue = 42;
            TestRange(data, data => data.TupleValue.Item3.ByteValue, "00101010");
        }

        [TestMethod]
        public override void ClassTupleNestedIndex()
        {
            var data = new SerializedRangeInfoExtensionsTestTopClass();
            data.TupleValue.Item3.ByteArray[1] = 42;
            TestRange(data, data => data.TupleValue.Item3.ByteArray[1], "00101010");
        }
    }
}
