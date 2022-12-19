using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.Tests
{
    public class InjectableClass
    {

    }

    public class FactoryCreatedClass
    {
        public delegate FactoryCreatedClass Factory(ulong clocks);
    }

    public class DICreatableClass
    {
        public DICreatableClass(InjectableClass injectable, FactoryCreatedClass.Factory factory)
        {

        }
    }

    public class DINotCreatableClass
    {
        public DINotCreatableClass(InjectableClass injectable, FactoryCreatedClass.Factory factory, int value)
        {

        }
    }

    [TestClass]
    public class RTLTypeCheckTests
    {
        [TestMethod]
        public void CanCreateWithDI()
        {
            Assert.IsTrue(RTLTypeCheck.CanCreateWithDI(typeof(InjectableClass)), nameof(InjectableClass));
            Assert.IsTrue(RTLTypeCheck.CanCreateWithDI(typeof(FactoryCreatedClass)), nameof(FactoryCreatedClass));
            Assert.IsTrue(RTLTypeCheck.CanCreateWithDI(typeof(DICreatableClass)), nameof(DICreatableClass));
            Assert.IsFalse(RTLTypeCheck.CanCreateWithDI(typeof(DINotCreatableClass)), nameof(DINotCreatableClass));
        }

        [TestMethod]
        public void IsToolkitType()
        {
            Assert.IsFalse(RTLTypeCheck.IsToolkitType(typeof(RTLTypeCheckTests)));
            Assert.IsTrue(RTLTypeCheck.IsToolkitType(typeof(DefaultRTLCombinationalModule<>)));
        }

        [TestMethod]
        public void IsBaseRTLModuleType()
        {
            Assert.IsFalse(RTLTypeCheck.IsBaseRTLModuleType(typeof(RTLTypeCheckTests)));
            Assert.IsTrue(RTLTypeCheck.IsBaseRTLModuleType(typeof(DefaultRTLCombinationalModule<>)));
            Assert.IsTrue(RTLTypeCheck.IsBaseRTLModuleType(typeof(DefaultRTLSynchronousModule<,>)));
        }

        [TestMethod]
        public void IsTuple()
        {
            Assert.IsFalse(RTLTypeCheck.IsTuple(typeof(RTLTypeCheckTests)));
            Assert.IsTrue(RTLTypeCheck.IsTuple(typeof((int, bool))));
            Assert.IsTrue(RTLTypeCheck.IsTuple(typeof((int, ulong, bool))));
            Assert.IsTrue(RTLTypeCheck.IsTuple(typeof((int, RTLBitArray, bool))));

            var tuple = new Tuple<bool, bool>(false, false);
            Assert.IsTrue(RTLTypeCheck.IsTuple(tuple.GetType()));
        }

        [TestMethod]
        public void IsFactoryCreatedModule()
        {
            Assert.IsFalse(RTLTypeCheck.IsFactoryCreatedModule(typeof(NotGateModule)));
            Assert.IsTrue(RTLTypeCheck.IsFactoryCreatedModule(typeof(FactoryCreatedModule)));
        }
    }
}
