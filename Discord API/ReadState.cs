using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API
{
    public struct ReadState
    {
        [JsonProperty(PropertyName = "mention_count")]
        public readonly uint MentionCount;
        [JsonProperty(PropertyName = "last_pin_timestamp")]
        public readonly DateTime LastPinTimestamp;
        [JsonProperty(PropertyName = "last_message_id")]
        public readonly Snowflake LastMessageId;
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;
    }
}
