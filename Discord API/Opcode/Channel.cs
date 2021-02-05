using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    /// <summary>
    /// Represents a guild or DM channel within Discord.
    /// </summary>
    public struct Channel
    {
        /// <summary>
        /// The id of this channel.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;
        
        /// <summary>
        /// The type of channel.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public readonly ChannelType Type;
        
        /// <summary>
        /// The id of the guild.
        /// </summary>
        [JsonProperty(PropertyName = "guild_id")]
        public readonly Snowflake GuildId;
        
        /// <summary>
        /// Sorting position of the channel.
        /// </summary>
        [JsonProperty(PropertyName = "position")]
        public readonly uint Position;
        
        /// <summary>
        /// Explicit permission overwrites for members and roles.
        /// </summary>
        [JsonProperty(PropertyName = "permission_overwrites")]
        public readonly Overwrite[] PermissionsOverwrites;
        
        /// <summary>
        /// The name of the channel.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public readonly string Name;
        
        /// <summary>
        /// The channel topic.
        /// </summary>
        [JsonProperty(PropertyName = "topic")]
        public readonly string Topic;
        
        /// <summary>
        /// Whether the channel is nsfw.
        /// </summary>
        [JsonProperty(PropertyName = "nsfw")]
        public readonly bool Nsfw;
        
        /// <summary>
        /// The id of the last message sent in this channel (may not point to an existing or valid message).
        /// </summary>
        [JsonProperty(PropertyName = "last_message_id")]
        public readonly Snowflake LastMessageId;
        
        /// <summary>
        /// The bitrate (in bits) of the voice channel.
        /// </summary>
        [JsonProperty(PropertyName = "bitrate")]
        public readonly uint Bitrate;
        
        /// <summary>
        /// The user limit of the voice channel.
        /// </summary>
        [JsonProperty(PropertyName = "user_limit")]
        public readonly uint UserLimit;
        
        /// <summary>
        /// Amount of seconds a user has to wait before sending another message; 
        /// bots, as well as users with the permission manage_messages or manage_channel, are unaffected.
        /// </summary>
        [JsonProperty(PropertyName = "rate_limit_per_user")]
        public readonly uint RateLimitPerUser;
        
        /// <summary>
        /// The recipients of the DM.
        /// </summary>
        [JsonProperty(PropertyName = "recipients")]
        public readonly User[] Recipients;

        /// <summary>
        /// Icon hash.
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public readonly string Icon;

        /// <summary>
        /// Id of the DM creator.
        /// </summary>
        [JsonProperty(PropertyName = "owner_id")]
        public readonly Snowflake OwnerId;

        /// <summary>
        /// Application id of the group DM creator if it is bot-created.
        /// </summary>
        [JsonProperty(PropertyName = "application_id")]
        public readonly Snowflake ApplicationId;

        /// <summary>
        /// Id of the parent category for a channel.
        /// </summary>
        [JsonProperty(PropertyName = "parent_id")]
        public readonly Snowflake ParentId;

        /// <summary>
        /// When the last pinned message was pinned.
        /// </summary>
        [JsonProperty(PropertyName = "last_pin_timestamp")]
        public readonly DateTime? LastPinTimestamp;

        /// <summary>
        /// The type of channel.
        /// </summary>
        public enum ChannelType : uint
        {
            /// <summary>
            /// A text channel within a server.
            /// </summary>
            GuildText = 0,

            /// <summary>
            /// A direct message between users.
            /// </summary>
            DirectMessage = 1,

            /// <summary>
            /// A voice channel within a server.
            /// </summary>
            GuildVoice = 2,

            /// <summary>
            /// A direct message between multiple users.
            /// </summary>
            GroupDirectMessage = 3,

            /// <summary>
            /// An organizational category that contains channels.
            /// </summary>
            GuildCategory = 4,

            /// <summary>
            /// A channel that users can follow and crosspost into their own server.
            /// </summary>
            GuildNews = 5,

            /// <summary>
            /// A channel in which game developers can sell their game on Discord.
            /// </summary>
            GuildStore = 6
        }
    }
}
