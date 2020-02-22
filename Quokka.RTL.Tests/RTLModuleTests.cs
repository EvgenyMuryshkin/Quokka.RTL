using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quokka.RTL.Tests
{
    class TestInputs
    {
        public bool I1 { get; set; }
    }

    class TestState
    {
        public bool S1 { get; set; }
    }

    class TestModule : RTLSynchronousModule<TestInputs, TestState>
    {
        public bool O => Inputs.I1;

        protected override void OnStage()
        {
        }
    }

    class ParentModule : RTLCombinationalModule<TestInputs>
    {
        public TestModule SingleChild = new TestModule();

        public bool PO => !SingleChild.O;

        public override void Schedule(Func<TestInputs> inputsFactory)
        {
            base.Schedule(inputsFactory);

            SingleChild.Schedule(() => new TestInputs() { I1 = Inputs.I1 });
        }
    }

    [TestClass]
    public class RTLModuleTests
    {
        [TestMethod]
        public void TestModuleTests()
        {
            var module = new TestModule();
            Assert.AreEqual(1, module.InputProps.Count());
            Assert.AreEqual(1, module.OutputProps.Count());
            Assert.AreEqual(1, module.StateProps.Count());
        }

        [TestMethod]
        public void ParentModuleTests()
        {
            var module = new ParentModule();
            Assert.AreEqual(1, module.InputProps.Count());
            Assert.AreEqual(1, module.OutputProps.Count());
            Assert.AreEqual(1, module.ModuleProps.Count());
            Assert.AreEqual(1, module.Modules.Count());
        }
    }
}
