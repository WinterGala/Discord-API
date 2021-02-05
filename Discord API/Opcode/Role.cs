using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public struct Role
    {
        /// <summary>
        /// Role Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public readonly Snowflake Id;
        /// <summary>
        /// Role name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public readonly string Name;
        /// <summary>
        /// Integer representation of hexadecimal color code.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public readonly uint Color;
        /// <summary>
        /// If this role is pinned in the user listing.
        /// </summary>
        [JsonProperty(PropertyName = "hoist")]
        public readonly bool Hoist;
        /// <summary>
        /// Position of this role.
        /// </summary>
        [JsonProperty(PropertyName = "position")]
        public readonly uint Position;
        /// <summary>
        /// Permission bit set.
        /// </summary>
        [JsonProperty(PropertyName = "permissions")]
        public readonly Permissions Permissions;
        /// <summary>
        /// Whether this role is managed by an integration.
        /// </summary>
        [JsonProperty(PropertyName = "managed")]
        public readonly bool Managed;
        /// <summary>
        /// Whether this role is mentionable.
        /// </summary>
        [JsonProperty(PropertyName = "Mentionable")]
        public readonly bool Mentionable;
    }
}
