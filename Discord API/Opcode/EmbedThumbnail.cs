using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class EmbedThumbnail
    {
        /// <summary>
        /// Source url of thumbnail (only supports http(s) and attachments).
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url;

        /// <summary>
        /// A proxied url of the thumbnail.
        /// </summary>
        [JsonProperty(PropertyName = "proxy_url")]
        public string ProxyUrl;

        /// <summary>
        /// Height of thumbnail.
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public string Height;

        /// <summary>
        /// Width of thumbnail.
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public string Width;
    }
}
