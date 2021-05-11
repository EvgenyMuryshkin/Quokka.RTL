using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL
{
    public interface IRTLClonable
    {
        object Clone();
    }

    public interface IRTLComparable
    {
        bool IsEqual(object rhs);
    }
}
