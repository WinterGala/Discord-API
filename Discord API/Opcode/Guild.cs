using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct Guild
    {
        public enum VerificationLevels : uint
        {
            /// <summary>
            /// Unrestricted.
            /// </summary>
            None = 0,
            /// <summary>
            /// Must have verified email on account.
            /// </summary>
            Low = 1,
            /// <summary>
            /// Must be registered on Discord for longer than 5 minutes.
            /// </summary>
            Medium = 2,
            /// <summary>
            /// Must be a member of the server for longer than 10 minutes.
            /// </summary>
            High = 3,
            /// <summary>
            /// Must have a verified phone number.
            /// </summary>
            VeryHigh = 4
        }

        public enum MessageNotificationLevel : uint
        {
            AllMessages = 0,
            OnlyMentions = 1
        }

        public enum ExplicitContentFilterLevel : uint
        {
            Disabled = 0,
            MembersWithoutRoles = 1,
            AllMembers = 2
        }

        public enum MultiFactorAuthenticationLevel : uint
        {
            None = 0,
            Elevated = 1
        }

        public enum PremiumTierLevel : uint
        {
            None = 0,
            Tier1 = 1,
            Tier2 = 2,
            Tier3 = 3
        }

        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;
        [JsonProperty(PropertyName = "name")]
        public readonly string Name;
        [JsonProperty(PropertyName = "icon")]
        public readonly string Icon;
        [JsonProperty(PropertyName = "splash")]
        public readonly string Splash;
        [JsonProperty(PropertyName = "owner")]
        public readonly bool? IsOwner;
        [JsonProperty(PropertyName = "owner_id")]
        public readonly Snowflake OwnerId;
        [JsonProperty(PropertyName = "permissions")]
        public readonly Permissions? Permissions;
        [JsonProperty(PropertyName = "region")]
        public readonly string Region;
        [JsonProperty(PropertyName = "afk_channel_id")]
        public readonly Snowflake AfkChannelId;
        [JsonProperty(PropertyName = "afk_timeout")]
        public readonly uint AfkTimeout;
        [JsonProperty(PropertyName = "embed_enabled")]
        public readonly bool? EmbedEnabled;
        [JsonProperty(PropertyName = "embed_channel_id")]
        public readonly Snowflake EmbedChannelId;
        [JsonProperty(PropertyName = "verification_level")]
        public readonly VerificationLevels VerificationLevel;
        [JsonProperty(PropertyName = "default_message_notifications")]
        public readonly MessageNotificationLevel DefaultMessageNotifications;
        [JsonProperty(PropertyName = "explicit_content_filter")]
        public readonly ExplicitContentFilterLevel ExplicitContentFilter;
        [JsonProperty(PropertyName = "roles")]
        public readonly Role[] Roles;
        [JsonProperty(PropertyName = "emojis")]
        public readonly Emoji[] Emojis;
        [JsonProperty(PropertyName = "features")]
        public readonly string[] Features;
        [JsonProperty(PropertyName = "mfa_level")]
        public readonly MultiFactorAuthenticationLevel MfaLevel;
        [JsonProperty(PropertyName = "application_id")]
        public readonly Snowflake ApplicationId;
        [JsonProperty(PropertyName = "widget_enabled")]
        public readonly bool? WidgetEnabled;
        [JsonProperty(PropertyName = "widget_channel_id")]
        public readonly Snowflake WidgetChannelId;
        [JsonProperty(PropertyName = "system_channel_id")]
        public readonly Snowflake SystemChannelId;
        [JsonProperty(PropertyName = "joined_at")]
        public readonly DateTime? JoinedAt;
        [JsonProperty(PropertyName = "large")]
        public readonly bool? Large;
        [JsonProperty(PropertyName = "unavailable")]
        public readonly bool? Unavailable;
        [JsonProperty(PropertyName = "member_count")]
        public readonly uint? MemberCount;
        [JsonProperty(PropertyName = "voice_states")]
        public readonly VoiceState?[] VoiceStates;
        [JsonProperty(PropertyName = "members")]
        public readonly GuildMember?[] GuildMembers;
        [JsonProperty(PropertyName = "channels")]
        public readonly Channel?[] Channels;
        [JsonProperty(PropertyName = "presences")]
        public readonly PresenceUpdate?[] Presences;
        [JsonProperty(PropertyName = "max_presences", NullValueHandling = NullValueHandling.Ignore)]
        public readonly uint? MaxPresences;
        [JsonProperty(PropertyName = "max_members")]
        public readonly uint? MaxMembers;
        [JsonProperty(PropertyName = "vanity_url_code")]
        public readonly string VanityUrlCode;
        [JsonProperty(PropertyName = "description")]
        public readonly string Description;
        [JsonProperty(PropertyName = "banner")]
        public readonly string Banner;
        [JsonProperty(PropertyName = "premium_tier")]
        public readonly PremiumTierLevel PremiumTier;
        [JsonProperty(PropertyName = "premium_subscription_count")]
        public readonly uint? PremiumSubscriptionCount;
        [JsonProperty(PropertyName = "preferred_locale")]
        public readonly string PreferredLocale;
    }
}
