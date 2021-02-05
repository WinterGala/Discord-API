using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct FeedSettings
    {
        [JsonProperty(PropertyName = "unsubscribed_users")]
        public readonly Snowflake[] UnsubscribedUsers;
        [JsonProperty(PropertyName = "unsubscribed_games")]
        public readonly Snowflake[] UnsubscribedGames;
        [JsonProperty(PropertyName = "subscribed_users")]
        public readonly Snowflake[] SubscribedUsers;
        [JsonProperty(PropertyName = "subscribed_games")]
        public readonly Snowflake[] SubscribedGames;
        [JsonProperty(PropertyName = "autosubscribed_users")]
        public readonly Snowflake[] AutosubscribedUsers;
    }
}
