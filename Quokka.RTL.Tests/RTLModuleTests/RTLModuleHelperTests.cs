using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Quokka.RTL.Tests
{
    class DefaultPipline : IRTLPipeline
    {
        public IRTLPipelineDiagnostics Diag => throw new NotImplementedException();
        public void Setup()
        {
            throw new NotImplementedException();
        }
    }

    class ClassWithPipelines
    {
        IRTLPipeline P1;
        IRTLPipeline P2 { get; }
    }

    [TestClass]
    public class RTLModuleHelperTests
    {
        [TestMethod]
        public void IsPipelineTypeMemberTest()
        {
            Assert.IsTrue(RTLModuleHelper.IsPipelineTypeMember(typeof(DefaultPipline)));
        }

        [TestMethod]
        public void PipelinePropertiesTest()
        {
            Assert.AreEqual(2, RTLModuleHelper.PipelineProperties(typeof(ClassWithPipelines)).Count);
        }
        [TestMethod]
        public void SynthesizableStructWithClassTest()
        {
            Assert.IsTrue(RTLModuleHelper.DeepEquals(new SynthesizableClassWithClass(), new SynthesizableClassWithClass()));

            var c1 = new SynthesizableClassWithClass()
            {
                Value = 10
            };
            var c2 = new SynthesizableClassWithClass()
            {
                Value = 20
            };
            Assert.IsFalse(RTLModuleHelper.DeepEquals(c1, c2));

            var c3 = new SynthesizableClassWithClass()
            {
                Class = new SynthesizableClass1(8)
            };
            var c4 = new SynthesizableClassWithClass()
            {
                Class = new SynthesizableClass1(8)
            };
            Assert.IsTrue(RTLModuleHelper.DeepEquals(c3, c4));

            var c5 = new SynthesizableClassWithClass()
            {
                Class = new SynthesizableClass1(8),
                Value = 10
            };
            var c6 = new SynthesizableClassWithClass()
            {
                Value = 20,
                Class = new SynthesizableClass1(8)
            };
            Assert.IsFalse(RTLModuleHelper.DeepEquals(c5, c6));

        }

        [TestMethod]
        public void SynthesizableStructTest()
        {
            Assert.IsTrue(RTLModuleHelper.IsSynthesizableObject(typeof(SynthesizableStruct)));
        }
        [TestMethod]
        public void SynthesizableClassTest()
        {
            Assert.IsTrue(RTLModuleHelper.IsSynthesizableObject(typeof(SynthesizableClass1)));
            Assert.IsTrue(RTLModuleHelper.IsSynthesizableObject(typeof(SynthesizableClass2)));
        }
        [TestMethod]
        public void NonSynthesizableStructTest()
        {
            Assert.IsTrue(RTLModuleHelper.IsSynthesizableObject(typeof(NonSynthesizableStruct)));
        }
        [TestMethod]
        public void NonSynthesizableClassTest()
        {
            Assert.IsTrue(RTLModuleHelper.IsSynthesizableObject(typeof(NonSynthesizableClass1)));
            Assert.IsTrue(RTLModuleHelper.IsSynthesizableObject(typeof(NonSynthesizableClass2)));
        }

        [TestMethod]
        public void AbstractImplementationTest()
        {
            var outputProps = RTLModuleHelper.OutputProperties(typeof(ImplementationClass));
            Assert.AreEqual(1, outputProps.Count);
        }

        [TestMethod]
        public void SynthesizableMembersTest()
        {
            Assert.AreEqual(3, RTLModuleHelper.SynthesizableMembers(typeof(BaseMembersTestClass)).Count());
            Assert.AreEqual(7, RTLModuleHelper.SynthesizableMembers(typeof(DerivedTestClass)).Count());
        }

        [TestMethod]
        public void IsInternalPropertyTest()
        {
            var props = RTLModuleHelper.SynthesizableMembers(typeof(DerivedTestClass));
            var internals = props.Where(p => RTLModuleHelper.IsInternalProperty(p));

            // arrays and private\protected members are considered internals 
            Assert.AreEqual(5, internals.Count());
        }

        [TestMethod]
        public void OverrideOutputTest()
        {
            var outputProps = RTLModuleHelper.OutputProperties(typeof(InheritedModule));
            Assert.AreEqual(1, outputProps.Count);
            Assert.AreEqual(typeof(InheritedModule), outputProps[0].DeclaringType);
        }

        [TestMethod]
        public void OverrideInputsTest()
        {
            var internalProps = RTLModuleHelper.InternalProperties(typeof(InheritedModule));
            Assert.AreEqual(1, internalProps.Count);
            Assert.AreEqual(typeof(InheritedModule), internalProps[0].DeclaringType);
        }

        [TestMethod]
        public void ActivateNative()
        {
            Assert.AreEqual(false, RTLModuleHelper.Activate<bool>());
            Assert.AreEqual(0, RTLModuleHelper.Activate<int>());
        }

        [TestMethod]
        public void ActivateStruct()
        {
            var defaultStruct = RTLModuleHelper.Activate<SynthesizableStruct>();
            Assert.AreEqual(0, defaultStruct.Value);
            Assert.AreEqual(false, defaultStruct.Flag);
            Assert.IsNull(defaultStruct.Array);
        }

        [TestMethod]
        public void ActivateClass()
        {
            var instance = RTLModuleHelper.Activate<SynthesizableClassWithClass>();
            Assert.AreEqual(42, instance.Value);
            Assert.IsNotNull(instance.Class);
            Assert.AreEqual(1, instance.Class.Array.Size);
        }

        T ActivateAnonymousType<T>(T template)
        {
            return RTLModuleHelper.Activate<T>();
        }

        [TestMethod]
        public void ActivateAnonymous()
        {
            var instance = ActivateAnonymousType(new { 
                Flag = true, 
                Value = 10, 
                Struct = new SynthesizableStruct(), 
                Class = new SynthesizableClassWithClass() 
            });

            // top level fields
            Assert.AreEqual(false, instance.Flag);
            Assert.AreEqual(0, instance.Value);

            // struct
            Assert.AreEqual(0, instance.Struct.Value);
            Assert.AreEqual(false, instance.Struct.Flag);
            Assert.IsNull(instance.Struct.Array);

            // class
            Assert.AreEqual(42, instance.Class.Class.Value);
            Assert.IsNotNull(instance.Class.Class);
            Assert.AreEqual(1, instance.Class.Class.Array.Size);
        }
    }
}
