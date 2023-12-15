using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;

namespace Quokka.RTL.Tests
{
    public class StateBitArrayAdjustChild
    {
        public StateBitArrayAdjustChild(int bits, RTLDataType type)
        {
            Field = new RTLBitArray().Resized(bits).TypeChanged(type);
            FieldArray = new[] { new RTLBitArray().Resized(bits).TypeChanged(type), new RTLBitArray().Resized(bits).TypeChanged(type) };
            Property = new RTLBitArray().Resized(bits).TypeChanged(type);
            PropertyArray = new[] { new RTLBitArray().Resized(bits).TypeChanged(type), new RTLBitArray().Resized(bits).TypeChanged(type) };
        }

        public RTLBitArray Field;
        public RTLBitArray[] FieldArray;
        public RTLBitArray Property { get; set; }
        public RTLBitArray[] PropertyArray { get; set; }
    }

    public class StateBitArrayAdjustParent
    {
        public StateBitArrayAdjustParent(int bits, RTLDataType type)
        {
            Field = new RTLBitArray().Resized(bits).TypeChanged(type);
            FieldArray = new[] { new RTLBitArray().Resized(bits).TypeChanged(type), new RTLBitArray().Resized(bits).TypeChanged(type) };
            Property = new RTLBitArray().Resized(bits).TypeChanged(type);
            PropertyArray = new[] { new RTLBitArray().Resized(bits).TypeChanged(type), new RTLBitArray().Resized(bits).TypeChanged(type) };
            ChildField = new StateBitArrayAdjustChild(bits, type);
            ChildProperty = new StateBitArrayAdjustChild(bits, type);
            ChildFieldList = new List<StateBitArrayAdjustChild>()
            {
                new StateBitArrayAdjustChild(bits, type),
                new StateBitArrayAdjustChild(bits, type)
            };
            ChildPropertyList = new List<StateBitArrayAdjustChild>()
            {
                new StateBitArrayAdjustChild(bits, type),
                new StateBitArrayAdjustChild(bits, type)
            };
            ChildFieldArray = new[]
            {
                new StateBitArrayAdjustChild(bits, type),
                new StateBitArrayAdjustChild(bits, type)
            };
            ChildPropertyArray = new[]
            {
                new StateBitArrayAdjustChild(bits, type),
                new StateBitArrayAdjustChild(bits, type)
            };
        }

        public RTLBitArray Field;
        public RTLBitArray[] FieldArray;
        public RTLBitArray Property { get; set; }
        public RTLBitArray[] PropertyArray { get; set; }

        public StateBitArrayAdjustChild ChildField { get; set; }
        public StateBitArrayAdjustChild ChildProperty { get; set; }
        public List<StateBitArrayAdjustChild> ChildFieldList;
        public List<StateBitArrayAdjustChild> ChildPropertyList { get; set; }
        public StateBitArrayAdjustChild[] ChildFieldArray;
        public StateBitArrayAdjustChild[] ChildPropertyArray { get; set; }
    }

    [TestClass]
    public class StateBitArrayAdjustTests
    {
        void assertBitArray(RTLBitArray source, int bits, RTLDataType type)
        {
            Assert.AreEqual(bits, source.Size);
            Assert.AreEqual(type, source.DataType);
        }

        void assertBitArray(IEnumerable<RTLBitArray> source, int bits, RTLDataType type)
        {
            foreach (var i in source)
                assertBitArray(i, bits, type);
        }

        void assertObject(StateBitArrayAdjustChild source, int bits, RTLDataType type)
        {
            assertBitArray(source.Field, bits, type);
            assertBitArray(source.FieldArray, bits, type);
            assertBitArray(source.Property, bits, type);
            assertBitArray(source.PropertyArray, bits, type);
        }

        void assertObject(StateBitArrayAdjustParent source, int bits, RTLDataType type)
        {
            assertBitArray(source.Field, bits, type);
            assertBitArray(source.FieldArray, bits, type);
            assertBitArray(source.Property, bits, type);
            assertBitArray(source.PropertyArray, bits, type);

            assertObject(source.ChildField, bits, type);
            assertObject(source.ChildProperty, bits, type);

            foreach (var i in source.ChildFieldList)
                assertObject(i, bits, type);

            foreach (var i in source.ChildPropertyList)
                assertObject(i, bits, type);

            foreach (var i in source.ChildFieldArray)
                assertObject(i, bits, type);

            foreach (var i in source.ChildPropertyArray)
                assertObject(i, bits, type);
        }

        [TestMethod]
        public void RunTest()
        {
            var state = new StateBitArrayAdjustParent(10, RTLDataType.Unsigned);
            var nextState = new StateBitArrayAdjustParent(11, RTLDataType.Signed);

            assertObject(state, 10, RTLDataType.Unsigned);
            assertObject(nextState, 11, RTLDataType.Signed);

            var adjust = new StateBitArrayAdjust<StateBitArrayAdjustParent>();
            adjust.Run(state, nextState);

            assertObject(nextState, 10, RTLDataType.Unsigned);
        }
    }
}
