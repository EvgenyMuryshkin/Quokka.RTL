using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quokka.RTL.VHDL
{
    public partial class vhdIdentifier
    {
        public vhdIdentifier WithIndex(IEnumerable<vhdRange> indexes)
        {
            var clone = this.Clone();

            clone.Indexes.AddRange(indexes);

            return clone;
        }

        public vhdIdentifier WithIndex(params vhdRange[] indexes)
        {
            return WithIndex(indexes.ToList());
        }
    }
}
