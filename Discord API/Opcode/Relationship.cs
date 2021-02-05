using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct Relationship
    {
        public enum RelationshipType : uint
        {
            Friend = 1,
            Blocked = 2,
            PendingFriend = 3
        }

        [JsonProperty(PropertyName = "user")]
        public readonly User User;
        [JsonProperty(PropertyName = "type")]
        public readonly RelationshipType Type;
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;
    }
}
