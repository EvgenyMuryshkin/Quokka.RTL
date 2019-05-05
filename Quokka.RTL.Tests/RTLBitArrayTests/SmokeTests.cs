using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
