// generated code, do not modify
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
namespace Quokka.RTL.RTLBitArrayTests
{
	[TestClass]
	public class Compare
	{
		[TestMethod]
		public void BoolEqualBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)(v2 ? 1 : 0), o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)(v2 ? 1 : 0), v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)(v2 ? 1 : 0), o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolNotEqualBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)(v2 ? 1 : 0), o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)(v2 ? 1 : 0), v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)(v2 ? 1 : 0), o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)(v2 ? 1 : 0), o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)(v2 ? 1 : 0), v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)(v2 ? 1 : 0), o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessOrEqualBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)(v2 ? 1 : 0), o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)(v2 ? 1 : 0), v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)(v2 ? 1 : 0), o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)(v2 ? 1 : 0), o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)(v2 ? 1 : 0), v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)(v2 ? 1 : 0), o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterOrEqualBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)(v2 ? 1 : 0), o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)(v2 ? 1 : 0), v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)(v2 ? 1 : 0), o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolEqualByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolNotEqualByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessOrEqualByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterOrEqualByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolEqualSbyte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolNotEqualSbyte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessSbyte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessOrEqualSbyte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterSbyte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterOrEqualSbyte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolEqualUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolNotEqualUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessOrEqualUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterOrEqualUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolEqualShort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolNotEqualShort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessShort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessOrEqualShort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterShort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterOrEqualShort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolEqualUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolNotEqualUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessOrEqualUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterOrEqualUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolEqualInt()
		{
			var op1 = new bool[] { true, false };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolNotEqualInt()
		{
			var op1 = new bool[] { true, false };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessInt()
		{
			var op1 = new bool[] { true, false };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolLessOrEqualInt()
		{
			var op1 = new bool[] { true, false };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterInt()
		{
			var op1 = new bool[] { true, false };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolGreaterOrEqualInt()
		{
			var op1 = new bool[] { true, false };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteEqualBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteNotEqualBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessOrEqualBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterOrEqualBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteEqualByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteNotEqualByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessOrEqualByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterOrEqualByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteEqualSbyte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteNotEqualSbyte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessSbyte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessOrEqualSbyte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterSbyte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterOrEqualSbyte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteEqualUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteNotEqualUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessOrEqualUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterOrEqualUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteEqualShort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteNotEqualShort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessShort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessOrEqualShort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterShort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterOrEqualShort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteEqualUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteNotEqualUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessOrEqualUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterOrEqualUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteEqualInt()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteNotEqualInt()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessInt()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteLessOrEqualInt()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterInt()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteGreaterOrEqualInt()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteEqualBool()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteNotEqualBool()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessBool()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessOrEqualBool()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterBool()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterOrEqualBool()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteEqualByte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteNotEqualByte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessByte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessOrEqualByte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterByte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterOrEqualByte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteEqualSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteNotEqualSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessOrEqualSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterOrEqualSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteEqualUshort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteNotEqualUshort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessUshort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessOrEqualUshort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterUshort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterOrEqualUshort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteEqualShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteNotEqualShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessOrEqualShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterOrEqualShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteEqualUint()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteNotEqualUint()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessUint()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessOrEqualUint()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterUint()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterOrEqualUint()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteEqualInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteNotEqualInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteLessOrEqualInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteGreaterOrEqualInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortEqualBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortNotEqualBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessOrEqualBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterOrEqualBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortEqualByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortNotEqualByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessOrEqualByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterOrEqualByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortEqualSbyte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortNotEqualSbyte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessSbyte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessOrEqualSbyte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterSbyte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterOrEqualSbyte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortEqualUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortNotEqualUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessOrEqualUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterOrEqualUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortEqualShort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortNotEqualShort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessShort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessOrEqualShort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterShort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterOrEqualShort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortEqualUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortNotEqualUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessOrEqualUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterOrEqualUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortEqualInt()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortNotEqualInt()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessInt()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortLessOrEqualInt()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterInt()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortGreaterOrEqualInt()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortEqualBool()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortNotEqualBool()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessBool()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessOrEqualBool()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterBool()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterOrEqualBool()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortEqualByte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortNotEqualByte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessByte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessOrEqualByte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterByte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterOrEqualByte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortEqualSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortNotEqualSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessOrEqualSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterOrEqualSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortEqualUshort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortNotEqualUshort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessUshort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessOrEqualUshort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterUshort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterOrEqualUshort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortEqualShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortNotEqualShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessOrEqualShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterOrEqualShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortEqualUint()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortNotEqualUint()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessUint()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessOrEqualUint()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterUint()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterOrEqualUint()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortEqualInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortNotEqualInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortLessOrEqualInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortGreaterOrEqualInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintEqualBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UintNotEqualBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessOrEqualBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterOrEqualBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintEqualByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UintNotEqualByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessOrEqualByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterOrEqualByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintEqualSbyte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UintNotEqualSbyte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessSbyte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessOrEqualSbyte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterSbyte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterOrEqualSbyte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintEqualUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UintNotEqualUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessOrEqualUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterOrEqualUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintEqualShort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UintNotEqualShort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessShort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessOrEqualShort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterShort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterOrEqualShort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintEqualUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UintNotEqualUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessOrEqualUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterOrEqualUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintEqualInt()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void UintNotEqualInt()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessInt()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void UintLessOrEqualInt()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterInt()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void UintGreaterOrEqualInt()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntEqualBool()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)(v2 ? 1 : 0), o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void IntNotEqualBool()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)(v2 ? 1 : 0), o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessBool()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)(v2 ? 1 : 0), o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessOrEqualBool()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)(v2 ? 1 : 0), o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterBool()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)(v2 ? 1 : 0), o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterOrEqualBool()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)(v2 ? 1 : 0), o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntEqualByte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void IntNotEqualByte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessByte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessOrEqualByte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterByte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterOrEqualByte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntEqualSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void IntNotEqualSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessOrEqualSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterOrEqualSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntEqualUshort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void IntNotEqualUshort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessUshort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessOrEqualUshort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterUshort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterOrEqualUshort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntEqualShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void IntNotEqualShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessOrEqualShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterOrEqualShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntEqualUint()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void IntNotEqualUint()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessUint()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessOrEqualUint()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterUint()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterOrEqualUint()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntEqualInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 == (long)v2, o1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, v1 == o2, $"{v1} == {v2}");
					Assert.AreEqual((long)v1 == (long)v2, o1 == v2, $"{v1} == {v2}");
				}
			}
		}
		[TestMethod]
		public void IntNotEqualInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 != (long)v2, o1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, v1 != o2, $"{v1} != {v2}");
					Assert.AreEqual((long)v1 != (long)v2, o1 != v2, $"{v1} != {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 < (long)v2, o1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, v1 < o2, $"{v1} < {v2}");
					Assert.AreEqual((long)v1 < (long)v2, o1 < v2, $"{v1} < {v2}");
				}
			}
		}
		[TestMethod]
		public void IntLessOrEqualInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, v1 <= o2, $"{v1} <= {v2}");
					Assert.AreEqual((long)v1 <= (long)v2, o1 <= v2, $"{v1} <= {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 > (long)v2, o1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, v1 > o2, $"{v1} > {v2}");
					Assert.AreEqual((long)v1 > (long)v2, o1 > v2, $"{v1} > {v2}");
				}
			}
		}
		[TestMethod]
		public void IntGreaterOrEqualInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, v1 >= o2, $"{v1} >= {v2}");
					Assert.AreEqual((long)v1 >= (long)v2, o1 >= v2, $"{v1} >= {v2}");
				}
			}
		}
	}
}
