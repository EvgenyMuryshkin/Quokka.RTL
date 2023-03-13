using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL.Tests
{
    public class BaseClass
    {
        [MemberIndex]
        public int Field5;
        [MemberIndex]
        public bool Prop5 { get; set; }
        [MemberIndex]
        public byte Field4;
        [MemberIndex]
        public RTLBitArray Prop4 { get; set; }
    }

    public class DerivedClass : BaseClass
    {
        [MemberIndex]
        public int Field3;
        [MemberIndex]
        public bool Prop3 { get; set; }
        [MemberIndex]
        public byte Field2;
        [MemberIndex]
        public RTLBitArray Prop2 { get; set; }
    }

    [TestClass]
    public class DotNetTests
    {
        [TestMethod]
        public void MetadataTokenTest()
        {
            for(var i = 0; i < 100; i++)
            {
                var ordered = RTLReflectionTools.SerializableMembers(typeof(DerivedClass));
                Assert.AreEqual(8, ordered.Count);
                Assert.AreEqual("Field5", ordered[0].Name);
                Assert.AreEqual("Prop5", ordered[1].Name);
                Assert.AreEqual("Field4", ordered[2].Name);
                Assert.AreEqual("Prop4", ordered[3].Name);
                Assert.AreEqual("Field3", ordered[4].Name);
                Assert.AreEqual("Prop3", ordered[5].Name);
                Assert.AreEqual("Field2", ordered[6].Name);
                Assert.AreEqual("Prop2", ordered[7].Name);
            }
        }
    }
}
