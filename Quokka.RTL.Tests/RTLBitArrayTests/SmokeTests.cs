﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quokka.RTL.RTLBitArrayTests
{
    [TestClass]
    public class SmokeTests
    {
        public TestContext TestContext { get; set; }

        private static TestContext _testContext;

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [TestMethod]
        public void UnboundedHexMultiplicationTest()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int bytes = 1;
            while (stopWatch.ElapsedMilliseconds < TimeSpan.FromSeconds(5).TotalMilliseconds)
            {
                // multiple F...F to itself
                var op = string.Join("", Enumerable.Range(0, bytes).Select(b => Convert.ToString(0xFF, 2)));
                var op1 = new RTLBitArray(op, bytes * 8, RTLBitArrayType.Unsigned);
                var op2 = new RTLBitArray(op, bytes * 8, RTLBitArrayType.Unsigned);

                var repeats = bytes * 2 - 1;

                var result = (op1 * op2);
                var multPattern = $"[F]{{{repeats}}}E[0]{{{repeats}}}1";

                Assert.IsTrue(Regex.IsMatch(result.ToString(), multPattern), $"Failed for {op1} * {op2}");

                var complement = !result + 1;
                var sum = result + complement;
                var sumPattern = $"1[0]{{{bytes * 2}}}";

                Assert.IsTrue(Regex.IsMatch(sum.ToString(), sumPattern), $"Failed for {result} complement");

                bytes++;
            }

            TestContext.WriteLine($"Reached {bytes * 8} bits");
        }

        [TestMethod]
        public void RandomMultiplicationTest()
        {
            var rnd = new Random(Environment.TickCount);
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while(stopWatch.ElapsedMilliseconds < TimeSpan.FromSeconds(5).TotalMilliseconds)
            {
                var op1 = rnd.Next();
                var op2 = rnd.Next();

                long result = (long)op1 * (long)op2;
                var rtlResult = (long)(new RTLBitArray(op1) * new RTLBitArray(op2));
                var message = $"{op1} * {op2}";

                Assert.AreEqual((sbyte)result, (sbyte)rtlResult, "sbyte: " + message);
                Assert.AreEqual((byte)result, (byte)rtlResult, "byte: " + message);
                Assert.AreEqual((short)result, (short)rtlResult, "short: " + message);
                Assert.AreEqual((ushort)result, (ushort)rtlResult, "ushort: " + message);
                Assert.AreEqual((int)result, (int)rtlResult, "int: " + message);
                Assert.AreEqual((uint)result, (uint)rtlResult, "uint: " + message);
                Assert.AreEqual((long)result, (long)rtlResult, "long: " + message);
                Assert.AreEqual((ulong)result, (ulong)rtlResult, "ulong: " + message);
            }
        }

        [TestMethod]
        public void StringCtorTest()
        {
            var source = new RTLBitArray("10000000");

            Assert.AreEqual((byte)0x80, (byte)source);
        }

        [TestMethod]
        public void BitsCtorTest()
        {
            var source = new RTLBitArray(true, true, false, false, true, false, false, false);

            Assert.AreEqual((byte)0xC8, (byte)source);
            Assert.AreEqual((short)0xC8, (short)source);
        }

        [TestMethod]
        public void ByteCtorTest()
        {
            var init = (byte)0xC2;
            var source = new RTLBitArray(init);

            Assert.AreEqual(init, (byte)source);
        }

        [TestMethod]
        public void ArrayCtorTest()
        {
            var high = (byte)0xC0;
            var low = (byte)0x0E;

            var source = new RTLBitArray(high, low);

            Assert.AreEqual(0xC00E, (ushort)source);
        }

        [TestMethod]
        public void RangeTest()
        {
            // 00001011
            var source = new RTLBitArray(0x0BU);

            var high = source[3, 2]; // 10
            Assert.AreEqual(2U, (uint)high);

            var low = source[1, 0]; // 11
            Assert.AreEqual(3U, (uint)low);

            var highRev = source[2, 3]; // 01
            Assert.AreEqual(1U, (uint)highRev);

            var rev = source[0, 7]; // 11010000
            Assert.AreEqual(0xD0U, (uint)rev);

            var part = source[6, 0]; // 0001011
            Assert.AreEqual(0x0BU, (uint)part);

            var part2 = source[7, 1]; // 0000101
            Assert.AreEqual(0x05U, (uint)part2);

            var partRev = source[0, 6]; // 1101000
            Assert.AreEqual(0x68U, (uint)partRev);

            var partRev2 = source[1, 7]; // 1010000
            Assert.AreEqual(0x50U, (uint)partRev2);
        }

        [TestMethod]
        public void ReverseTest()
        {
            var source = new RTLBitArray((byte)0x8BU);
            var reversed = source.Reversed();
            Assert.AreEqual(0xD1U, (byte)reversed);
        }

        [TestMethod]
        public void UnsignedResizedTest()
        {
            var source = new RTLBitArray((byte)0x8BU);
            var resized = source.Resized(16);
            Assert.AreEqual(0x8BU, (ushort)resized);
        }

        [TestMethod]
        public void SignedResizedTest()
        {
            var source = new RTLBitArray((sbyte)-10);
            var resized = source.Resized(16);
            Assert.AreEqual(-10, (sbyte)resized);
            Assert.AreEqual(-10, (short)resized);
            Assert.AreEqual(-10, (int)resized);
        }

        [TestMethod]
        public void TypeChangedTest()
        {
            var source = new RTLBitArray((byte)0x8BU);
            var typeChanged = source.TypeChanged(RTLBitArrayType.Signed).Resized(16);

            Assert.AreEqual("1111111110001011", typeChanged.AsBinaryString());

            Assert.AreEqual(-117, (sbyte)typeChanged);
            Assert.AreEqual(-117, (short)typeChanged);
        }
    }
}
