using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct UserSettings
    {
        [JsonProperty(PropertyName = "timezone_offset")]
        public readonly int TimezoneOffset;
        [JsonProperty(PropertyName = "theme")]
        public readonly string Theme;
        [JsonProperty(PropertyName = "status")]
        public readonly string Status;
        [JsonProperty(PropertyName = "show_current_game")]
        public readonly bool ShowCurrentGame;
        [JsonProperty(PropertyName = "restrcited_guilds")]
        public readonly Snowflake[] RestrictedGuilds;
        [JsonProperty(PropertyName = "render_reactions")]
        public readonly bool RenderReactions;
        [JsonProperty(PropertyName = "render_embeds")]
        public readonly bool RenderEmbeds;
        [JsonProperty(PropertyName = "message_display_compact")]
        public readonly bool MessageDisplayCompact;
        [JsonProperty(PropertyName = "locale")]
        public readonly string Locale;
        [JsonProperty(PropertyName = "inline_media_embed")]
        public readonly bool InlineMediaEmbed;
        [JsonProperty(PropertyName = "inline_attachment_embed")]
        public readonly bool InlineAttachmentMedia;
        [JsonProperty(PropertyName = "guild_positions")]
        public readonly Snowflake[] GuildPositions;
        [JsonProperty(PropertyName = "guild_folders")]
        public readonly GuildFolder[] GuildFolders;
        [JsonProperty(PropertyName = "gif_auto_play")]
        public readonly bool GifAutoPlay;
        [JsonProperty(PropertyName = "friend_source_flags")]
        public readonly FriendSourceFlags FriendSourceFlags;
        [JsonProperty(PropertyName = "explicit_content_filter")]
        public readonly int ExplicitContentFilter;
        [JsonProperty(PropertyName = "enable_tts_command")]
        public readonly bool EnableTtsCommand;
        [JsonProperty(PropertyName = "disable_games_tab")]
        public readonly bool DisableGamesTab;
        [JsonProperty(PropertyName = "developer_mode")]
        public readonly bool DeveloperMode;
        [JsonProperty(PropertyName = "detect_platform_accounts")]
        public readonly bool DetectPlatformAccounts;
        [JsonProperty(PropertyName = "default_guilds_restricted")]
        public readonly bool DefaultGuildsRestricted;
        [JsonProperty(PropertyName = "convert_emoticons")]
        public readonly bool ConvertEmoticons;
        [JsonProperty(PropertyName = "animate_emoji")]
        public readonly bool AnimateEmoji;
        [JsonProperty(PropertyName = "afk_timeout")]
        public readonly uint AfkTimeout;
    }
}
