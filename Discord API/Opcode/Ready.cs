using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct Ready
    {
        [JsonProperty(PropertyName = "v")]
        public int V;
        [JsonProperty(PropertyName = "user_settings")]
        public readonly UserSettings UserSettings;
        [JsonProperty(PropertyName = "user_guild_settings")]
        public readonly GuildSettings[] UserGuildSettings;
        [JsonProperty(PropertyName = "user_feed_settings")]
        public readonly FeedSettings UserFeedSettings;
        [JsonProperty(PropertyName = "user")]
        public User User;
        [JsonProperty(PropertyName = "tutorial")]
        public readonly bool? Tutorial;
        [JsonProperty(PropertyName = "session_id")]
        public readonly string SessionId;
        [JsonProperty(PropertyName = "relationships")]
        public readonly Relationship[] Relationships;
        [JsonProperty(PropertyName = "read_state")]
        public readonly ReadState[] ReadStates;
        [JsonProperty(PropertyName = "private_channels")]
        public readonly Channel[] PrivateChannels;
        [JsonProperty(PropertyName = "presences")]
        public readonly PresenceUpdate[] Presences;
        [JsonProperty(PropertyName = "notes")]
        public readonly Dictionary<Snowflake, string> Notes;
        [JsonProperty(PropertyName = "guilds")]
        public readonly Guild[] Guilds;
        [JsonProperty(PropertyName = "consents")]
        public readonly Personalization Consents;
        [JsonProperty(PropertyName = "connected_accounts")]
        public readonly Connection[] ConnectedAccounts;
        [JsonProperty(PropertyName = "analytics_token")]
        public readonly string AnalyticsToken;
        [JsonProperty(PropertyName = "_trace")]
        public readonly string[] Trace;
        /*[JsonProperty(PropertyName = "guilds")]
        public UnavailableGuild[] Guilds;*/
        [JsonProperty(PropertyName = "shard")]
        public int[] Shard;
    }
}
