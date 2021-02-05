using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API
{
    public struct ConnectionProperties
    {
        [JsonProperty(PropertyName = "$os")]
        public string Os;
        [JsonProperty(PropertyName = "$browser")]
        public string Browser;
        [JsonProperty(PropertyName = "$device")]
        public string Device;
    }
}
