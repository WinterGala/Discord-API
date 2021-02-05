using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct ActivitySecrets
    {
        [JsonProperty(PropertyName = "join")]
        public readonly string Join;
        [JsonProperty(PropertyName = "spectate")]
        public readonly string Spectate;
        [JsonProperty(PropertyName = "match")]
        public readonly string Match;
    }
}
