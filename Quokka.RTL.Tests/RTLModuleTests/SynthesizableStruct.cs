namespace Quokka.RTL.Tests
{
    struct SynthesizableStruct
    {
        public int Value;
        public bool Flag { get; set; }
        public RTLBitArray Array { get; set; }

        public SynthesizableStruct(int size)
        {
            Value = 10;
            Flag = true;
            Array = new RTLBitArray(size);
        }
    }
}
