using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct ClientStatus
    {
        [JsonProperty(PropertyName = "desktop")]
        public readonly string Desktop;
        [JsonProperty(PropertyName = "mobile")]
        public readonly string Mobile;
        [JsonProperty(PropertyName = "web")]
        public readonly string Web;
    }
}
