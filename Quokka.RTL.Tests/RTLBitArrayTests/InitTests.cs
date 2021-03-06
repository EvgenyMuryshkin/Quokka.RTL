// generated code, do not modify
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
namespace Quokka.RTL.RTLBitArrayTests
{
	[TestClass]
	public class Init
	{
		[TestMethod]
		public void FromBool()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (bool)o1, $"{v1}");
			}
		}
		[TestMethod]
		public void FromByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (byte)o1, $"{v1}");
			}
		}
		[TestMethod]
		public void FromSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (sbyte)o1, $"{v1}");
			}
		}
		[TestMethod]
		public void FromUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (ushort)o1, $"{v1}");
			}
		}
		[TestMethod]
		public void FromShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (short)o1, $"{v1}");
			}
		}
		[TestMethod]
		public void FromUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (uint)o1, $"{v1}");
			}
		}
		[TestMethod]
		public void FromInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (int)o1, $"{v1}");
			}
		}
		[TestMethod]
		public void FromUlong()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (ulong)o1, $"{v1}");
			}
		}
		[TestMethod]
		public void FromLong()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				Assert.AreEqual(v1, (long)o1, $"{v1}");
			}
		}
	}
}
