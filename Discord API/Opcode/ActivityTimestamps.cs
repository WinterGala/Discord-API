using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct ActivityTimestamps
    {
        [JsonProperty(PropertyName = "start")]
        public readonly ulong Start;
        [JsonProperty(PropertyName = "end")]
        public readonly ulong End;
    }
}
