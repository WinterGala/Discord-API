using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct TypingStart
    {
        [JsonProperty(PropertyName = "channel_id")]
        public readonly Snowflake ChannelId;
        [JsonProperty(PropertyName = "guild_id")]
        public readonly Snowflake GuildId;
        [JsonProperty(PropertyName = "user_id")]
        public readonly Snowflake UserId;
        [JsonProperty(PropertyName = "timestamp", ItemConverterType = typeof(DateTime))]
        public readonly DateTime Timestamp;
    }
}
