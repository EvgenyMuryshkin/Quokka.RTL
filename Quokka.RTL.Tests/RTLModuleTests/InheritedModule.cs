namespace Quokka.RTL.Tests
{
    class InheritedModule : BaseOverrideModule
    {
        public override bool OutValue => false;
        protected override bool InternalValue => false;
    }
}
