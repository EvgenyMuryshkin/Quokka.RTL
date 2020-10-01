using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quokka.RTL.Tests
{
    struct SynthesizableStruct
    {
        public int Value;
        public bool Flag { get; set; }
        public RTLBitArray Array { get; set; }

        public SynthesizableStruct(int size)
        {
            Value = 10;
            Flag = true;
            Array = new RTLBitArray(size);
        }
    }

    class SynthesizableClass1
    {
        public int Value;
        public bool Flag { get; set; }
        public RTLBitArray Array { get; set; } = new RTLBitArray(8);

        public SynthesizableClass1(int size)
        {
            Array = new RTLBitArray(size);
        }
    }

    class SynthesizableClass2
    {
        public int Size = 8;
        public SynthesizableStruct Struct { get; set; }

        public SynthesizableClass2()
        {
            Struct = new SynthesizableStruct();
        }

        public SynthesizableClass2(int size)
        {
            Struct = new SynthesizableStruct(size);
            Size = size;
        }
    }

    struct NonSynthesizableStruct
    {
        public void Method()
        {

        }
    }

    class NonSynthesizableClass1
    {
        public NonSynthesizableStruct Struct = new NonSynthesizableStruct();
    }

    class NonSynthesizableClass2
    {
        public void Method()
        {

        }
    }

    class BaseOverrideModule : RTLCombinationalModule<TestInputs>
    {
        public virtual bool OutValue => Inputs.WE;
        protected virtual bool InternalValue => Inputs.WE;
    }

    class InheritedModule : BaseOverrideModule
    {
        public override bool OutValue => false;
        protected override bool InternalValue => false;
    }

    class ParentModule : RTLCombinationalModule<TestInputs>
    {
        public KeepTestModule SingleChild1 = new KeepTestModule();
        public KeepTestModule SingleChild2 = new KeepTestModule();
        byte internalData => SingleChild1.Data;

        public byte Data => internalData;

        KeepTestModule[] children => new[]
        {
            SingleChild1,
            SingleChild2
        };

        protected override void OnSchedule(Func<TestInputs> inputsFactory)
        {
            base.OnSchedule(inputsFactory);

            SingleChild1.Schedule(inputsFactory);
            SingleChild2.Schedule(inputsFactory);
        }
    }

    public class BaseMembersTestClass
    {
        public int BasePublic1;
        RTLBitArray BasePrivate1;
        byte[] BasePrivate2 = new byte[256];
    }

    public class DerivedTestClass : BaseMembersTestClass
    {
        public bool DerivedPublic1;
        byte[] DerivedPrivate1 = new byte[256];

        RTLBitArray DerivedPrivate2;
        RTLBitArray DerivedPrivate3 => DerivedPublic1;
    }

    public abstract class AbstractBaseClass
    {
        public abstract bool Value { get; }
    }

    public class ImplementationClass : AbstractBaseClass
    {
        public override bool Value => true;
    }

    [TestClass]
    public class RTLModuleTests
    {
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
        public void IsInternalTest()
        {
            var type = typeof(DerivedTestClass);
            var member = type.GetMember("V5");
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
        public void TestModuleMembersTests()
        {
            var module = new KeepTestModule();
            module.Setup();

            Assert.AreEqual(4, module.InputProps.Count());
            Assert.AreEqual(2, module.OutputProps.Count());
            Assert.AreEqual(2, module.StateProps.Count());
            Assert.AreEqual(1, module.InternalProps.Count());
        }

        [TestMethod]
        public void ParentModuleMembersTests()
        {
            var module = new ParentModule();
            module.Setup();

            Assert.AreEqual(4, module.InputProps.Count());
            Assert.AreEqual(1, module.OutputProps.Count());
            Assert.AreEqual(3, module.ModuleProps.Count());
            Assert.AreEqual(2, module.Modules.Count());
            Assert.AreEqual(1, module.InternalProps.Count());
        }

        [TestMethod]
        public void CycleTest()
        {
            var module = new ParentModule();
            module.Setup();

            module.Cycle(new TestInputs()
            {
                WE = true,
                WriteAddress = 10,
                WriteData = 10
            });

            Assert.AreEqual(0, module.Data);
            module.Cycle(new TestInputs()
            {
                ReadAddress = 10
            });
            Assert.AreEqual(10, module.Data);
        }

        [TestMethod]
        public void MissingBuffStateTest()
        {
            var module = new MissingTestModule();
            module.Setup();
            Assert.ThrowsException<Exception>(() => module.Reset());
        }

        [TestMethod]
        public void ResetBuffStateTest()
        {
            var module = new ResetTestModule();
            module.Setup();

            module.Cycle(new TestInputs()
            {
                WE = true,
                WriteAddress = 10,
                WriteData = 0
            });
            
            Assert.AreEqual(0, module.State.Buff[10]);
            module.Reset();
            Assert.AreEqual(10, module.State.Buff[10]);

        }

        [TestMethod]
        public void KeepBuffStateTest()
        {
            var module = new KeepTestModule();
            module.Setup();
            module.Cycle(new TestInputs()
            {
                WE = true,
                WriteAddress = 10,
                WriteData = 10
            });

            Assert.AreEqual(10, module.State.Buff[10]);
            module.Reset();
            Assert.AreEqual(10, module.State.Buff[10]);
        }

        [TestMethod]
        public void FeedbackTest()
        {
            var module = new NotGateFeedbackModule();
            module.Setup();

            Assert.IsTrue(module.Stage(0));
            Assert.IsTrue(module.Stage(1));
        }
    }
}
