using System;

namespace Quokka.RTL
{
    public interface IRTLClassFactory
    {
        T Create<T>();
        T Create<T>(Type type);
    }
}
