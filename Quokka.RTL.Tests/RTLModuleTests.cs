using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quokka.RTL.Tests
{
    class ParentModule : RTLCombinationalModule<TestInputs>
    {
        public KeepTestModule SingleChild = new KeepTestModule();

        public byte Data => SingleChild.Data;

        public override void Schedule(Func<TestInputs> inputsFactory)
        {
            base.Schedule(inputsFactory);

            SingleChild.Schedule(inputsFactory);
        }
    }

    public class MembersTestClass
    {
        public int V1;
        public bool V2 { get; set; }
        public byte[] V3;
        public byte[] V4 { get; set; }

        RTLBitArray V5;
        RTLBitArray V6 { get; set; }
        RTLBitArray V7 => V2;
    }

    [TestClass]
    public class RTLModuleTests
    {
        [TestMethod]
        public void SynthesizableMembersTest()
        {
            Assert.AreEqual(7, RTLModuleHelper.SynthesizableMembers(typeof(MembersTestClass)).Count());
        }

        [TestMethod]
        public void IsInternalPropertyTest()
        {
            var props = RTLModuleHelper.SynthesizableMembers(typeof(MembersTestClass));
            var internals = props.Where(p => RTLModuleHelper.IsInternalProperty(p));

            // arrays and private\protected members are considered internals 
            Assert.AreEqual(5, internals.Count());
        }

        [TestMethod]
        public void IsInternalTest()
        {
            var type = typeof(KeepTestModule);
            var member = type.GetMember("IsWriting");
            //Assert.IsTrue(RTLModuleHelper.IsSynthesizableSignalType(member.GetMemberType()))
        }

        [TestMethod]
        public void TestModuleMembersTests()
        {
            var module = new KeepTestModule();
            Assert.AreEqual(4, module.InputProps.Count());
            Assert.AreEqual(2, module.OutputProps.Count());
            Assert.AreEqual(2, module.StateProps.Count());
            Assert.AreEqual(1, module.InternalProps.Count());
        }

        [TestMethod]
        public void ParentModuleMembersTests()
        {
            var module = new ParentModule();
            Assert.AreEqual(4, module.InputProps.Count());
            Assert.AreEqual(1, module.OutputProps.Count());
            Assert.AreEqual(1, module.ModuleProps.Count());
            Assert.AreEqual(1, module.Modules.Count());
        }

        [TestMethod]
        public void CycleTest()
        {
            var module = new ParentModule();
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
    }
}
