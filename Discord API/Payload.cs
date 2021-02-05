using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Discord_API
{
    public struct Payload
    {
        [JsonProperty(PropertyName = "op")]
        public readonly int Opcode;
        [JsonProperty(PropertyName = "d")]
        public readonly JContainer Data;
        [JsonProperty(PropertyName = "s")]
        public readonly int? SequenceNumber;
        [JsonProperty(PropertyName = "t")]
        public readonly string EventName;
    }
}
