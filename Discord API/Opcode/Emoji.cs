using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct Emoji
    {
        /// <summary>
        /// Emoji Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;
        /// <summary>
        /// Emoji Name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public readonly string Name;
        /// <summary>
        /// Roles this emoji is whitelisted to.
        /// </summary>
        [JsonProperty(PropertyName = "roles")]
        public readonly Role[] Roles;
        /// <summary>
        /// User that created this emoji.
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public readonly User User;
        /// <summary>
        /// Whether this emoji must be wrapped in colons.
        /// </summary>
        [JsonProperty(PropertyName = "require_colons")]
        public readonly bool RequireColons;
        /// <summary>
        /// Whether this emoji is managed.
        /// </summary>
        [JsonProperty(PropertyName = "managed")]
        public readonly bool Managed;
        /// <summary>
        /// Whether this emoji is animated.
        /// </summary>
        [JsonProperty(PropertyName = "animated")]
        public readonly bool Animated;
    }
}
