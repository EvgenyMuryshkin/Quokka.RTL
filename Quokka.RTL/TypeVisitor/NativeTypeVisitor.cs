using System;

namespace Quokka.RTL.TypeVisitor
{
    public abstract class RequiredTypeVisitor
    {
        protected virtual void OnUnsupported(object value)
        {
            if (value == null) throw new NullReferenceException(nameof(value));

            throw new Exception($"{GetType().Name}: Value of type '{value.GetType()}' was not handled");
        }

        protected abstract void OnValue(byte value);
        protected abstract void OnValue(sbyte value);
        protected abstract void OnValue(ushort value);
        protected abstract void OnValue(short value);
        protected abstract void OnValue(uint value);
        protected abstract void OnValue(int value);
        protected abstract void OnValue(ulong value);
        protected abstract void OnValue(long value);
        protected abstract void OnValue(float value);
        protected abstract void OnValue(RTLBitArray value);

        public virtual void Visit(object value)
        {
            switch (value)
            {
                case byte v: OnValue(v); break;
                case sbyte v: OnValue(v); break;
                case ushort v: OnValue(v); break;
                case short v: OnValue(v); break;
                case uint v: OnValue(v); break;
                case int v: OnValue(v); break;
                case ulong v: OnValue(v); break;
                case long v: OnValue(v); break;
                case float v: OnValue(v); break;
                case RTLBitArray v: OnValue(v); break;
                default: OnUnsupported(value); break;
            }
        }
    }

    public class OptionalTypeVisitor : RequiredTypeVisitor
    {
        protected virtual void OnOptional(object value) { }
        protected override void OnValue(RTLBitArray value) => OnOptional(value);
        protected override void OnValue(byte value) => OnOptional(value);
        protected override void OnValue(float value) => OnOptional(value);
        protected override void OnValue(int value) => OnOptional(value);
        protected override void OnValue(long value) => OnOptional(value);
        protected override void OnValue(sbyte value) => OnOptional(value);
        protected override void OnValue(short value) => OnOptional(value);
        protected override void OnValue(uint value) => OnOptional(value);
        protected override void OnValue(ulong value) => OnOptional(value);
        protected override void OnValue(ushort value) => OnOptional(value);
    }
}
