namespace Quokka.RTL.Tests
{
    class SynthesizableClass2
    {
        public int Size = 8;
        public SynthesizableStruct Struct { get; set; }

        public SynthesizableClass2()
        {
            Struct = new SynthesizableStruct();
        }

        public SynthesizableClass2(int size)
        {
            Struct = new SynthesizableStruct(size);
            Size = size;
        }
    }
}
