using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Quokka.RTL.Tests
{
    abstract class StallControlBaseType
    {
        public bool? ready { get; set; }
    }

    class StallControlStage1 : StallControlBaseType
    {
        public byte data;
        public byte counter;
    }

    public abstract class AutoPropagatePipelineModuleStage
    {
        // nullable signals will be propagated through pipeline
        public bool? ready;
    }

    public class AutoPropagatePipelineModuleStage0 : AutoPropagatePipelineModuleStage
    {
        public ushort[] sums = new ushort[5];
    }

    class DefaultPipline : IRTLPipeline
    {
        public IRTLPipelineDiagnostics Diag => throw new NotImplementedException();
        public void Setup(IRTLCombinationalModule module)
        {
            throw new NotImplementedException();
        }

        public IRTLPipelinePeek<TState> Peek<TState>()
        {
            throw new NotImplementedException();
        }
    }

    class ClassWithPipelines
    {
        IRTLPipeline P1;
        IRTLPipeline NotAPipiline { get; }
    }

    [TestClass]
    public class RTLModuleHelperTests
    {
        [TestMethod]
        public void NullsDeepEquals()
        {
            Assert.IsTrue(DeepDiff.DeepEquals(null, null));
            Assert.IsFalse(DeepDiff.DeepEquals(true, null));
            Assert.IsTrue(DeepDiff.DeepEquals(true, true));
        }

        [TestMethod]
        public void StallTestCase()
        {
            Assert.IsTrue(DeepDiff.DeepEquals(
                new StallControlStage1() { ready = true, counter = 1, data = 2 },
                new StallControlStage1() { ready = true, counter = 1, data = 2 }
            ));
        }

        [TestMethod]
        public void ArrayDeepEquals()
        {
            var s1 = new AutoPropagatePipelineModuleStage0();
            var s2 = new AutoPropagatePipelineModuleStage0();
            Assert.IsTrue(DeepDiff.DeepEquals(s1, s2));
            s1.ready = true;
            s2.ready = true;
            Assert.IsTrue(DeepDiff.DeepEquals(s1, s2));

            s1.sums = new ushort[] { 1, 2 };
            Assert.IsFalse(DeepDiff.DeepEquals(s1, s2));

            s2.sums = new ushort[] { 1, 2 };
            Assert.IsTrue(DeepDiff.DeepEquals(s1, s2));

            s2.sums = new ushort[] { 1, 2, 3 };
            Assert.IsFalse(DeepDiff.DeepEquals(s1, s2));

            s2.sums = null;
            Assert.IsFalse(DeepDiff.DeepEquals(s1, s2));
        }

        [TestMethod]
        public void IsPipelineTypeMemberTest()
        {
            Assert.IsTrue(RTLModuleHelper.IsPipelineTypeMember(typeof(DefaultPipline)));
        }

        [TestMethod]
        public void PipelinePropertiesTest()
        {
            Assert.AreEqual(1, RTLModuleHelper.PipelineProperties(typeof(ClassWithPipelines)).Count);
        }
        [TestMethod]
        public void SynthesizableStructWithClassTest()
        {
            Assert.IsTrue(DeepDiff.DeepEquals(new SynthesizableClassWithClass(), new SynthesizableClassWithClass()));

            var c1 = new SynthesizableClassWithClass()
            {
                Value = 10
            };
            var c2 = new SynthesizableClassWithClass()
            {
                Value = 20
            };
            Assert.IsFalse(DeepDiff.DeepEquals(c1, c2));

            var c3 = new SynthesizableClassWithClass()
            {
                Class = new SynthesizableClass1(8)
            };
            var c4 = new SynthesizableClassWithClass()
            {
                Class = new SynthesizableClass1(8)
            };
            Assert.IsTrue(DeepDiff.DeepEquals(c3, c4));

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
            Assert.IsFalse(DeepDiff.DeepEquals(c5, c6));

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
            Assert.IsTrue(RTLModuleHelper.IsSynthesizableObject(typeof(SynthesizableClassWithNullables)));
            Assert.IsTrue(RTLModuleHelper.IsSynthesizableObject(typeof(Stage0PipelineState)));            
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
        public void SynthesizableNullableType()
        {
            Assert.IsFalse(RTLModuleHelper.IsSynthesizableObject(typeof(bool?)));
        }

        [TestMethod]
        public void AbstractImplementationTest()
        {
            var outputProps = RTLModuleHelper.OutputProperties(typeof(ImplementationClass));
            Assert.AreEqual(1, outputProps.Count);
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
        public void ActivateNullable()
        {
            Assert.AreEqual(false, RTLModuleHelper.Activate<bool?>());
            Assert.AreEqual(0, RTLModuleHelper.Activate<int?>());
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
