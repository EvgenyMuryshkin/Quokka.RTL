using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL.Tests
{
    class PerfState
    {
        public PerfState() : this(0)
        {

        }

        public PerfState(int size)
        {
            Buff = new RTLMemoryBlock<byte[]>(Enumerable.Range(0, size).Select(i => new byte[4]));
        }

        public RTLMemoryBlock<byte[]> Buff;
    }

    class DeepReflectionOverwriteTestClassOfFields
    {
        public int Field;
        public int Property { get; set; }
        public DeepReflectionCopyTestEnum Enum;
        public RTLBitArray BitArray { get; set; }
        public int Getter => Field + Property;
    }

    class DeepReflectionOverwriteTestClassOfObjects
    {
        public DeepReflectionCopyTestChildClass Class;
        public DeepReflectionCopyTestChildStruct Struct;
        public (bool, byte, DeepReflectionCopyTestChildClass, DeepReflectionCopyTestChildStruct) Tuple { get; set; }
    }

    class DeepReflectionOverwriteTestClassOfArrays
    {
        public byte[] ArrayOfBytes { get; set; }
        public DeepReflectionCopyTestChildClass[] ArrayOfClasses { get; set; }
        public DeepReflectionCopyTestChildStruct[] ArrayOfStructs { get; set; }
        public RTLBitArray[] ArrayOfBitArrays;
    }
    //class DeepReflectionOverwriteTestClassOfLists
    //{
    //    public List<byte> ListOfBytes { get; set; }
    //    public List<DeepReflectionCopyTestChildClass> ListOfClasses { get; set; }
    //    public List<DeepReflectionCopyTestChildStruct> ListOfStructs { get; set; }
    //    public List<RTLBitArray> ListOfBitArrays;
    //}

    class DeepReflectionOverwriteTestClassOfMemoryBlocks
    {
        public RTLMemoryBlock<byte> MemoryBlockOfBytes { get; set; }
        public RTLMemoryBlock<DeepReflectionCopyTestChildStruct> MemoryBlockOfStructs { get; set; }
        public RTLMemoryBlock<DeepReflectionCopyTestChildClass> MemoryBlockOfClasses { get; set; }
        public RTLMemoryBlock<RTLBitArray> MemoryBlockOfBitArrays { get; set; }

    }

    [TestClass]
    public class DeepReflectionOverwriteTests
    {
        void AssertEquals<T>(T lhs, T rhs)
        {
            var lhsJson = DeepJSONCopy.Serialize(lhs);
            var rhsJson = DeepJSONCopy.Serialize(rhs);

            for (int i = 0; i < Math.Min(lhsJson.Length, rhsJson.Length); i++)
            {
                if (lhsJson[i] != rhsJson[i])
                {
                    var lhsSub = lhsJson.Substring(i - 5);
                    var rhsSub = rhsJson.Substring(i - 5);
                    Assert.AreEqual(lhsSub, rhsSub);
                }
            }
        }

        [TestMethod]
        public void TestFields()
        {
            var source = new DeepReflectionOverwriteTestClassOfFields()
            {
                Field = 1,
                Property = 2,
                Enum = DeepReflectionCopyTestEnum.V3,
                BitArray = new RTLBitArray(int.MaxValue),
            };

            var copy = DeepReflectionCopy.DeepCopy(source);

            source.Field = 2;
            source.Property = 3;
            source.Enum = DeepReflectionCopyTestEnum.V1;
            source.BitArray = new RTLBitArray(int.MinValue);

            DeepReflectionOverwrite.Run(source, copy);

            AssertEquals(source, copy);
        }

        [TestMethod]
        public void TestObjects()
        {
            var source = new DeepReflectionOverwriteTestClassOfObjects()
            {
                Class = new DeepReflectionCopyTestChildClass() { Value = 10 },
                Struct = new DeepReflectionCopyTestChildStruct() { Value = 20 },
                Tuple = (false, 0, new DeepReflectionCopyTestChildClass() { Value = 30 }, new DeepReflectionCopyTestChildStruct() { Value = 40 })
            };

            var copy = DeepReflectionCopy.DeepCopy(source);
            source.Class.Value++;
            source.Struct.Value++;
            source.Tuple = (
                !source.Tuple.Item1,
                (byte)(source.Tuple.Item2 + 1),
                new DeepReflectionCopyTestChildClass() { Value = source.Tuple.Item3.Value + 1 },
                new DeepReflectionCopyTestChildStruct() { Value = source.Tuple.Item4.Value + 1 }
            );

            DeepReflectionOverwrite.Run(source, copy);
            AssertEquals(source, copy);
        }

        [TestMethod]
        public void TestArrays()
        {
            var source = new DeepReflectionOverwriteTestClassOfArrays()
            {
                ArrayOfBitArrays = Enumerable.Range(0, 10).Select(i => new RTLBitArray(i)).ToArray(),
                ArrayOfBytes = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray(),
                ArrayOfStructs = Enumerable.Range(0, 10).Select(i => new DeepReflectionCopyTestChildStruct() { Value = i }).ToArray(),
                ArrayOfClasses = Enumerable.Range(0, 10).Select(i => new DeepReflectionCopyTestChildClass() { Value = i }).ToArray()
            };

            var copy = DeepReflectionCopy.DeepCopy(source);
            source.ArrayOfBitArrays[1]++;
            source.ArrayOfBytes[2]++;
            source.ArrayOfStructs[3].Value++;
            source.ArrayOfClasses[5].Value++;

            DeepReflectionOverwrite.Run(source, copy);
            AssertEquals(source, copy);
        }

        //[TestMethod]
        //public void TestLists()
        //{
        //    var source = new DeepReflectionOverwriteTestClassOfLists()
        //    {
        //        ListOfBitArrays = Enumerable.Range(0, 10).Select(i => new RTLBitArray(i)).ToList(),
        //        ListOfBytes = Enumerable.Range(0, 256).Select(i => (byte)i).ToList(),
        //        ListOfStructs = Enumerable.Range(0, 10).Select(i => new DeepReflectionCopyTestChildStruct() { Value = i }).ToList(),
        //        ListOfClasses = Enumerable.Range(0, 10).Select(i => new DeepReflectionCopyTestChildClass() { Value = i }).ToList()
        //    };
        //
        //    var copy = DeepReflectionCopy.DeepCopy(source);
        //
        //    AssertEquals(source, copy);
        //}

        [TestMethod]
        public void TestMemoryBlocks()
        {
            var source = new DeepReflectionOverwriteTestClassOfMemoryBlocks()
            {
                MemoryBlockOfBitArrays = new RTLMemoryBlock<RTLBitArray>(Enumerable.Range(0, 10).Select(i => new RTLBitArray(i))),
                MemoryBlockOfBytes = new RTLMemoryBlock<byte>(Enumerable.Range(0, 256).Select(i => (byte)i)),
                MemoryBlockOfStructs = new RTLMemoryBlock<DeepReflectionCopyTestChildStruct>(Enumerable.Range(0, 10).Select(i => new DeepReflectionCopyTestChildStruct() { Value = i })),
                MemoryBlockOfClasses = new RTLMemoryBlock<DeepReflectionCopyTestChildClass>(Enumerable.Range(0, 10).Select(i => new DeepReflectionCopyTestChildClass() { Value = i }))
            };

            var copy = DeepReflectionCopy.DeepCopy(source);
            AssertEquals(source, copy);

            source.MemoryBlockOfBitArrays[1]++;
            source.MemoryBlockOfBytes[2]++;
            var structIndex = source.MemoryBlockOfStructs[3];
            structIndex.Value++;
            source.MemoryBlockOfStructs[3] = structIndex;
            source.MemoryBlockOfClasses[5].Value++;

            DeepReflectionOverwrite.Run(source, copy);
            AssertEquals(source, copy);

            source.MemoryBlockOfBitArrays.Commit();
            source.MemoryBlockOfBytes.Commit();
            source.MemoryBlockOfStructs.Commit();
            source.MemoryBlockOfClasses.Commit();

            copy.MemoryBlockOfBitArrays.Commit();
            copy.MemoryBlockOfBytes.Commit();
            copy.MemoryBlockOfStructs.Commit();
            copy.MemoryBlockOfClasses.Commit();


            AssertEquals(source, copy);
        }

        [TestMethod]
        public void MarkAsModified()
        {
            var source = new PerfState(256);
            var copy = DeepReflectionCopy.DeepCopy(source);

            source.Buff[1][2] = 42;

            DeepReflectionOverwrite.Run(source, copy);

            AssertEquals(source, copy);
        }

        [TestMethod]
        public void CopyPerfTest()
        {
            var source = new PerfState(0xFFFF);

            for (var i = 0; i < 1000; i++)
            {
                source.Buff[i][2] = (byte)i;
                var copy = DeepReflectionCopy.DeepCopy(source);
                Assert.AreEqual(copy.Buff[i][2], source.Buff[i][2]);
            }
        }

        [TestMethod]
        public void OverridePerfTest()
        {
            var source = new PerfState(0xFFFF);
            var copy = DeepReflectionCopy.DeepCopy(source);

            source.Buff.MarkForModifications();

            for (var i = 0; i < 1000; i++)
            {
                source.Buff[i][2] = (byte)i;
                source.Buff.Modified(i);
                DeepReflectionOverwrite.Run(source, copy);

                Assert.AreEqual(copy.Buff[i][2], source.Buff[i][2]);
            }
        }
    }
}
