using System;
using System.Collections.Generic;
using System.Text;

namespace FPGA
{
    public class InputSignal<T> : Signal<T>
    {
        public static InputSignal<T> operator !(InputSignal<T> source)
        {
            throw new Exception("Simulation not implemented yet");
        }

        public static implicit operator T(InputSignal<T> source)
        {
            throw new Exception("Simulation not implemented yet");
        }

        public static explicit operator byte(InputSignal<T> source)
        {
            throw new Exception("Simulation not implemented yet");
        }

        public static explicit operator uint(InputSignal<T> source)
        {
            throw new Exception("Simulation not implemented yet");
        }
        /*
        public static implicit operator byte(InputSignal<T> source)
        {
            throw new Exception("Simulation not implemented yet");
        }

        public static implicit operator uint(InputSignal<T> source)
        {
            throw new Exception("Simulation not implemented yet");
        }*/
    }

    public class OutputSignal<T> : Signal<T>
    {
        public static implicit operator OutputSignal<T>(T source)
        {
            return new OutputSignal<T>();
        }

        public static implicit operator T(OutputSignal<T> source)
        {
            throw new Exception("Simulation not implemented yet");
        }
    }

    public class BidirSignal<T>
    {
        public static implicit operator BidirSignal<T>(T source)
        {
            return new BidirSignal<T>();
        }

        public static implicit operator T(BidirSignal<T> source)
        {
            throw new Exception("Simulation not implemented yet");
        }
    }

    internal class SignalState<T>
    {
        internal T _value;
        HashSet<Action<T>> _subscribers = new HashSet<Action<T>>();

        public SignalState()
        {
            _value = default(T);
        }

        public SignalState(T value)
        {
            _value = value;
        }

        public void Toggle(T value)
        {
            var handlers = new HashSet<Action<T>>(_subscribers);
            foreach(var handler in handlers)
            {
                handler(value);
                handler(_value);
            }
        }

        public void Subscribe(Action<T> handler)
        {
            _subscribers.Add(handler);
            handler(_value);
        }

        public void Unsubscribe(Action<T> handler)
        {
            _subscribers.Remove(handler);
        }
    }

    public class Signal<T>
    {
        SignalState<T> _state;

        public Signal()
        {
            _state = new SignalState<T>(default(T));
        }

        public Signal(T value)
        {
            _state = new SignalState<T>(value);
        }

        internal Signal(SignalState<T> state)
        {
            _state = state;
        }

        public void Toggle(T value)
        {
            _state.Toggle(value);
        }

        public void Subscribe(Action<T> handler)
        {
            _state.Subscribe(handler);
        }

        public void Usubscribe(Action<T> handler)
        {
            _state.Unsubscribe(handler);
        }

        public static implicit operator T(Signal<T> source)
        {
            return source._state._value;
        }

        public static implicit operator Signal<T>(T source)
        {
            return new Signal<T>(source);
        }

        public static implicit operator Func<T>(Signal<T> source)
        {
            return () => { return source._state._value; };
        }

        public static bool operator ==(Signal<T> c1, Signal<T> c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Signal<T> c1, Signal<T> c2)
        {
            return !c1.Equals(c2);
        }
    }
}
