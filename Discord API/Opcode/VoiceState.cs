using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct VoiceState
    {
        /// <summary>
        /// The guild id this voice state is for.
        /// </summary>
        [JsonProperty(PropertyName = "guild_id")]
        public readonly Snowflake GuildId;
        /// <summary>
        /// The channel id this user is connected to.
        /// </summary>
        [JsonProperty(PropertyName = "channel_id")]
        public readonly Snowflake ChannelId;
        /// <summary>
        /// The user id this voice state is for.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public readonly Snowflake UserId;
        /// <summary>
        /// The guild member this voice state is for.
        /// </summary>
        [JsonProperty(PropertyName = "member")]
        public readonly GuildMember Member;
        /// <summary>
        /// The session id for this voice state.
        /// </summary>
        [JsonProperty(PropertyName = "session_id")]
        public readonly string SessionId;
        /// <summary>
        /// Whether this user is deafened by the server.
        /// </summary>
        [JsonProperty(PropertyName = "deaf")]
        public readonly bool Deaf;
        /// <summary>
        /// Whether this user is muted by the server.
        /// </summary>
        [JsonProperty(PropertyName = "mute")]
        public readonly bool Mute;
        /// <summary>
        /// Whether this user is locally deafened.
        /// </summary>
        [JsonProperty(PropertyName = "self_deaf")]
        public readonly bool SelfDeaf;
        /// <summary>
        /// Whether this user is locally muted.
        /// </summary>
        [JsonProperty(PropertyName = "self_mute")]
        public readonly bool SelfMute;
        /// <summary>
        /// Whether this user is muted by the current user.
        /// </summary>
        [JsonProperty(PropertyName = "suppress")]
        public readonly bool Suppress;
    }
}
