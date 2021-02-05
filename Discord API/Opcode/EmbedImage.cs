using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class EmbedImage
    {
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url;
        [JsonProperty(PropertyName = "proxy_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ProxyUrl;
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public string Height;
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public string Width;
    }
}
