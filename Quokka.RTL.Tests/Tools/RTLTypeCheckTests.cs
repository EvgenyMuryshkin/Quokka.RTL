﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL.Tests
{
    [TestClass]
    public class RTLTypeCheckTests
    {
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
        }

        [TestMethod]
        public void IsFactoryCreatedModule()
        {
            Assert.IsFalse(RTLTypeCheck.IsFactoryCreatedModule(typeof(NotGateModule)));
            Assert.IsTrue(RTLTypeCheck.IsFactoryCreatedModule(typeof(FactoryCreatedModule)));
        }
    }
}
