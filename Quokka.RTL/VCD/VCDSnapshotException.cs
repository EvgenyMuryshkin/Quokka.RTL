using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.VCD
{
    public class VCDSnapshotException : Exception
    {
        public VCDSnapshotException(string message) : base(message) { }
        public VCDSnapshotException(string message, Exception innerException) : base(message, innerException) { }
    }
}
