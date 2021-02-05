using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct GuildSettings
    {
        [JsonProperty(PropertyName = "suppress_everyone")]
        public readonly bool SuppressEveryone;
        [JsonProperty(PropertyName = "muted")]
        public readonly bool Muted;
        [JsonProperty(PropertyName = "mobile_push")]
        public readonly bool MobilePush;
        [JsonProperty(PropertyName = "message_notifications")]
        public readonly int MessageNotifications;
        [JsonProperty(PropertyName = "guild_id")]
        public readonly Snowflake GuildId;
        [JsonProperty(PropertyName = "channel_overrides")]
        public readonly ChannelOverride[] ChannelOverrides;

        public struct ChannelOverride
        {
            [JsonProperty(PropertyName = "muted")]
            public readonly bool Muted;
            [JsonProperty(PropertyName = "message_notification")]
            public readonly int MessageNotifications;
            [JsonProperty(PropertyName = "channel_id")]
            public readonly Snowflake ChannelId;
        }
    }
}
