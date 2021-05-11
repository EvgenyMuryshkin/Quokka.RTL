using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Quokka.RTL
{
    public class ReflectionCache<TKey, TValue>
    {
        ConcurrentDictionary<TKey, TValue> _cache = new ConcurrentDictionary<TKey, TValue>();
        Func<TKey, TValue> _accessor;

        public ReflectionCache(Func<TKey, TValue> accessor)
        {
            _accessor = accessor;
        }

        public TValue this[TKey value]
        {
            get
            {
                return _cache.GetOrAdd(value, (key) => _accessor(key));
            }
        }
    }

    public class MemberInfoCache<TValue> : ReflectionCache<MemberInfo, TValue>
    {
        public MemberInfoCache(Func<MemberInfo, TValue> accessor) : base(accessor)
        {
        }
    }

    public class PropertyInfoCache<TValue> : ReflectionCache<PropertyInfo, TValue>
    {
        public PropertyInfoCache(Func<PropertyInfo, TValue> accessor) : base(accessor)
        {
        }
    }

    public class TypeCache<TValue> : ReflectionCache<Type, TValue>
    {
        public TypeCache(Func<Type, TValue> accessor) : base(accessor)
        {
        }
    }
}
