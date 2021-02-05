using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct ActivityAssets
    {
        [JsonProperty(PropertyName = "large_image")]
        public readonly string LargeImage;
        [JsonProperty(PropertyName = "large_text")]
        public readonly string LargeText;
        [JsonProperty(PropertyName = "small_image")]
        public readonly string SmallImage;
        [JsonProperty(PropertyName = "small_text")]
        public readonly string SmallText;
    }
}
