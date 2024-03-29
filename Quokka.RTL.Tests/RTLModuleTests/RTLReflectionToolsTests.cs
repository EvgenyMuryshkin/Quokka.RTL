﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Linq;

namespace Quokka.RTL.Tests
{
    public interface IRFT1
    {
        int IRFT1Prop { get; set; }
    }

    public interface IRFT2
    {
        int IRFT2Prop { get; }
    }

    public class RFTClass : IRFT1, IRFT2
    {
        public int RFTClassField;
        public RTLBitArray RFTClassProp { get; set; }
        public int IRFT1Prop { get; set; }

        int IRFT2.IRFT2Prop => 0;
    }

    public class t_iq
    {
        public t_iq(int size)
        {
            i = new RTLBitArray().Resized(size);
            q = new RTLBitArray().Resized(size);
        }

        [MemberIndex(0)]
        public RTLBitArray i;

        [MemberIndex(1)]
        public RTLBitArray q;
    }

    public class t_iq16 : t_iq
    {
        public t_iq16() : base(16) { }
    }

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

    public class IOTupleModuleInputsObjectL2
    {
        public bool L2Flag;
    }

    public class IOTupleModuleInputsObjectL1
    {
        public bool L1Flag;
        public IOTupleModuleInputsObjectL2 L2 = new IOTupleModuleInputsObjectL2();
    }

    public class IOTupleModuleInputs
    {
        public Tuple<bool, byte, RTLBitArray, IOTupleModuleInputsObjectL1> iTuple = new Tuple<bool, byte, RTLBitArray, IOTupleModuleInputsObjectL1>(false, byte.MinValue, new RTLBitArray().Resized(4), new IOTupleModuleInputsObjectL1());
    }

    [TestClass]
    public class RTLReflectionToolsTests
    {
        [TestMethod]
        public void PiplineRequestMembers()
        {
            Assert.AreEqual(3, RTLReflectionTools.SerializableMembers(typeof(RTLPipelineStageRequestSignals)).Count);
        }

        [TestMethod]
        public void InterfaceMembers()
        {
            Assert.AreEqual(1, RTLReflectionTools.SynthesizableMembers(typeof(IRTLPipelinePreviewSignals)).Count());
        }

        [TestMethod]
        public void TupleMembers()
        {
            Assert.AreEqual(
                5, 
                RTLReflectionTools.SynthesizableMembers(
                    typeof((int, bool, (int, bool), RTLBitArray, BaseMembersTestClass))
                    ).Count()
            );
        }

        [TestMethod]
        public void SynthesizableMembersTest()
        {
            Assert.AreEqual(3, RTLReflectionTools.SynthesizableMembers(typeof(BaseMembersTestClass)).Count());
            Assert.AreEqual(7, RTLReflectionTools.SynthesizableMembers(typeof(DerivedTestClass)).Count());
        }

        [TestMethod]
        public void SynthesizableMembersTupleTest()
        {
            Assert.AreEqual(1, RTLReflectionTools.SynthesizableMembers(typeof(IOTupleModuleInputs)).Count());
            Assert.AreEqual(1, RTLReflectionTools.SerializableMembers(typeof(IOTupleModuleInputs)).Count());

            Assert.AreEqual(2, RTLReflectionTools.SynthesizableMembers(typeof(IOTupleModuleInputsObjectL1)).Count());
            Assert.AreEqual(2, RTLReflectionTools.SerializableMembers(typeof(IOTupleModuleInputsObjectL1)).Count());

            Assert.AreEqual(3, RTLReflectionTools.SerializableMembers(typeof(Tuple<bool, byte, int>)).Count());
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
        public void BooRange()
        {
            var value = new IOTupleModuleInputsObjectL1();
            var flag = value.GetType().GetMember(nameof(IOTupleModuleInputsObjectL1.L1Flag))[0];
            var flagRange = RTLReflectionTools.SerializedRange(value, flag);
            Assert.IsFalse(flagRange.IsRange);

            var l2 = value.GetType().GetMember(nameof(IOTupleModuleInputsObjectL1.L2))[0];
            var l2Range = RTLReflectionTools.SerializedRange(value, l2);
            Assert.IsTrue(l2Range.IsRange);

        }

        [TestMethod]
        public void t_iq16()
        {
            var value = new t_iq16();
            var i = value.GetType().GetMember("i")[0];
            var q = value.GetType().GetMember("q")[0];

            var i_range = RTLReflectionTools.SerializedRange(value, i).FromTo();
            Assert.AreEqual(15, i_range.Item1);
            Assert.AreEqual(0, i_range.Item2);

            var q_range = RTLReflectionTools.SerializedRange(value, q).FromTo();
            Assert.AreEqual(31, q_range.Item1);
            Assert.AreEqual(16, q_range.Item2);
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
            var range = RTLReflectionTools.SerializedRange(nonIndexed, nonIndexedMember).FromTo();
            Assert.AreEqual(31, range.Item1);
            Assert.AreEqual(0, range.Item2);
        }

        [TestMethod]
        public void SerializedRange_Value()
        {
            var indexedClass = new IndexedClass();
            Assert.AreEqual((31, 0), RTLReflectionTools.SerializedRange(indexedClass, typeof(IndexedClass).GetMember(nameof(IndexedClass.IntValue))[0]).FromTo());
            Assert.AreEqual((41, 32), RTLReflectionTools.SerializedRange(indexedClass, typeof(IndexedClass).GetMember(nameof(IndexedClass.BitArray))[0]).FromTo());
            Assert.AreEqual((49, 42), RTLReflectionTools.SerializedRange(indexedClass, typeof(IndexedClass).GetMember(nameof(IndexedClass.ByteValue))[0]).FromTo());
        }

        [TestMethod]
        public void RecursiveMembers()
        {
            var members = RTLReflectionTools.RecursiveMembers(typeof(RFTClass));
            Assert.AreEqual(4, members.Count());
        }
    }
}
