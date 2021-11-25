using System;

namespace Quokka.RTL.Tools
{
    internal class Disposable : IDisposable
    {
        Action _onDispose;
        internal Disposable(Action onDispose)
        {
            _onDispose = onDispose;
        }

        public static IDisposable Create(Action onDispose)
        {
            return new Disposable(onDispose);
        }

        public void Dispose()
        {
            _onDispose?.Invoke();
            _onDispose = null;
        }
    }
}
