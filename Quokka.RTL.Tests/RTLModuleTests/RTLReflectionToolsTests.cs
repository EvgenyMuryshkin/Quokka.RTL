using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Linq;

namespace Quokka.RTL.Tests
{
    public class NotIndexedClass
    {
        public int Value;
    }

    public class IndexedClass
    {
        [MemberIndex(0)]
        public int IntValue;

        [MemberIndex(1)]
        public RTLBitArray BitArray { get; set; } = new RTLBitArray().Resized(10);

        [MemberIndex(2)]
        public byte ByteValue;
    }

    [TestClass]
    public class RTLReflectionToolsTests
    {
        [TestMethod]
        public void InterfaceMembers()
        {
            Assert.AreEqual(1, RTLReflectionTools.RecursiveMembers(typeof(IRTLPipelinePreviewSignals)).Count());
        }

        [TestMethod]
        public void SynthesizableMembersTest()
        {
            Assert.AreEqual(3, RTLReflectionTools.SynthesizableMembers(typeof(BaseMembersTestClass)).Count());
            Assert.AreEqual(7, RTLReflectionTools.SynthesizableMembers(typeof(DerivedTestClass)).Count());
        }

        [TestMethod]
        public void IsInternalPropertyTest()
        {
            var props = RTLReflectionTools.SynthesizableMembers(typeof(DerivedTestClass));
            var internals = props.Where(p => RTLModuleHelper.IsInternalProperty(p));

            // arrays and private\protected members are considered internals 
            Assert.AreEqual(5, internals.Count());
        }

        [TestMethod]
        public void CustomBitArrayMember()
        {
            var props = RTLReflectionTools.SynthesizableMembers(typeof(CustomBitArrayClass));
            var internals = props.Where(p => RTLModuleHelper.IsInternalProperty(p));
            Assert.AreEqual(1, internals.Count());

            Assert.IsTrue(RTLTypeCheck.IsSynthesizableObject(typeof(CustomBitArrayClass)));
        }

        [TestMethod]
        public void SerializedRange_Exception()
        {
            var nonIndexed = new NotIndexedClass();
            var nonIndexedMember = typeof(NotIndexedClass).GetMember("Value")[0];

            Assert.ThrowsException<NullReferenceException>(() => RTLReflectionTools.SerializedRange(null, null));
            Assert.ThrowsException<NullReferenceException>(() => RTLReflectionTools.SerializedRange(nonIndexed, null));
            Assert.ThrowsException<Exception>(() => RTLReflectionTools.SerializedRange(nonIndexed, nonIndexedMember));
        }

        [TestMethod]
        public void SerializedRange_Valie()
        {
            var indexedClass = new IndexedClass();
            Assert.AreEqual((31, 0), RTLReflectionTools.SerializedRange(indexedClass, typeof(IndexedClass).GetMember(nameof(IndexedClass.IntValue))[0]));
            Assert.AreEqual((41, 32), RTLReflectionTools.SerializedRange(indexedClass, typeof(IndexedClass).GetMember(nameof(IndexedClass.BitArray))[0]));
            Assert.AreEqual((49, 42), RTLReflectionTools.SerializedRange(indexedClass, typeof(IndexedClass).GetMember(nameof(IndexedClass.ByteValue))[0]));
        }

    }
}
