using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class EmbedVideo
    {
        /// <summary>
        /// Source url of video.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url;

        /// <summary>
        /// Height of video.
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public uint Height;

        /// <summary>
        /// Width of video.
        /// </summary>
        [JsonProperty(PropertyName = "wdith")]
        public uint Width;
    }
}
