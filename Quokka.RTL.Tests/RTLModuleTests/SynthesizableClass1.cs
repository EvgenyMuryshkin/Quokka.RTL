namespace Quokka.RTL.Tests
{
    class SynthesizableClass1
    {
        public int Value = 42;
        public bool Flag { get; set; }
        public RTLBitArray Array { get; set; } = new RTLBitArray(8);

        public SynthesizableClass1(int size)
        {
            Array = new RTLBitArray().Resized(size);
        }
    }
}
