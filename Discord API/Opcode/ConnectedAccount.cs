using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct ConnectedAccount
    {
        [JsonProperty(PropertyName = "visibilty")]
        public readonly uint Visibility;
        [JsonProperty(PropertyName = "verified")]
        public readonly bool Verified;
        [JsonProperty(PropertyName = "type")]
        public readonly string Type;
        [JsonProperty(PropertyName = "show_activity")]
        public readonly bool ShowActivity;
        [JsonProperty(PropertyName = "revoked")]
        public readonly bool Revoked;
        [JsonProperty(PropertyName = "name")]
        public readonly string Name;
        [JsonProperty(PropertyName = "id")]
        public readonly string Id;
        [JsonProperty(PropertyName = "friend_sync")]
        public readonly bool FriendSync;
    }
}
