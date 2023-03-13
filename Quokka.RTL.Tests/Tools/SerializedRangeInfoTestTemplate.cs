namespace Quokka.RTL.Tests
{
    public abstract class SerializedRangeInfoTestTemplate
    {
        public abstract void SelfNative();
        public abstract void SelfArray();
        public abstract void ArrayIndex();
        public abstract void TupleItem();
        public abstract void TupleItemIndex();
        public abstract void TupleArrayItem();
        public abstract void TupleArrayItemIndex();

        public abstract void ClassMember();
        public abstract void ClassMemberIndex();
        public abstract void ClassTupleValue();
        public abstract void ClassTupleNestedValue();
        public abstract void ClassTupleNestedIndex();
    }
}
