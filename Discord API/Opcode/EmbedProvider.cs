using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class EmbedProvider
    {
        /// <summary>
        /// Name of provider.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Url of provider.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url;
    }
}
