using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class Embed
    {
        /// <summary>
        /// Title of embed.
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title;

        /// <summary>
        /// Type of embed (always "rich" for webhook embeds).
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type;

        /// <summary>
        /// Description of embed.
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description;

        /// <summary>
        /// Url of embed.
        /// </summary>
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url;

        /// <summary>
        /// Timestamp of embed content.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Timestamp;

        /// <summary>
        /// Color code of the embed.
        /// </summary>
        [JsonProperty(PropertyName = "color", NullValueHandling = NullValueHandling.Ignore)]
        public int Color;

        /// <summary>
        /// Footer information.
        /// </summary>
        [JsonProperty(PropertyName = "footer")]
        public EmbedFooter Footer;

        /// <summary>
        /// Image information.
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public EmbedImage Image;

        /// <summary>
        /// Thumbnail information.
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public EmbedThumbnail Thumbnail;

        /// <summary>
        /// Video information.
        /// </summary>
        [JsonProperty(PropertyName = "video", NullValueHandling = NullValueHandling.Ignore)]
        public EmbedVideo Video;

        /// <summary>
        /// Provider information.
        /// </summary>
        [JsonProperty(PropertyName = "provider", NullValueHandling = NullValueHandling.Ignore)]
        public EmbedProvider Provider;

        /// <summary>
        /// Author information.
        /// </summary>
        [JsonProperty(PropertyName = "author", NullValueHandling = NullValueHandling.Ignore)]
        public EmbedAuthor Author;

        /// <summary>
        /// Fields information.
        /// </summary>
        [JsonProperty(PropertyName = "fields", NullValueHandling = NullValueHandling.Ignore)]
        public EmbedField[] Fields;
    }
}
