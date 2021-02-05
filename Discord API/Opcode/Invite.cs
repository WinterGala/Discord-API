using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class Invite
    {
        /// <summary>
        /// The invite code (unique ID).
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public readonly string Code;
        /// <summary>
        /// The guild this invite is for.
        /// </summary>
        [JsonProperty(PropertyName = "guild")]
        public readonly Guild? Guild;
        /// <summary>
        /// The channel this invite is for.
        /// </summary>
        [JsonProperty(PropertyName = "channel")]
        public readonly Channel Channel;
        /// <summary>
        /// The target user for this invite.
        /// </summary>
        [JsonProperty(PropertyName = "target_user")]
        public readonly User? TargetUser;
        /// <summary>
        /// The type of target user for this invite.
        /// </summary>
        [JsonProperty(PropertyName = "target_user_type")]
        public readonly uint? TargetUserType;
        /// <summary>
        /// Approximate count of online members (only present when target_user is set).
        /// </summary>
        [JsonProperty(PropertyName = "approximate_presence_count")]
        public readonly uint? ApproximatePresenceCount;
        /// <summary>
        /// Approximate count of total members.
        /// </summary>
        [JsonProperty(PropertyName = "approximate_memeber_count")]
        public readonly uint? ApproximateMemberCount;
    }
}
