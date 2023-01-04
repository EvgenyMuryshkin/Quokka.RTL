using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL
{
    public partial class RTLBitArray : ICloneable
    {
        public object Clone()
        {
            return new RTLBitArray(this);
        }
    }
}
