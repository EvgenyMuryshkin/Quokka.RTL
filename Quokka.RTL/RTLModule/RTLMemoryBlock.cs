using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public interface IRTLMemoryBlock : ICloneable
    {
        void Stage(IRTLMemoryBlock source);
        void CommitSelf();
        object ToSerialized();
        void FromSerialized(object source);
        Type SerializedType();
        Type ElementType();
        bool IsMarkedForModifications { get; }
        void MarkForModifications();
        void Modified(int index);
        object FirstOrDefault();
        int Length { get; }
        object ValueAt(int index);
        IEnumerable<object> AsEnumerableOfObjects();
    }

    public class RTLMemoryBlockSerialized<T>
    {
        public T[] Buffer = new T[0];
        public Dictionary<int, T> Override = new Dictionary<int, T>();
    }

    [JsonConverter(typeof(RTLMemoryBlockConverter))]
    public class RTLMemoryBlock<T> : IRTLMemoryBlock
    {
        internal T[] _buffer;
        internal Dictionary<int, T> _override = new Dictionary<int, T>();

        public RTLMemoryBlock(int size)
        {
            if (!typeof(T).IsValueType && size > 0)
                throw new Exception($"Type {typeof(T)} is not a value type, please use IEnumerable ctor");
            _buffer = new T[size];
        }

        public RTLMemoryBlock(IEnumerable<T> source)
        {
            _buffer = source.ToArray();
        }

        public void Initialize(T[] source)
        {
            source.CopyTo(_buffer, 0);
        }

        public object ToSerialized()
        {
            return new RTLMemoryBlockSerialized<T>() { Buffer = _buffer, Override = _override };
        }
        
        public Type SerializedType()
        {
            return typeof(RTLMemoryBlockSerialized<T>);
        }
        public Type ElementType()
        {
            return typeof(T);
        }

        public void FromSerialized(object source)
        {
            var s = (RTLMemoryBlockSerialized<T>)source;
            _buffer = s.Buffer;
            _override = s.Override;
        }

        public bool IsMarkedForModifications { get; set; }
        public void MarkForModifications()
            => IsMarkedForModifications = true;

        public void Modified(int index)
        {
            _override[index] = this[index];
        }

        internal RTLMemoryBlock(IEnumerable<T> source, bool _marker)
        {
            var typeOfT = typeof(T);
            if (typeOfT.IsValueType)
            {
                _buffer = source.ToArray();
            }
            else if (typeof(ICloneable).IsAssignableFrom(typeOfT))
            {
                _buffer = source.Select(s => (s as ICloneable).Clone()).Select(s => (T)s).ToArray();
            }
            else
            {
                _buffer = source.Select(s => DeepJSONCopy.DeepCopy(s)).ToArray();
            }
        }

        public T this[int index]
        {
            get
            {
                if (!_override.TryGetValue(index, out T value))
                    value = _buffer[index];

                return value;
            }
            set
            {
                _override[index] = value;
            }
        }

        public T this[uint index]
        {
            get
            {
                if (!_override.TryGetValue((int)index, out T value))
                    value = _buffer[index];

                return value;
            }
            set
            {
                _override[(int)index] = value;
            }
        }

        public object ValueAt(int index) => this[index];
        public IEnumerable<object> AsEnumerableOfObjects() => _buffer.OfType<object>();

        public object FirstOrDefault() => _buffer.FirstOrDefault();
        public int Length => _buffer.Length;
        public IEnumerable<TResult> Select<TResult>(Func<T, TResult> p) => _buffer.Select(p);
        public void Stage(IRTLMemoryBlock source)
        {
            var typedSource = source as RTLMemoryBlock<T>;
            _override = DeepJSONCopy.DeepCopy(typedSource._override);
        }

        public void CommitFromMemoryBlock(IRTLMemoryBlock source)
        {
            var typedSource = source as RTLMemoryBlock<T>;
            Commit(typedSource._override);
        }
        public void CommitSelf()
        {
            Commit(_override);
        }

        public Dictionary<int, T> Commit(Dictionary<int, T> value = null)
        {
            Dictionary<int, T> result = value ?? _override;

            foreach (var pair in result)
            {
                var clonable = pair.Value as ICloneable;
                if (clonable != null)
                {
                    _buffer[pair.Key] = (T)clonable.Clone();
                }
                else if (pair.Value.GetType().IsValueType)
                {
                    _buffer[pair.Key] = pair.Value;
                }
                else
                {
                    throw new Exception($"Type {typeof(T)} must be IClonable");
                }
            }

            _override = new Dictionary<int, T>();

            return result;
        }

        public void Cancel()
        {
            _override = new Dictionary<int, T>();
        }

        public object Clone()
        {
            return new RTLMemoryBlock<T>(_buffer, true);
        }
    }
}
