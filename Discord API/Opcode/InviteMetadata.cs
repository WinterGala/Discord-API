using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class InviteMetadata
    {
        /// <summary>
        /// User who created the invite.
        /// </summary>
        [JsonProperty(PropertyName = "inviter")]
        public readonly User Inviter;
        /// <summary>
        /// Number of times this invite has been used.
        /// </summary>
        [JsonProperty(PropertyName = "uses")]
        public readonly uint Uses;
        /// <summary>
        /// Max number of times this invite can be used.
        /// </summary>
        [JsonProperty(PropertyName = "max_uses")]
        public readonly uint MaxUses;
        /// <summary>
        /// Duration (in seconds) after which the invite expires.
        /// </summary>
        [JsonProperty(PropertyName = "max_age")]
        public readonly uint MaxAge;
        /// <summary>
        /// Whether this invite only grants temporary membership.
        /// </summary>
        [JsonProperty(PropertyName = "temporary")]
        public readonly bool Temporary;
        /// <summary>
        /// When this invite was created.
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public readonly DateTime CreatedAt;
    }
}
