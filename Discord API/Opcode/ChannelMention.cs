using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    /// <summary>
    /// Represents a channel mention.
    /// </summary>
    public class ChannelMention
    {
        /// <summary>
        /// Id of the channel
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;

        /// <summary>
        /// Id of the guild containing the channel.
        /// </summary>
        [JsonProperty(PropertyName = "guild_id")]
        public readonly Snowflake GuildId;

        /// <summary>
        /// The type of channel.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public readonly Channel.ChannelType Type;

        /// <summary>
        /// The name of the channel.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public readonly string Name;
    }
}
