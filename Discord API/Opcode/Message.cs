using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct Message
    {
        /// <summary>
        /// Id of the message.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;

        /// <summary>
        /// Id of the channel the message was sent in.
        /// </summary>
        [JsonProperty(PropertyName = "channel_id")]
        public readonly Snowflake ChannelId;
        
        /// <summary>
        /// Id of the guild the message was sent in.
        /// </summary>
        [JsonProperty(PropertyName = "guild_id")]
        public readonly Snowflake GuildId;
        
        /// <summary>
        /// The author of this message (not guaranteed to be a valid user).
        /// </summary>
        [JsonProperty(PropertyName = "author")]
        public readonly User Author;

        /// <summary>
        /// Member properties for this message's author.
        /// </summary>
        [JsonProperty(PropertyName = "member")]
        public readonly GuildMember Member;

        /// <summary>
        /// Contents of the message.
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public readonly string Content;

        /// <summary>
        /// When this message was sent.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public readonly DateTime Timestamp;

        /// <summary>
        /// When this message was edited (or null if never).
        /// </summary>
        [JsonProperty(PropertyName = "edited_timestamp")]
        public readonly DateTime? EditedTimestamp;

        /// <summary>
        /// Whether this was a TTS message.
        /// </summary>
        [JsonProperty(PropertyName = "tts")]
        public readonly bool Tts;

        /// <summary>
        /// Whether this message mentions everyone.
        /// </summary>
        [JsonProperty(PropertyName = "mention_everyone")]
        public readonly bool MentionEveryone;

        /// <summary>
        /// Users specifically mentioned in the message.
        /// </summary>
        [JsonProperty(PropertyName = "mentions")]
        public readonly User[] Mentions;

        /// <summary>
        /// Roles specifically mentioned in this message.
        /// </summary>
        [JsonProperty(PropertyName = "mention_roles")]
        public readonly Snowflake[] MentionsRoles;

        /// <summary>
        /// Channels specifically mentioned in this message.
        /// </summary>
        [JsonProperty(PropertyName = "mention_channels")]
        public readonly ChannelMention[] MentionChannels;

        /// <summary>
        /// Any attached files.
        /// </summary>
        [JsonProperty(PropertyName = "attachments")]
        public readonly Attachment[] Attachments;


    }
}
