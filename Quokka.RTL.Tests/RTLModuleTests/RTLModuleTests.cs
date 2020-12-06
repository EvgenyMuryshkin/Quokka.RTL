using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quokka.RTL.Tests
{
    [TestClass]
    public class RTLModuleTests
    {
        [TestMethod]
        public void IsInternalTest()
        {
            var type = typeof(DerivedTestClass);
            var member = type.GetMember("V5");
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
