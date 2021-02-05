using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct Overwrite
    {
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;
        [JsonProperty(PropertyName = "type")]
        public readonly string Type;
        [JsonProperty(PropertyName = "allow")]
        public readonly Permissions Allow;
        [JsonProperty(PropertyName = "deny")]
        public readonly Permissions Deny;
    }
}
