using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Quokka.RTL.Tests
{
    public class RTLMemoryBlockState
    {
        public RTLMemoryBlock<byte>  Buff = new RTLMemoryBlock<byte>(10);
    }
    [TestClass]
    public class RTLMemoryBlockTests
    {
        [TestMethod]
        public void ByteCommitTest()
        {
            var block = new RTLMemoryBlock<byte>(10);
            block[1] = 10;
            Assert.AreEqual(10, block[1]);
            block.Commit();
            Assert.AreEqual(10, block[1]);
        }

        [TestMethod]
        public void ByteCancelTest()
        {
            var block = new RTLMemoryBlock<byte>(10);
            block[1] = 10;
            Assert.AreEqual(10, block[1]);
            block.Cancel();
            Assert.AreEqual(0, block[1]);
        }

        [TestMethod]
        public void ByteArrayCommitTest()
        {
            var block = new RTLMemoryBlock<byte[]>(Enumerable.Range(0, 10).Select(_ => new byte[] { 0, 0, 0 ,0 }));
            block[1] = [1, 1, 1, 1];
            Assert.AreEqual(1, block[1][0]);
            Assert.AreEqual(1, block[1][1]);
            Assert.AreEqual(1, block[1][2]);
            Assert.AreEqual(1, block[1][3]);
            block.Commit();
            Assert.AreEqual(1, block[1][0]);
            Assert.AreEqual(1, block[1][1]);
            Assert.AreEqual(1, block[1][2]);
            Assert.AreEqual(1, block[1][3]);
        }

        [TestMethod]
        public void RTLBitArrayCommitTest()
        {
            var block = new RTLMemoryBlock<RTLBitArray>(Enumerable.Range(0, 10).Select(_ => new RTLBitArray(0)));
            block[1] = new RTLBitArray(int.MaxValue);
            Assert.AreEqual<int>(int.MaxValue, block[1]);
            block.Commit();
            Assert.AreEqual<int>(int.MaxValue, block[1]);
        }

        [TestMethod]
        public void RTLBitArrayCommitExternalTest()
        {
            var block1 = new RTLMemoryBlock<RTLBitArray>(Enumerable.Range(0, 10).Select(_ => new RTLBitArray(0)));
            var block2 = new RTLMemoryBlock<RTLBitArray>(Enumerable.Range(0, 10).Select(_ => new RTLBitArray(0)));
            block1[1] = new RTLBitArray(int.MaxValue);
            var block1Commit = block1.Commit();
            block2.Commit(block1Commit);
            Assert.AreEqual<int>(int.MaxValue, block2[1]);
        }

        [TestMethod]
        public void DeepCopyTest()
        {           
            var state = new RTLMemoryBlockState();
            state.Buff[1] = new RTLBitArray(int.MaxValue);

            var state1 = DeepReflectionCopy.DeepCopy(state);
            Assert.AreEqual<int>(int.MaxValue, state1.Buff[1]);

            state.Buff.Commit();
            var state2 = DeepReflectionCopy.DeepCopy(state);
            Assert.AreEqual<int>(int.MaxValue, state2.Buff[1]);
        }
    }
}
