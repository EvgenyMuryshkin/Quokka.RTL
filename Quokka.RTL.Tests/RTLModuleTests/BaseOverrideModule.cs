namespace Quokka.RTL.Tests
{
    class BaseOverrideModule : DefaultRTLCombinationalModule<TestInputs>
    {
        public virtual bool OutValue => Inputs.WE;
        protected virtual bool InternalValue => Inputs.WE;
    }
}
