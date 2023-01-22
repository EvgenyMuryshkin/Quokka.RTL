﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL.Tests
{
    static class TestExtensions
    {
        public static string Path(this List<MemberInfo> source)
        {
            return source.Select(s => s.Name).StringJoin(".");
        }
    }

    class UnwrapStructL3
    {
        public bool Native;
        public byte[] Array = new byte[4];
        public Tuple<byte, Tuple<bool, RTLBitArray>> Tuple = new Tuple<byte, Tuple<bool, RTLBitArray>>(42, new Tuple<bool, RTLBitArray>(false, new RTLBitArray()));
    }


    class UnwrapStructL2
    {
        public UnwrapStructL3 L3 = new UnwrapStructL3();
        public UnwrapStructL3[] L3Array = new UnwrapStructL3[0];
        public Tuple<UnwrapStructL3, UnwrapStructL3[]> L3Tuple = new Tuple<UnwrapStructL3, UnwrapStructL3[]>(new UnwrapStructL3(), new UnwrapStructL3[0]);
    }


    class UnwrapStructL1
    {
    }


    [TestClass]
    public class RTLReflectionToolsTests_UnwrapStruct
    {
        [TestMethod]
        public void Null()
        {
            var result = RTLReflectionTools.UnwrapMemberInfo(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Native()
        {
            var result = RTLReflectionTools.UnwrapMemberInfo(typeof(int));
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void RTLBitArray()
        {
            var result = RTLReflectionTools.UnwrapMemberInfo(typeof(RTLBitArray));
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TupleL3()
        {
            var result = RTLReflectionTools.UnwrapMemberInfo(typeof(UnwrapStructL3));
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("Native", result[0].Path());
            Assert.AreEqual("Array", result[1].Path());
            Assert.AreEqual("Tuple.Item1", result[2].Path());
            Assert.AreEqual("Tuple.Item2.Item1", result[3].Path());
            Assert.AreEqual("Tuple.Item2.Item2", result[4].Path());
        }

        [TestMethod]
        public void TupleL2()
        {
            var result = RTLReflectionTools.UnwrapMemberInfo(typeof(UnwrapStructL2));
            Assert.IsNotNull(result);
            var allItems = result.Select(c => c.Path()).ToList();

            Assert.AreEqual(20, result.Count);
            Assert.AreEqual("L3.Native", result[0].Path());
            Assert.AreEqual("L3.Array", result[1].Path());
            Assert.AreEqual("L3.Tuple.Item1", result[2].Path());
            Assert.AreEqual("L3.Tuple.Item2.Item1", result[3].Path());
            Assert.AreEqual("L3.Tuple.Item2.Item2", result[4].Path());

            Assert.AreEqual("L3Array.Native", result[5].Path());
            Assert.AreEqual("L3Array.Array", result[6].Path());
            Assert.AreEqual("L3Array.Tuple.Item1", result[7].Path());
            Assert.AreEqual("L3Array.Tuple.Item2.Item1", result[8].Path());
            Assert.AreEqual("L3Array.Tuple.Item2.Item2", result[9].Path());

            Assert.AreEqual("L3Tuple.Item1.Native", result[10].Path());
            Assert.AreEqual("L3Tuple.Item1.Array", result[11].Path());
            Assert.AreEqual("L3Tuple.Item1.Tuple.Item1", result[12].Path());
            Assert.AreEqual("L3Tuple.Item1.Tuple.Item2.Item1", result[13].Path());
            Assert.AreEqual("L3Tuple.Item1.Tuple.Item2.Item2", result[14].Path());

            Assert.AreEqual("L3Tuple.Item2.Native", result[15].Path());
            Assert.AreEqual("L3Tuple.Item2.Array", result[16].Path());
            Assert.AreEqual("L3Tuple.Item2.Tuple.Item1", result[17].Path());
            Assert.AreEqual("L3Tuple.Item2.Tuple.Item2.Item1", result[18].Path());
            Assert.AreEqual("L3Tuple.Item2.Tuple.Item2.Item2", result[19].Path());
        }

    }
}
