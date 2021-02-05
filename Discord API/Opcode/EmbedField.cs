using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class EmbedField
    {
        /// <summary>
        /// Name of the field.
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name;

        /// <summary>
        /// Value of the field.
        /// </summary>
        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value;

        /// <summary>
        /// Whether or not this field should display inline.
        /// </summary>
        [JsonProperty(PropertyName = "inline", NullValueHandling = NullValueHandling.Ignore)]
        public bool Inline;
    }
}
