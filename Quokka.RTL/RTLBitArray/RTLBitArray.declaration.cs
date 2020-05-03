using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    [JsonConverter(typeof(RTLBitArrayConverter))]
    public partial class RTLBitArray
    {
    }
}
