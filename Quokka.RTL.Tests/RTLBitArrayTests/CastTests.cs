// generated code, do not modify
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
namespace Quokka.RTL.RTLBitArrayTests
{
	[TestClass]
	public class Cast
	{
		[TestMethod]
		public void BoolToBool()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(v1, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void BoolToByte()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)(v1 ? 1 : 0), (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void BoolToSbyte()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)(v1 ? 1 : 0), (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void BoolToUshort()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)(v1 ? 1 : 0), (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void BoolToShort()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)(v1 ? 1 : 0), (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void BoolToUint()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)(v1 ? 1 : 0), (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void BoolToInt()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)(v1 ? 1 : 0), (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void BoolToUlong()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)(v1 ? 1 : 0), (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void BoolToLong()
		{
			var op1 = new bool[] { true, false };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)(v1 ? 1 : 0), (long)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToBool()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(((v1 & 1) == 1) ? true : false, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToByte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)v1, (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToSbyte()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)v1, (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToUshort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)v1, (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToShort()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)v1, (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToUint()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)v1, (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToInt()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)v1, (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToUlong()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)v1, (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ByteToLong()
		{
			var op1 = new byte[] { 0, 1, byte.MaxValue / 2, byte.MaxValue / 2 + 1, byte.MaxValue - 1, byte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)v1, (long)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToBool()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(((v1 & 1) == 1) ? true : false, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToByte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)v1, (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToSbyte()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)v1, (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToUshort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)v1, (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToShort()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)v1, (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToUint()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)v1, (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToInt()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)v1, (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToUlong()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)v1, (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void SbyteToLong()
		{
			var op1 = new sbyte[] { sbyte.MinValue, sbyte.MinValue + 1, -1, 0, 1, sbyte.MaxValue - 1, sbyte.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)v1, (long)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToBool()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(((v1 & 1) == 1) ? true : false, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToByte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)v1, (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToSbyte()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)v1, (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToUshort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)v1, (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToShort()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)v1, (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToUint()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)v1, (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToInt()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)v1, (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToUlong()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)v1, (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UshortToLong()
		{
			var op1 = new ushort[] { 0, 1, ushort.MaxValue / 2, ushort.MaxValue / 2 + 1, ushort.MaxValue - 1, ushort.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)v1, (long)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToBool()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(((v1 & 1) == 1) ? true : false, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToByte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)v1, (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToSbyte()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)v1, (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToUshort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)v1, (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToShort()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)v1, (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToUint()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)v1, (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToInt()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)v1, (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToUlong()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)v1, (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void ShortToLong()
		{
			var op1 = new short[] { short.MinValue, short.MinValue + 1, -1, 0, 1, short.MaxValue - 1, short.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)v1, (long)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToBool()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(((v1 & 1) == 1) ? true : false, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToByte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)v1, (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToSbyte()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)v1, (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToUshort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)v1, (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToShort()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)v1, (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToUint()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)v1, (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToInt()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)v1, (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToUlong()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)v1, (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UintToLong()
		{
			var op1 = new uint[] { 0, 1, uint.MaxValue / 2, uint.MaxValue / 2 + 1, uint.MaxValue - 1, uint.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)v1, (long)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToBool()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(((v1 & 1) == 1) ? true : false, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToByte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)v1, (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToSbyte()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)v1, (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToUshort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)v1, (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToShort()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)v1, (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToUint()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)v1, (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToInt()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)v1, (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToUlong()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)v1, (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void IntToLong()
		{
			var op1 = new int[] { int.MinValue, int.MinValue + 1, -1, 0, 1, int.MaxValue - 1, int.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)v1, (long)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToBool()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(((v1 & 1) == 1) ? true : false, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToByte()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)v1, (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToSbyte()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)v1, (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToUshort()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)v1, (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToShort()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)v1, (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToUint()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)v1, (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToInt()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)v1, (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToUlong()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)v1, (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void UlongToLong()
		{
			var op1 = new ulong[] { 0, 1, ulong.MaxValue / 2, ulong.MaxValue / 2 + 1, ulong.MaxValue - 1, ulong.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)v1, (long)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToBool()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual(((v1 & 1) == 1) ? true : false, (bool)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToByte()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((byte)v1, (byte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToSbyte()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((sbyte)v1, (sbyte)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToUshort()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ushort)v1, (ushort)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToShort()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((short)v1, (short)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToUint()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((uint)v1, (uint)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToInt()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((int)v1, (int)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToUlong()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((ulong)v1, (ulong)(new RTLBitArray(v1)));
			}
		}
		[TestMethod]
		public void LongToLong()
		{
			var op1 = new long[] { long.MinValue, long.MinValue + 1, -1, 0, 1, long.MaxValue - 1, long.MaxValue };
			foreach (var v1 in op1)
			{
				Assert.AreEqual((long)v1, (long)(new RTLBitArray(v1)));
			}
		}
	}
}
