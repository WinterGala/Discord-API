using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    /// <summary>
    /// Represents an embed footer.
    /// </summary>
    public class EmbedFooter
    {
        /// <summary>
        /// Footer text.
        /// </summary>
        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text;

        /// <summary>
        /// Url of footer icon (only supports http(s) and attachments).
        /// </summary>
        [JsonProperty(PropertyName = "icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl;

        /// <summary>
        /// A proxied url of footer icon.
        /// </summary>
        [JsonProperty(PropertyName = "proxy_icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ProxyIconUrl;
    }
}
