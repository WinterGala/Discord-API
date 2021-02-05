using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct PresenceUpdate
    {
        [JsonProperty(PropertyName = "user")]
        public readonly User User;
        [JsonProperty(PropertyName = "roles")]
        public readonly Snowflake[] Roles;
        [JsonProperty(PropertyName = "game", NullValueHandling = NullValueHandling.Include)]
        public readonly Activity? Game;
        [JsonProperty(PropertyName = "guild_id")]
        public readonly Snowflake GuildId;
        [JsonProperty(PropertyName = "status")]
        public readonly string Status;
        [JsonProperty(PropertyName = "last_modified")]
        public readonly ulong LastModified;
        [JsonProperty(PropertyName = "activities")]
        public readonly Activity[] Activities;
        [JsonProperty(PropertyName = "client_status")]
        public readonly ClientStatus ClientStatus;
    }
}
