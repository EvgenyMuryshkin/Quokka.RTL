// generated code, do not modify
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace Quokka.RTL.RTLBitArrayTests
{
    [TestClass]
	public class PerfTests
    {
        static int Tier1Size = 1000000;

        RTLBitArray[] TierValues(int size) => Enumerable.Range(0, size).Select(v => new RTLBitArray(int.MaxValue - size / 2 + v)).ToArray();

        RTLBitArray[] Tier1Values => TierValues(Tier1Size);
        RTLBitArray[] Tier2Values => TierValues(Tier1Size / 2);
        RTLBitArray[] Tier3Values => TierValues(Tier1Size / 3);
        RTLBitArray[] Tier4Values => TierValues(Tier1Size / 4);
        RTLBitArray[] Tier5Values => TierValues(Tier1Size / 5);
        RTLBitArray[] Tier6Values => TierValues(Tier1Size / 6);

        void Measure(Action f, int max)
        {
            var sw = new Stopwatch();
            sw.Start();
            f();
            var time = sw.ElapsedMilliseconds;
            Trace.WriteLine($"Completed in {time} ms");
            Assert.IsTrue(time < max, $"Measure failed: {time} < {max}");
        }

        [TestMethod]
        public void TimeChangeTest()
        {
            Measure(() =>
            {
                var source = new RTLBitArray(int.MaxValue);
                foreach (var idx in Enumerable.Range(-Tier1Size / 2, Tier1Size))
                {
                    var t = source.TypeChanged(RTLSignalType.Unsigned);
                }
            }, 1000);
        }

        [TestMethod]
        public void ResizeTest()
        {
            Measure(() =>
            {
                var source = new RTLBitArray(int.MaxValue);
                foreach (var idx in Enumerable.Range(-Tier1Size / 2, Tier1Size))
                {
                    var t = source.Resized(30);
                }
            }, 1000);
        }

        [TestMethod]
        public void EqualsTest()
        {
            var lhs = new RTLBitArray(int.MaxValue);
            var milValues = Tier1Values;

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = lhs == idx;
                }
            }, 1000);
        }

        [TestMethod]
        public void GreaterTest()
        {
            var lhs = new RTLBitArray(0);
            var milValues = Tier1Values;

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = lhs > idx;
                }
            }, 1000);
        }

        [TestMethod]
        public void GreaterEqualTest()
        {
            var lhs = new RTLBitArray(0);
            var milValues = Tier1Values;

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = lhs >= idx;
                }
            }, 1000);
        }

        [TestMethod]
        public void LessTest()
        {
            var lhs = new RTLBitArray(0);
            var milValues = Tier1Values;

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = lhs < idx;
                }
            }, 1000);
        }

        [TestMethod]
        public void AndTest()
        {
            var milValues = Tier1Values;
            var op = new RTLBitArray(1);

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = idx & op;
                }
            }, 2000);
        }

        [TestMethod]
        public void OrTest()
        {
            var milValues = Tier1Values;
            var op = new RTLBitArray(1);

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = idx | op;
                }
            }, 2000);
        }

        [TestMethod]
        public void XorTest()
        {
            var milValues = Tier1Values;
            var op = new RTLBitArray(1);

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = idx ^ op;
                }
            }, 2000);
        }

        [TestMethod]
        public void NotTest()
        {
            var milValues = Tier1Values;

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = !idx;
                }
            }, 1000);

        }

        [TestMethod]
        public void AddTest()
        {
            var milValues = Tier1Values;
            var op = new RTLBitArray(1);

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = idx + op;
                }
            }, 3000);
        }

        [TestMethod]
        public void SubTest()
        {
            var milValues = Tier1Values;
            var op = new RTLBitArray(1);

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = idx - op;
                }
            }, 3000);
        }

        [TestMethod]
        public void MulTest()
        {
            var milValues = Tier6Values;
            var op = new RTLBitArray(int.MaxValue);

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = idx * op;
                }
            }, 3000);
        }

        [TestMethod]
        public void LessOrEqTest()
        {
            var lhs = new RTLBitArray(0);
            var milValues = Tier1Values;

            Measure(() =>
            {
                foreach (var idx in milValues)
                {
                    var result = lhs <= idx;
                }
            }, 1000);
        }

        [TestMethod]
        public void ToBits()
        {
            Measure(() =>
            {
                foreach (var idx in Enumerable.Range(0, Tier1Size))
                {
                    var bits = Convert.ToString(idx, 2);
                }
            }, 1000);
        }

        [TestMethod]
        public void BitArrayCtor()
        {
            Measure(() =>
            {
                var source = new bool[] {
                    true, true, true, true, true, true, true, true,
                    true, true, true, true, true, true, true, true,
                    true, true, true, true, true, true, true, true,
                    true, true, true, true, true, true, true, true,
                };

                foreach (var idx in Enumerable.Range(0, Tier1Size))
                {
                    var bits = new BitArray(source);
                }
            }, 1000);
        }

        [TestMethod]
        public void RTLBitArrayBitsCtor()
        {
            Measure(() =>
            {
                var source = new bool[] { 
                    true, true, true, true, true, true, true, true,
                    true, true, true, true, true, true, true, true,
                    true, true, true, true, true, true, true, true,
                    true, true, true, true, true, true, true, true,
                };

                foreach (var idx in Enumerable.Range(0, Tier1Size))
                {
                    var v = new RTLBitArray(source);
                }
            }, 1000);
        }

        [TestMethod]
        public void RTLBitArrayIntCast()
        {
            Measure(() =>
            {
                foreach (var idx in Enumerable.Range(0, Tier1Size))
                {
                    RTLBitArray v = idx;
                }
            }, 1000);
        }

        [TestMethod]
        public void RTLBitArrayRTLBitArrayCtor()
        {
            Measure(() =>
            {
                var source = new RTLBitArray(42);
                foreach (var idx in Enumerable.Range(0, Tier1Size))
                {
                    var v = new RTLBitArray(idx);
                }
            }, 1000);
        }

        [TestMethod]
        public void RTLBitArrayIntCtor()
        {
            Measure(() =>
            {
                foreach (var idx in Enumerable.Range(0, Tier1Size))
                {
                    var v = new RTLBitArray(idx);
                    //var v = FromInt(idx);
                    //RTLBitArray v = idx;
                    /*
                    var v = new RTLBitArray(
                        RTLSignalType.Signed,
                        Convert.ToString(idx, 2),
                        32);
                    */
                }
            }, 1000);
        }

        [TestMethod]
        public void RTLBitArrayStringCtor()
        {
            Measure(() =>
            {
                foreach (var idx in Enumerable.Range(0, Tier1Size))
                {
                    var bits = Convert.ToString(idx, 2);
                    var v = new RTLBitArray(RTLSignalType.Unsigned, bits, 32);
                }
            }, 1000);
        }
    }
}
