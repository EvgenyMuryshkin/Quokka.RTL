using System;

namespace Quokka.RTL.Tools
{
    public class RTLSignalInfo
    {
        public Type Type { get; set; }
        public int Size { get; set; }
        public RTLDataType SignalType { get; set; } = RTLDataType.Unsigned;

        public RTLSignalInfo() { }

        public RTLSignalInfo(
            Type type,
            int size,
            RTLDataType signalType)
        {
            Type = type;
            Size = size;
            SignalType = signalType;
        }

        public override string ToString()
        {
            return $"Type: {(Type?.Name ?? "null")}, {Size} bits, {SignalType}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is RTLSignalInfo s)
                return Type == s.Type && Size == s.Size && SignalType == s.SignalType;

            return false;
        }

        public static bool operator !=(RTLSignalInfo lhs, RTLSignalInfo rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator ==(RTLSignalInfo lhs, RTLSignalInfo rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }
            if (ReferenceEquals(lhs, null))
            {
                return false;
            }
            if (ReferenceEquals(rhs, null))
            {
                return false;
            }

            return lhs.Equals(rhs);
        }

        public override int GetHashCode()
        {
            return (Type?.GetHashCode() ?? 0) ^ Size.GetHashCode() ^ SignalType.GetHashCode();
        }
    }
}
