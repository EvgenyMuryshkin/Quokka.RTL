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
            return $"{(_dataType == RTLBitArrayType.Signed ? "S" : "U")}:{AsBinaryString()}";
        }

        public override string ToString()
        {
            List<List<bool>> parts = new List<List<bool>>();
            IEnumerable<bool> source = MSB;

            while(source.Any())
            {
                parts.Add(source.Take(8).ToList());
                source = source.Skip(8);
            }

            var byteParts = parts
                .Select(p => string.Join("", p.Select(b => b ? "1" : "0")))
                .Select(p => Convert.ToByte(p, 2))
                .ToList();

            var result = string.Join("", byteParts.Select(p => p.ToString("X02"))).TrimStart(new[] { '0' });

            return result == "" ? "0" : result;
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
