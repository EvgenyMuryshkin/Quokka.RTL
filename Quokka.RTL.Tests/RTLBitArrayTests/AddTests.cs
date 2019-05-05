// generated code, do not modify
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
namespace Quokka.RTL.RTLBitArrayTests
{
	[TestClass]
	public class Add
	{
		[TestMethod]
		public void BoolToBool()
		{
			var op1 = new bool[] { true, false };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)(v2 ? 1 : 0), (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)(v2 ? 1 : 0), (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)(v2 ? 1 : 0), (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolToByte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolToSbyte()
		{
			var op1 = new bool[] { true, false };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolToUshort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolToShort()
		{
			var op1 = new bool[] { true, false };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolToUint()
		{
			var op1 = new bool[] { true, false };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void BoolToInt()
		{
			var op1 = new bool[] { true, false };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)(v1 ? 1 : 0) + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteToBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteToByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteToSbyte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteToUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteToShort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteToUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ByteToInt()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteToBool()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteToByte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteToSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteToUshort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteToShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteToUint()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void SbyteToInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortToBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortToByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortToSbyte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortToUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortToShort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortToUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UshortToInt()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortToBool()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortToByte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortToSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortToUshort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortToShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortToUint()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void ShortToInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UintToBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UintToByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UintToSbyte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UintToUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UintToShort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UintToUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void UintToInt()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void IntToBool()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)(v2 ? 1 : 0), (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void IntToByte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void IntToSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void IntToUshort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void IntToShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void IntToUint()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
		[TestMethod]
		public void IntToInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			var op2 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				var o1 = new RTLBitArray(v1);
				foreach (var v2 in op2)
				{
					var o2 = new RTLBitArray(v2);
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(v1 + o2), $"{v1} + {v2}");
					Assert.AreEqual((long)v1 + (long)v2, (long)(o1 + v2), $"{v1} + {v2}");
				}
			}
		}
	}
}
