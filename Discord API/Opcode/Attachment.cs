using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    /// <summary>
    /// Represents a Discord attachment.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Attachment id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;

        /// <summary>
        /// Name of file attached.
        /// </summary>
        [JsonProperty(PropertyName = "filename")]
        public readonly string Filename;

        /// <summary>
        /// Size of file in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public readonly uint Size;

        /// <summary>
        /// Source url of file.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public readonly string Url;

        /// <summary>
        /// A proxied url of file.
        /// </summary>
        [JsonProperty(PropertyName = "proxy_url")]
        public readonly string ProxyUrl;

        /// <summary>
        /// Height of file (if image).
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public readonly uint? Height;

        /// <summary>
        /// Width of file (if image).
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public readonly uint? Width;
    }
}
