using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Discord_API.Opcode
{
    public class Ban
    {
        [JsonProperty(PropertyName = "reason")]
        public readonly string Reason;
        [JsonProperty(PropertyName = "user")]   
        public readonly User User;
    }
}
