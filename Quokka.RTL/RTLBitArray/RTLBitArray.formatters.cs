using Quokka.RTL.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        public ulong As64BitsUnsigned()
        {
            var v = new RTLBitArray(this);
            v.internalResize(64);

            return v.MSB.Aggregate(0UL, (acc, bit) => (acc << 1) | (bit ? 1UL : 0UL));
        }

        public string AsBinaryString()
        {
            return string.Join("", MSB.Select(b => b ? "1" : "0"));
        }

        public string AsJSONValue()
        {
            return $"{(DataType == RTLSignalType.Signed ? "S" : "U")}:{AsBinaryString()}";
        }

        public override string ToString()
        {
            List<List<bool>> parts = new List<List<bool>>();
            IEnumerable<bool> source = LSB;

            while (source.Any())
            {
                parts.Add(source.Take(8).Reverse().ToList());
                source = source.Skip(8);
            }

            var byteParts = parts
                .AsEnumerable()
                .Reverse()
                .Select(p => string.Join("", p.Select(b => b ? "1" : "0")))
                .Select(p => Convert.ToByte(p, 2))
                .ToList();

            var result = string.Join("", byteParts.Select(p => p.ToString("X02"))).TrimStart(new[] { '0' });
            if (result == "")
                result = "0";

            return $"0x{result}";
        }

        public override int GetHashCode()
        {
            return As64BitsUnsigned().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var bitArray = obj as RTLBitArray;
            if (bitArray == null)
                return false;

            return this == bitArray;
        }
    }
}
