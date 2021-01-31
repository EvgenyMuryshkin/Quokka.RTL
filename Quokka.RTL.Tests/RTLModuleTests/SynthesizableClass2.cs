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

    class SynthesizableClassWithNullables
    {
        public bool? Nullablefield;
        public bool? NullableProperty1 { get; set; }
        public bool? NullableProperty2 { get; private set; }
        public bool? NullableProperty3 { private get; set; }
    }

    abstract class StageStateBaseType
    {
        public bool? IsReady { get; set; }
    }

    class Stage0PipelineState : StageStateBaseType
    {
        public ushort[] sums { get; set; } = new ushort[4];
        public ushort S0Counter { get; set; }
    }
}
