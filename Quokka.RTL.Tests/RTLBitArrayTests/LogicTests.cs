// generated code, do not modify
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
namespace Quokka.RTL.RTLBitArrayTests
{
	[TestClass]
	public class Logic
	{
		[TestMethod]
		public void BoolAndBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) & (byte)(v2 ? 1 : 0), (byte)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & (byte)(v2 ? 1 : 0), (byte)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & (byte)(v2 ? 1 : 0), (byte)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolOrBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) | (byte)(v2 ? 1 : 0), (byte)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | (byte)(v2 ? 1 : 0), (byte)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | (byte)(v2 ? 1 : 0), (byte)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolXorBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ (byte)(v2 ? 1 : 0), (byte)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ (byte)(v2 ? 1 : 0), (byte)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ (byte)(v2 ? 1 : 0), (byte)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolAndByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (byte)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (byte)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (byte)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolOrByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (byte)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (byte)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (byte)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolXorByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (byte)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (byte)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (byte)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolAndUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (ushort)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (ushort)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (ushort)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolOrUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (ushort)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (ushort)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (ushort)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolXorUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (ushort)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (ushort)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (ushort)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolAndUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (uint)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (uint)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (uint)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolOrUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (uint)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (uint)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (uint)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolXorUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (uint)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (uint)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (uint)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolAndUlong()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) & v2, (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolOrUlong()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) | v2, (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolXorUlong()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual((byte)(v1 ? 1 : 0) ^ v2, (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteAndBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (byte)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (byte)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (byte)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteOrBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (byte)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (byte)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (byte)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteXorBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (byte)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (byte)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (byte)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteAndByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (byte)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (byte)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (byte)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteOrByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (byte)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (byte)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (byte)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteXorByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (byte)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (byte)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (byte)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteAndUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ushort)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ushort)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ushort)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteOrUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ushort)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ushort)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ushort)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteXorUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ushort)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ushort)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ushort)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteAndUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (uint)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteOrUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (uint)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteXorUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteAndUlong()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteOrUlong()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteXorUlong()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteAndSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (sbyte)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (sbyte)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (sbyte)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteOrSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (sbyte)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (sbyte)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (sbyte)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteXorSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (sbyte)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (sbyte)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (sbyte)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteAndShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (short)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (short)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (short)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteOrShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (short)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (short)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (short)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteXorShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (short)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (short)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (short)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteAndInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (int)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteOrInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (int)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteXorInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteAndLong()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (long)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteOrLong()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (long)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteXorLong()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortAndBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (ushort)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (ushort)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (ushort)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortOrBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (ushort)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (ushort)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (ushort)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortXorBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (ushort)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (ushort)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (ushort)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortAndByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ushort)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ushort)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ushort)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortOrByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ushort)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ushort)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ushort)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortXorByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ushort)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ushort)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ushort)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortAndUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ushort)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ushort)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ushort)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortOrUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ushort)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ushort)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ushort)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortXorUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ushort)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ushort)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ushort)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortAndUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (uint)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortOrUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (uint)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortXorUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortAndUlong()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortOrUlong()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortXorUlong()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortAndSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (short)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (short)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (short)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortOrSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (short)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (short)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (short)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortXorSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (short)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (short)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (short)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortAndShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (short)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (short)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (short)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortOrShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (short)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (short)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (short)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortXorShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (short)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (short)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (short)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortAndInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (int)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortOrInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (int)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortXorInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortAndLong()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (long)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortOrLong()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (long)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortXorLong()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UintAndBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (uint)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (uint)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (uint)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UintOrBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (uint)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (uint)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (uint)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UintXorBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (uint)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (uint)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (uint)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UintAndByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (uint)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UintOrByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (uint)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UintXorByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UintAndUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (uint)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UintOrUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (uint)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UintXorUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UintAndUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (uint)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (uint)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UintOrUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (uint)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (uint)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UintXorUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (uint)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UintAndUlong()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UintOrUlong()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UintXorUlong()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void IntAndSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (int)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void IntOrSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (int)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void IntXorSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void IntAndShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (int)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void IntOrShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (int)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void IntXorShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void IntAndInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (int)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (int)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void IntOrInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (int)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (int)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void IntXorInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (int)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void IntAndLong()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (long)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void IntOrLong()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (long)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void IntXorLong()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongAndBool()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & (byte)(v2 ? 1 : 0), (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongOrBool()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | (byte)(v2 ? 1 : 0), (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongXorBool()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ (byte)(v2 ? 1 : 0), (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongAndByte()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongOrByte()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongXorByte()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongAndUshort()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongOrUshort()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongXorUshort()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongAndUint()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongOrUint()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongXorUint()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongAndUlong()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (ulong)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (ulong)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongOrUlong()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (ulong)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (ulong)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void UlongXorUlong()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			var op2 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (ulong)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void LongAndSbyte()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (long)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void LongOrSbyte()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (long)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void LongXorSbyte()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void LongAndShort()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (long)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void LongOrShort()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (long)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void LongXorShort()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void LongAndInt()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (long)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void LongOrInt()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (long)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void LongXorInt()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
		[TestMethod]
		public void LongAndLong()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 & v2, (long)(o1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(v1 & o2), $"{v1} & {v2}");
					Assert.AreEqual(v1 & v2, (long)(o1 & v2), $"{v1} & {v2}");
				}
			}
		}
		[TestMethod]
		public void LongOrLong()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 | v2, (long)(o1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(v1 | o2), $"{v1} | {v2}");
					Assert.AreEqual(v1 | v2, (long)(o1 | v2), $"{v1} | {v2}");
				}
			}
		}
		[TestMethod]
		public void LongXorLong()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			var op2 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(v1 ^ o2), $"{v1} ^ {v2}");
					Assert.AreEqual(v1 ^ v2, (long)(o1 ^ v2), $"{v1} ^ {v2}");
				}
			}
		}
	}
}
