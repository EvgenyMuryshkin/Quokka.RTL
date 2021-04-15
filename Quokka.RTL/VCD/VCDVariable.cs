using Quokka.RTL;
using System;

namespace Quokka.VCD
{
    public class VCDVariable
    {
        public VCDVariable(string name, object value, int size = 0, VCDVariableType type = VCDVariableType.Undefined )
        {
            Name = name;
            Value = value;
            Size = size == 0 ? VCDInteraction.SizeOf(value) : size;
            Type = type == VCDVariableType.Undefined ? VCDInteraction.VarType(value) : type;
        }

        public string Name { get; }
        public int Size { get; set; }
        public VCDVariableType Type { get; set; }

        object _value;
        public object Value {
            get
            {
                return _value;
            }
            set
            {
                if (_value == null)
                {
                    _value = value;
                }
                else
                {
                    if (_value.GetType() != value.GetType())
                        throw new Exception($"Value type change detected in {Name}");

                    _value = value;
                }
            }
        }

        public VCDVariable SetValue(object value)
        {
            Value = value;
            return this;
        }

        public override string ToString()
        {
            return $"{Name} = {Value}, {Type}, {Size} bits";
        }
    }
}
