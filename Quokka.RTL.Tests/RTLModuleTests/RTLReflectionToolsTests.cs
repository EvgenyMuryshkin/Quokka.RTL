using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System.Linq;

namespace Quokka.RTL.Tests
{
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
    }
}
