using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quokka.RTL.Tests
{
    // Native
    // RTLBitArray
    // Object

    // Tuple
    // Array


    class CombinationalUnrollObjectL2
    {

    }

    class CombinationalUnrollObjectL1
    {
        public bool NativeField;
        public RTLBitArray BitArrayField = new RTLBitArray().Resized(2);
        public CombinationalUnrollObjectL2 Object = new CombinationalUnrollObjectL2();

        public (bool, RTLBitArray, CombinationalUnrollObjectL2) Tuple;

        public (bool[], RTLBitArray[], CombinationalUnrollObjectL2[]) TupleOfArrays;

    }

    class CombinationalUnrollTestClass
    {
        public bool NativeField;
        public RTLBitArray BitArrayField = new RTLBitArray().Resized(2);
        public CombinationalUnrollObjectL1 Object = new CombinationalUnrollObjectL1();

        public (bool, RTLBitArray, CombinationalUnrollObjectL1) Tuple;
        public (bool, RTLBitArray, CombinationalUnrollObjectL1)[] TupleArray;

        public (bool[], RTLBitArray[], CombinationalUnrollObjectL1[]) TupleOfArrays;
        public (bool[], RTLBitArray[], CombinationalUnrollObjectL1[])[] TupleOfArraysArray;
    }

    [TestClass]
    public class CombinationalUnrollTests
    {
        [TestMethod]
        public void Native()
        {

        }
    }
}
