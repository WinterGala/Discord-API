using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class EmbedAuthor
    {
        /// <summary>
        /// Name of author.
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name;

        /// <summary>
        /// Url of author.
        /// </summary>
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url;

        /// <summary>
        /// Url of author icon (only supports http(s) and attachments).
        /// </summary>
        [JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl;

        /// <summary>
        /// A proxied url of author icon.
        /// </summary>
        [JsonProperty(PropertyName = "proxy_icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ProxyIconUrl;
    }
}
