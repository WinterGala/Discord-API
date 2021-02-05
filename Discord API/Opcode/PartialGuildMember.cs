using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct PartialGuildMember
    {
        [JsonProperty(PropertyName = "roles")]
        public readonly Snowflake[] Roles;
        [JsonProperty(PropertyName = "premium_since", NullValueHandling = NullValueHandling.Ignore)]
        public readonly DateTime? PremiumSince;
        [JsonProperty(PropertyName = "nick")]
        public readonly string Nickname;
        [JsonProperty(PropertyName = "mute")]
        public readonly bool Muted;
        [JsonProperty(PropertyName = "joined_at")]
        public readonly DateTime JoinedAt;
        [JsonProperty(PropertyName = "hoisted_role")]
        public readonly Snowflake HoistedRole;
        [JsonProperty(PropertyName = "deaf")]
        public readonly bool Deafened;
    }
}
