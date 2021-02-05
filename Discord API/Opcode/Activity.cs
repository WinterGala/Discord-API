using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct Activity
    {
        public enum ActivityType : uint
        {
            Game = 0,
            Streaming = 1,
            Listening = 2
        }

        [Flags]
        public enum ActivityFlags : uint
        {
            Instance = 0,
            Join = 1,
            Spectate = 1 << 2,
            JoinRequest = 1 << 3,
            Sync = 1 << 4,
            Play = 1 << 5
        }

        [JsonProperty(PropertyName = "name")]
        public readonly string Name;
        [JsonProperty(PropertyName = "type")]
        public readonly ActivityType Type;
        [JsonProperty(PropertyName = "url")]
        public readonly string Url;
        [JsonProperty(PropertyName = "timestamps")]
        public readonly ActivityTimestamps Timestamps;
        [JsonProperty(PropertyName = "application_id")]
        public readonly Snowflake ApplicationId;
        [JsonProperty(PropertyName = "details")]
        public readonly string Details;
        [JsonProperty(PropertyName = "state")]
        public readonly string State;
        [JsonProperty(PropertyName = "party")]
        public readonly ActivityParty? Party;
        [JsonProperty(PropertyName = "assets")]
        public readonly ActivityAssets Assets;
        [JsonProperty(PropertyName = "secrets")]
        public readonly ActivitySecrets Secrets;
        [JsonProperty(PropertyName = "instance")]
        public readonly bool? Instance;
        [JsonProperty(PropertyName = "flags")]
        public readonly ActivityFlags Flags;
    }
}
